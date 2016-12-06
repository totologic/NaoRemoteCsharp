using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using LitJson;

namespace NaoRemote
{
    //
    // author : Cedric Jules
    //
    // thank you to : http://lbv.github.io/litjson/
    //
    public class NaoRemoteModule
    {

        private static bool _active;
        private static Socket _sender;
        private static byte[] _bytes;
        private IPAddress ipAddress;
        private IPEndPoint _remoteEP;
        private Thread _sockThread;

        private ManualResetEvent[] _poolWaiter;
        private int _poolWaiterIndex;

        private int _callCounter;
        private Dictionary<int, ManualResetEvent> _pendingWaiter;
        private Dictionary<int, String> _pendingResults;
        private Dictionary<int, String> _pendingErrors;

        public delegate void NaoEventHandler(String eventName, NaoEventData data);
        private Dictionary<String, List<NaoEventHandler>> _eventHandlers;

        public NaoRemoteModule()
        {
            _active = false;
            _bytes = new byte[1024];
            _poolWaiter = new ManualResetEvent[50];
            for (int i = 0; i < 50; i++)
            {
                _poolWaiter[i] = new ManualResetEvent(false);
            }
            _poolWaiterIndex = 0;
            _callCounter = 0;
            _pendingWaiter = new Dictionary<int, ManualResetEvent>();
            _pendingResults = new Dictionary<int, string>();
            _pendingErrors = new Dictionary<int, string>();
            _eventHandlers = new Dictionary<string, List<NaoEventHandler>>();
        }

        public void Connect(String ip)
        {
            if (_active)
                return;

            _active = true;

            ipAddress = IPAddress.Parse(ip);
            _remoteEP = new IPEndPoint(ipAddress, 62574);
            _sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _sender.Connect(_remoteEP);
            _sockThread = new Thread(new ThreadStart(sockLoop));
            _sockThread.Start();
        }

        public void Disconnect()
        {
            if (!_active)
                return;

            _active = false;
            _sockThread.Abort();
            _sender.Disconnect(false);
        }

        public T Eval<T>(String moduleName, Boolean usePost, String methodName, params Object[] args)
        {
            int c;
            ManualResetEvent waiter;
            Dictionary<String, Object> request;
            String s;
            byte[] msg;
            int bytesSent;

            lock (_poolWaiter)
            {
                c = _callCounter;
                _callCounter++;
                waiter = _poolWaiter[_poolWaiterIndex];
                _poolWaiterIndex = (_poolWaiterIndex + 1) % 50;
                _pendingWaiter[c] = waiter;
            }

            request = new Dictionary<String, Object>()
            {
                {"type", "eval"}, {"id", c}, {"modu", moduleName}, {"post", ((usePost) ? "1" : "0")}, {"meth", methodName}, {"args", JsonMapper.ToJson(args)}
            };
            s = JsonMapper.ToJson(request);

            msg = Encoding.UTF8.GetBytes(s);
            //Console.WriteLine("Sent : {0}", s);
            bytesSent = _sender.Send(msg);
            waiter.WaitOne();
            waiter.Reset();
            if (_pendingResults.ContainsKey(c))
            {
                String result = _pendingResults[c];
                _pendingResults.Remove(c);
                if (result == "null")
                {
                    return default(T);
                }
                else
                {
                    return JsonMapper.ToObject<List<T>>(result)[0];
                }
            }
            else
            {
                String error = _pendingErrors[c];
                _pendingErrors.Remove(c);
                Exception e = new Exception(error);
                throw e;
            }
        }

        public void SubscribeToEvent(String eventName, NaoEventHandler action)
        {
            lock (_eventHandlers)
            {
                List<NaoEventHandler> lActions;
                if (_eventHandlers.ContainsKey(eventName))
                {
                    lActions = _eventHandlers[eventName];
                    if (!lActions.Contains(action))
                    {
                        lActions.Add(action);
                    }
                }
                else
                {
                    lActions = new List<NaoEventHandler>();

                    int c;
                    ManualResetEvent waiter;
                    Dictionary<String, Object> request;
                    String s;
                    byte[] msg;
                    int bytesSent;
                    String result;

                    lock (_poolWaiter)
                    {
                        c = _callCounter;
                        _callCounter++;
                        waiter = _poolWaiter[_poolWaiterIndex];
                        _poolWaiterIndex = (_poolWaiterIndex + 1) % 50;
                        _pendingWaiter[c] = waiter;
                    }

                    request = new Dictionary<String, Object>()
                    {
                        {"type", "subs"}, {"id", c}, {"evt", eventName}
                    };
                    s = JsonMapper.ToJson(request);

                    msg = Encoding.UTF8.GetBytes(s);
                    //Console.WriteLine("Sent : {0}", s);
                    bytesSent = _sender.Send(msg);
                    waiter.WaitOne();
                    waiter.Reset();
                    result = _pendingResults[c];
                    _pendingResults.Remove(c);

                    lActions.Add(action);
                    _eventHandlers[eventName] = lActions;
                }
            }
        }

        public void UnsubscribeToEvent(String eventName, NaoEventHandler action)
        {
            lock (_eventHandlers)
            {
                List<NaoEventHandler> lActions;
                if (_eventHandlers.ContainsKey(eventName))
                {
                    lActions = _eventHandlers[eventName];
                    if (lActions.Contains(action))
                    {
                        lActions.Remove(action);
                        if (lActions.Count == 0)
                        {
                            _eventHandlers.Remove(eventName);

                            int c;
                            ManualResetEvent waiter;
                            Dictionary<String, Object> request;
                            String s;
                            byte[] msg;
                            int bytesSent;
                            String result;

                            lock (_poolWaiter)
                            {
                                c = _callCounter;
                                _callCounter++;
                                waiter = _poolWaiter[_poolWaiterIndex];
                                _poolWaiterIndex = (_poolWaiterIndex + 1) % 50;
                                _pendingWaiter[c] = waiter;
                            }

                            request = new Dictionary<String, Object>()
                            {
                                {"type", "unsu"}, {"id", c}, {"evt", eventName}
                            };
                            s = JsonMapper.ToJson(request);

                            msg = Encoding.UTF8.GetBytes(s);
                            //Console.WriteLine("Sent : {0}", s);
                            bytesSent = _sender.Send(msg);
                            waiter.WaitOne();
                            waiter.Reset();
                            result = _pendingResults[c];
                            _pendingResults.Remove(c);
                        }
                    }
                }
            }
        }

        public void sockLoop()
        {
            while (_active)
            {
                try
                {
                    int bytesRec;
                    String recv;
                    String[] responsesArray;

                    bytesRec = _sender.Receive(_bytes);
                    recv = Encoding.ASCII.GetString(_bytes, 0, bytesRec);
                    //Console.WriteLine("Received : {0}", recv);
                    String[] splitter = { ";;;" };
                    responsesArray = recv.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < responsesArray.Length; i++)
                    {
                        JsonData response = JsonMapper.ToObject(responsesArray[i]);
                        if (((String)response["type"]) == "resu")
                        {
                            int c = (int)response["id"];
                            if ((String)response["stat"] == "1")
                                _pendingResults[c] = (string)response["res"];
                            else
                                _pendingErrors[c] = (string)response["err"];
                            _pendingWaiter[c].Set();
                            _pendingWaiter.Remove(c);
                        }
                        else if (((String)response["type"]) == "evnt")
                        {
                            String eventName = (String)response["name"];
                            String value = (String)response["val"];
                            lock (_eventHandlers)
                            {
                                if (_eventHandlers.ContainsKey(eventName))
                                {
                                    List<NaoEventHandler> lActions = _eventHandlers[eventName];
                                    for (int j = 0; j < lActions.Count; j++)
                                    {
                                        lActions[j](eventName, new NaoEventData(value));
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                }
            }
        }

    }


}

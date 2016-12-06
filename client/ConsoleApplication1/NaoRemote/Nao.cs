using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaoRemote
{

    public class Nao
    {

        private NaoRemoteModule _naoModule;

        private ALBehaviorManager _ALBehaviorManager;
        private ALMotion _ALMotion;

        public Nao()
        {
            _naoModule = new NaoRemoteModule();

            _ALBehaviorManager = new ALBehaviorManager(_naoModule);
            _ALMotion = new ALMotion(_naoModule);
        }

        public void Connect(String ip)
        {
            _naoModule.Connect(ip);
        }

        public void Disconnect()
        {
            _naoModule.Disconnect();
        }

        public T Eval<T>(String moduleName, Boolean usePost, String methodName, params Object[] args)
        {
            return _naoModule.Eval<T>(moduleName, usePost, methodName, args);
        }

        public void SubscribeToEvent(String eventName, NaoRemoteModule.NaoEventHandler action)
        {
            _naoModule.SubscribeToEvent(eventName, action);
        }

        public void UnsubscribeToEvent(String eventName, NaoRemoteModule.NaoEventHandler action)
        {
            _naoModule.UnsubscribeToEvent(eventName, action);
        }

        public ALBehaviorManager ALBehaviorManager              { get { return _ALBehaviorManager;                  } }
        public ALMotion ALMotion                                { get { return _ALMotion;                           } }

    }

}

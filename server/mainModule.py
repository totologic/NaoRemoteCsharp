'''
@author: Cedric Jules
'''
from abstractMainModule import AbstractMainModule
from debug import Debug
from socketConnection import SocketConnection
from pydispatch import dispatcher
from proxySet import ProxySet
from memoryEvents import MemoryEvents
import json
from proxyNames import ProxyNames

class MainModule(AbstractMainModule):
    
    def __init__(self, name, generatedBoxObject=None):
        AbstractMainModule.__init__(self, name, generatedBoxObject)
        Debug.log("MainModule __init__")
        #
        self._manageAppLeave = False
        self._socket = None
    
    def __del__(self):
        #Debug.log("MainModule __del__")
        AbstractMainModule.__del__(self)
    
    def start(self):
        AbstractMainModule.start(self)
        self._socket = SocketConnection( 62574 )
        self._socket.start()
        dispatcher.connect(self._onMsg, SocketConnection.SIGNAL_MSG_RECEIVED, self._socket)
        dispatcher.connect(self._onDisconnect, SocketConnection.SIGNAL_CLIENT_DISCONNECT, self._socket)
        #ProxySet.getProxy(ProxyNames.ALTextToSpeech).say("nao remote")
    
    def stop(self):
        Debug.log("MainModule stop")
        self._socket.stop()
        self._socket = None
        AbstractMainModule.stop(self)
    
    def _onDisconnect(self):
        MemoryEvents.cleanEventSubscriptions()
    
    def _onMsg(self):
        msg = self._socket.getCurrMsg()
        obj = self.noUnicode(json.loads(msg))
        status = "1"
        res = None
        err = None
        if obj["type"] == "eval" :
            ## { "type", "id", "modu", "post", "meth", "args" }
            try:
                prx = ProxySet.getProxy( obj["modu"] )
                if obj["post"] == "1" :
                    prx = getattr(prx, "post")
                mtd = getattr(prx, obj["meth"])
                args = self.noUnicode(json.loads(obj["args"]))
                Debug.log(args)
                res = apply(mtd, args)
            except Exception, e:
                status = "0"
                err = e
        elif obj["type"] == "subs" :
            ## { "type", "id", "evt" }
            try:
                MemoryEvents.subscribeToEvent(obj["evt"], self._onEvent)
            except Exception, e:
                status = "0"
                err = e
        elif obj["type"] == "unsu" :
            ## { "type", "id", "evt" }
            try:
                MemoryEvents.unsubscribeToEvent(obj["evt"], self._onEvent)
            except Exception, e:
                status = "0"
                err = e
        if status == "1":
            response = {"type":"resu", "id":obj["id"], "stat":status, "res":"["+json.dumps(res)+"]"}
        else:
            response = {"type":"resu", "id":obj["id"], "stat":status, "err":str(err)}
        self._socket.send( json.dumps(response) + ";;;" );
    
    def _onEvent(self, eventName, value, subscriberIdentifier):
        Debug.log("onEvent " + eventName)
        response = {"type":"evnt", "name":eventName, "val":"["+json.dumps(value)+"]"}
        self._socket.send( json.dumps(response) + ";;;");
    
    def noUnicode(self, obj):
        result = None
        if isinstance(obj, dict):
            result = {}
            for key in obj:
                result[self.noUnicode(key)] = self.noUnicode(obj[key])
        elif isinstance(obj, list):
            result = [self.noUnicode(element) for element in obj]
        elif isinstance(obj, unicode):
            result = obj.encode('utf-8')
        else:
            result = obj
        return result

    
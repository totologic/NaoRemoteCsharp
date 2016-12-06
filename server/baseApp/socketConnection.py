'''
@author: Cedric Jules
'''

from debug import Debug
from pydispatch import dispatcher
import socket
import threading

class SocketConnection():
    
    SIGNAL_MSG_RECEIVED = "signalMessageReceived"
    SIGNAL_CLIENT_DISCONNECT = "signalClientDisconnect"
    
    def __init__(self, port):
        Debug.log("SocketConnection __init__")
        self.__port = port
        self.__active = False
        self.__thread = None
        self.__socket = None
        self.__socketChannel = None
        self.__msgStr = None
        self.__msgArr = None
    
    def __del__(self):
        Debug.log("SocketConnection __del__")
    
    
    def start(self):
        Debug.log("SocketConnection start")
        self.__active = True
        self.__start()
    
    def __start(self):
        Debug.log("SocketConnection __start")
        self.__thread = threading.Thread(None, self.__mainThread, "SocketConnectionThread", (), {})
        self.__thread.start()
    
    def stop(self):
        Debug.log("SocketConnection stop")
        self.__active = False
        if self.__socketChannel != None:
            self.__socketChannel.shutdown(socket.SHUT_RDWR)
            self.__socketChannel = None
        self.__socket.close()
        Debug.log("SocketConnection stop is complete")
    
    def send(self, msgStr):
        if self.__active :
            Debug.log("SocketConnection sent: '" + msgStr + "'")
            self.__socketChannel.send(msgStr)
    
    def getCurrMsg(self):
        return self.__msgStr
    
    def __mainThread(self):
        if self.__active:
            Debug.log("SocketConnection __mainThread")
            self.__socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
            self.__socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
            self.__socket.bind(('', self.__port))
            self.__socket.setblocking(1)
            self.__socket.settimeout(1.0)
            self.__socket.listen(5)
            Debug.log("SocketConection socket inited")
        else:
            return
        
        while self.__active:
            try:
                self.__socketChannel = self.__socket.accept()[0]
                Debug.log("SocketConnection socket connection accepted")
                self.__socketChannel.settimeout(1.0)
                break
            except Exception:
                pass
        
        if self.__socketChannel == None:
            Debug.log("SocketConnection socket connection aborted")
            return
        
        while self.__active:
            Debug.log("SocketConnection wait for socket message")
            while self.__active:
                try:
                    self.__msgStr = self.__socketChannel.recv(256)
                    Debug.log("SocketConnection received: '" + self.__msgStr + "'")
                    break
                except Exception:
                    pass
            
            if not self.__active:
                break
            
            if not self.__msgStr :
                Debug.log("SocketConnection socket connection interrupted")
                self.stop()
                self.__active = True
                dispatcher.send(SocketConnection.SIGNAL_CLIENT_DISCONNECT, self)
                threading.Timer(1, self.__start).start()
                break
                return
            
            self.__msgArr = self.__msgStr.split(";;;")
            while len(self.__msgArr) > 0 :
                self.__msgStr = self.__msgArr.pop(0)
                if self.__msgStr == "" :
                    continue
                else :
                    dispatcher.send(SocketConnection.SIGNAL_MSG_RECEIVED, self)
    
    
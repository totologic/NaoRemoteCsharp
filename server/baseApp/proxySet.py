'''
@author: cedric jules
'''
from proxyNames import ProxyNames
from naoqi import ALProxy
from debug import Debug

class ProxySet():
    proxysDict = {}
    proxyMemory = None
    
    @staticmethod
    def getProxy(name):
        if not name in ProxySet.proxysDict:
            try:
                ProxySet.proxysDict[name] = ALProxy(name)
                if name == ProxyNames.ALMemory:
                    ProxySet.proxyMemory = ProxySet.proxysDict[name]
            except Exception, e:
                Debug.log(e)
        return ProxySet.proxysDict[name]
    
    @staticmethod
    def getProxyMemory():
        if ProxySet.proxyMemory == None:
            ProxySet.getProxy(ProxyNames.ALMemory)
        return ProxySet.proxyMemory
    
    @staticmethod
    def subscribeToEvent(eventName, moduleName, methodName):
        ProxySet.getProxyMemory().subscribeToEvent(eventName, moduleName, methodName)
    
    @staticmethod
    def unsubscribeToEvent(eventName, moduleName):
        ProxySet.getProxyMemory().unsubscribeToEvent(eventName, moduleName)



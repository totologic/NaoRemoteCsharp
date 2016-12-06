'''
@author: cedric jules
'''
from proxySet import ProxySet

class MemoryEvents():
    
    moduleName = None
    
    dictEventMethods = {}
    
    
    @staticmethod
    def subscribeToEvent(eventName, method):
        eventsDict = MemoryEvents.dictEventMethods
        if not eventName in eventsDict:
            methodsList = []
            eventsDict[eventName] = methodsList
        else:
            methodsList = eventsDict[eventName]
        
        if not method in methodsList:
            methodsList.append(method)
        
        ProxySet.subscribeToEvent(eventName, MemoryEvents.moduleName, "onEvent")
    
    
    @staticmethod
    def unsubscribeToEvent(eventName, method):
        eventsDict = MemoryEvents.dictEventMethods
        if eventName in eventsDict:
            methodsList = eventsDict[eventName]
            if method in methodsList:
                methodsList.remove(method)
                if len(methodsList) == 0:
                    ProxySet.unsubscribeToEvent(eventName, MemoryEvents.moduleName)
    
    
    @staticmethod
    def cleanEventSubscriptions():
        eventsDict = MemoryEvents.dictEventMethods
        for eventName in eventsDict:
            if len(eventsDict[eventName]) > 0:
                try :
                    ProxySet.unsubscribeToEvent(eventName, MemoryEvents.moduleName)
                except Exception:
                    pass
    
    
    @staticmethod
    def onEvent(*args):
        eventsDict = MemoryEvents.dictEventMethods
        if args[0] in eventsDict:
            for method in eventsDict[args[0]]:
                method(*args)
'''
@author: cedric jules
'''
from memoryEvents import MemoryEvents
from naoqi import ALModule
from debug import Debug
from appLeave import AppLeave
from pydispatch import dispatcher

class AbstractMainModule(ALModule):
    
    def __init__(self, name, generatedBoxObject):
        ALModule.__init__(self, name)
        MemoryEvents.moduleName = name
        Debug.setGeneratedBoxObject(generatedBoxObject)
        self._manageAppLeave = False
        self.alive = None
    
    def start(self):
        if self._manageAppLeave:
            self.__appLeave = AppLeave()
            dispatcher.connect(self.__onLeaveAsked, AppLeave.SIGNAL_LEAVE_ASKED, self.__appLeave)
            self.__appLeave.start()
        self.alive = True
    
    def stop(self):
        self.alive = False
        MemoryEvents.cleanEventSubscriptions()
        self.exit()
    
    
    def onEvent(self, *args):
        MemoryEvents.onEvent(*args)
    
    def __onLeaveAsked(self):
        if self.__appLeave != None:
            self.__appLeave.stop()
            self.__appLeave = None
        self.stop()


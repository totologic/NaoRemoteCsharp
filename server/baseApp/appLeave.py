'''
@author: cedric jules
'''
from debug import Debug
from headSensorsTaper import HeadSensorsTaper
from pydispatch import dispatcher

class AppLeave():
    
    SIGNAL_LEAVE_ASKED = "signalLeaveAsked"
    
    __hasFocus = None
    
    def __init__(self):
        self.__headSensorsTaper = HeadSensorsTaper.getInstance()
    
    @staticmethod
    def setFocus(value):
        AppLeave.__hasFocus = value
    
    def start(self):
        Debug.log("AppLeave start")
        AppLeave.__hasFocus = True
        dispatcher.connect(self.__onOverallTap, HeadSensorsTaper.SIGNAL_SINGLE_TAP_OVERALL, self.__headSensorsTaper)
    
    def stop(self):
        Debug.log("AppLeave stop")
    
    def __onOverallTap(self):
        if AppLeave.__hasFocus :
            Debug.log("AppLeave send: " + AppLeave.SIGNAL_LEAVE_ASKED)
            dispatcher.send(AppLeave.SIGNAL_LEAVE_ASKED, self)
    
    
    
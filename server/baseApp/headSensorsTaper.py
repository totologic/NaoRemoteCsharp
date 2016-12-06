'''
Created on 30 juil. 2013

@author: cedric
'''
from debug import Debug
from memoryEvents import MemoryEvents
from pydispatch import dispatcher

class HeadSensorsTaper(object):
    
    __instance = None
    __fromGetInstance = False
    
    SIGNAL_SINGLE_TAP_FRONT = "signalSingleTapFront"
    SIGNAL_SINGLE_TAP_MIDDLE = "signalSingleTapMiddle"
    SIGNAL_SINGLE_TAP_REAR = "signalSingleTapRear"
    SIGNAL_SINGLE_TAP_OVERALL = "signalSingleTapOverAll"
    
    def __init__(self):
        Debug.log("HeadSensorsTaper __init__")
        if not HeadSensorsTaper.__fromGetInstance :
            exception = Exception()
            exception.message = "HeadSensorsTaper cannot be instancied directly ; use static getInstance() instead."
        #
        self.__curSequence = ""
        self.__frontIsDown = False
        self.__middleIsDown = False
        self.__rearIsDown = False
        MemoryEvents.subscribeToEvent("FrontTactilTouched", self.__onFrontTactilTouched)
        MemoryEvents.subscribeToEvent("MiddleTactilTouched", self.__onMiddleTactilTouched)
        MemoryEvents.subscribeToEvent("RearTactilTouched", self.__onRearTactilTouched)
    
    @staticmethod
    def getInstance():
        if HeadSensorsTaper.__instance == None :
            __fromGetInstance = True
            HeadSensorsTaper.__instance = HeadSensorsTaper()
            __fromGetInstance = False
        return HeadSensorsTaper.__instance
    
    def start(self):
        Debug.log("HeadSensorsTaper start")
    
    def stop(self):
        Debug.log("HeadSensorsTaper stop")
        
    
    def __onRearTactilTouched(self, eventName, value, subscriberIdentifier):
        if value == 1.0 :
            self.__rearIsDown = True
            self.__curSequence += "RD"
            #self.__prxAudioPlayer.play( self.__soundSensorDown )
        else :
            self.__rearIsDown = False
            self.__curSequence += "RU"
            #self.__prxAudioPlayer.play( self.__soundSensorUp )
            self.__checkSequence()
    
    
    def __onMiddleTactilTouched(self, eventName, value, subscriberIdentifier):
        if value == 1.0 :
            self.__middleIsDown = True
            self.__curSequence += "MD"
            #self.__prxAudioPlayer.play( self.__soundSensorDown )
        else :
            self.__middleIsDown = False
            self.__curSequence += "MU"
            #self.__prxAudioPlayer.play( self.__soundSensorUp )
            self.__checkSequence()
    
    def __onFrontTactilTouched(self, eventName, value, subscriberIdentifier):
        if value == 1.0 :
            self.__frontIsDown = True
            self.__curSequence += "FD"
            #self.__prxAudioPlayer.play( self.__soundSensorDown )
        else :
            self.__frontIsDown = False
            self.__curSequence += "FU"
            #self.__prxAudioPlayer.play( self.__soundSensorUp )
            self.__checkSequence()
    
    def __checkSequence(self):
        s = self.__curSequence
        if (not self.__frontIsDown) and (not self.__middleIsDown) and (not self.__rearIsDown) :
            if s == "FDFU" :
                Debug.log("HeadSensorsTaper single tap on FRONT detected")
                dispatcher.send(HeadSensorsTaper.SIGNAL_SINGLE_TAP_FRONT, self)
            elif s == "MDMU" :
                Debug.log("HeadSensorsTaper single tap on MIDDLE detected")
                dispatcher.send(HeadSensorsTaper.SIGNAL_SINGLE_TAP_MIDDLE, self)
            elif s == "RDRU" :
                Debug.log("HeadSensorsTaper single tap on REAR detected")
                dispatcher.send(HeadSensorsTaper.SIGNAL_SINGLE_TAP_REAR, self)
            elif len(s) == 12 :
                s0_6 = s[0:6]
                s6_12 = s[6:12]
                if s0_6 == "FDMDRD" or s0_6 == "FDRDMD" or s0_6 == "MDFDRD" or s0_6 == "MDRDFD" or s0_6 == "RDFDMD" or s0_6 == "RDMDFD" :
                    if s6_12 == "FUMURU" or s6_12 == "FURUMU" or s6_12 == "MUFURU" or s6_12 == "MURUFU" or s6_12 == "RUFUMU" or s6_12 == "RUMUFU" :
                        Debug.log("HeadSensorsTaper single tap on OVERALL detected")
                        dispatcher.send(HeadSensorsTaper.SIGNAL_SINGLE_TAP_OVERALL, self)
            self.__curSequence = ""
    
    
    
    
    
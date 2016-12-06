
from mainModule import MainModule
from naoqi import ALBroker
import time
import sys


#NAO_IP = "169.254.30.101" ## your NAO's IP
NAO_IP = "127.0.0.1" ## your NAO's IP
MODULE_NAME = "remoteModule" ## your module's name

PORT = 9559

myBroker = ALBroker("myBroker", "0.0.0.0", 0, NAO_IP, PORT)
vars()[MODULE_NAME] = MainModule(MODULE_NAME)
vars()[MODULE_NAME].start()

time.sleep(5)
vars()[MODULE_NAME].stop()

time.sleep(1)

while vars()[MODULE_NAME].alive:
    time.sleep(1)
     
myBroker.shutdown()
sys.exit(0)
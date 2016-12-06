'''
@author: cedric jules
'''
class Debug():
    
    __generatedBoxObject = None
    
    @staticmethod
    def setGeneratedBoxObject( generatedBoxObject ):
        Debug.__generatedBoxObject = generatedBoxObject
    
    @staticmethod
    def log(message):
        if Debug.__generatedBoxObject != None:
            Debug.__generatedBoxObject.log(message)
        else:
            print message
    

import clr

class BizhawkPlugin:
    APIs = None
    
    @staticmethod
    def set_apicontainer(container):
        BizhawkPlugin.APIs = container

    def Restart(self):
        pass
        
    def UpdateAfter(self):
        pass
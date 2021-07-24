import clr

class BizhawkPlugin:
    apicontainer = None
    
    @classmethod
    def set_apicontainer(self, container):
        self.apicontainer = container

    def Restart(self):
        pass
        
    def UpdateAfter(self):
        pass
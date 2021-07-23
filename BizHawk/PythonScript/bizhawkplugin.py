import clr
clr.AddReference("System.Windows.Forms")
clr.AddReference("System")
from System.Windows.Forms import *
from System import Console



apicontainer = None
def set_apicontainer(container):
    global apicontainer
    apicontainer = container

try:
    import private.bizhawkplugin
except ImportError:
    def restart():
        print("Hi from python!")
        global apicontainer

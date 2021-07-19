import clr
clr.AddReference("System.Windows.Forms")
clr.AddReference("System")
from System.Windows.Forms import *
from System import Console
#MessageBox.Show("Unable to save file, try again.")

apicontainer = None
def set_apicontainer(container):
    global apicontainer
    apicontainer = container
    
def restart():
    Console.WriteLine("HiiiiIIIii")
    global apicontainer
    MessageBox.Show(apicontainer.GameInfo.GetRomName() + "ponyboi222")

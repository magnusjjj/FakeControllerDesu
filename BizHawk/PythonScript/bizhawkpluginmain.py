from library.bizhawkplugin import BizhawkPlugin

def set_apicontainer(container):
    BizhawkPlugin.set_apicontainer(container)
    
try:
    from private.plugin import Plugin
except ImportError:
    class Plugin(BizhawkPlugin):
        def Restart(self):
            print("Hi from python! Start creating a plugin by making a bizhawkplugin.py in the private directory, available from when you press the 'Open Script Directory' button!")
            
plugin = Plugin()
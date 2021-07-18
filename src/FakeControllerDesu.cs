using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BizHawk.Client.Common;
using BizHawk.Client.EmuHawk;
using Python.Runtime;

namespace FakeControllerDesu
{
    [ExternalTool("FakeControllerDesu")]
    public sealed class FakeControllerDesu : ToolFormBase, IExternalToolForm
    {
        
        protected override string WindowTitleStatic => "MyTool";

        object reloadlock = new object();

        private IntPtr pythonthreadstate;

        public ApiContainer? _maybeAPIContainer { get; set; }

        private ApiContainer APIs => _maybeAPIContainer!;

        private dynamic module;

        public void ReloadScript()
        {
            lock (reloadlock) { 
                if (PythonEngine.IsInitialized)
                {
                    PythonEngine.EndAllowThreads(pythonthreadstate);
                    PythonEngine.Shutdown();
                }

                Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", "python39.dll");
                PythonEngine.Initialize();
                pythonthreadstate = PythonEngine.BeginAllowThreads();
                
                using (Py.GIL())
                {
                    PythonEngine.RunSimpleString(
@"import sys
sys.path.append(""C:\\Users\\Tuxie\\Desktop\\bizhawkplugin\\"")
"
                    );

                    module = Py.Import("bizhawkplugin");
                    
                    module.set_apicontainer(APIs);



                    /*                dynamic fky = Py.Import("fakecontrolleryo");
                                    fky.start();*/
                }
            }
        }

        public override void Restart()
        {
            using (Py.GIL()) {
                module.set_apicontainer(APIs);
                module.restart();
            }
        }

        public FakeControllerDesu()
        {
            ClientSize = new Size(480, 320);
            SuspendLayout();
            Controls.Add(new Label { AutoSize = true, Text = "Hello, simplewindow!" });
            ResumeLayout();
            ReloadScript();
        }
    }
}

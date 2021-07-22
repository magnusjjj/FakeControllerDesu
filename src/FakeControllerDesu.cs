using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
    public partial class FakeControllerDesu : ToolFormBase, IExternalToolForm
    {
        
        protected override string WindowTitleStatic => "MyTool";

        // These get sets to a collection of BizHawk's API's.
        public ApiContainer? _maybeAPIContainer { get; set; }
        private ApiContainer APIs => _maybeAPIContainer!;


        private dynamic module; // This will be the script that is loaded. We call the restart function and things on it.
        object reloadlock = new object(); // This is a lock, so that we don't accidentally run a shutdown while still reloading the script.
        private IntPtr pythonthreadstate; // To be able to stop and start threading, we need to keep track of this.

        // We watch for changes in the script, and restart if its changed.
        FileSystemWatcher watcher;

        // This is how we start and restart
        public void ReloadScript()
        {
            lock (reloadlock)
            {
                if (PythonEngine.IsInitialized) // Only run this code if python has actually started.
                {
                     PythonEngine.Shutdown();
                }

                Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", PythonHelper.FindLibPythonName()); // Not really implemented yet.
                PythonEngine.Initialize();
                pythonthreadstate = PythonEngine.BeginAllowThreads();
                using (Py.GIL()) // The GIL is the Global Interpreter Lock. This is so that we don't touch python while it's running.
                {
                    dynamic sys = Py.Import("sys");
                    sys.path.append(PythonHelper.FindScriptLocation());
                    PrintRedirect pr = new PrintRedirect();
                    pr.WriteEvent += OnPrint;
                    sys.stdout = pr;
                    module = Py.Import("bizhawkplugin");
                }

                string path = Directory.GetCurrentDirectory();
            }
        }

        private void OnPrint(object sender, WriteEventArgs e)
        {
            LogBox.AppendText(e.text);
        }

        // This is called each time the emulator is started, or a new rom is loaded.
        public override void Restart()
        {
            using (Py.GIL()) {
                module.set_apicontainer(APIs);
                module.restart();
            }
        }

        // In this section, we look for changes in the script.
        private void StartFileWatcher()
        {
            watcher = new FileSystemWatcher(PythonHelper.FindScriptLocation());
            watcher.NotifyFilter = NotifyFilters.Attributes
                     | NotifyFilters.CreationTime
                     | NotifyFilters.DirectoryName
                     | NotifyFilters.FileName
                     | NotifyFilters.LastWrite
                     | NotifyFilters.Security;

            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnChanged;
            watcher.Error += Watcher_Error;

            watcher.Filter = "*.py";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

        }

        private void Watcher_Error(object sender, ErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            ReloadScript();
        }

        public FakeControllerDesu()
        { 
            ResumeLayout();
            PythonHelper.EnsurePython();
            ReloadScript();
            StartFileWatcher();
            InitializeComponent();
        }

        private void EvalButtonClick(object sender, EventArgs e)
        {
            using (Py.GIL())
            {
                PythonEngine.RunSimpleString(txtEval.Text);
            }
        }

        private void OpenScriptDirectoryButton_Click(object sender, EventArgs e) // Todo: Does this work on linux?
        {
            Process.Start(PythonHelper.FindScriptLocation());
        }
    }
}
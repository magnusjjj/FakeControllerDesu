using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace FakeControllerDesu
{
    class PythonHelper
    {
        class PipOutput
        {
            public string name = "";
            public string version = "";
        }

        public static string FindLibPythonName()
        {
            // https://github.com/ktbarrett/find_libpython
            try
            {
                var cliProcess = new Process()
                {
                    StartInfo = new ProcessStartInfo("python", "-m find_libpython")
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true
                    }
                };
                cliProcess.Start();
                string cliOut = cliProcess.StandardOutput.ReadToEnd();
                cliProcess.WaitForExit();
                cliProcess.Close();
                return Path.GetFileName(cliOut);
            }
            catch
            {
                MessageBox.Show("Could not find python, or another similar error occured. Check that it's installed and on the PATH");
                return "";
            }
        }

        public static string FindScriptLocation()
        {
            return Path.Combine(new string[] { Directory.GetCurrentDirectory(), "PythonScript" });
        }

        public static bool EnsurePython()
        {
            string cliOut = "";
            try { 
                var cliProcess = new Process()
                {
                    StartInfo = new ProcessStartInfo("python", "-m pip list --disable-pip-version-check --format json")
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        CreateNoWindow = true
                    }
                };
                cliProcess.Start();
                cliOut = cliProcess.StandardOutput.ReadToEnd();
                cliProcess.WaitForExit();
                cliProcess.Close();
            } catch {
                MessageBox.Show("Could not find python, or another similar error occured. Check that it's installed and on the PATH");
                return false;
            }

            List<PipOutput> listofpackages = JsonConvert.DeserializeObject<List<PipOutput>>(cliOut);

            if(listofpackages.Where(item => item.name == "pythonnet" || item.name == "find-libpython").Count() == 2)
            {
                return true;
            } else
            {
                var result = MessageBox.Show(@"Python is installed, and on the path, but not all the requirements are met.
These can be installed via running pip install pythonnet find_libpython. We can run that command for you. Do you want to do that now?", "Requirements not met", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    var cliProcess = new Process()
                    {
                        StartInfo = new ProcessStartInfo("python", "-m pip install wheel pythonnet find_libpython")
                        {
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            WindowStyle = ProcessWindowStyle.Hidden,
                            CreateNoWindow = true
                        }
                    };
                    cliProcess.Start();
                    cliOut = cliProcess.StandardOutput.ReadToEnd();
                    cliProcess.WaitForExit();
                    cliProcess.Close();
                    MessageBox.Show(cliOut);
                    return true;
                } else
                {
                    return false;
                }
            }
        }
    }
}

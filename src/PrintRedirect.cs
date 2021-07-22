using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeControllerDesu
{
    public class WriteEventArgs
    {
        public WriteEventArgs(string intext) { text = intext; }
        public string text;
    }

    class PrintRedirect
    {
        public event WriteEventHandler WriteEvent;
        public delegate void WriteEventHandler(object sender, WriteEventArgs e);

        public void write(string input)
        {
            WriteEvent?.Invoke(this, new WriteEventArgs(input));
        }
    }
}

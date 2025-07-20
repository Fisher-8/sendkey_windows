using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SendKey_Windows
{
    public partial class Form1 : Form
    {
        [DllImport("user32")]
        static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vKey);

        [DllImport("user32")]
        static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Form1()
        {
            InitializeComponent();
        }

        private void fProgram_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, 31196, 0, 0x70);
        }

        private void fProgram_Close(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 31196);
        }

        char[] cArray = { '\n', '\r', '+', '^', '%', '~'};

        private void InputKeys(string s)
        {
            foreach (char c in s)
            {
                var x = Array.FindIndex(cArray, i => i == c);
                if ( x > -1 )
                {
                    switch (x)
                    {
                        //case 0: SendKeys.Send("{ENTER}"); break;
                        case 1: SendKeys.Send("{ENTER}"); break;
                        case 2: SendKeys.Send("{+}"); break;
                        case 3: SendKeys.Send("{^}"); break;
                        case 4: SendKeys.Send("{%}"); break;
                        case 5: SendKeys.Send("{~}"); break;
                    }
                }
                else
                {
                    SendKeys.Send(c.ToString());
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.WParam.ToInt32() == 31196)
            {
                InputKeys(textBox1.Text);
            }
            base.WndProc(ref m);
        }
    }
}

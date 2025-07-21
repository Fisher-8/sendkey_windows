using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendKey_Windows
{
    public partial class Form1 : Form
    {
        [DllImport("user32")]
        static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vKey);

        [DllImport("user32")]
        static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        static string fnKey = "F1";
        static int fnKeyNm = 112, enterDelay = 200, keyDelay = 10;

        public Form1(string[] param)
        {
            if (param.Length > 0) { int.TryParse(param[0], out fnKeyNm); if (fnKeyNm >= 1 && fnKeyNm <= 24) { fnKey = "F" + fnKeyNm.ToString(); fnKeyNm = +fnKeyNm + 111; } }
            if (param.Length > 1) { int.TryParse(param[1], out enterDelay); if (!(enterDelay >= 0 && enterDelay <= 9999)) { enterDelay = 200; } }
            if (param.Length > 2) { int.TryParse(param[1], out keyDelay); if (!(keyDelay >= 0 && keyDelay <= 999)) { keyDelay = 10; } }
            InitializeComponent();
        }

        private void fProgram_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, 31196, 0, (byte)fnKeyNm);
        }

        private void fProgram_Close(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, 31196);
        }

        char[] cArray = { '\n', '\r', '+', '^', '%', '~', '(', ')', '{', '}'};

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
                        case 1: SendKeys.SendWait("{ENTER}"); Task.Delay(enterDelay).Wait(); break;
                        case 2: SendKeys.SendWait("{+}"); Task.Delay(keyDelay).Wait(); break;
                        case 3: SendKeys.SendWait("{^}"); Task.Delay(keyDelay).Wait(); break;
                        case 4: SendKeys.SendWait("{%}"); Task.Delay(keyDelay).Wait(); break;
                        case 5: SendKeys.SendWait("{~}"); Task.Delay(keyDelay).Wait(); break;
                        case 6: SendKeys.SendWait("{(}"); Task.Delay(keyDelay).Wait(); break;
                        case 7: SendKeys.SendWait("{)}"); Task.Delay(keyDelay).Wait(); break;
                        case 8: SendKeys.SendWait("{{}"); Task.Delay(keyDelay).Wait(); break;
                        case 9: SendKeys.SendWait("{}}"); Task.Delay(keyDelay).Wait(); break;
                    }
                }
                else
                {
                    SendKeys.Send(c.ToString()); Task.Delay(keyDelay).Wait();
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

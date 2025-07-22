using System;
using System.Collections.Generic;
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

        private string fnKey = "F1";
        private int p0, p1, p2, fnKeyNm = 112, enterDelay = 300, keyDelay = 5;
        private const int hKey = 0x0312, hKeyID = 31196;
        private static readonly Dictionary<char, string> dKey = new Dictionary<char, string>() { ['+'] = "{+}", ['^'] = "{^}", ['%'] = "{%}", ['~'] = "{~}", ['('] = "{(}", [')'] = "{)}", ['{'] = "{{}", ['}'] = "{}}" };

        public Form1(string[] param)
        {
            if (param.Length > 0) { if (int.TryParse(param[0], out p0) && p0 >= 1 && p0 <= 24) { fnKey = "F" + p0.ToString(); fnKeyNm = p0 + 111; } }
            if (param.Length > 1) { if (int.TryParse(param[1], out p1) && p1 >= 0 && p1 <= 9999) { enterDelay = p1; } }
            if (param.Length > 2) { if (int.TryParse(param[2], out p2) && p2 >= 0 && p2 <= 999) { keyDelay = p2; } }
            InitializeComponent();
        }

        private void fProgram_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, hKeyID, 0, (byte)fnKeyNm);
        }

        private void fProgram_Close(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(this.Handle, hKeyID);
        }

        private async void InputKeys(string s)
        {
            foreach (char c in s)
            {
                if (dKey.TryGetValue(c, out var k)) { SendKeys.SendWait(k); await Task.Delay(keyDelay); }
                else if (c == '\n') { }
                else if (c == '\r') { SendKeys.SendWait("{ENTER}"); await Task.Delay(enterDelay); }
                else { SendKeys.SendWait(c.ToString()); await Task.Delay(keyDelay); }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == hKey && m.WParam.ToInt32() == hKeyID)
            {
                InputKeys(textBox1.Text);
            }
            base.WndProc(ref m);
        }
    }
}

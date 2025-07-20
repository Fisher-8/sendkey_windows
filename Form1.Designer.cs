namespace SendKey_Windows
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            this.textBox1.Name = "textBox1";
            this.textBox1.TabIndex = 0;
            this.textBox1.Multiline = true;
            this.textBox1.Size = new System.Drawing.Size(100, 40);
            this.textBox1.Location = new System.Drawing.Point(2, 2);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top|System.Windows.Forms.AnchorStyles.Bottom)|System.Windows.Forms.AnchorStyles.Left)|System.Windows.Forms.AnchorStyles.Right)));
            this.Name = "Form1";
            this.Text = "F1";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ClientSize = new System.Drawing.Size(104, 44);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.Controls.Add(this.textBox1);
            this.Load += new System.EventHandler(this.fProgram_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fProgram_Close);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.TextBox textBox1;
    }
}


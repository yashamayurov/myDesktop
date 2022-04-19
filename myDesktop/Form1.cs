using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace myDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            Button button = (Button)sender;
            string filename = button.Tag.ToString();
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = filename;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }
        private void Form1_Activated(object sender, EventArgs e)
        {

            label1.Text = "Имя терминальной станции:"+ Environment.MachineName;
            string myPath = Environment.GetCommandLineArgs()[1];
            string[] allfiles = Directory.GetFiles(myPath);
            int top = 20;
            int left = 10;
            int height = 40;
            int width = 500;
            int i = 1;
            foreach (string filename in allfiles)
            {
                Button button = new Button();
                button.Left = left;
                button.Top = top * i;
                button.Name = "btn" + i;
                button.Width = width;
                button.Height = height;
                button.Text = Path.GetFileNameWithoutExtension(filename);
                button.Tag = filename;
                button.Click += ButtonOnClick;

                this.Controls.Add(button);
                top += button.Height + 2;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", "/c shutdown -s -t 3");
            Application.Exit();
        }
    }
}

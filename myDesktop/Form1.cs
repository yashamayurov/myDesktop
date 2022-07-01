using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace myDesktop
{
    public partial class Form1 : Form
    {

        private Process proc = new Process();
        public Form1()
        {
            InitializeComponent();
            resfreshButtons();
            labelComName.Text = "Имя терминальной станции:" + Environment.MachineName;
        }
        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            Button button = (Button)sender;
            string filename = "\""+button.Tag.ToString()+"\"";
            proc.StartInfo.FileName = "mstsc.exe";
            proc.StartInfo.Arguments = filename;
            proc.StartInfo.UseShellExecute = true;
            proc.EnableRaisingEvents = true;
            proc.Start();
            this.Visible = false;
            Thread.Sleep(1000);
            int idProc = proc.Id;
            
            MessageBox.Show(idProc.ToString());

            int i = 1;
            while (i>0)
            {
                  Process[] procs = Process.GetProcessesByName("mstsc");
                  i = procs.Length;
            }
            this.Visible = true;
        }
        private void resfreshButtons()
        {


            
            string myPath = Environment.GetCommandLineArgs()[1];
            string[] allfiles = Directory.GetFiles(myPath);
            int left = 10;
            int height = 40;
            int width = 500;
            int i = 1;
            foreach (string filename in allfiles)
            {
                Button button = new Button();


                button.Left = left;
                button.Top = height * i;
                button.Name = "btn" + i.ToString();
                button.Width = width;
                button.Height = height;
                button.Text = Path.GetFileNameWithoutExtension(filename);
 
                button.Tag = filename;
                button.Click += ButtonOnClick;

                panel1.Controls.Add(button);
           

                i++;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //resfreshButtons();
        }

       
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToShortTimeString();
            labelDate.Text = DateTime.Today.ToShortDateString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd", "/c shutdown -s -t 3");
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

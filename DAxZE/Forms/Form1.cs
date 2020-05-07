using System;
using System.Windows.Forms;

namespace DAxZE
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public static Form1 MainForm;
        public static string serverName = string.Empty;

        private const string serverHost = ".moecube.com:10800";
        private WebsocketCore wscore = new WebsocketCore();

        //####################################################

        public Form1()
        {
            InitializeComponent();
            MainForm = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroComboBox1.SelectedIndex = 1;
            pictureBox1.Cursor = Cursors.Hand;
        }

        private void MetroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (metroComboBox1.SelectedIndex)
            {

                case 0: serverName = $"baka1st{serverHost}"; break;

                case 1: serverName = $"baka2nd{serverHost}"; break;

                case 2: serverName = $"baka3rd{serverHost}"; break;

            }

            wscore.ConnectToServer();

        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(metroTextBox1.Text))
            {
                Clipboard.SetText(metroTextBox1.Text);
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://usaginya.lofter.com");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            wscore.Websocket_Closed(null, null);
            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }

        private void MetroButtonCPort_Click(object sender, EventArgs e)
        {
            try
            {
                wscore.Local_port = Convert.ToUInt16(MetroTextBoxzCPort.Text);
                wscore.ConnectToServer();
            }
            catch { }
        }

        private void MetroTextBoxzCPort_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(MetroTextBoxzCPort.Text))
                {
                    MetroTextBoxzCPort.Text = ushort.MinValue.ToString();
                }
                else if (Convert.ToUInt32(MetroTextBoxzCPort.Text) > ushort.MaxValue)
                {
                    MetroTextBoxzCPort.Text = ushort.MaxValue.ToString();
                }
            }
            catch { }
        }

    }
}

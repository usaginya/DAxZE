using DAxZE.Extension;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAxZE
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public static Form1 MainForm;
        public static string serverName = string.Empty;

        private string version = string.Empty;
        private const string serverMainHost = ".moecube.com:10800";

        private AppSettings settings = new AppSettings();
        private WebsocketCore wscore = new WebsocketCore();
        private Dictionary<int, string> serverGroup = new Dictionary<int, string>();

        public static string AppName => Application.ProductName;
        public static string AppVersion => Application.ProductVersion;
        //####################################################

        public Form1()
        {
            InitializeComponent();
            MainForm = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ver = AppVersion.Split('.');
            version = $"{ver[0]}.{ver[1]}";
            Text += $"ver{version}";

            metroLabel4.Location = new Point(
                metroLabel4.Location.X + (ver[0].Length + ver[1].Length) * 16 + 41,
                metroLabel4.Location.Y);

            NotifyIcon1.Text = AppName;
            pictureBox1.Cursor = Cursors.Hand;
            MetroLabelNetworkLatency.Text = string.Empty;

            CreateServerListGroup();

#pragma warning disable CS4014 // 异步检查更新
            settings.CheckUpdate(version, CheckUpdateComplete);
#pragma warning restore CS4014 // 异步检查更新
        }

        private void CheckUpdateComplete(AppSettings.UpdateInfo updateInfo)
        {
            if (!updateInfo.haveUpdate)
            { return; }

            DialogResult result =
                MessageBox.Show(
                this,
                $"发现新版本，是否更新？" +
                $"{Environment.NewLine}{AppName} {updateInfo.newVer}" +
                $"{Environment.NewLine}{updateInfo.updateMsg}",
                "更新提示",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(updateInfo.downloadUrl);
            }
        }

        private void CreateServerListGroup()
        {
            int i = 0;
            JArray serverList = settings.GetServerList();

            if (serverList.Count < 1)
            {
                string[] nameArray = { "  北京", "  上海", "  广州", "  深圳" };
                string[] hostArray =
                {
                    $"mt-pek-1{serverMainHost}",
                    $"mt-sha-1{serverMainHost}",
                    $"mt-can-1{serverMainHost}",
                    $"mt-szx-1{serverMainHost}"
                };

                metroComboBox1.Items.AddRange(nameArray);
                for (i = 0; i < 4; i++)
                {
                    serverGroup.Add(i, hostArray[i]);
                }
                metroComboBox1.SelectedIndex = 1;
                return;
            }

            //Create form setting file
            const string keyName = "name";
            const string keyHost = "host";
            foreach (JObject server in serverList)
            {
                if (!server.ContainsKey(keyName) || !server.ContainsKey(keyHost))
                { continue; }
                metroComboBox1.Items.Add($"  {server[keyName]}");
                serverGroup.Add(i, server[keyHost].ToString());
                i++;
            }
            metroComboBox1.SelectedIndex = settings.GetFirstServer(i);

            if (i < 1)
            {
                MetroLabelState.Text = "少女休息中";
                metroComboBox1.Items.Add("  无服务器配置");
                metroComboBox1.SelectedIndex = 0;
            }
        }

        //####################################################
        private void MetroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serverGroup.Count < 1)
            { return; }

            serverName = serverGroup[metroComboBox1.SelectedIndex];
            wscore.ConnectToServer();
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(metroTextBox1.Text))
            { return; }

            Clipboard.SetText(metroTextBox1.Text);

            #region - Async change button text -
            if (metroButton1.Tag != null)
            { return; }

            metroButton1.Tag = Task.Factory.StartNew(async () =>
           {
               string oldText = metroButton1.Text;
               Invoke(new Action(() =>
               {
                   metroButton1.Text = $"已{oldText}";
               }));
               await Task.Delay(1000);
               Invoke(new Action(() =>
               {
                   metroButton1.Text = oldText;
                   metroButton1.Tag = null;
               }));
           });
            #endregion
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/usaginya/DAxZE");
        }

        private void MetroButtonCPort_Click(object sender, EventArgs e)
        {
            if (serverGroup.Count < 1)
            { return; }

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

        private void MetroLabel4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://yiu.moest.top");
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
            }
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                    ShowInTaskbar = true;
                }
                Activate();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            wscore.CloseConnect();
        }

        //##################################
        public void ShowToolTip(Control control, string caption)
        {
            MetroToolTip1.SetToolTip(control, $"  {caption}  ");
        }

    }
}

namespace DAxZE
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.MetroLabelState = new MetroFramework.Controls.MetroLabel();
            this.MetroLabelMessage = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.MetroTextBoxzCPort = new MetroFramework.Controls.MetroTextBox();
            this.metroButtonCPort = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.MetroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.NotifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.MetroLabelNetworkLatency = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(255, 75);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(102, 25);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "服务器地区";
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.DropDownWidth = 174;
            this.metroComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.metroComboBox1.ForeColor = System.Drawing.Color.Black;
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Location = new System.Drawing.Point(363, 73);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(174, 29);
            this.metroComboBox1.TabIndex = 2;
            this.metroComboBox1.UseCustomForeColor = true;
            this.metroComboBox1.UseSelectable = true;
            this.metroComboBox1.SelectedIndexChanged += new System.EventHandler(this.MetroComboBox1_SelectedIndexChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(258, 115);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(99, 25);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "给对方的IP";
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(150, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(363, 115);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(174, 25);
            this.metroTextBox1.TabIndex = 4;
            this.metroTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBox1.UseCustomForeColor = true;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.DeepPink;
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton1.ForeColor = System.Drawing.Color.White;
            this.metroButton1.Location = new System.Drawing.Point(363, 193);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(172, 47);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Magenta;
            this.metroButton1.TabIndex = 8;
            this.metroButton1.Text = "复制 IP";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.MetroButton1_Click);
            // 
            // MetroLabelState
            // 
            this.MetroLabelState.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.MetroLabelState.ForeColor = System.Drawing.Color.DeepPink;
            this.MetroLabelState.Location = new System.Drawing.Point(23, 265);
            this.MetroLabelState.Name = "MetroLabelState";
            this.MetroLabelState.Size = new System.Drawing.Size(84, 23);
            this.MetroLabelState.TabIndex = 9;
            this.MetroLabelState.Text = "少女祈祷中";
            this.MetroLabelState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MetroLabelState.UseCustomForeColor = true;
            // 
            // MetroLabelMessage
            // 
            this.MetroLabelMessage.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.MetroLabelMessage.Location = new System.Drawing.Point(113, 265);
            this.MetroLabelMessage.Name = "MetroLabelMessage";
            this.MetroLabelMessage.Size = new System.Drawing.Size(422, 23);
            this.MetroLabelMessage.TabIndex = 10;
            this.MetroLabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 167);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.MetroToolTip1.SetToolTip(this.pictureBox1, "Goto github ");
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(273, 153);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(84, 25);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "建主端口";
            // 
            // MetroTextBoxzCPort
            // 
            // 
            // 
            // 
            this.MetroTextBoxzCPort.CustomButton.Image = null;
            this.MetroTextBoxzCPort.CustomButton.Location = new System.Drawing.Point(59, 1);
            this.MetroTextBoxzCPort.CustomButton.Name = "";
            this.MetroTextBoxzCPort.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.MetroTextBoxzCPort.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.MetroTextBoxzCPort.CustomButton.TabIndex = 1;
            this.MetroTextBoxzCPort.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MetroTextBoxzCPort.CustomButton.UseSelectable = true;
            this.MetroTextBoxzCPort.CustomButton.Visible = false;
            this.MetroTextBoxzCPort.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.MetroTextBoxzCPort.ForeColor = System.Drawing.Color.BlueViolet;
            this.MetroTextBoxzCPort.Lines = new string[] {
        "10800"};
            this.MetroTextBoxzCPort.Location = new System.Drawing.Point(363, 153);
            this.MetroTextBoxzCPort.MaxLength = 5;
            this.MetroTextBoxzCPort.Name = "MetroTextBoxzCPort";
            this.MetroTextBoxzCPort.PasswordChar = '\0';
            this.MetroTextBoxzCPort.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.MetroTextBoxzCPort.SelectedText = "";
            this.MetroTextBoxzCPort.SelectionLength = 0;
            this.MetroTextBoxzCPort.SelectionStart = 0;
            this.MetroTextBoxzCPort.ShortcutsEnabled = true;
            this.MetroTextBoxzCPort.Size = new System.Drawing.Size(83, 25);
            this.MetroTextBoxzCPort.TabIndex = 6;
            this.MetroTextBoxzCPort.Text = "10800";
            this.MetroTextBoxzCPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MetroTextBoxzCPort.UseCustomForeColor = true;
            this.MetroTextBoxzCPort.UseSelectable = true;
            this.MetroTextBoxzCPort.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.MetroTextBoxzCPort.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MetroTextBoxzCPort.TextChanged += new System.EventHandler(this.MetroTextBoxzCPort_TextChanged);
            // 
            // metroButtonCPort
            // 
            this.metroButtonCPort.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.metroButtonCPort.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButtonCPort.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButtonCPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.metroButtonCPort.Location = new System.Drawing.Point(452, 153);
            this.metroButtonCPort.Name = "metroButtonCPort";
            this.metroButtonCPort.Size = new System.Drawing.Size(83, 25);
            this.metroButtonCPort.Style = MetroFramework.MetroColorStyle.Magenta;
            this.metroButtonCPort.TabIndex = 7;
            this.metroButtonCPort.Text = "更 改";
            this.metroButtonCPort.UseCustomForeColor = true;
            this.metroButtonCPort.UseSelectable = true;
            this.metroButtonCPort.UseStyleColors = true;
            this.metroButtonCPort.Click += new System.EventHandler(this.MetroButtonCPort_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Cursor = System.Windows.Forms.Cursors.Help;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(113, 25);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(61, 25);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Magenta;
            this.metroLabel4.TabIndex = 11;
            this.metroLabel4.Text = "by YIU";
            this.MetroToolTip1.SetToolTip(this.metroLabel4, "Goto blog");
            this.metroLabel4.UseCustomForeColor = true;
            this.metroLabel4.UseStyleColors = true;
            this.metroLabel4.Click += new System.EventHandler(this.MetroLabel4_Click);
            // 
            // MetroToolTip1
            // 
            this.MetroToolTip1.Style = MetroFramework.MetroColorStyle.Magenta;
            this.MetroToolTip1.StyleManager = null;
            this.MetroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // NotifyIcon1
            // 
            this.NotifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon1.Icon")));
            this.NotifyIcon1.Visible = true;
            this.NotifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseClick);
            // 
            // MetroLabelNetworkLatency
            // 
            this.MetroLabelNetworkLatency.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MetroLabelNetworkLatency.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.MetroLabelNetworkLatency.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.MetroLabelNetworkLatency.ForeColor = System.Drawing.Color.BlueViolet;
            this.MetroLabelNetworkLatency.Location = new System.Drawing.Point(255, 205);
            this.MetroLabelNetworkLatency.Name = "MetroLabelNetworkLatency";
            this.MetroLabelNetworkLatency.Size = new System.Drawing.Size(102, 23);
            this.MetroLabelNetworkLatency.TabIndex = 12;
            this.MetroLabelNetworkLatency.Tag = "ms";
            this.MetroLabelNetworkLatency.Text = "ms";
            this.MetroLabelNetworkLatency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MetroLabelNetworkLatency.UseCustomForeColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 307);
            this.Controls.Add(this.MetroLabelNetworkLatency);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroButtonCPort);
            this.Controls.Add(this.MetroTextBoxzCPort);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.MetroLabelMessage);
            this.Controls.Add(this.MetroLabelState);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(20, 60, 20, 18);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Magenta;
            this.Text = "DA☆ZE  ";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton metroButton1;
        internal MetroFramework.Controls.MetroLabel MetroLabelState;
        internal MetroFramework.Controls.MetroTextBox metroTextBox1;
        internal MetroFramework.Controls.MetroLabel MetroLabelMessage;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        internal MetroFramework.Controls.MetroTextBox MetroTextBoxzCPort;
        internal MetroFramework.Controls.MetroButton metroButtonCPort;
        internal MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        internal MetroFramework.Components.MetroToolTip MetroToolTip1;
        private System.Windows.Forms.NotifyIcon NotifyIcon1;
        internal MetroFramework.Controls.MetroLabel MetroLabelNetworkLatency;
    }
}


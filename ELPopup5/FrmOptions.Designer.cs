namespace ELPopup5
{
    partial class FrmOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOptions));
            this.tcTabs = new System.Windows.Forms.TabControl();
            this.tcTabsPageGeneral = new System.Windows.Forms.TabPage();
            this.picHelpOutbound = new System.Windows.Forms.PictureBox();
            this.ckbUseComputerTime = new System.Windows.Forms.CheckBox();
            this.ckbOutboundCalls = new System.Windows.Forms.CheckBox();
            this.ckbInboundCalls = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ndPopupTiming = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tcTabsPageSerialServer = new System.Windows.Forms.TabPage();
            this.lbSerialStatus = new System.Windows.Forms.Label();
            this.lbSerialServerConnection = new System.Windows.Forms.Label();
            this.picHelpCOMPort = new System.Windows.Forms.PictureBox();
            this.picHelpRelayIP = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCOMPorts = new System.Windows.Forms.ComboBox();
            this.tcTabsPageMisc = new System.Windows.Forms.TabPage();
            this.btnResetLineDisplay = new System.Windows.Forms.Button();
            this.btnResetScreenSize = new System.Windows.Forms.Button();
            this.tcTabs.SuspendLayout();
            this.tcTabsPageGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpOutbound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndPopupTiming)).BeginInit();
            this.tcTabsPageSerialServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpCOMPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpRelayIP)).BeginInit();
            this.tcTabsPageMisc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcTabs
            // 
            this.tcTabs.Controls.Add(this.tcTabsPageGeneral);
            this.tcTabs.Controls.Add(this.tcTabsPageSerialServer);
            this.tcTabs.Controls.Add(this.tcTabsPageMisc);
            this.tcTabs.Location = new System.Drawing.Point(13, 14);
            this.tcTabs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcTabs.Name = "tcTabs";
            this.tcTabs.SelectedIndex = 0;
            this.tcTabs.Size = new System.Drawing.Size(325, 240);
            this.tcTabs.TabIndex = 0;
            // 
            // tcTabsPageGeneral
            // 
            this.tcTabsPageGeneral.Controls.Add(this.picHelpOutbound);
            this.tcTabsPageGeneral.Controls.Add(this.ckbUseComputerTime);
            this.tcTabsPageGeneral.Controls.Add(this.ckbOutboundCalls);
            this.tcTabsPageGeneral.Controls.Add(this.ckbInboundCalls);
            this.tcTabsPageGeneral.Controls.Add(this.label2);
            this.tcTabsPageGeneral.Controls.Add(this.ndPopupTiming);
            this.tcTabsPageGeneral.Controls.Add(this.label1);
            this.tcTabsPageGeneral.Location = new System.Drawing.Point(4, 30);
            this.tcTabsPageGeneral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcTabsPageGeneral.Name = "tcTabsPageGeneral";
            this.tcTabsPageGeneral.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcTabsPageGeneral.Size = new System.Drawing.Size(317, 206);
            this.tcTabsPageGeneral.TabIndex = 0;
            this.tcTabsPageGeneral.Text = "General";
            this.tcTabsPageGeneral.UseVisualStyleBackColor = true;
            // 
            // picHelpOutbound
            // 
            this.picHelpOutbound.Image = global::ELPopup5.Properties.Resources.HelpIcon;
            this.picHelpOutbound.Location = new System.Drawing.Point(218, 103);
            this.picHelpOutbound.Name = "picHelpOutbound";
            this.picHelpOutbound.Size = new System.Drawing.Size(28, 29);
            this.picHelpOutbound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picHelpOutbound.TabIndex = 7;
            this.picHelpOutbound.TabStop = false;
            // 
            // ckbUseComputerTime
            // 
            this.ckbUseComputerTime.AutoSize = true;
            this.ckbUseComputerTime.Location = new System.Drawing.Point(38, 156);
            this.ckbUseComputerTime.Name = "ckbUseComputerTime";
            this.ckbUseComputerTime.Size = new System.Drawing.Size(252, 25);
            this.ckbUseComputerTime.TabIndex = 5;
            this.ckbUseComputerTime.Text = "Use Computer Time for Logging";
            this.ckbUseComputerTime.UseVisualStyleBackColor = true;
            this.ckbUseComputerTime.CheckedChanged += new System.EventHandler(this.ckbUseComputerTime_CheckedChanged);
            // 
            // ckbOutboundCalls
            // 
            this.ckbOutboundCalls.AutoSize = true;
            this.ckbOutboundCalls.Location = new System.Drawing.Point(38, 104);
            this.ckbOutboundCalls.Name = "ckbOutboundCalls";
            this.ckbOutboundCalls.Size = new System.Drawing.Size(185, 25);
            this.ckbOutboundCalls.TabIndex = 4;
            this.ckbOutboundCalls.Text = "Popup Outbound Calls";
            this.ckbOutboundCalls.UseVisualStyleBackColor = true;
            this.ckbOutboundCalls.CheckedChanged += new System.EventHandler(this.ckbOutboundCalls_CheckedChanged);
            // 
            // ckbInboundCalls
            // 
            this.ckbInboundCalls.AutoSize = true;
            this.ckbInboundCalls.Checked = true;
            this.ckbInboundCalls.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbInboundCalls.Location = new System.Drawing.Point(38, 73);
            this.ckbInboundCalls.Name = "ckbInboundCalls";
            this.ckbInboundCalls.Size = new System.Drawing.Size(172, 25);
            this.ckbInboundCalls.TabIndex = 3;
            this.ckbInboundCalls.Text = "Popup Inbound Calls";
            this.ckbInboundCalls.UseVisualStyleBackColor = true;
            this.ckbInboundCalls.CheckedChanged += new System.EventHandler(this.ckbInboundCalls_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "seconds";
            // 
            // ndPopupTiming
            // 
            this.ndPopupTiming.Location = new System.Drawing.Point(146, 22);
            this.ndPopupTiming.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.ndPopupTiming.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ndPopupTiming.Name = "ndPopupTiming";
            this.ndPopupTiming.Size = new System.Drawing.Size(47, 29);
            this.ndPopupTiming.TabIndex = 1;
            this.ndPopupTiming.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ndPopupTiming.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ndPopupTiming.Leave += new System.EventHandler(this.ndPopupTiming_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Popup Timing";
            // 
            // tcTabsPageSerialServer
            // 
            this.tcTabsPageSerialServer.Controls.Add(this.lbSerialStatus);
            this.tcTabsPageSerialServer.Controls.Add(this.lbSerialServerConnection);
            this.tcTabsPageSerialServer.Controls.Add(this.picHelpCOMPort);
            this.tcTabsPageSerialServer.Controls.Add(this.picHelpRelayIP);
            this.tcTabsPageSerialServer.Controls.Add(this.comboBox1);
            this.tcTabsPageSerialServer.Controls.Add(this.label4);
            this.tcTabsPageSerialServer.Controls.Add(this.label3);
            this.tcTabsPageSerialServer.Controls.Add(this.cbCOMPorts);
            this.tcTabsPageSerialServer.Location = new System.Drawing.Point(4, 30);
            this.tcTabsPageSerialServer.Name = "tcTabsPageSerialServer";
            this.tcTabsPageSerialServer.Size = new System.Drawing.Size(317, 206);
            this.tcTabsPageSerialServer.TabIndex = 1;
            this.tcTabsPageSerialServer.Text = "Seral Server";
            this.tcTabsPageSerialServer.UseVisualStyleBackColor = true;
            // 
            // lbSerialStatus
            // 
            this.lbSerialStatus.AutoSize = true;
            this.lbSerialStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSerialStatus.Location = new System.Drawing.Point(92, 21);
            this.lbSerialStatus.Name = "lbSerialStatus";
            this.lbSerialStatus.Size = new System.Drawing.Size(129, 21);
            this.lbSerialStatus.TabIndex = 7;
            this.lbSerialStatus.Text = "Serial Relay: OFF";
            // 
            // lbSerialServerConnection
            // 
            this.lbSerialServerConnection.AutoSize = true;
            this.lbSerialServerConnection.Location = new System.Drawing.Point(22, 166);
            this.lbSerialServerConnection.Name = "lbSerialServerConnection";
            this.lbSerialServerConnection.Size = new System.Drawing.Size(209, 21);
            this.lbSerialServerConnection.TabIndex = 1;
            this.lbSerialServerConnection.Text = "Serial Server: Not Connected";
            // 
            // picHelpCOMPort
            // 
            this.picHelpCOMPort.Image = global::ELPopup5.Properties.Resources.HelpIcon;
            this.picHelpCOMPort.Location = new System.Drawing.Point(286, 64);
            this.picHelpCOMPort.Name = "picHelpCOMPort";
            this.picHelpCOMPort.Size = new System.Drawing.Size(28, 29);
            this.picHelpCOMPort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picHelpCOMPort.TabIndex = 6;
            this.picHelpCOMPort.TabStop = false;
            // 
            // picHelpRelayIP
            // 
            this.picHelpRelayIP.Image = global::ELPopup5.Properties.Resources.HelpIcon;
            this.picHelpRelayIP.Location = new System.Drawing.Point(286, 110);
            this.picHelpRelayIP.Name = "picHelpRelayIP";
            this.picHelpRelayIP.Size = new System.Drawing.Size(28, 29);
            this.picHelpRelayIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picHelpRelayIP.TabIndex = 5;
            this.picHelpRelayIP.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Do not Relay Data",
            "Entire LAN (255.255.255.255)",
            "Local Computer (127.0.0.1)"});
            this.comboBox1.Location = new System.Drawing.Point(74, 110);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(206, 29);
            this.comboBox1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Relay IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Connect to COM Port";
            // 
            // cbCOMPorts
            // 
            this.cbCOMPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCOMPorts.FormattingEnabled = true;
            this.cbCOMPorts.Location = new System.Drawing.Point(166, 64);
            this.cbCOMPorts.Name = "cbCOMPorts";
            this.cbCOMPorts.Size = new System.Drawing.Size(114, 29);
            this.cbCOMPorts.TabIndex = 0;
            this.cbCOMPorts.SelectedIndexChanged += new System.EventHandler(this.cbCOMPorts_SelectedIndexChanged);
            // 
            // tcTabsPageMisc
            // 
            this.tcTabsPageMisc.Controls.Add(this.btnResetScreenSize);
            this.tcTabsPageMisc.Controls.Add(this.btnResetLineDisplay);
            this.tcTabsPageMisc.Location = new System.Drawing.Point(4, 30);
            this.tcTabsPageMisc.Name = "tcTabsPageMisc";
            this.tcTabsPageMisc.Padding = new System.Windows.Forms.Padding(3);
            this.tcTabsPageMisc.Size = new System.Drawing.Size(317, 206);
            this.tcTabsPageMisc.TabIndex = 2;
            this.tcTabsPageMisc.Text = "Misc.";
            this.tcTabsPageMisc.UseVisualStyleBackColor = true;
            // 
            // btnResetLineDisplay
            // 
            this.btnResetLineDisplay.Location = new System.Drawing.Point(61, 34);
            this.btnResetLineDisplay.Name = "btnResetLineDisplay";
            this.btnResetLineDisplay.Size = new System.Drawing.Size(192, 31);
            this.btnResetLineDisplay.TabIndex = 0;
            this.btnResetLineDisplay.Text = "Reset Display Line Count";
            this.btnResetLineDisplay.UseVisualStyleBackColor = true;
            // 
            // btnResetScreenSize
            // 
            this.btnResetScreenSize.Location = new System.Drawing.Point(61, 71);
            this.btnResetScreenSize.Name = "btnResetScreenSize";
            this.btnResetScreenSize.Size = new System.Drawing.Size(192, 31);
            this.btnResetScreenSize.TabIndex = 1;
            this.btnResetScreenSize.Text = "Reset Screen Size";
            this.btnResetScreenSize.UseVisualStyleBackColor = true;
            this.btnResetScreenSize.Click += new System.EventHandler(this.btnResetScreenSize_Click);
            // 
            // FrmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 262);
            this.Controls.Add(this.tcTabs);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOptions_FormClosing);
            this.tcTabs.ResumeLayout(false);
            this.tcTabsPageGeneral.ResumeLayout(false);
            this.tcTabsPageGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpOutbound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndPopupTiming)).EndInit();
            this.tcTabsPageSerialServer.ResumeLayout(false);
            this.tcTabsPageSerialServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpCOMPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpRelayIP)).EndInit();
            this.tcTabsPageMisc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcTabs;
        private System.Windows.Forms.TabPage tcTabsPageGeneral;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ndPopupTiming;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tcTabsPageSerialServer;
        private System.Windows.Forms.Label lbSerialServerConnection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCOMPorts;
        private System.Windows.Forms.CheckBox ckbUseComputerTime;
        private System.Windows.Forms.CheckBox ckbOutboundCalls;
        private System.Windows.Forms.CheckBox ckbInboundCalls;
        private System.Windows.Forms.PictureBox picHelpRelayIP;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbSerialStatus;
        private System.Windows.Forms.PictureBox picHelpCOMPort;
        private System.Windows.Forms.TabPage tcTabsPageMisc;
        private System.Windows.Forms.PictureBox picHelpOutbound;
        private System.Windows.Forms.Button btnResetLineDisplay;
        private System.Windows.Forms.Button btnResetScreenSize;
    }
}
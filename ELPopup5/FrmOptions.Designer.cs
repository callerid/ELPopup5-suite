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
            this.ckbUseComputerTime = new System.Windows.Forms.CheckBox();
            this.ckbOutboundCalls = new System.Windows.Forms.CheckBox();
            this.ckbInboundCalls = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ndPopupTiming = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tcTabsPageSerialServer = new System.Windows.Forms.TabPage();
            this.btnRefreshSerialList = new System.Windows.Forms.Button();
            this.lbSerialStatus = new System.Windows.Forms.Label();
            this.lbSerialServerConnection = new System.Windows.Forms.Label();
            this.picHelpCOMPort = new System.Windows.Forms.PictureBox();
            this.picHelpRelayIP = new System.Windows.Forms.PictureBox();
            this.cbRelayIP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCOMPorts = new System.Windows.Forms.ComboBox();
            this.tcTabsPageLogging = new System.Windows.Forms.TabPage();
            this.lbLogStatus = new System.Windows.Forms.Label();
            this.lbLoggingFileLocation = new System.Windows.Forms.TextBox();
            this.btnStopLogging = new System.Windows.Forms.Button();
            this.btnSelectLoggingFile = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ndRecordCount = new System.Windows.Forms.NumericUpDown();
            this.lbTotalLogCount = new System.Windows.Forms.Label();
            this.btnExportRecords = new System.Windows.Forms.Button();
            this.tcTabsPageMisc = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.ckbStartInSystemTray = new System.Windows.Forms.CheckBox();
            this.btnImportOldDatabase = new System.Windows.Forms.Button();
            this.btnResetLineDisplay = new System.Windows.Forms.Button();
            this.sfdLoggingFile = new System.Windows.Forms.SaveFileDialog();
            this.tcTabs.SuspendLayout();
            this.tcTabsPageGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndPopupTiming)).BeginInit();
            this.tcTabsPageSerialServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpCOMPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpRelayIP)).BeginInit();
            this.tcTabsPageLogging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndRecordCount)).BeginInit();
            this.tcTabsPageMisc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcTabs
            // 
            this.tcTabs.Controls.Add(this.tcTabsPageGeneral);
            this.tcTabs.Controls.Add(this.tcTabsPageSerialServer);
            this.tcTabs.Controls.Add(this.tcTabsPageLogging);
            this.tcTabs.Controls.Add(this.tcTabsPageMisc);
            this.tcTabs.Location = new System.Drawing.Point(13, 14);
            this.tcTabs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tcTabs.Name = "tcTabs";
            this.tcTabs.SelectedIndex = 0;
            this.tcTabs.Size = new System.Drawing.Size(349, 264);
            this.tcTabs.TabIndex = 0;
            this.tcTabs.SelectedIndexChanged += new System.EventHandler(this.tcTabs_SelectedIndexChanged);
            // 
            // tcTabsPageGeneral
            // 
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
            this.tcTabsPageGeneral.Size = new System.Drawing.Size(341, 230);
            this.tcTabsPageGeneral.TabIndex = 0;
            this.tcTabsPageGeneral.Text = "General";
            this.tcTabsPageGeneral.UseVisualStyleBackColor = true;
            // 
            // ckbUseComputerTime
            // 
            this.ckbUseComputerTime.AutoSize = true;
            this.ckbUseComputerTime.Checked = true;
            this.ckbUseComputerTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbUseComputerTime.Location = new System.Drawing.Point(60, 170);
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
            this.ckbOutboundCalls.Location = new System.Drawing.Point(60, 118);
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
            this.ckbInboundCalls.Location = new System.Drawing.Point(60, 87);
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
            this.label2.Location = new System.Drawing.Point(221, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "seconds";
            // 
            // ndPopupTiming
            // 
            this.ndPopupTiming.Location = new System.Drawing.Point(168, 36);
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
            this.label1.Location = new System.Drawing.Point(56, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Popup Timing";
            // 
            // tcTabsPageSerialServer
            // 
            this.tcTabsPageSerialServer.Controls.Add(this.btnRefreshSerialList);
            this.tcTabsPageSerialServer.Controls.Add(this.lbSerialStatus);
            this.tcTabsPageSerialServer.Controls.Add(this.lbSerialServerConnection);
            this.tcTabsPageSerialServer.Controls.Add(this.picHelpCOMPort);
            this.tcTabsPageSerialServer.Controls.Add(this.picHelpRelayIP);
            this.tcTabsPageSerialServer.Controls.Add(this.cbRelayIP);
            this.tcTabsPageSerialServer.Controls.Add(this.label4);
            this.tcTabsPageSerialServer.Controls.Add(this.label3);
            this.tcTabsPageSerialServer.Controls.Add(this.cbCOMPorts);
            this.tcTabsPageSerialServer.Location = new System.Drawing.Point(4, 30);
            this.tcTabsPageSerialServer.Name = "tcTabsPageSerialServer";
            this.tcTabsPageSerialServer.Size = new System.Drawing.Size(341, 230);
            this.tcTabsPageSerialServer.TabIndex = 1;
            this.tcTabsPageSerialServer.Text = "Serial Server";
            this.tcTabsPageSerialServer.UseVisualStyleBackColor = true;
            // 
            // btnRefreshSerialList
            // 
            this.btnRefreshSerialList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshSerialList.Location = new System.Drawing.Point(77, 88);
            this.btnRefreshSerialList.Name = "btnRefreshSerialList";
            this.btnRefreshSerialList.Size = new System.Drawing.Size(106, 26);
            this.btnRefreshSerialList.TabIndex = 9;
            this.btnRefreshSerialList.Text = "Refresh Search";
            this.btnRefreshSerialList.UseVisualStyleBackColor = true;
            this.btnRefreshSerialList.Click += new System.EventHandler(this.btnRefreshSerialList_Click);
            // 
            // lbSerialStatus
            // 
            this.lbSerialStatus.AutoSize = true;
            this.lbSerialStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSerialStatus.Location = new System.Drawing.Point(113, 30);
            this.lbSerialStatus.Name = "lbSerialStatus";
            this.lbSerialStatus.Size = new System.Drawing.Size(114, 16);
            this.lbSerialStatus.TabIndex = 7;
            this.lbSerialStatus.Text = "Serial Relay: OFF";
            // 
            // lbSerialServerConnection
            // 
            this.lbSerialServerConnection.AutoSize = true;
            this.lbSerialServerConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSerialServerConnection.Location = new System.Drawing.Point(22, 128);
            this.lbSerialServerConnection.Name = "lbSerialServerConnection";
            this.lbSerialServerConnection.Size = new System.Drawing.Size(181, 16);
            this.lbSerialServerConnection.TabIndex = 1;
            this.lbSerialServerConnection.Text = "Serial Server: Not Connected";
            // 
            // picHelpCOMPort
            // 
            this.picHelpCOMPort.Image = global::ELPopup5.Properties.Resources.HelpIcon;
            this.picHelpCOMPort.Location = new System.Drawing.Point(302, 58);
            this.picHelpCOMPort.Name = "picHelpCOMPort";
            this.picHelpCOMPort.Size = new System.Drawing.Size(28, 29);
            this.picHelpCOMPort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picHelpCOMPort.TabIndex = 6;
            this.picHelpCOMPort.TabStop = false;
            // 
            // picHelpRelayIP
            // 
            this.picHelpRelayIP.Image = global::ELPopup5.Properties.Resources.HelpIcon;
            this.picHelpRelayIP.Location = new System.Drawing.Point(302, 184);
            this.picHelpRelayIP.Name = "picHelpRelayIP";
            this.picHelpRelayIP.Size = new System.Drawing.Size(28, 29);
            this.picHelpRelayIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picHelpRelayIP.TabIndex = 5;
            this.picHelpRelayIP.TabStop = false;
            // 
            // cbRelayIP
            // 
            this.cbRelayIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRelayIP.FormattingEnabled = true;
            this.cbRelayIP.Items.AddRange(new object[] {
            "Do not Relay Data",
            "Entire LAN (255.255.255.255)"});
            this.cbRelayIP.Location = new System.Drawing.Point(77, 184);
            this.cbRelayIP.Name = "cbRelayIP";
            this.cbRelayIP.Size = new System.Drawing.Size(219, 24);
            this.cbRelayIP.TabIndex = 4;
            this.cbRelayIP.SelectedIndexChanged += new System.EventHandler(this.cbRelayIP_SelectedIndexChanged);
            this.cbRelayIP.TextChanged += new System.EventHandler(this.cbRelayIP_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Relay IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "COM Port";
            // 
            // cbCOMPorts
            // 
            this.cbCOMPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCOMPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCOMPorts.FormattingEnabled = true;
            this.cbCOMPorts.Location = new System.Drawing.Point(77, 58);
            this.cbCOMPorts.Name = "cbCOMPorts";
            this.cbCOMPorts.Size = new System.Drawing.Size(219, 24);
            this.cbCOMPorts.TabIndex = 0;
            this.cbCOMPorts.SelectedIndexChanged += new System.EventHandler(this.cbCOMPorts_SelectedIndexChanged);
            // 
            // tcTabsPageLogging
            // 
            this.tcTabsPageLogging.Controls.Add(this.lbLogStatus);
            this.tcTabsPageLogging.Controls.Add(this.lbLoggingFileLocation);
            this.tcTabsPageLogging.Controls.Add(this.btnStopLogging);
            this.tcTabsPageLogging.Controls.Add(this.btnSelectLoggingFile);
            this.tcTabsPageLogging.Controls.Add(this.label9);
            this.tcTabsPageLogging.Controls.Add(this.label8);
            this.tcTabsPageLogging.Controls.Add(this.label7);
            this.tcTabsPageLogging.Controls.Add(this.label6);
            this.tcTabsPageLogging.Controls.Add(this.ndRecordCount);
            this.tcTabsPageLogging.Controls.Add(this.lbTotalLogCount);
            this.tcTabsPageLogging.Controls.Add(this.btnExportRecords);
            this.tcTabsPageLogging.Location = new System.Drawing.Point(4, 30);
            this.tcTabsPageLogging.Name = "tcTabsPageLogging";
            this.tcTabsPageLogging.Padding = new System.Windows.Forms.Padding(3);
            this.tcTabsPageLogging.Size = new System.Drawing.Size(341, 230);
            this.tcTabsPageLogging.TabIndex = 3;
            this.tcTabsPageLogging.Text = "Call Records";
            this.tcTabsPageLogging.UseVisualStyleBackColor = true;
            // 
            // lbLogStatus
            // 
            this.lbLogStatus.AutoSize = true;
            this.lbLogStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogStatus.Location = new System.Drawing.Point(21, 69);
            this.lbLogStatus.Name = "lbLogStatus";
            this.lbLogStatus.Size = new System.Drawing.Size(0, 17);
            this.lbLogStatus.TabIndex = 13;
            // 
            // lbLoggingFileLocation
            // 
            this.lbLoggingFileLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbLoggingFileLocation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoggingFileLocation.Location = new System.Drawing.Point(86, 69);
            this.lbLoggingFileLocation.Multiline = true;
            this.lbLoggingFileLocation.Name = "lbLoggingFileLocation";
            this.lbLoggingFileLocation.Size = new System.Drawing.Size(239, 33);
            this.lbLoggingFileLocation.TabIndex = 12;
            this.lbLoggingFileLocation.Text = "Select Log File to Log Call Records";
            // 
            // btnStopLogging
            // 
            this.btnStopLogging.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopLogging.Location = new System.Drawing.Point(134, 37);
            this.btnStopLogging.Name = "btnStopLogging";
            this.btnStopLogging.Size = new System.Drawing.Size(127, 26);
            this.btnStopLogging.TabIndex = 11;
            this.btnStopLogging.Text = "Stop Logging";
            this.btnStopLogging.UseVisualStyleBackColor = true;
            this.btnStopLogging.Visible = false;
            this.btnStopLogging.Click += new System.EventHandler(this.lbStopLogging_Click);
            // 
            // btnSelectLoggingFile
            // 
            this.btnSelectLoggingFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectLoggingFile.Location = new System.Drawing.Point(12, 37);
            this.btnSelectLoggingFile.Name = "btnSelectLoggingFile";
            this.btnSelectLoggingFile.Size = new System.Drawing.Size(116, 26);
            this.btnSelectLoggingFile.TabIndex = 9;
            this.btnSelectLoggingFile.Text = "Select Log File";
            this.btnSelectLoggingFile.UseVisualStyleBackColor = true;
            this.btnSelectLoggingFile.Click += new System.EventHandler(this.btnSelectLoggingFile_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 21);
            this.label9.TabIndex = 7;
            this.label9.Text = "Text Log";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(216, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "to export.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 21);
            this.label7.TabIndex = 5;
            this.label7.Text = "Export CSV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(44, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "# of Records";
            // 
            // ndRecordCount
            // 
            this.ndRecordCount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ndRecordCount.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.ndRecordCount.Location = new System.Drawing.Point(134, 164);
            this.ndRecordCount.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.ndRecordCount.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.ndRecordCount.Name = "ndRecordCount";
            this.ndRecordCount.Size = new System.Drawing.Size(76, 25);
            this.ndRecordCount.TabIndex = 3;
            this.ndRecordCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ndRecordCount.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.ndRecordCount.ValueChanged += new System.EventHandler(this.ndRecordCount_ValueChanged);
            // 
            // lbTotalLogCount
            // 
            this.lbTotalLogCount.AutoSize = true;
            this.lbTotalLogCount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalLogCount.Location = new System.Drawing.Point(44, 140);
            this.lbTotalLogCount.Name = "lbTotalLogCount";
            this.lbTotalLogCount.Size = new System.Drawing.Size(166, 17);
            this.lbTotalLogCount.TabIndex = 2;
            this.lbTotalLogCount.Text = "Total of: 100 records in log";
            // 
            // btnExportRecords
            // 
            this.btnExportRecords.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportRecords.Location = new System.Drawing.Point(32, 195);
            this.btnExportRecords.Name = "btnExportRecords";
            this.btnExportRecords.Size = new System.Drawing.Size(275, 25);
            this.btnExportRecords.TabIndex = 1;
            this.btnExportRecords.Text = "Export Last 50 Records to CSV file";
            this.btnExportRecords.UseVisualStyleBackColor = true;
            this.btnExportRecords.Click += new System.EventHandler(this.btnExportRecords_Click);
            // 
            // tcTabsPageMisc
            // 
            this.tcTabsPageMisc.Controls.Add(this.label5);
            this.tcTabsPageMisc.Controls.Add(this.btnClearLog);
            this.tcTabsPageMisc.Controls.Add(this.ckbStartInSystemTray);
            this.tcTabsPageMisc.Controls.Add(this.btnImportOldDatabase);
            this.tcTabsPageMisc.Controls.Add(this.btnResetLineDisplay);
            this.tcTabsPageMisc.Location = new System.Drawing.Point(4, 30);
            this.tcTabsPageMisc.Name = "tcTabsPageMisc";
            this.tcTabsPageMisc.Padding = new System.Windows.Forms.Padding(3);
            this.tcTabsPageMisc.Size = new System.Drawing.Size(341, 230);
            this.tcTabsPageMisc.TabIndex = 2;
            this.tcTabsPageMisc.Text = "Misc.";
            this.tcTabsPageMisc.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 34);
            this.label5.TabIndex = 4;
            this.label5.Text = "Delete all Call Records\r\nfrom Database";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLog.Location = new System.Drawing.Point(195, 179);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(56, 31);
            this.btnClearLog.TabIndex = 3;
            this.btnClearLog.Text = "Delete";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // ckbStartInSystemTray
            // 
            this.ckbStartInSystemTray.AutoSize = true;
            this.ckbStartInSystemTray.Checked = true;
            this.ckbStartInSystemTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbStartInSystemTray.Location = new System.Drawing.Point(63, 38);
            this.ckbStartInSystemTray.Name = "ckbStartInSystemTray";
            this.ckbStartInSystemTray.Size = new System.Drawing.Size(246, 25);
            this.ckbStartInSystemTray.TabIndex = 2;
            this.ckbStartInSystemTray.Text = "Display Main Screen on Startup";
            this.ckbStartInSystemTray.UseVisualStyleBackColor = true;
            this.ckbStartInSystemTray.CheckedChanged += new System.EventHandler(this.ckbStartInSystemTray_CheckedChanged);
            // 
            // btnImportOldDatabase
            // 
            this.btnImportOldDatabase.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportOldDatabase.Location = new System.Drawing.Point(92, 135);
            this.btnImportOldDatabase.Name = "btnImportOldDatabase";
            this.btnImportOldDatabase.Size = new System.Drawing.Size(159, 31);
            this.btnImportOldDatabase.TabIndex = 1;
            this.btnImportOldDatabase.Text = "Import Old Database";
            this.btnImportOldDatabase.UseVisualStyleBackColor = true;
            this.btnImportOldDatabase.Click += new System.EventHandler(this.btnImportOldDatabase_Click);
            // 
            // btnResetLineDisplay
            // 
            this.btnResetLineDisplay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetLineDisplay.Location = new System.Drawing.Point(92, 98);
            this.btnResetLineDisplay.Name = "btnResetLineDisplay";
            this.btnResetLineDisplay.Size = new System.Drawing.Size(159, 31);
            this.btnResetLineDisplay.TabIndex = 0;
            this.btnResetLineDisplay.Text = "Reset Display Line Count";
            this.btnResetLineDisplay.UseVisualStyleBackColor = true;
            this.btnResetLineDisplay.Click += new System.EventHandler(this.btnResetLineDisplay_Click);
            // 
            // FrmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 292);
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
            ((System.ComponentModel.ISupportInitialize)(this.ndPopupTiming)).EndInit();
            this.tcTabsPageSerialServer.ResumeLayout(false);
            this.tcTabsPageSerialServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpCOMPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHelpRelayIP)).EndInit();
            this.tcTabsPageLogging.ResumeLayout(false);
            this.tcTabsPageLogging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ndRecordCount)).EndInit();
            this.tcTabsPageMisc.ResumeLayout(false);
            this.tcTabsPageMisc.PerformLayout();
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
        private System.Windows.Forms.ComboBox cbRelayIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbSerialStatus;
        private System.Windows.Forms.PictureBox picHelpCOMPort;
        private System.Windows.Forms.TabPage tcTabsPageMisc;
        private System.Windows.Forms.Button btnResetLineDisplay;
        private System.Windows.Forms.TabPage tcTabsPageLogging;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ndRecordCount;
        private System.Windows.Forms.Label lbTotalLogCount;
        private System.Windows.Forms.Button btnExportRecords;
        private System.Windows.Forms.Button btnSelectLoggingFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.SaveFileDialog sfdLoggingFile;
        private System.Windows.Forms.TextBox lbLoggingFileLocation;
        private System.Windows.Forms.Button btnStopLogging;
        private System.Windows.Forms.Label lbLogStatus;
        private System.Windows.Forms.Button btnImportOldDatabase;
        private System.Windows.Forms.CheckBox ckbStartInSystemTray;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRefreshSerialList;
    }
}
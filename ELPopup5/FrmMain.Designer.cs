namespace ELPopup5
{
    partial class FrmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.dgvCallLog = new System.Windows.Forms.DataGridView();
            this.lbLine1 = new System.Windows.Forms.Label();
            this.tbL1Number = new System.Windows.Forms.TextBox();
            this.tbL1Name = new System.Windows.Forms.TextBox();
            this.tbL2Name = new System.Windows.Forms.TextBox();
            this.tbL2Number = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbL3Name = new System.Windows.Forms.TextBox();
            this.tbL3Number = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbL4Name = new System.Windows.Forms.TextBox();
            this.tbL4Number = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbL5Name = new System.Windows.Forms.TextBox();
            this.tbL5Number = new System.Windows.Forms.TextBox();
            this.lbL5 = new System.Windows.Forms.Label();
            this.tbL6Name = new System.Windows.Forms.TextBox();
            this.tbL6Number = new System.Windows.Forms.TextBox();
            this.lbL6 = new System.Windows.Forms.Label();
            this.tbL7Name = new System.Windows.Forms.TextBox();
            this.tbL7Number = new System.Windows.Forms.TextBox();
            this.lbL7 = new System.Windows.Forms.Label();
            this.tbL8Name = new System.Windows.Forms.TextBox();
            this.tbL8Number = new System.Windows.Forms.TextBox();
            this.lbL8 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ndDisplayCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvCallLogColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCallLogColNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCallLogColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCallLogColDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCallLogColLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCallLogColIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCallLogColRings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCallLogColSortDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCallLogColUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCallLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndDisplayCount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCallLog
            // 
            this.dgvCallLog.AllowUserToAddRows = false;
            this.dgvCallLog.AllowUserToDeleteRows = false;
            this.dgvCallLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCallLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCallLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvCallLogColName,
            this.dgvCallLogColNumber,
            this.dgvCallLogColDate,
            this.dgvCallLogColDuration,
            this.dgvCallLogColLine,
            this.dgvCallLogColIO,
            this.dgvCallLogColRings,
            this.dgvCallLogColSortDate,
            this.dgvCallLogColUID});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCallLog.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCallLog.Location = new System.Drawing.Point(31, 198);
            this.dgvCallLog.MultiSelect = false;
            this.dgvCallLog.Name = "dgvCallLog";
            this.dgvCallLog.ReadOnly = true;
            this.dgvCallLog.RowHeadersVisible = false;
            this.dgvCallLog.RowTemplate.Height = 35;
            this.dgvCallLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCallLog.Size = new System.Drawing.Size(693, 251);
            this.dgvCallLog.TabIndex = 0;
            this.dgvCallLog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCallLog_CellClick);
            this.dgvCallLog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvCallLog_MouseUp);
            // 
            // lbLine1
            // 
            this.lbLine1.AutoSize = true;
            this.lbLine1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLine1.Location = new System.Drawing.Point(27, 29);
            this.lbLine1.Name = "lbLine1";
            this.lbLine1.Size = new System.Drawing.Size(27, 21);
            this.lbLine1.TabIndex = 1;
            this.lbLine1.Text = "L1";
            // 
            // tbL1Number
            // 
            this.tbL1Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL1Number.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL1Number.Location = new System.Drawing.Point(60, 27);
            this.tbL1Number.Name = "tbL1Number";
            this.tbL1Number.Size = new System.Drawing.Size(153, 29);
            this.tbL1Number.TabIndex = 2;
            this.tbL1Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL1Number.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // tbL1Name
            // 
            this.tbL1Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL1Name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL1Name.Location = new System.Drawing.Point(219, 27);
            this.tbL1Name.Name = "tbL1Name";
            this.tbL1Name.Size = new System.Drawing.Size(153, 29);
            this.tbL1Name.TabIndex = 3;
            this.tbL1Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL1Name.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // tbL2Name
            // 
            this.tbL2Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL2Name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL2Name.Location = new System.Drawing.Point(219, 62);
            this.tbL2Name.Name = "tbL2Name";
            this.tbL2Name.Size = new System.Drawing.Size(153, 29);
            this.tbL2Name.TabIndex = 6;
            this.tbL2Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL2Name.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // tbL2Number
            // 
            this.tbL2Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL2Number.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL2Number.Location = new System.Drawing.Point(60, 62);
            this.tbL2Number.Name = "tbL2Number";
            this.tbL2Number.Size = new System.Drawing.Size(153, 29);
            this.tbL2Number.TabIndex = 5;
            this.tbL2Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL2Number.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "L2";
            // 
            // tbL3Name
            // 
            this.tbL3Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL3Name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL3Name.Location = new System.Drawing.Point(219, 97);
            this.tbL3Name.Name = "tbL3Name";
            this.tbL3Name.Size = new System.Drawing.Size(153, 29);
            this.tbL3Name.TabIndex = 9;
            this.tbL3Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL3Name.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // tbL3Number
            // 
            this.tbL3Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL3Number.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL3Number.Location = new System.Drawing.Point(60, 97);
            this.tbL3Number.Name = "tbL3Number";
            this.tbL3Number.Size = new System.Drawing.Size(153, 29);
            this.tbL3Number.TabIndex = 8;
            this.tbL3Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL3Number.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "L3";
            // 
            // tbL4Name
            // 
            this.tbL4Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL4Name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL4Name.Location = new System.Drawing.Point(219, 132);
            this.tbL4Name.Name = "tbL4Name";
            this.tbL4Name.Size = new System.Drawing.Size(153, 29);
            this.tbL4Name.TabIndex = 12;
            this.tbL4Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL4Name.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // tbL4Number
            // 
            this.tbL4Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL4Number.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL4Number.Location = new System.Drawing.Point(60, 132);
            this.tbL4Number.Name = "tbL4Number";
            this.tbL4Number.Size = new System.Drawing.Size(153, 29);
            this.tbL4Number.TabIndex = 11;
            this.tbL4Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL4Number.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "L4";
            // 
            // tbL5Name
            // 
            this.tbL5Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL5Name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL5Name.Location = new System.Drawing.Point(635, 27);
            this.tbL5Name.Name = "tbL5Name";
            this.tbL5Name.Size = new System.Drawing.Size(153, 29);
            this.tbL5Name.TabIndex = 15;
            this.tbL5Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL5Name.Visible = false;
            this.tbL5Name.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // tbL5Number
            // 
            this.tbL5Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL5Number.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL5Number.Location = new System.Drawing.Point(476, 27);
            this.tbL5Number.Name = "tbL5Number";
            this.tbL5Number.Size = new System.Drawing.Size(153, 29);
            this.tbL5Number.TabIndex = 14;
            this.tbL5Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL5Number.Visible = false;
            this.tbL5Number.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // lbL5
            // 
            this.lbL5.AutoSize = true;
            this.lbL5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbL5.Location = new System.Drawing.Point(443, 29);
            this.lbL5.Name = "lbL5";
            this.lbL5.Size = new System.Drawing.Size(27, 21);
            this.lbL5.TabIndex = 13;
            this.lbL5.Text = "L5";
            this.lbL5.Visible = false;
            // 
            // tbL6Name
            // 
            this.tbL6Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL6Name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL6Name.Location = new System.Drawing.Point(635, 62);
            this.tbL6Name.Name = "tbL6Name";
            this.tbL6Name.Size = new System.Drawing.Size(153, 29);
            this.tbL6Name.TabIndex = 18;
            this.tbL6Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL6Name.Visible = false;
            this.tbL6Name.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // tbL6Number
            // 
            this.tbL6Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL6Number.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL6Number.Location = new System.Drawing.Point(476, 62);
            this.tbL6Number.Name = "tbL6Number";
            this.tbL6Number.Size = new System.Drawing.Size(153, 29);
            this.tbL6Number.TabIndex = 17;
            this.tbL6Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL6Number.Visible = false;
            this.tbL6Number.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // lbL6
            // 
            this.lbL6.AutoSize = true;
            this.lbL6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbL6.Location = new System.Drawing.Point(443, 64);
            this.lbL6.Name = "lbL6";
            this.lbL6.Size = new System.Drawing.Size(27, 21);
            this.lbL6.TabIndex = 16;
            this.lbL6.Text = "L6";
            this.lbL6.Visible = false;
            // 
            // tbL7Name
            // 
            this.tbL7Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL7Name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL7Name.Location = new System.Drawing.Point(635, 97);
            this.tbL7Name.Name = "tbL7Name";
            this.tbL7Name.Size = new System.Drawing.Size(153, 29);
            this.tbL7Name.TabIndex = 21;
            this.tbL7Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL7Name.Visible = false;
            this.tbL7Name.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // tbL7Number
            // 
            this.tbL7Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL7Number.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL7Number.Location = new System.Drawing.Point(476, 97);
            this.tbL7Number.Name = "tbL7Number";
            this.tbL7Number.Size = new System.Drawing.Size(153, 29);
            this.tbL7Number.TabIndex = 20;
            this.tbL7Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL7Number.Visible = false;
            this.tbL7Number.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // lbL7
            // 
            this.lbL7.AutoSize = true;
            this.lbL7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbL7.Location = new System.Drawing.Point(443, 99);
            this.lbL7.Name = "lbL7";
            this.lbL7.Size = new System.Drawing.Size(27, 21);
            this.lbL7.TabIndex = 19;
            this.lbL7.Text = "L7";
            this.lbL7.Visible = false;
            // 
            // tbL8Name
            // 
            this.tbL8Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL8Name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL8Name.Location = new System.Drawing.Point(635, 132);
            this.tbL8Name.Name = "tbL8Name";
            this.tbL8Name.Size = new System.Drawing.Size(153, 29);
            this.tbL8Name.TabIndex = 24;
            this.tbL8Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL8Name.Visible = false;
            this.tbL8Name.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // tbL8Number
            // 
            this.tbL8Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbL8Number.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbL8Number.Location = new System.Drawing.Point(476, 132);
            this.tbL8Number.Name = "tbL8Number";
            this.tbL8Number.Size = new System.Drawing.Size(153, 29);
            this.tbL8Number.TabIndex = 23;
            this.tbL8Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbL8Number.Visible = false;
            this.tbL8Number.Click += new System.EventHandler(this.CopyTextboxText);
            // 
            // lbL8
            // 
            this.lbL8.AutoSize = true;
            this.lbL8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbL8.Location = new System.Drawing.Point(443, 134);
            this.lbL8.Name = "lbL8";
            this.lbL8.Size = new System.Drawing.Size(27, 21);
            this.lbL8.TabIndex = 22;
            this.lbL8.Text = "L8";
            this.lbL8.Visible = false;
            // 
            // tbSearch
            // 
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(110, 169);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(233, 25);
            this.tbSearch.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Search Log:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Click Name or Number to Copy";
            // 
            // ndDisplayCount
            // 
            this.ndDisplayCount.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.ndDisplayCount.Location = new System.Drawing.Point(635, 170);
            this.ndDisplayCount.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.ndDisplayCount.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.ndDisplayCount.Name = "ndDisplayCount";
            this.ndDisplayCount.Size = new System.Drawing.Size(89, 20);
            this.ndDisplayCount.TabIndex = 28;
            this.ndDisplayCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ndDisplayCount.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.ndDisplayCount.Leave += new System.EventHandler(this.ndDisplayCount_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(495, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Display Record Count";
            // 
            // dgvCallLogColName
            // 
            this.dgvCallLogColName.HeaderText = "Name";
            this.dgvCallLogColName.Name = "dgvCallLogColName";
            this.dgvCallLogColName.ReadOnly = true;
            this.dgvCallLogColName.Width = 160;
            // 
            // dgvCallLogColNumber
            // 
            this.dgvCallLogColNumber.HeaderText = "Number";
            this.dgvCallLogColNumber.Name = "dgvCallLogColNumber";
            this.dgvCallLogColNumber.ReadOnly = true;
            this.dgvCallLogColNumber.Width = 160;
            // 
            // dgvCallLogColDate
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvCallLogColDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCallLogColDate.HeaderText = "Date and Time";
            this.dgvCallLogColDate.Name = "dgvCallLogColDate";
            this.dgvCallLogColDate.ReadOnly = true;
            this.dgvCallLogColDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvCallLogColDate.Width = 170;
            // 
            // dgvCallLogColDuration
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvCallLogColDuration.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCallLogColDuration.HeaderText = "Duration";
            this.dgvCallLogColDuration.Name = "dgvCallLogColDuration";
            this.dgvCallLogColDuration.ReadOnly = true;
            this.dgvCallLogColDuration.Width = 60;
            // 
            // dgvCallLogColLine
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvCallLogColLine.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCallLogColLine.HeaderText = "Line";
            this.dgvCallLogColLine.Name = "dgvCallLogColLine";
            this.dgvCallLogColLine.ReadOnly = true;
            this.dgvCallLogColLine.Width = 38;
            // 
            // dgvCallLogColIO
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvCallLogColIO.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCallLogColIO.HeaderText = "IO";
            this.dgvCallLogColIO.Name = "dgvCallLogColIO";
            this.dgvCallLogColIO.ReadOnly = true;
            this.dgvCallLogColIO.Width = 32;
            // 
            // dgvCallLogColRings
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvCallLogColRings.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCallLogColRings.HeaderText = "Rings";
            this.dgvCallLogColRings.Name = "dgvCallLogColRings";
            this.dgvCallLogColRings.ReadOnly = true;
            this.dgvCallLogColRings.Width = 40;
            // 
            // dgvCallLogColSortDate
            // 
            this.dgvCallLogColSortDate.HeaderText = "Sortable Date";
            this.dgvCallLogColSortDate.Name = "dgvCallLogColSortDate";
            this.dgvCallLogColSortDate.ReadOnly = true;
            this.dgvCallLogColSortDate.Visible = false;
            // 
            // dgvCallLogColUID
            // 
            this.dgvCallLogColUID.HeaderText = "UID";
            this.dgvCallLogColUID.Name = "dgvCallLogColUID";
            this.dgvCallLogColUID.ReadOnly = true;
            this.dgvCallLogColUID.Visible = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 472);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ndDisplayCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbL8Name);
            this.Controls.Add(this.tbL8Number);
            this.Controls.Add(this.lbL8);
            this.Controls.Add(this.tbL7Name);
            this.Controls.Add(this.tbL7Number);
            this.Controls.Add(this.lbL7);
            this.Controls.Add(this.tbL6Name);
            this.Controls.Add(this.tbL6Number);
            this.Controls.Add(this.lbL6);
            this.Controls.Add(this.tbL5Name);
            this.Controls.Add(this.tbL5Number);
            this.Controls.Add(this.lbL5);
            this.Controls.Add(this.tbL4Name);
            this.Controls.Add(this.tbL4Number);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbL3Name);
            this.Controls.Add(this.tbL3Number);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbL2Name);
            this.Controls.Add(this.tbL2Number);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbL1Name);
            this.Controls.Add(this.tbL1Number);
            this.Controls.Add(this.lbLine1);
            this.Controls.Add(this.dgvCallLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(752, 511);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Popup";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCallLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndDisplayCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCallLog;
        private System.Windows.Forms.Label lbLine1;
        private System.Windows.Forms.TextBox tbL1Number;
        private System.Windows.Forms.TextBox tbL1Name;
        private System.Windows.Forms.TextBox tbL2Name;
        private System.Windows.Forms.TextBox tbL2Number;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbL3Name;
        private System.Windows.Forms.TextBox tbL3Number;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbL4Name;
        private System.Windows.Forms.TextBox tbL4Number;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbL5Name;
        private System.Windows.Forms.TextBox tbL5Number;
        private System.Windows.Forms.Label lbL5;
        private System.Windows.Forms.TextBox tbL6Name;
        private System.Windows.Forms.TextBox tbL6Number;
        private System.Windows.Forms.Label lbL6;
        private System.Windows.Forms.TextBox tbL7Name;
        private System.Windows.Forms.TextBox tbL7Number;
        private System.Windows.Forms.Label lbL7;
        private System.Windows.Forms.TextBox tbL8Name;
        private System.Windows.Forms.TextBox tbL8Number;
        private System.Windows.Forms.Label lbL8;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown ndDisplayCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCallLogColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCallLogColNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCallLogColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCallLogColDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCallLogColLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCallLogColIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCallLogColRings;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCallLogColSortDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCallLogColUID;
    }
}


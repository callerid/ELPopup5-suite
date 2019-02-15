namespace ELPopup5
{
    partial class FrmPopup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPopup));
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.tbInOutCall = new System.Windows.Forms.TextBox();
            this.timerAutoClose = new System.Windows.Forms.Timer(this.components);
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbCopiedNumber = new System.Windows.Forms.Label();
            this.lbCopiedName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbNumber
            // 
            this.tbNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumber.Location = new System.Drawing.Point(62, 24);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.ReadOnly = true;
            this.tbNumber.Size = new System.Drawing.Size(172, 32);
            this.tbNumber.TabIndex = 2;
            this.tbNumber.Text = "111111111111111";
            this.tbNumber.WordWrap = false;
            this.tbNumber.Click += new System.EventHandler(this.CopyTextboxText);
            this.tbNumber.MouseLeave += new System.EventHandler(this.FrmPopup_MouseLeave);
            this.tbNumber.MouseHover += new System.EventHandler(this.FrmPopup_MouseHover);
            // 
            // tbInOutCall
            // 
            this.tbInOutCall.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInOutCall.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInOutCall.Location = new System.Drawing.Point(24, 24);
            this.tbInOutCall.Name = "tbInOutCall";
            this.tbInOutCall.ReadOnly = true;
            this.tbInOutCall.Size = new System.Drawing.Size(32, 32);
            this.tbInOutCall.TabIndex = 3;
            this.tbInOutCall.Text = "L1";
            this.tbInOutCall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbInOutCall.WordWrap = false;
            this.tbInOutCall.MouseLeave += new System.EventHandler(this.FrmPopup_MouseLeave);
            this.tbInOutCall.MouseHover += new System.EventHandler(this.FrmPopup_MouseHover);
            // 
            // timerAutoClose
            // 
            this.timerAutoClose.Enabled = true;
            this.timerAutoClose.Interval = 5000;
            this.timerAutoClose.Tick += new System.EventHandler(this.timerAutoClose_Tick);
            // 
            // tbName
            // 
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(240, 24);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(218, 32);
            this.tbName.TabIndex = 4;
            this.tbName.Text = "222222222222222";
            this.tbName.WordWrap = false;
            this.tbName.Click += new System.EventHandler(this.CopyTextboxText);
            this.tbName.MouseLeave += new System.EventHandler(this.FrmPopup_MouseLeave);
            this.tbName.MouseHover += new System.EventHandler(this.FrmPopup_MouseHover);
            // 
            // lbCopiedNumber
            // 
            this.lbCopiedNumber.AutoSize = true;
            this.lbCopiedNumber.Location = new System.Drawing.Point(62, 58);
            this.lbCopiedNumber.Name = "lbCopiedNumber";
            this.lbCopiedNumber.Size = new System.Drawing.Size(88, 13);
            this.lbCopiedNumber.TabIndex = 5;
            this.lbCopiedNumber.Text = "Copied Number";
            this.lbCopiedNumber.Visible = false;
            this.lbCopiedNumber.MouseLeave += new System.EventHandler(this.FrmPopup_MouseLeave);
            this.lbCopiedNumber.MouseHover += new System.EventHandler(this.FrmPopup_MouseHover);
            // 
            // lbCopiedName
            // 
            this.lbCopiedName.AutoSize = true;
            this.lbCopiedName.Location = new System.Drawing.Point(237, 58);
            this.lbCopiedName.Name = "lbCopiedName";
            this.lbCopiedName.Size = new System.Drawing.Size(76, 13);
            this.lbCopiedName.TabIndex = 6;
            this.lbCopiedName.Text = "Copied Name";
            this.lbCopiedName.Visible = false;
            this.lbCopiedName.MouseLeave += new System.EventHandler(this.FrmPopup_MouseLeave);
            this.lbCopiedName.MouseHover += new System.EventHandler(this.FrmPopup_MouseHover);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(463, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 21);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseLeave += new System.EventHandler(this.FrmPopup_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.FrmPopup_MouseHover);
            // 
            // FrmPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 80);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbCopiedName);
            this.Controls.Add(this.lbCopiedNumber);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbInOutCall);
            this.Controls.Add(this.tbNumber);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Incoming Call";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPopup_FormClosed);
            this.MouseLeave += new System.EventHandler(this.FrmPopup_MouseLeave);
            this.MouseHover += new System.EventHandler(this.FrmPopup_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.TextBox tbInOutCall;
        private System.Windows.Forms.Timer timerAutoClose;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbCopiedNumber;
        private System.Windows.Forms.Label lbCopiedName;
        private System.Windows.Forms.Button btnClose;
    }
}
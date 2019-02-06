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
            this.tbCallerId = new System.Windows.Forms.TextBox();
            this.tbInOutCall = new System.Windows.Forms.TextBox();
            this.timerAutoClose = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tbCallerId
            // 
            this.tbCallerId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCallerId.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCallerId.Location = new System.Drawing.Point(50, 23);
            this.tbCallerId.Name = "tbCallerId";
            this.tbCallerId.ReadOnly = true;
            this.tbCallerId.Size = new System.Drawing.Size(390, 32);
            this.tbCallerId.TabIndex = 2;
            this.tbCallerId.Text = "111111111111111   222222222222222";
            this.tbCallerId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbCallerId.WordWrap = false;
            this.tbCallerId.MouseLeave += new System.EventHandler(this.FrmPopup_MouseLeave);
            this.tbCallerId.MouseHover += new System.EventHandler(this.FrmPopup_MouseHover);
            // 
            // tbInOutCall
            // 
            this.tbInOutCall.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInOutCall.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInOutCall.Location = new System.Drawing.Point(12, 23);
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
            // FrmPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 80);
            this.Controls.Add(this.tbInOutCall);
            this.Controls.Add(this.tbCallerId);
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

        private System.Windows.Forms.TextBox tbCallerId;
        private System.Windows.Forms.TextBox tbInOutCall;
        private System.Windows.Forms.Timer timerAutoClose;
    }
}
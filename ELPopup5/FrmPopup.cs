﻿using ELPopup5.Classes;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ELPopup5
{
    public partial class FrmPopup : Form
    {

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_SHOWWINDOW = 0x0040;
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        public int ID;
        public int POS;
        public int LineNumber = -1;
        public bool MouseIsHoving = false;
        public string TheNumber;
        public string USTRING;
        public string FullName;

        public FrmPopup(int id, int line, bool isInbound, string num, string name, int x, int y, int pos, string uString)
        {
            InitializeComponent();
            timerAutoClose.Interval = int.Parse(Program.AppSettings[(int)Program.AppSetting.POPUP_TIME]) * 1000;

            LineNumber = line;

            ID = id;
            POS = pos;
            TheNumber = num;
            FullName = name;
            USTRING = uString;

            tbInOutCall.Text = "L" + line.ToString();
            Opacity = 0.93;

            if (isInbound)
            {
                ForeColor = Program.C_INCOMING_CALL_FOREGROUND;
            }
            else
            {
                BackColor = Color.LightBlue;
            }

            Text = tbInOutCall.Text;

            if (isInbound)
            {
                BackColor = Program.C_INCOMING_CALL_BACKGROUND;
                tbInOutCall.BackColor = Program.C_INCOMING_CALL_BACKGROUND;
                tbNumber.BackColor = Program.C_INCOMING_CALL_BACKGROUND;
                tbName.BackColor = Program.C_INCOMING_CALL_BACKGROUND;

                tbInOutCall.ForeColor = Program.C_INCOMING_CALL_FOREGROUND;
                tbNumber.ForeColor = Program.C_INCOMING_CALL_FOREGROUND;
                tbName.ForeColor = Program.C_INCOMING_CALL_FOREGROUND;

                lbClose.ForeColor = Program.C_INCOMING_CALL_FOREGROUND;

            }
            else
            {
                BackColor = Program.C_OUTGOING_CALL_BACKGROUND;
                tbInOutCall.BackColor = Program.C_OUTGOING_CALL_BACKGROUND;
                tbNumber.BackColor = Program.C_OUTGOING_CALL_BACKGROUND;
                tbName.BackColor = Program.C_OUTGOING_CALL_BACKGROUND;

                tbInOutCall.ForeColor = Program.C_OUTGOING_CALL_FOREGROUND;
                tbNumber.ForeColor = Program.C_OUTGOING_CALL_FOREGROUND;
                tbName.ForeColor = Program.C_OUTGOING_CALL_FOREGROUND;

                lbClose.ForeColor = Program.C_OUTGOING_CALL_FOREGROUND;
            }

            tbNumber.Text = num;
            tbName.Text = name;

            Location = new Point(x, y);

            IntPtr handle = this.Handle;
            SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);

        }

        public void Reposition(int x, int y)
        {
            Location = new Point(x, y);
        }

        public void CopyTextboxText(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox tb = (TextBox)sender;
                if (string.IsNullOrEmpty(tb.Text)) return;
                Clipboard.SetText(tb.Text);
                string type = (tb.Name.ToLower().Contains("number")) ? "Number" : "Name";

                tb.Text = "Copied";
                timerResetToNameAndNumber.Interval = 1000;
                timerResetToNameAndNumber.Enabled = true;
                timerResetToNameAndNumber.Start();
            }
        }

        private void timerAutoClose_Tick(object sender, EventArgs e)
        {
            Program.fMain.pController.RemovePopup(ID);
            Close();
        }

        private void FrmPopup_MouseHover(object sender, EventArgs e)
        {
            timerAutoClose.Stop();
            MouseIsHoving = true;
        }

        private void FrmPopup_MouseLeave(object sender, EventArgs e)
        {
            timerAutoClose.Start();
            MouseIsHoving = false;
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            Program.fMain.pController.RemovePopup(ID);
            Close();
        }

        public void UpdateXY(int x, int y)
        {
            Location = new Point(x, y);
        }

        private void FrmPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.fMain.pController.RemovePopup(ID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timerResetToNameAndNumber_Tick(object sender, EventArgs e)
        {
            timerResetToNameAndNumber.Enabled = false;
            timerResetToNameAndNumber.Stop();

            tbName.Text = FullName;
            tbNumber.Text = TheNumber;
        }
    }
}

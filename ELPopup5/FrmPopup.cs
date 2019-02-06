using ELPopup5.Classes;
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
        public bool MouseIsHoving = false;
        public string TheNumber;
        public string USTRING;
        public string FullName;

        public FrmPopup(int id, int line, bool isInbound, string num, string name, int x, int y, int pos, string uString)
        {
            InitializeComponent();

            ID = id;
            POS = pos;
            TheNumber = num;
            FullName = name;
            USTRING = uString;

            tbInOutCall.Text = "L" + line.ToString();
            Opacity = 0.93;

            if (isInbound)
            {
                BackColor = Program.C_INCOMING_CALL_BACKGROUND;
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
                tbCallerId.BackColor = Program.C_INCOMING_CALL_BACKGROUND;

                tbInOutCall.ForeColor = Program.C_INCOMING_CALL_FOREGROUND;
                tbCallerId.ForeColor = Program.C_INCOMING_CALL_FOREGROUND;

            }
            else
            {
                BackColor = Program.C_OUTGOING_CALL_BACKGROUND;
                tbInOutCall.BackColor = Program.C_OUTGOING_CALL_BACKGROUND;
                tbCallerId.BackColor = Program.C_OUTGOING_CALL_BACKGROUND;

                tbInOutCall.ForeColor = Program.C_OUTGOING_CALL_FOREGROUND;
                tbCallerId.ForeColor = Program.C_OUTGOING_CALL_FOREGROUND;
            }

            tbCallerId.Text = num.ToString().PadRight(18, ' ') + name.ToString().Trim();

            Location = new Point(x, y);

            IntPtr handle = this.Handle;
            SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);

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

    }
}

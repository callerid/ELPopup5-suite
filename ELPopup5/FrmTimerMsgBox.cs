using ELPopup5.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ELPopup5
{
    public partial class FrmTimerMsgBox : Form
    {
        public FrmTimerMsgBox(string title, string msg, int milliseconds = 1500)
        {
            InitializeComponent();
            Common.DrawColors(this, title);

            Text = title;
            tbMsg.Text = Environment.NewLine + Environment.NewLine + msg;
            tbMsg.SelectionStart = tbMsg.Text.Length - 1;

            timerAutoClose.Interval = milliseconds;
            timerAutoClose.Start();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timerAutoClose_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}

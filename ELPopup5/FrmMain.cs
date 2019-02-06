using cid_cm.Classes;
using ELPopup5.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ELPopup5
{
    public partial class FrmMain : Form
    {

        private const int DGV_LOG_NAME = 0;
        private const int DGV_LOG_NUMBER = 1;
        private const int DGV_LOG_DATE = 2;
        private const int DGV_LOG_DUR = 3;
        private const int DGV_LOG_LINE = 4;
        private const int DGV_LOG_IO = 5;
        private const int DGV_LOG_RINGS = 6;
        private const int DGV_LOG_SORT_DATE = 7;
        private const int DGV_LOG_ID = 8;


        // UPD Port
        public static UdpReceiverClass UdpReceiver = new UdpReceiverClass();
        readonly Thread _udpReceiveThread = new Thread(UdpReceiver.UdpIdleReceive);

        // Controllers
        public PopupController pController = null;

        // Name and Number Textboxes
        private TextBox[] tbNumbers = new TextBox[10];
        private TextBox[] tbNames = new TextBox[10];

        public FrmMain()
        {
            InitializeComponent();

            tbNumbers[1] = tbL1Number;
            tbNumbers[2] = tbL2Number;
            tbNumbers[3] = tbL3Number;
            tbNumbers[4] = tbL4Number;
            tbNumbers[5] = tbL5Number;
            tbNumbers[6] = tbL6Number;
            tbNumbers[7] = tbL7Number;
            tbNumbers[8] = tbL8Number;

            tbNames[1] = tbL1Name;
            tbNames[2] = tbL2Name;
            tbNames[3] = tbL3Name;
            tbNames[4] = tbL4Name;
            tbNames[5] = tbL5Name;
            tbNames[6] = tbL6Name;
            tbNames[7] = tbL7Name;
            tbNames[8] = tbL8Name;


            Common.DrawColors(this, "ELPopup 5 - v." + Application.ProductVersion);

            // Initialize popup controller
            pController = new PopupController();

            // Start listener for UDP traffic
            Subscribe(UdpReceiver);
            _udpReceiveThread.IsBackground = true;
            _udpReceiveThread.Start();

            PopulateCallLog();

        }

        public void Subscribe(UdpReceiverClass u)
        {
            // If UDP event occurs run HeardIt method
            u.DataReceived += HeardIt;
        }

        private void HeardIt(UdpReceiverClass u, EventArgs e)
        {
            // HELP : example how to call method
            // Invoke((MethodInvoker)(() => methodName()));
            Invoke((MethodInvoker)(GetCall));

        }

        private bool PreviousPacketWasOutbound = false;
        private void GetCall()
        {
            // Parse up call
            CallRecord call_record = new CallRecord(UdpReceiverClass.ReceivedMessage);

            // Show popup
            if (call_record.IsStartRecord())
            {
                pController.AddPopup(call_record.Line, call_record.IsInbound(), call_record.PhoneNumber, call_record.Name);
                PreviousPacketWasOutbound = !call_record.IsInbound();
            }
            else if (call_record.IsEndRecord())
            {
                PreviousPacketWasOutbound = false;
            }

            if (call_record.Detailed && call_record.DetailedType == "N")
            {
                var uString = call_record.Line + " " + (call_record.IsInbound() ? "1" : "0") + " " + call_record.PhoneNumber + " " + call_record.Name;
                pController.RemovePopup(uString);
            }

            switch (call_record.Line)
            {

                case 5:
                case 6:
                case 7:
                case 8:

                    UnHideLines();

                    break;
            }


            if (call_record.Detailed)
            {
                if(call_record.DetailedType == "R")
                {
                    tbNames[call_record.Line].Text = "";
                    tbNumbers[call_record.Line].Text = "";

                    tbNames[call_record.Line].BackColor = Color.Pink;
                    tbNumbers[call_record.Line].BackColor = Color.Pink;
                }
                else if(call_record.DetailedType == "F")
                {
                    if (PreviousPacketWasOutbound)
                    {
                        tbNames[call_record.Line].Text = "";
                        tbNumbers[call_record.Line].Text = "";
                    }

                    tbNames[call_record.Line].BackColor = Color.LightYellow;
                    tbNumbers[call_record.Line].BackColor = Color.LightYellow;
                }
                else
                {
                    tbNames[call_record.Line].BackColor = Program.C_BACKGROUND;
                    tbNumbers[call_record.Line].BackColor = Program.C_BACKGROUND;
                }
            }
            else
            {
                if (call_record.IsEndRecord())
                {
                    tbNames[call_record.Line].BackColor = Program.C_BACKGROUND;
                    tbNumbers[call_record.Line].BackColor = Program.C_BACKGROUND;
                    
                }
                else
                {
                    if(call_record.IsStartRecord()){

                        if (call_record.IsInbound())
                        {
                            tbNames[call_record.Line].BackColor = Program.C_INCOMING_CALL_BACKGROUND;
                            tbNumbers[call_record.Line].BackColor = Program.C_INCOMING_CALL_BACKGROUND;
                            tbNames[call_record.Line].ForeColor = Program.C_INCOMING_CALL_FOREGROUND;
                            tbNumbers[call_record.Line].ForeColor = Program.C_INCOMING_CALL_FOREGROUND;
                        }
                        else
                        {

                            tbNames[call_record.Line].BackColor = Program.C_OUTGOING_CALL_BACKGROUND;
                            tbNumbers[call_record.Line].BackColor = Program.C_OUTGOING_CALL_BACKGROUND;
                            tbNames[call_record.Line].ForeColor = Program.C_OUTGOING_CALL_FOREGROUND;
                            tbNumbers[call_record.Line].ForeColor = Program.C_OUTGOING_CALL_FOREGROUND;
                        }

                        AddToCallLog(call_record.Name, call_record.PhoneNumber, call_record.DateTime, call_record.Duration, call_record.Line, call_record.InboundOrOutboundOrBlock, call_record.RingNumber.ToString(), call_record.IsEndRecord(), call_record.UniqueID);

                    }
                }
                
                tbNames[call_record.Line].Text = call_record.Name;
                tbNumbers[call_record.Line].Text = call_record.PhoneNumber;
            }

            if (call_record.IsEndRecord())
            {
                AddToCallLog(call_record.Name, call_record.PhoneNumber, call_record.DateTime, call_record.Duration, call_record.Line, call_record.InboundOrOutboundOrBlock, call_record.RingNumber.ToString(), call_record.IsEndRecord(), call_record.UniqueID);

                CallLog.AddCall(call_record.Line.ToString(), call_record.StartOrEnd, call_record.InboundOrOutboundOrBlock, call_record.Duration.ToString().PadLeft(4, '0'), call_record.CheckSum,
                        call_record.RingNumber.ToString(), call_record.DateTime.ToString(), call_record.PhoneNumber, call_record.Name, call_record.UniqueID);
            }
        }

        private void AddToCallLog(string name, string number, DateTime datetime, int duration, int line, string io, string rings, bool is_end_record, string id)
        {

            if(id != "none")
            {
                int index = -1;
                int cnt = 0;
                foreach (DataGridViewRow call_row in dgvCallLog.Rows)
                {

                    if (call_row.Cells[DGV_LOG_ID].Value.ToString() == id)
                    {
                        index = cnt;
                        break;
                    }

                    cnt++;

                }

                if (index != -1)
                {

                    if (is_end_record)
                    {
                        dgvCallLog.Rows[index].Cells[DGV_LOG_DUR].Value = Common.ConvertDurationToTime(duration);
                        return;
                    }

                }
            }            

            if (dgvCallLog.Rows.Count < 1)
            {
                dgvCallLog.Rows.Add();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_NAME].Value = name;
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_NUMBER].Value = number;
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_DATE].Value = datetime.ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_DUR].Value = Common.ConvertDurationToTime(duration);
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_LINE].Value = line.ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_IO].Value = io;

                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].DefaultCellStyle.BackColor = io == "I" ? Program.C_INCOMING_CALL_BACKGROUND : Program.C_OUTGOING_CALL_BACKGROUND;
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].DefaultCellStyle.ForeColor = io == "I" ? Program.C_INCOMING_CALL_FOREGROUND : Program.C_OUTGOING_CALL_FOREGROUND;

                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_RINGS].Value = rings;
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_SORT_DATE].Value = datetime;
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_ID].Value = id;
                return;
            }

            DataGridViewRow row = (DataGridViewRow)dgvCallLog.Rows[0].Clone();
            row.Cells[DGV_LOG_NAME].Value = name;
            row.Cells[DGV_LOG_NUMBER].Value = number;
            row.Cells[DGV_LOG_DATE].Value = datetime.ToString();
            row.Cells[DGV_LOG_DUR].Value = Common.ConvertDurationToTime(duration);
            row.Cells[DGV_LOG_LINE].Value = line.ToString();
            row.Cells[DGV_LOG_IO].Value = io;

            row.DefaultCellStyle.BackColor = io == "I" ? Program.C_INCOMING_CALL_BACKGROUND : Program.C_OUTGOING_CALL_BACKGROUND;
            row.DefaultCellStyle.ForeColor = io == "I" ? Program.C_INCOMING_CALL_FOREGROUND : Program.C_OUTGOING_CALL_FOREGROUND;

            row.Cells[DGV_LOG_RINGS].Value = rings;
            row.Cells[DGV_LOG_SORT_DATE].Value = datetime;
            row.Cells[DGV_LOG_ID].Value = id;

            dgvCallLog.Rows.Insert(0, row);
            dgvCallLog.ClearSelection();
            dgvCallLog.Rows[0].Selected = true;


        }

        public void UnHideLines()
        {

            lbL5.Visible = true;
            lbL6.Visible = true;
            lbL7.Visible = true;
            lbL8.Visible = true;

            tbL5Name.Visible = true;
            tbL6Name.Visible = true;
            tbL7Name.Visible = true;
            tbL8Name.Visible = true;

            tbL5Number.Visible = true;
            tbL6Number.Visible = true;
            tbL7Number.Visible = true;
            tbL8Number.Visible = true;

            this.Size = new Size(835, 500);

        }

        public void CopyTextboxText(object sender, EventArgs e)
        {
            if(sender is TextBox)
            {
                TextBox tb = (TextBox)sender;
                if (string.IsNullOrEmpty(tb.Text)) return;
                Clipboard.SetText(tb.Text);
                string type = (tb.Name.ToLower().Contains("number")) ? "Number" : "Name";
                FrmTimerMsgBox msg = new FrmTimerMsgBox("Copied " + type, "Copied " + type + " to Clipboard.", 1000);
                msg.ShowDialog();
            }
        }

        private void PopulateCallLog()
        {
            dgvCallLog.Rows.Clear();

            DataTable calls_data = CallLog.GetCallLog((int)ndDisplayCount.Value);

            foreach (DataRow call in calls_data.Rows)
            {
                dgvCallLog.Rows.Add();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_NAME].Value = call["name"].ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_NUMBER].Value = call["number"].ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_DATE].Value = call["time"].ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_DUR].Value = Common.ConvertDurationToTime(int.Parse(call["dur"].ToString()));
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_LINE].Value = call["line"].ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_IO].Value = call["io"].ToString();

                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].DefaultCellStyle.BackColor = call["io"].ToString() == "I" ? Program.C_INCOMING_CALL_BACKGROUND : Program.C_OUTGOING_CALL_BACKGROUND;
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].DefaultCellStyle.ForeColor = call["io"].ToString() == "I" ? Program.C_INCOMING_CALL_FOREGROUND : Program.C_OUTGOING_CALL_FOREGROUND;

                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_RINGS].Value = call["rings"].ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_SORT_DATE].Value = DateTime.Parse(call["time"].ToString());
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_ID].Value = call["uid"].ToString();

            }

            dgvCallLog.ClearSelection();
        }

        private void ndDisplayCount_Leave(object sender, EventArgs e)
        {
            PopulateCallLog();
        }

        private void dgvCallLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int cell = e.ColumnIndex;

            if (row == -1 || cell == -1) return;

            FrmTimerMsgBox msg;
            switch (cell)
            {
                case DGV_LOG_NAME:

                    Clipboard.SetText(dgvCallLog.Rows[row].Cells[DGV_LOG_NAME].Value.ToString());

                    msg = new FrmTimerMsgBox("Copied Name", "Name copied to Clipboard.", 1000);
                    msg.ShowDialog();

                    break;

                case DGV_LOG_NUMBER:

                    Clipboard.SetText(dgvCallLog.Rows[row].Cells[DGV_LOG_NUMBER].Value.ToString());

                    msg = new FrmTimerMsgBox("Copied Number", "Number copied to Clipboard.", 1000);
                    msg.ShowDialog();

                    break;
            }

        }

        private bool DateSortAsc = true;
        private void dgvCallLog_MouseUp(object sender, MouseEventArgs e)
        {
            int row = dgvCallLog.HitTest(e.X, e.Y).RowIndex;
            int cell = dgvCallLog.HitTest(e.X, e.Y).ColumnIndex;

            if(cell == DGV_LOG_DATE && row == -1)
            {

                ListSortDirection sort = DateSortAsc ? ListSortDirection.Ascending : ListSortDirection.Descending;
                DateSortAsc = !DateSortAsc;
                dgvCallLog.Sort(dgvCallLogColSortDate, sort);

            }
        }
    }
}

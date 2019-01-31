using cid_cm.Classes;
using ELPopup5.Classes;
using System;
using System.Collections.Generic;
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


        // UPD Port
        public static UdpReceiverClass UdpReceiver = new UdpReceiverClass();
        readonly Thread _udpReceiveThread = new Thread(UdpReceiver.UdpIdleReceive);
        public List<string> previousReceptions = new List<string>();

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

            DataTable calls_data = CallLog.GetCallLog();

            foreach (DataRow call in calls_data.Rows)
            {
                dgvCallLog.Rows.Add();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_NAME].Value = call["name"].ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_NUMBER].Value = call["number"].ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_DATE].Value = call["time"].ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_DUR].Value = Common.ConvertDurationToTime(int.Parse(call["dur"].ToString()));
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_LINE].Value = call["line"].ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_IO].Value = call["io"].ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_RINGS].Value = call["rings"].ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_SORT_DATE].Value = DateTime.Parse(call["time"].ToString());

            }

            dgvCallLog.ClearSelection();

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

        private void RemovePreviousReceptionFromBuffer(string reception)
        {
            List<int> indexes = new List<int>();
            int cnt = 0;
            foreach (string rec in previousReceptions)
            {
                if (rec.Contains(reception.Substring(reception.Length - 20)))
                {
                    indexes.Add(cnt);
                }

                cnt++;

            }

            for (int i = indexes.Count - 1; i >= 0; i--)
            {
                previousReceptions.RemoveAt(indexes[i]);
            }

        }

        private void GetCall()
        {
            string reception = UdpReceiverClass.ReceivedMessage;

            if (previousReceptions.Contains(reception))
            {
                return;
            }
            else
            {
                if (previousReceptions.Count > 30)
                {
                    previousReceptions.Add(reception);
                    previousReceptions.RemoveAt(0);
                }
                else
                {
                    previousReceptions.Add(reception);
                }
            }

            // Parse up call
            CallRecord call_record = new CallRecord(UdpReceiverClass.ReceivedMessage);

            // If couldn't parse then skip call
            if (!call_record.IsValid) return;
                                    
            // Show popup
            if (call_record.IsStartRecord())
            {
                pController.AddPopup(call_record.Line, call_record.IsInbound(), call_record.PhoneNumber, call_record.Name);
            }
            else if (call_record.IsEndRecord())
            {

                RemovePreviousReceptionFromBuffer(reception);

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
                    tbNames[call_record.Line].BackColor = Color.Pink;
                    tbNumbers[call_record.Line].BackColor = Color.Pink;
                }
                else if(call_record.DetailedType == "F")
                {
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
                            tbNames[call_record.Line].BackColor = Color.LightGreen;
                            tbNumbers[call_record.Line].BackColor = Color.LightGreen;
                        }
                        else
                        {
                            tbNames[call_record.Line].BackColor = Color.LightBlue;
                            tbNumbers[call_record.Line].BackColor = Color.LightBlue;
                        }
                        

                    }
                }
                
                tbNames[call_record.Line].Text = call_record.Name;
                tbNumbers[call_record.Line].Text = call_record.PhoneNumber;
            }

            if (call_record.IsEndRecord())
            {
                AddToCallLog(call_record.Name, call_record.PhoneNumber, call_record.DateTime, call_record.Duration, call_record.Line, call_record.InboundOrOutboundOrBlock, call_record.RingNumber.ToString());

                CallLog.AddCall(call_record.Line.ToString(), call_record.StartOrEnd, call_record.InboundOrOutboundOrBlock, call_record.Duration.ToString().PadLeft(4, '0'), call_record.CheckSum,
                        call_record.RingNumber.ToString(), call_record.DateTime.ToString(), call_record.PhoneNumber, call_record.Name);
            }
        }

        private void AddToCallLog(string name, string number, DateTime datetime, int duration, int line, string io, string rings)
        {

            if (dgvCallLog.Rows.Count < 1)
            {
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_NAME].Value = name;
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_NUMBER].Value = number;
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_DATE].Value = datetime.ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_DUR].Value = Common.ConvertDurationToTime(duration);
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_LINE].Value = line.ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_IO].Value = io;
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_RINGS].Value = rings;
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_SORT_DATE].Value = datetime;
                return;
            }

            DataGridViewRow row = (DataGridViewRow)dgvCallLog.Rows[0].Clone();
            row.Cells[DGV_LOG_NAME].Value = name;
            row.Cells[DGV_LOG_NUMBER].Value = number;
            row.Cells[DGV_LOG_DATE].Value = datetime.ToString();
            row.Cells[DGV_LOG_DUR].Value = Common.ConvertDurationToTime(duration);
            row.Cells[DGV_LOG_LINE].Value = line.ToString();
            row.Cells[DGV_LOG_IO].Value = io;
            row.Cells[DGV_LOG_RINGS].Value = rings;
            row.Cells[DGV_LOG_SORT_DATE].Value = datetime;

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
    }
}

﻿using cid_cm.Classes;
using ELPopup5.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace ELPopup5
{
    public partial class FrmMain : Form
    {

        private const int DGV_LOG_DATE = 0;
        private const int DGV_LOG_NAME = 1;
        private const int DGV_LOG_NUMBER = 2;
        private const int DGV_LOG_DUR = 3;
        private const int DGV_LOG_LINE = 4;
        private const int DGV_LOG_IO = 5;
        private const int DGV_LOG_RINGS = 6;
        private const int DGV_LOG_SORT_DATE = 7;
        private const int DGV_LOG_ID = 8;

        private enum ConnectionType { Serial, UDP };
        private ConnectionType PreviousConnection = ConnectionType.UDP;

        // UPD Port
        public static UdpReceiverClass UdpReceiver;
        readonly Thread _udpReceiveThread;

        // Serial Port
        public static SerialPortReceiverClass SerialReceiver;

        // Controllers
        public PopupController pController = null;

        // Name and Number Textboxes
        private TextBox[] tbNumbers = new TextBox[14];
        private TextBox[] tbNames = new TextBox[14];
        private Label[] lbLines = new Label[14];

        private enum Lines { OneThroughFour, FiveThroughEight, EightThroughTwelve };

        NotifyIcon sys_tray_icon;
        private bool Kill = false;

        private List<string> PreviousReceptions = new List<string>();

        private void SysTrayMenuOpen_Clicked(object sender, EventArgs e)
        {
            this.Show();
            sys_tray_icon.Visible = false;
        }

        private void SysTrayMenuClose_Clicked(object sender, EventArgs e)
        {
            Kill = true;
            Close();
        }

        private void SysTrayMenuOptions_Clicked(object sender, EventArgs e)
        {
            FrmOptions fOptions = new FrmOptions();
            fOptions.ShowDialog();
        }

        public FrmMain()
        {
            InitializeComponent();

            if (Properties.Settings.Default.USE_CUSTOM_MAIN_WINDOW_SIZING)
            {
                Size = new Size(Properties.Settings.Default.MAIN_WINDOW_WIDTH, Properties.Settings.Default.MAIN_WINDOW_HEIGHT);
            }

            if (Properties.Settings.Default.USE_CUSTOM_POSITION)
            {
                Location = new Point(Properties.Settings.Default.MAIN_WINDOW_X, Properties.Settings.Default.MAIN_WINDOW_Y);
            }
            else
            {
                this.CenterToScreen();   
            }

            UdpReceiver = new UdpReceiverClass();
            _udpReceiveThread = new Thread(UdpReceiver.UdpIdleReceive);

            SerialReceiver = new SerialPortReceiverClass(Properties.Settings.Default.SS_COM_PORT);          

            sys_tray_icon = new NotifyIcon();
            sys_tray_icon.Icon = new Icon("phone.ico");

            ContextMenuStrip sys_tray_menu = new ContextMenuStrip();

            sys_tray_icon.DoubleClick += new EventHandler(SysTrayMenuOpen_Clicked);

            ToolStripMenuItem sys_tray_menu_open = new ToolStripMenuItem();
            sys_tray_menu_open.Text = "Main Window";
            sys_tray_menu_open.Click += new EventHandler(SysTrayMenuOpen_Clicked);
            sys_tray_menu.Items.Add(sys_tray_menu_open);

            ToolStripMenuItem sys_tray_menu_options = new ToolStripMenuItem();
            sys_tray_menu_options.Text = "Options";
            sys_tray_menu_options.Click += new EventHandler(SysTrayMenuOptions_Clicked);
            sys_tray_menu.Items.Add(sys_tray_menu_options);

            ToolStripMenuItem sys_tray_menu_close = new ToolStripMenuItem();
            sys_tray_menu_close.Text = "Close";
            sys_tray_menu_close.Click += new EventHandler(SysTrayMenuClose_Clicked);
            sys_tray_menu.Items.Add(sys_tray_menu_close);

            sys_tray_icon.ContextMenuStrip = sys_tray_menu;

            lbLines[1] = lbL1;
            lbLines[2] = lbL2;
            lbLines[3] = lbL3;
            lbLines[4] = lbL4;
            lbLines[5] = lbL5;
            lbLines[6] = lbL6;
            lbLines[7] = lbL7;
            lbLines[8] = lbL8;
            lbLines[9] = lbL9;
            lbLines[10] = lbL10;
            lbLines[11] = lbL11;
            lbLines[12] = lbL12;

            tbNumbers[1] = tbL1Number;
            tbNumbers[2] = tbL2Number;
            tbNumbers[3] = tbL3Number;
            tbNumbers[4] = tbL4Number;
            tbNumbers[5] = tbL5Number;
            tbNumbers[6] = tbL6Number;
            tbNumbers[7] = tbL7Number;
            tbNumbers[8] = tbL8Number;
            tbNumbers[9] = tbL9Number;
            tbNumbers[10] = tbL10Number;
            tbNumbers[11] = tbL11Number;
            tbNumbers[12] = tbL12Number;

            tbNames[1] = tbL1Name;
            tbNames[2] = tbL2Name;
            tbNames[3] = tbL3Name;
            tbNames[4] = tbL4Name;
            tbNames[5] = tbL5Name;
            tbNames[6] = tbL6Name;
            tbNames[7] = tbL7Name;
            tbNames[8] = tbL8Name;
            tbNames[9] = tbL9Name;
            tbNames[10] = tbL10Name;
            tbNames[11] = tbL11Name;
            tbNames[12] = tbL12Name;

            // Initialize popup controller
            pController = new PopupController();

            // Start listener for UDP traffic
            Subscribe(UdpReceiver);
            _udpReceiveThread.IsBackground = true;
            _udpReceiveThread.Start();

            // Start listener for SERIAL traffic
            SerialSubscribe(SerialReceiver);
            SerialReceiver.OpenCOMPort();

            PopulateCallLog();

            string serial_status = "Serial: Not Connected";
            if (SerialReceiver.GetPortName() != "None")
            {
                serial_status = "Serial Bound to Port: " + SerialReceiver.GetPortName();
            }

            Common.DrawColors(this, "ELPopup 5 - v." + Application.ProductVersion + "        UDP Listening on Port: " + UdpReceiverClass.BoundTo + "        " + serial_status);

        }

        public void SerialSubscribe(SerialPortReceiverClass s)
        {
            s.DataReceived += SerialReception;
        }

        public void SerialReception(SerialPortReceiverClass sender)
        {
            PreviousConnection = ConnectionType.Serial;
            Invoke((MethodInvoker)(ParseCall));
        }

        public void Subscribe(UdpReceiverClass u)
        {
            // If UDP event occurs run HeardIt method
            u.DataReceived += UDPReception;
        }

        private void UDPReception(UdpReceiverClass u, EventArgs e)
        {
            PreviousConnection = ConnectionType.UDP;
            Invoke((MethodInvoker)(ParseCall));

        }

        private bool PreviousPacketWasOutbound = false;
        private void ParseCall()
        {
            // Parse up call
            CallRecord call_record;

            if (PreviousConnection == ConnectionType.Serial)
            {
                call_record = new CallRecord(SerialPortReceiverClass.PreviousPacket);
            }
            else
            {
                call_record = new CallRecord(UdpReceiverClass.ReceivedMessage);
            }

            if (!call_record.IsValid) return;

            if (PreviousReceptions.Contains(call_record.Reception_String))
            {
                return;
            }

            PreviousReceptions.Add(call_record.Reception_String);

            timerClearPreviousReceptions.Enabled = true;
            timerClearPreviousReceptions.Stop();
            timerClearPreviousReceptions.Interval = 500;
            timerClearPreviousReceptions.Start();

            bool line_number_too_high = true;
            if (call_record.Line > 12)
            {
                line_number_too_high = false;
                lbHighLineNumber.Visible = true;
            }

            // Show popup
            if (call_record.IsStartRecord() && line_number_too_high)
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

            if (call_record.Line > 8)
            {
                UnHideLines(Lines.EightThroughTwelve);
            }
            else if(call_record.Line > 4)
            {
                UnHideLines(Lines.FiveThroughEight);
            }

            if (line_number_too_high)
            {
                if (!call_record.Detailed && call_record.IsStartRecord())
                {
                    AddToCallLog(call_record.Name, call_record.PhoneNumber, call_record.DateTime, call_record.Duration, call_record.Line, call_record.InboundOrOutboundOrBlock, call_record.RingNumber.ToString(), call_record.IsEndRecord(), call_record.UniqueID);
                }

                return;
            }
            
            if (call_record.Detailed)
            {
                if(call_record.DetailedType == "R")
                {
                    tbNames[call_record.Line].Text = "Ringing";
                    tbNumbers[call_record.Line].Text = "Ringing";

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
                    tbNames[call_record.Line].BackColor = Color.White;
                    tbNumbers[call_record.Line].BackColor = Color.White;
                }
            }
            else
            {
                if (call_record.IsEndRecord())
                {
                    tbNames[call_record.Line].BackColor = Color.White;
                    tbNumbers[call_record.Line].BackColor = Color.White;
                    
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
                        call_record.RingNumber.ToString(), call_record.DateTime, call_record.PhoneNumber, call_record.Name, call_record.UniqueID);
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
            
            if(datetime.Month==00 || datetime.Day == 00 || Properties.Settings.Default.USE_COMPUTER_TIME)
            {
                datetime = DateTime.Now;
            }

            if (dgvCallLog.Rows.Count < 1)
            {
                dgvCallLog.Rows.Add();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_NAME].Value = name;
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_NUMBER].Value = number;
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_DATE].Value = GetDateTimeWithoutSeconds(datetime);
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_DUR].Value = Common.ConvertDurationToTime(duration);
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_LINE].Value = line.ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_IO].Value = io;

                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].DefaultCellStyle.ForeColor = io == "I" ? Program.C_INCOMING_CALL_FOREGROUND : Program.C_OUTGOING_CALL_FOREGROUND;

                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_RINGS].Value = rings;
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_SORT_DATE].Value = datetime;
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_ID].Value = id;
                dgvCallLog.ClearSelection();
                return;
            }

            DataGridViewRow row = (DataGridViewRow)dgvCallLog.Rows[0].Clone();
            row.Cells[DGV_LOG_NAME].Value = name;
            row.Cells[DGV_LOG_NUMBER].Value = number;
            row.Cells[DGV_LOG_DATE].Value = GetDateTimeWithoutSeconds(datetime);
            row.Cells[DGV_LOG_DUR].Value = Common.ConvertDurationToTime(duration);
            row.Cells[DGV_LOG_LINE].Value = line.ToString();
            row.Cells[DGV_LOG_IO].Value = io;

            row.DefaultCellStyle.ForeColor = io == "I" ? Program.C_INCOMING_CALL_FOREGROUND : Program.C_OUTGOING_CALL_FOREGROUND;

            row.Cells[DGV_LOG_RINGS].Value = rings;
            row.Cells[DGV_LOG_SORT_DATE].Value = datetime;
            row.Cells[DGV_LOG_ID].Value = id;

            dgvCallLog.Rows.Insert(0, row);
            dgvCallLog.ClearSelection();


        }

        private void UnHideLines(Lines l, bool reset = false)
        {

            if (reset)
            {
                for (int i = 1; i < 13; i++)
                {
                    lbLines[i].Visible = false;
                    tbNames[i].Visible = false;
                    tbNumbers[i].Visible = false;
                }
            }

            if(l == Lines.OneThroughFour)
            {

                for(int i = 1; i < 5; i++)
                {
                    lbLines[i].Visible = true;
                    tbNames[i].Visible = true;
                    tbNumbers[i].Visible = true;
                }

                for (int i = 5; i < 13; i++)
                {
                    lbLines[i].Visible = false;
                    tbNames[i].Visible = false;
                    tbNumbers[i].Visible = false;
                }

                if (!Properties.Settings.Default.USE_CUSTOM_MAIN_WINDOW_SIZING)
                {
                    Size = new Size(777, 511);
                    Properties.Settings.Default.MAIN_WINDOW_WIDTH = 777;
                    Properties.Settings.Default.MAIN_WINDOW_HEIGHT = 511;
                }

                if (Properties.Settings.Default.MAX_LINE_NUMBER < 4)
                {
                    Properties.Settings.Default.MAX_LINE_NUMBER = 4;
                    Properties.Settings.Default.Save();
                }

            }
            else if(l == Lines.FiveThroughEight)
            {

                for (int i = 5; i < 9; i++)
                {
                    lbLines[i].Visible = true;
                    tbNames[i].Visible = true;
                    tbNumbers[i].Visible = true;
                }

                if (!Properties.Settings.Default.USE_CUSTOM_MAIN_WINDOW_SIZING)
                {
                    Size = new Size(790, 511);
                    Properties.Settings.Default.MAIN_WINDOW_WIDTH = 790;
                    Properties.Settings.Default.MAIN_WINDOW_HEIGHT = 511;
                }

                if (Properties.Settings.Default.MAX_LINE_NUMBER < 8)
                {
                    Properties.Settings.Default.MAX_LINE_NUMBER = 8;
                    Properties.Settings.Default.Save();
                }

            }
            else if(l == Lines.EightThroughTwelve)
            {

                for (int i = 1; i < 13; i++)
                {
                    lbLines[i].Visible = true;
                    tbNames[i].Visible = true;
                    tbNumbers[i].Visible = true;
                }

                if (!Properties.Settings.Default.USE_CUSTOM_MAIN_WINDOW_SIZING)
                {
                    Size = new Size(1171, 511);
                    Properties.Settings.Default.MAIN_WINDOW_WIDTH = 1171;
                    Properties.Settings.Default.MAIN_WINDOW_HEIGHT = 511;
                }

                if (Properties.Settings.Default.MAX_LINE_NUMBER < 12)
                {
                    Properties.Settings.Default.MAX_LINE_NUMBER = 12;
                    Properties.Settings.Default.Save();
                }

            }

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

        private string GetDateTimeWithoutSeconds(DateTime d)
        {

            string month = d.Month.ToString().PadLeft(2, '0');
            string day = d.Day.ToString().PadLeft(2, '0');
            string year = DateTime.Now.Year.ToString();
            int hrs = d.Hour;
            string mins = d.Minute.ToString().PadLeft(2, '0');

            string am_pm = "AM";
            string hours = "12";

            if(hrs == 12)
            {
                hours = "12";
                am_pm = "PM";
            }
            else if(hrs == 0)
            {
                hours = "12";
                am_pm = "AM";
            }
            else if(hrs > 12)
            {
                hours = (hrs - 12).ToString();
                am_pm = "PM";
            }
            else if(hrs < 12)
            {
                hours = hrs.ToString();
                am_pm = "AM";
            }


            return month + "/" + day + "/" + year + " " + hours + ":" + mins + " " + am_pm;


        }

        private void PopulateCallLog()
        {
            dgvCallLog.Rows.Clear();

            DataTable call_data;

            if (string.IsNullOrEmpty(cbSearch.Text))
            {
                call_data = CallLog.GetCallLog((int)ndDisplayCount.Value);
            }
            else
            {
                call_data = CallLog.FilterCallLog(cbSearch.Text, (int)ndDisplayCount.Value);
            }
            
            foreach (DataRow call in call_data.Rows)
            {

                DateTime the_date = Common.GetDateTimeFromSQLiteDate(call["time"].ToString());

                dgvCallLog.Rows.Add();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_NAME].Value = call["name"].ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_NUMBER].Value = call["number"].ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_DATE].Value = GetDateTimeWithoutSeconds(the_date);
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_DUR].Value = Common.ConvertDurationToTime(int.Parse(call["dur"].ToString()));
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_LINE].Value = call["line"].ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_IO].Value = call["io"].ToString();

                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].DefaultCellStyle.ForeColor = call["io"].ToString() == "I" ? Program.C_INCOMING_CALL_FOREGROUND : Program.C_OUTGOING_CALL_FOREGROUND;

                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_RINGS].Value = call["rings"].ToString();
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_SORT_DATE].Value = the_date;
                dgvCallLog.Rows[dgvCallLog.Rows.Count - 1].Cells[DGV_LOG_ID].Value = call["uid"].ToString();

            }

            dgvCallLog.ClearSelection();
                        
        }

        private void ndDisplayCount_Leave(object sender, EventArgs e)
        {
            PopulateCallLog();
        }
        
        private bool DateSortAsc = true;
        private int[] LastRowCell = new int[2] { 0, 0 };
        private void dgvCallLog_MouseUp(object sender, MouseEventArgs e)
        {
            int row = dgvCallLog.HitTest(e.X, e.Y).RowIndex;
            int cell = dgvCallLog.HitTest(e.X, e.Y).ColumnIndex;

            dgvCallLog.ClearSelection();

            if (cell == DGV_LOG_DATE && row == -1)
            {

                ListSortDirection sort = DateSortAsc ? ListSortDirection.Ascending : ListSortDirection.Descending;
                DateSortAsc = !DateSortAsc;
                dgvCallLog.Sort(dgvCallLogColSortDate, sort);

            }

            if (row == -1 || cell == -1 || e.Button != MouseButtons.Right) return;

            if (!(cell == DGV_LOG_NAME || cell == DGV_LOG_NUMBER)) return;

            LastRowCell = new int[2] { row, cell };

            ContextMenu copy_menu = new ContextMenu();
            MenuItem copy = new MenuItem("Copy");
            copy.Click += new EventHandler(CopyCallLogMenu);
            copy_menu.MenuItems.Add(copy);
            
            copy_menu.Show(dgvCallLog, new Point(e.X, e.Y));

        }
        
        private void CopyCallLogMenu(object sender, EventArgs e)
        {
            FrmTimerMsgBox msg;
            switch (LastRowCell[1])
            {
                case DGV_LOG_NUMBER:

                    Clipboard.SetText(dgvCallLog.Rows[LastRowCell[0]].Cells[LastRowCell[1]].Value.ToString());
                    msg = new FrmTimerMsgBox("Copied", "Copied Number to Clipboard.", 1000);
                    msg.ShowDialog();

                    break;

                case DGV_LOG_NAME:

                    Clipboard.SetText(dgvCallLog.Rows[LastRowCell[0]].Cells[LastRowCell[1]].Value.ToString());
                    msg = new FrmTimerMsgBox("Copied", "Copied Name to Clipboard.", 1000);
                    msg.ShowDialog();

                    break;

            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!Kill)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    sys_tray_icon.Visible = true;
                    this.Hide();
                    e.Cancel = true;
                }
            }
            else
            {
                sys_tray_icon.Visible = false;
            }

        }

        private void timerClearPreviousReceptions_Tick(object sender, EventArgs e)
        {
            PreviousReceptions.Clear();
            timerClearPreviousReceptions.Stop();
            timerClearPreviousReceptions.Enabled = false;
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            dgvCallLog.ClearSelection();

            if (Properties.Settings.Default.USE_CUSTOM_MAIN_WINDOW_SIZING)
            {
                Size = new Size(Properties.Settings.Default.MAIN_WINDOW_WIDTH, Properties.Settings.Default.MAIN_WINDOW_HEIGHT);
            }
            else
            {
                switch (Properties.Settings.Default.MAX_LINE_NUMBER)
                {
                    case 4:
                        UnHideLines(Lines.OneThroughFour, true);
                        break;
                    case 8:
                        UnHideLines(Lines.FiveThroughEight, true);
                        break;
                    case 12:
                        UnHideLines(Lines.EightThroughTwelve, true);
                        break;
                }
            }

            if (Properties.Settings.Default.USE_CUSTOM_POSITION)
            {
                Location = new Point(Properties.Settings.Default.MAIN_WINDOW_X, Properties.Settings.Default.MAIN_WINDOW_Y);
            }

        }

        private void lbClearLog_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all calls from Database?", "Clear?", MessageBoxButtons.YesNo) == DialogResult.No) return;
            CallLog.DeleteDatabase();
            dgvCallLog.Rows.Clear();
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCallLog();
        }

        private void timerUpdateBoundTo_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UdpReceiverClass.BoundTo))
            {

                string serial_status = "Serial: Not Connected";
                if (SerialReceiver.GetPortName() != "None")
                {
                    serial_status = "Serial Bound to Port: " + SerialReceiver.GetPortName();
                }

                Common.DrawColors(this, "ELPopup 5 - v." + Application.ProductVersion + "        UDP Listening on Port: " + UdpReceiverClass.BoundTo + "        " + serial_status);

                timerUpdateBoundTo.Stop();
                timerUpdateBoundTo.Enabled = false;
            }

        }

        private void cbSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateCallLog();
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.USE_CUSTOM_MAIN_WINDOW_SIZING = true;
            Properties.Settings.Default.MAIN_WINDOW_WIDTH = Size.Width;
            Properties.Settings.Default.MAIN_WINDOW_HEIGHT = Size.Height;
            Properties.Settings.Default.Save();
        }

        private void FrmMain_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.USE_CUSTOM_POSITION = true;
            Properties.Settings.Default.MAIN_WINDOW_X = Location.X;
            Properties.Settings.Default.MAIN_WINDOW_Y = Location.Y;
            Properties.Settings.Default.Save();
        }

        private void FrmMain_Activated(object sender, EventArgs e)
        {
            FrmMain_Shown(null, null);
        }
    }
}

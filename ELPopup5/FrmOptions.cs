using ELPopup5.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace ELPopup5
{
    public partial class FrmOptions : Form
    {
        private bool LoadingForm = true;
        private bool DO_NOT_UPDATE = false;

        public FrmOptions(bool do_not_initialize = false)
        {
            if (do_not_initialize)
            {
                DO_NOT_UPDATE = true;
                return;
            }

            LoadingForm = true;

            InitializeComponent();

            Common.DrawColors(this, "Options");
            lbCaptureTextFolder.ForeColor = Color.DarkRed;
            lbLoggingFileLocation.BackColor = Program.C_BACKGROUND;

            RefreshLogCount();

            if(Program.AppSettings["LOGGING_FILE"] != "none" && bool.Parse(Program.AppSettings["LOGGING"]))
            {
                lbLogStatus.Text = "Logging:";
                lbLogStatus.ForeColor = Color.Black;
                lbLoggingFileLocation.Text = Program.AppSettings["LOGGING_FILE"];
                btnStopLogging.Text = "Stop Logging";
                btnStopLogging.Visible = true;
            }
            else if (!bool.Parse(Program.AppSettings["LOGGING"]) && Program.AppSettings["LOGGING_FILE"] != "none")
            {
                lbLogStatus.Text = "Stopped:";
                lbLogStatus.ForeColor = Color.Red;
                lbLoggingFileLocation.Text = Program.AppSettings["LOGGING_FILE"];
                btnStopLogging.Text = "Resume Logging";
                btnStopLogging.Visible = true;
            }
            else
            {
                lbLogStatus.Text = "";
                lbLogStatus.ForeColor = Color.Black;
                lbLoggingFileLocation.Text = "Select Log File to Log Call Records";
                btnStopLogging.Text = "Stop Logging";
                btnStopLogging.Visible = false;
            }
            
            foreach(string port in Program.COM_PORTS)
            {
                cbCOMPorts.Items.Add(port);
            }

            int port_index = -1;
            int port_count = 0;

            foreach(string port in cbCOMPorts.Items)
            {
                if (port.Contains(Program.AppSettings["SS_COM_PORT"]))
                {
                    port_index = port_count;
                    break;
                }
                port_count++;
            }

            if (port_index != -1)
            {
                cbCOMPorts.SelectedIndex = port_index;
            }
            else
            {
                cbCOMPorts.SelectedIndex = 0;
            }

            ckbInboundCalls.Checked = bool.Parse(Program.AppSettings["POPUP_INBOUND"]);
            ckbOutboundCalls.Checked = bool.Parse(Program.AppSettings["POPUP_OUTBOUND"]);

            ndPopupTiming.Value = int.Parse(Program.AppSettings["POPUP_TIME"]);

            if (Program.AppSettings["RELAY_IP"].Contains("0.0.0.0"))
            {
                cbRelayIP.SelectedIndex = 0;
            }
            else if (Program.AppSettings["RELAY_IP"].Contains("255.255.255.255"))
            {
                cbRelayIP.SelectedIndex = 1;
            }
            else
            {
                cbRelayIP.Text = Program.AppSettings["RELAY_IP"];
            }

            ckbStartInSystemTray.Checked = !bool.Parse(Program.AppSettings["START_MINIMIZED"]);

            if(Program.AppSettings["CAPTURING_LINE_FILES"] != "none")
            {
                ckbCapturingLineTextFiles.Checked = true;
                lbCaptureTextFolder.Text = "Folder: " + Program.AppSettings["CAPTURING_LINE_FILES"];
            }
            else
            {
                ckbCapturingLineTextFiles.Checked = false;
                lbCaptureTextFolder.Text = "Folder: None";
            }

            LoadingForm = false;

        }

        private void cbCOMPorts_SelectedIndexChanged(object sender, EventArgs e)
        {

            Program.AppSettings["SS_COM_PORT"] = Program.COM_PORTS[cbCOMPorts.SelectedIndex].Replace(" (Unit Detected)", "").Replace(" (Another app using COM Port)","");
            Common.SaveSettings();
            
            if(Program.AppSettings["SS_COM_PORT"] == "None")
            {
                FrmMain.SerialReceiver.CloseCOMPort();
                lbSerialServerConnection.Text = "Serial Server: Not Connected";
                lbSerialStatus.Text = "Serial Relay: OFF";
                return;
            }

            lbSerialServerConnection.Text = "Serial Server: Connected to " + FrmMain.SerialReceiver.GetPortName();

            bool relaying = !cbRelayIP.Text.ToLower().Contains("0.0.0.0") || Program.AppSettings["RELAY_IP"].ToLower().Contains("0.0.0.0");

            if (relaying)
            {
                lbSerialStatus.Text = "Serial Relay: ON";
            }
            else
            {
                lbSerialStatus.Text = "Serial Relay: Capture Only";
            }

            if (LoadingForm) return;

            FrmMain.SerialReceiver.ChangePort(Program.AppSettings["SS_COM_PORT"]);
            lbSerialServerConnection.Text = "Serial Server: Connected to " + FrmMain.SerialReceiver.GetPortName();

            if (Program.COM_PORT_BIND_FAILED)
            {
                lbSerialServerConnection.Text = "Serial Server: Failed. Port already in use.";
                lbSerialStatus.Text = "Serial Relay: OFF";
            }
        }

        private void ndPopupTiming_Leave(object sender, EventArgs e)
        {
            SaveAllSettings();
        }

        private void SaveAllSettings()
        {
            Program.AppSettings["SS_COM_PORT"] = cbCOMPorts.Text;
            Program.AppSettings["POPUP_TIME"] = ndPopupTiming.Value.ToString();
            Program.AppSettings["POPUP_INBOUND"] = ckbInboundCalls.Checked ? "True" : "False";
            Program.AppSettings["POPUP_OUTBOUND"] = ckbOutboundCalls.Checked ? "True" : "False";
            Program.AppSettings["USE_COMPUTER_TIME"] = ckbUseComputerTime.Checked ? "True" : "False";
            Common.SaveSettings();
        }

        private void FrmOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAllSettings();
        }

        private void ckbInboundCalls_CheckedChanged(object sender, EventArgs e)
        {
            SaveAllSettings();
        }

        private void ckbOutboundCalls_CheckedChanged(object sender, EventArgs e)
        {
            SaveAllSettings();
        }

        private void ckbUseComputerTime_CheckedChanged(object sender, EventArgs e)
        {
            SaveAllSettings();
        }

        private void btnResetScreenSize_Click(object sender, EventArgs e)
        {
            Program.AppSettings["USE_CUSTOM_MAIN_WINDOW_SIZING"] = "False";
            Program.AppSettings["MAX_LINE_NUMBER"] = "-1";
            Common.SaveSettings();
            Program.fMain.Has_Activated = false;
            Program.fMain.RefreshWindow();
        }

        private void cbRelayIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.AppSettings["RELAY_IP"] = cbRelayIP.Text;
            
            if(cbRelayIP.Text.ToLower().Contains("do not relay data"))
            {
                Program.AppSettings["RELAY_IP"] = "0.0.0.0";
            }
            else if (cbRelayIP.Text.ToLower().Contains("255.255.255.255"))
            {
                Program.AppSettings["RELAY_IP"] = "255.255.255.255";
            }
            else
            {
                Program.AppSettings["RELAY_IP"] = cbRelayIP.Text;
            }

            Common.SaveSettings();
        }

        private void cbRelayIP_TextChanged(object sender, EventArgs e)
        {
            Program.AppSettings["RELAY_IP"] = cbRelayIP.Text;
            Common.SaveSettings();
        }

        private void btnResetLineDisplay_Click(object sender, EventArgs e)
        {
            Program.AppSettings["MAX_LINE_NUMBER"] = "-1";
            Common.SaveSettings();
            Program.fMain.Has_Activated = false;
            Program.fMain.RefreshWindow();
        }

        private void ndRecordCount_ValueChanged(object sender, EventArgs e)
        {
            btnExportRecords.Text = "Export Last " + ((int)ndRecordCount.Value).ToString() + " Records to CSV file";
        }

        private void btnSelectLoggingFile_Click(object sender, EventArgs e)
        {
            sfdLoggingFile.DefaultExt = ".txt";
            sfdLoggingFile.Filter = "Text Files|*.txt";
            sfdLoggingFile.FileName = "CallerID_Log";

            DialogResult r = sfdLoggingFile.ShowDialog();

            if(r!= DialogResult.Cancel && r!= DialogResult.Abort && r != DialogResult.None)
            {
                Program.AppSettings["LOGGING_FILE"] = sfdLoggingFile.FileName;
                Program.AppSettings["LOGGING"] = "True";
                Common.SaveSettings();

                lbLogStatus.Text = "Logging";
                lbLoggingFileLocation.Text = Program.AppSettings["LOGGING_FILE"];
                btnStopLogging.Visible = true;

            }
        }

        public void RefreshLogCount()
        {
            int log_records = CallLog.GetCallLog(999999999).Rows.Count;
            lbTotalLogCount.Text = "Total of: " + log_records + " records in log";
        }

        private void lbStopLogging_Click(object sender, EventArgs e)
        {

            if(btnStopLogging.Text != "Resume Logging" && Program.AppSettings["LOGGING_FILE"] != "none")
            {
                btnStopLogging.Text = "Resume Logging";

                lbLogStatus.Text = "Stopped:";
                lbLogStatus.ForeColor = Color.Red;

                Program.AppSettings["LOGGING"] = "False";
                Common.SaveSettings();
            }
            else
            {
                btnStopLogging.Text = "Stop Logging";

                lbLogStatus.Text = "Logging:";
                lbLogStatus.ForeColor = Color.Black;

                Program.AppSettings["LOGGING"] = "True";
                Common.SaveSettings();
            }
        }

        private void btnExportRecords_Click(object sender, EventArgs e)
        {

            int records_to_export = (int)ndRecordCount.Value;

            DataTable records = CallLog.GetCallLog(records_to_export);

            string export_string = "Date And Time,Number,Name,Duration,Line,IO,Rings" + Environment.NewLine;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "Call_Log";
            sfd.Filter = "Comma Seperated File|*.csv";

            DialogResult r = sfd.ShowDialog();

            if (r != DialogResult.Cancel && r != DialogResult.Abort && r != DialogResult.None)
            {
                FrmTimerMsgBox fExporting = new FrmTimerMsgBox("Exporting", "Please wait...", 60000 * 10, true);
                fExporting.Show();

                if (File.Exists(sfd.FileName))
                {
                    File.Delete(sfd.FileName);
                }

                foreach (DataRow record in records.Rows)
                {
                    Application.DoEvents();
                    DateTime the_date = Common.GetDateTimeFromSQLiteDate(record["time"].ToString());

                    // Export into CVS file format
                    export_string += Common.FormatDateToExportCSVFormat(the_date) + ",";
                    export_string += record["number"].ToString() + ",";
                    export_string += "\"" + Common.GetUnsafeSqlString(record["name"].ToString()) + "\",";
                    export_string += "\"" + Common.ConvertDurationToTime(int.Parse(record["dur"].ToString())).Replace(":", ".") + "\",";
                    export_string += record["line"].ToString() + ",";
                    export_string += record["io"].ToString() + ",";
                    export_string += record["rings"].ToString();

                    export_string += Environment.NewLine;

                }

                File.WriteAllText(sfd.FileName, export_string);

                if (fExporting.Visible) fExporting.Close();
            }

        }

        private void btnImportOldDatabase_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\CallerID.com\ELPopup\"))
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\CallerID.com\ELPopup\";

                DialogResult r = ofd.ShowDialog();

                if (r != DialogResult.OK && r != DialogResult.Yes) return;

                string filename = ofd.FileName;

                ImportOldDatabase(filename);
            }
            else
            {
                FrmTimerMsgBox msg = new FrmTimerMsgBox("No Old Database", "Could not find old ELPopup database.", 1500);
                msg.ShowDialog();
            }
            
        }

        public void ImportOldDatabase(string filename)
        {

            if (!File.Exists(filename)) return;

            DataTable imported_call_log = CallLog.GetCallLog(999999999, filename);

            FrmTimerMsgBox msg = new FrmTimerMsgBox("Importing Call Log", "Importing", 500000, true);
            msg.Show();
            foreach(DataRow call in imported_call_log.Rows)
            {
                Application.DoEvents();
                string date_string = call["time"].ToString();
                DateTime date = DateTime.ParseExact(date_string, "yyyyMMddHHmmss", null);
                CallLog.AddCall(call["line"].ToString(), call["type"].ToString(), call["io"].ToString(), call["dur"].ToString(), call["checksum"].ToString(), call["rings"].ToString(), date, call["number"].ToString(), call["name"].ToString(), call["uid"].ToString());

            }

            if (msg.Visible) msg.Close();

            if(!DO_NOT_UPDATE) Program.fMain.RefreshCallLog();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            File.Move(filename, filename.Replace(".db3", "-imported-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + ".db3"));
                        
        }

        private void ckbStartInSystemTray_CheckedChanged(object sender, EventArgs e)
        {
            Program.AppSettings["START_MINIMIZED"] = (!ckbStartInSystemTray.Checked) ? "True" : "False";
            Common.SaveSettings();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {

            DialogResult result = Common.MessageBox("Clear All Call Records", "Are you sure you want to Delete All Call Records?", true, DialogResult.Cancel, true, DialogResult.Yes, false, DialogResult.None, "Cancel", "Yes", "", 1);

            if (result == DialogResult.Cancel) return;
            
            CallLog.DeleteDatabase();

            Program.fMain.Has_Activated = false;
            Program.fMain.RefreshWindow();

        }

        private void btnRefreshSerialList_Click(object sender, EventArgs e)
        {
            Program.COM_PORTS.Clear();
            cbCOMPorts.Items.Clear();
            FrmMain.SerialReceiver.CloseCOMPort();
            Program.fMain.SerialReadIn = "";

            Program.COM_PORTS.Add("None");
            string[] com_ports = SerialPort.GetPortNames();
            string found_port_name = "";

            FrmTimerMsgBox fPleaseWait = new FrmTimerMsgBox("Searching COM Ports", "Searching COM Ports. Please wait...", 100000);
            fPleaseWait.Show();

            foreach (string port_name in com_ports)
            {
                Program.fMain.PortScan = new SerialPort(port_name, 9600, Parity.None, 8, StopBits.One);
                string found_text = "";

                try
                {
                    Program.fMain.PortScan.DataReceived += new SerialDataReceivedEventHandler(Program.fMain.PortTest);
                    Program.fMain.PortScan.Open();
                    Program.fMain.PortScan.Write("@");
                    Program.fMain.PortScan.ReadTimeout = 900;
                    Common.WaitFor(1000);
                    if (Program.fMain.SerialReadIn == "#")
                    {
                        found_port_name = port_name;
                        found_text = " (Unit Detected)";
                    }
                    Program.fMain.PortScan.Close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    found_text = " (Another app using COM Port)";
                }

                Program.COM_PORTS.Add(port_name + found_text);

            }

            if (fPleaseWait.Visible) fPleaseWait.Close();

            if (found_port_name != "" && found_port_name != "None")
            {
                Program.AppSettings["SS_COM_PORT"] = found_port_name;
                Common.SaveSettings();
            }

            foreach (string port in Program.COM_PORTS)
            {
                cbCOMPorts.Items.Add(port);
            }

            int port_index = -1;
            int port_count = 0;

            foreach (string port in cbCOMPorts.Items)
            {
                if (port.Contains(Program.AppSettings["SS_COM_PORT"]))
                {
                    port_index = port_count;
                    break;
                }
                port_count++;
            }

            if (port_index != -1)
            {
                cbCOMPorts.SelectedIndex = port_index;
            }
            else
            {
                cbCOMPorts.SelectedIndex = 0;
            }

        }

        private void tcTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcTabs.SelectedTab.Name.ToLower().Contains("serial"))
            {
                btnRefreshSerialList_Click(null, null);
            }
        }

        private void picHelpSerialServer_Click(object sender, EventArgs e)
        {
            Common.OpenManual(4);
        }

        private void picHelpGeneral_Click(object sender, EventArgs e)
        {
            Common.OpenManual(4);
        }

        private void picHelpCallRecords_Click(object sender, EventArgs e)
        {
            Common.OpenManual(5);
        }

        private void picHelpMisc_Click(object sender, EventArgs e)
        {
            Common.OpenManual(5);
        }

        private bool SkipCheckingOfTextFile = false;
        private void ckbCapturingLineTextFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (LoadingForm) return;

            if (SkipCheckingOfTextFile)
            {
                SkipCheckingOfTextFile = false;
                return;
            }

            if (ckbCapturingLineTextFiles.Checked)
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                    {
                        string dir = fbd.SelectedPath;
                        Program.AppSettings["CAPTURING_LINE_FILES"] = dir;
                        lbCaptureTextFolder.Text = "Folder: " + dir;
                        Common.SaveSettings();
                    }
                    else
                    {
                        SkipCheckingOfTextFile = true;
                        ckbCapturingLineTextFiles.Checked = false;
                    }
                }

            }
            else
            {
                DialogResult r = Common.MessageBox("Stop Writing to Text Files", "Stop writing text files?" + Environment.NewLine + "Your Caller ID application may depend on this.", true, DialogResult.Yes, true, DialogResult.No, false, DialogResult.None, "Yes", "No", "", 2);

                if (r == DialogResult.No)
                {
                    SkipCheckingOfTextFile = true;
                    ckbCapturingLineTextFiles.Checked = true;
                    return;
                }

                Program.AppSettings["CAPTURING_LINE_FILES"] = "none";
                lbCaptureTextFolder.Text = "Folder: None";
                Common.SaveSettings();

            }

        }
    }
}

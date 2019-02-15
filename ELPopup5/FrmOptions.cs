using ELPopup5.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ELPopup5
{
    public partial class FrmOptions : Form
    {
        public FrmOptions()
        {
            InitializeComponent();
            Common.DrawColors(this, "Options");

            string[] com_ports = SerialPort.GetPortNames();

            cbCOMPorts.Items.Add("None");
            
            foreach(string com_port in com_ports)
            {
                cbCOMPorts.Items.Add(com_port);
            }

            if (cbCOMPorts.Items.Contains(Properties.Settings.Default.SS_COM_PORT))
            {
                cbCOMPorts.SelectedItem = Properties.Settings.Default.SS_COM_PORT;
            }

            ndPopupTiming.Value = Properties.Settings.Default.POPUP_TIME;

        }

        private void cbCOMPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SS_COM_PORT = cbCOMPorts.SelectedItem.ToString();
            Properties.Settings.Default.Save();
            
            if(Properties.Settings.Default.SS_COM_PORT == "None")
            {
                FrmMain.SerialReceiver.CloseCOMPort();
                lbSerialServerConnection.Text = "Serial Server: Not Connected";
                lbSerialStatus.Text = "Serial Relay: OFF";
                return;
            }

            FrmMain.SerialReceiver.ChangePort(Properties.Settings.Default.SS_COM_PORT);

            lbSerialServerConnection.Text = "Serial Server: Connected to " + FrmMain.SerialReceiver.GetPortName();
            lbSerialStatus.Text = "Serial Relay: ON";
        }

        private void ndPopupTiming_Leave(object sender, EventArgs e)
        {
            SaveAllSettings();
        }

        private void SaveAllSettings()
        {
            Properties.Settings.Default.SS_COM_PORT = cbCOMPorts.Text;
            Properties.Settings.Default.POPUP_TIME = (int)ndPopupTiming.Value;
            Properties.Settings.Default.POPUP_INBOUND = ckbInboundCalls.Checked;
            Properties.Settings.Default.POPUP_OUTBOUND = ckbOutboundCalls.Checked;
            Properties.Settings.Default.USE_COMPUTER_TIME = ckbUseComputerTime.Checked;
            Properties.Settings.Default.Save();
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
            Properties.Settings.Default.USE_CUSTOM_MAIN_WINDOW_SIZING = false;
            Properties.Settings.Default.MAX_LINE_NUMBER = 4;
            Properties.Settings.Default.Save();
        }
    }
}

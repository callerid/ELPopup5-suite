using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace ELPopup5.Classes
{
    
    public class SerialPortReceiverClass
    {

        private SerialPort COM_PORT = null;
        private string PORT_NAME = "None";

        public static string PreviousPacket = ""; 

        public delegate void SerialHandler(SerialPortReceiverClass handler);
        public event SerialHandler DataReceived;

        public SerialPortReceiverClass(string port_name)
        {
            if (port_name == "None" || string.IsNullOrEmpty(port_name))
            {
                COM_PORT = new SerialPort();
                return;
            }

            PORT_NAME = port_name.Replace(" (Unit Detected)", "");
            COM_PORT = new SerialPort(PORT_NAME, 9600, Parity.None, 8, StopBits.One);
            OpenCOMPort();
        }
        
        public void ReadCOMPort(object sender, SerialDataReceivedEventArgs e)
        {
            PreviousPacket = COM_PORT.ReadLine();
            DataReceived(this);
        }

        public void ChangePort(string port_name)
        {
            CloseCOMPort();

            if(port_name == "None")
            {
                COM_PORT = new SerialPort();
                return;
            }

            PORT_NAME = port_name.Replace(" (Unit Detected)", "");
            COM_PORT = new SerialPort(PORT_NAME, 9600, Parity.None, 8, StopBits.One);

            OpenCOMPort();

        }

        public void OpenCOMPort()
        {
            if (COM_PORT.IsOpen)
            {
                COM_PORT.Close();
            }

            try
            {
                COM_PORT.Open();
                COM_PORT.DataReceived += ReadCOMPort;
                Program.COM_PORT_BIND_FAILED = false;
            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
                
                if (!Program.COM_PORT_BIND_FAILED)
                {
                    Program.COM_PORT_BIND_FAILED = true;
                    PORT_NAME = PORT_NAME + " in use";
                    FrmTimerMsgBox msg = new FrmTimerMsgBox("COM PORT FAILED TO BIND", "Program already bound to ELPopup's selected COM port.", 4000);
                    msg.ShowDialog();
                }

                if (COM_PORT.IsOpen)
                {
                    COM_PORT.Close();
                }

            }
            
        }

        public void CloseCOMPort()
        {
            if (COM_PORT.IsOpen)
            {
                COM_PORT.Close();
            }

            COM_PORT = new SerialPort();
        }

        public void WriteToCOMPort(string send_this)
        {
            if (!COM_PORT.IsOpen)
            {
                OpenCOMPort();
            }

            byte[] to_send = Encoding.UTF8.GetBytes(send_this);
            COM_PORT.Write(to_send, 0, to_send.Length);

        }

        public string GetPortName()
        {
            return PORT_NAME;
        }

    }
}

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
            if (port_name == "None")
            {
                COM_PORT = new SerialPort();
                return;
            }

            PORT_NAME = port_name;
            COM_PORT = new SerialPort(port_name, 9600, Parity.None, 8, StopBits.One);
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

            PORT_NAME = port_name;
            COM_PORT = new SerialPort(port_name, 9600, Parity.None, 8, StopBits.One);

            OpenCOMPort();

        }

        public void OpenCOMPort()
        {
            if (COM_PORT.IsOpen)
            {
                COM_PORT.Close();
            }

            COM_PORT.Open();
            COM_PORT.DataReceived += ReadCOMPort;
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

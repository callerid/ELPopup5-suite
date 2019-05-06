using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ELPopup5.Classes
{
    public class UdpReceiverClass
    {
        // Declare variables
        public static Boolean Done;
        public static string ReceivedMessage;
        public static byte[] ReceviedMessageByte;
        public static string BoundTo = "";

        // Define event
        public delegate void UdpEventHandler(UdpReceiverClass u, EventArgs e);
        public event UdpEventHandler DataReceived;

        public static void SendUDP(string send_string, string ip, int port)
        {
            if (ip == "0.0.0.0") return;

            bool valid_ip = true;

            try
            {
                IPAddress temp = IPAddress.Parse(ip);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                valid_ip = false;
            }

            if (!valid_ip) return;

            byte[] to_send = Encoding.ASCII.GetBytes(send_string);

            UdpClient udp_sender = new UdpClient();

            udp_sender.Connect(new IPEndPoint(IPAddress.Parse(ip), port));

            udp_sender.Send(to_send, to_send.Length);

            udp_sender.Close();

        }

        // Idle listening
        public void UdpIdleReceive()
        {

            // Set done to false so loop will begin
            Done = false;

            // Setup filter for too small messages
            const int filterMessageSmallerThan = 4;

            // Setup socket for listening
            UdpClient listener = null;
            IPEndPoint groupEp = null;

            bool bound = false;
            int[] udp_ports = new int[] { 3520, 6699, 3521, 3522, 3523, 3524, 3525, 3526, 3527, 3528, 3529 };
            int index = 0;

            bool monitoring = true;

            while (monitoring)
            {

                while (index < udp_ports.Length && !bound)
                {
                    try
                    {
                        listener = new UdpClient(udp_ports[index]);
                        groupEp = new IPEndPoint(IPAddress.Any, udp_ports[index]);
                        bound = true;
                        BoundTo = udp_ports[index].ToString();
                        Console.WriteLine("Bound to: " + BoundTo);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        bound = false;
                        index++;
                    }
                }

                if (!bound)
                {
                    var erString = "Binding to ports 3520-3529 or 6699 failed.";
                    MessageBox.Show(erString);
                    return;
                }

                // Wait for broadcast
                try
                {
                    while (!Done)
                    {
                        // Receive broadcast
                        ReceviedMessageByte = listener.Receive(ref groupEp);
                        ReceivedMessage = Encoding.UTF7.GetString(ReceviedMessageByte, 0, ReceviedMessageByte.Length);

                        // Filter smaller messages););
                        if (ReceviedMessageByte.Length > filterMessageSmallerThan)
                        {
                            DataReceived(this, EventArgs.Empty);
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                    if (!Directory.Exists(Program.ErrorLogFile.Replace("error_log.dat", "")))
                    {
                        Directory.CreateDirectory(Program.ErrorLogFile.Replace("error_log.dat", ""));
                    }

                    File.WriteAllText(Program.ErrorLogFile, ex.ToString() + Environment.NewLine);

                }

                listener.Close();

            }

        }

    }
}

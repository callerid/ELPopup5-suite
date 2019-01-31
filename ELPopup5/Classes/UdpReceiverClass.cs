using System;
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
        public static int[] NListenPorts = new int[] { 3520 };
        public static string BoundTo;

        // Define event
        public delegate void UdpEventHandler(UdpReceiverClass u, EventArgs e);
        public event UdpEventHandler DataReceived;

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
            try
            {
                listener = new UdpClient(3520);
                groupEp = new IPEndPoint(IPAddress.Any, 3520);
                bound = true;
                BoundTo = "3520";
            }
            catch (Exception ex)
            {
                bound = false;
                Console.Write("Failed to bind: " + ex.ToString());
            }

            if (!bound)
            {
                var erString = "Binding to ports 3520 failed. Closing...";
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
            }

            listener.Close();
        }

    }
}

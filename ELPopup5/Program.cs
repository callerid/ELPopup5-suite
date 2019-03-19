using ELPopup5.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace ELPopup5
{
    static class Program
    {
        
        // Forms
        public static FrmMain fMain = null;
        public static FrmOptions fOptions = null;
        public static FrmManual fManual = null;

        // File paths
        public static string ConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CallerID.com\ELPopup5\config.dat";

        // Colors
        public static Color C_BACKGROUND = Color.FromArgb(214, 225, 235);
        public static Color C_TEXT = Color.Black;
        public static Color C_INCOMING_CALL_BACKGROUND = Color.WhiteSmoke;
        public static Color C_INCOMING_CALL_FOREGROUND = Color.FromArgb(31, 152, 41);

        public static Color C_OUTGOING_CALL_BACKGROUND = Color.WhiteSmoke;
        public static Color C_OUTGOING_CALL_FOREGROUND = Color.FromArgb(41, 122, 163);

        public static Color C_CALL_FINISHED_BACKGROUND = Color.FromArgb(227, 227, 227);

        public static bool COM_PORT_BIND_FAILED = false;

        public static List<string> COM_PORTS = new List<string>();

        [STAThread]
        static void Main()
        {

            // Load properties
            Common.LoadSettings();

            // Create Database if needed
            CallLog.CreateDatabase();

            bool exists = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1;

            if (exists)
            {
                FrmTimerMsgBox msg = new FrmTimerMsgBox("App Already Opened", "ELPoup 5 Already Running", 4000);
                msg.ShowDialog();
                Application.Exit();
                return;
            }

            // Setup styles and rendering
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create main form
            fMain = new FrmMain();

            // Launch main form
            if (Properties.Settings.Default.START_MINIMIZED)
            {
                Application.Run();
            }
            else
            {
                Application.Run(fMain);
            }

        }
    }
}

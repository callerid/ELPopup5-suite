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
        public static string ErrorLogFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CallerID.com\ELPopup5\error_log.dat";

        // Config settings
        public static Dictionary<int, string> AppSettings = new Dictionary<int, string>();
        
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

        public enum AppSetting
        {

            POPUP_INBOUND,
            POPUP_TIME,
            RELAY_IP,
            LOGGING_FILE,
            MAIN_WINDOW_Y,
            START_MINIMIZED,
            CAPTURING_LINE_FILES,
            DISPLAY_RECORD_COUNT,
            USE_CUSTOM_MAIN_WINDOW_SIZING,
            POPUP_OUTBOUND,
            MAIN_WINDOW_HEIGHT,
            MAX_LINE_NUMBER,
            LOGGING,
            MAIN_WINDOW_WIDTH,
            USE_COMPUTER_TIME,
            USE_CUSTOM_POSITION,
            SS_COM_PORT,
            MAIN_WINDOW_X
        }

        [STAThread]
        static void Main()
        {

            Common.InitializeSettings();

            // Load properties
            Common.LoadSettings();

            // Create Database if needed
            CallLog.CreateDatabase();

            bool exists = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1;

            if (exists)
            {
                FrmTimerMsgBox msg = new FrmTimerMsgBox("App Already Opened", "ELPoup 5 Already Running in System Tray", 4000);
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
            Application.Run(fMain);            

        }
    }
}

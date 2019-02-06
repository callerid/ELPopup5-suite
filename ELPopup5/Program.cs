using ELPopup5.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ELPopup5
{
    static class Program
    {
        
        // Forms
        public static FrmMain fMain = null;

        // Colors
        public static Color C_BACKGROUND = Color.FromArgb(214, 225, 235);
        public static Color C_TEXT = Color.FromArgb(74, 92, 109);
        public static Color C_INCOMING_CALL_BACKGROUND = Color.FromArgb(169, 213, 173);
        public static Color C_INCOMING_CALL_FOREGROUND = Color.FromArgb(43, 89, 47);

        public static Color C_OUTGOING_CALL_BACKGROUND = Color.FromArgb(169, 187, 213);
        public static Color C_OUTGOING_CALL_FOREGROUND = Color.FromArgb(43, 74, 89);


        [STAThread]
        static void Main()
        {
            // Create Database if needed
            CallLog.CreateDatabase();

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

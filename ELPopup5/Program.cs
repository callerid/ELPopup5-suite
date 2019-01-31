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

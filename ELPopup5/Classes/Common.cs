using System;
using System.Drawing;
using System.Windows.Forms;

namespace ELPopup5.Classes
{
    class Common
    {

        public static void DrawColors(Form f, string title)
        {
            f.Text = title;

            f.BackColor = Program.C_BACKGROUND;
            f.ForeColor = Program.C_TEXT;

            foreach(Control c in f.Controls)
            {

                if(c is TextBox)
                {
                    c.BackColor = Program.C_BACKGROUND;
                    c.ForeColor = Program.C_TEXT;
                }

                if(c is DataGridView)
                {
                    DataGridView dgv = (DataGridView)c;
                    dgv.BackgroundColor = Program.C_BACKGROUND;
                    dgv.DefaultCellStyle.SelectionBackColor = Program.C_TEXT;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                }

            }

        }

        public static Control FindFocusedControl(Control control)
        {
            var container = control as IContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as IContainerControl;
            }
            return control;
        }

        public static string ConvertDurationToTime(int duration)
        {

            string dur = "";

            TimeSpan d = new TimeSpan(0, 0, duration);

            int hours = d.Hours;
            int minutes = d.Minutes;

            if (hours > 0) dur += hours.ToString().PadLeft(2, '0') + ":";
            dur += minutes.ToString().PadLeft(2, '0') + ":";
            string sec = d.Seconds.ToString().PadLeft(2, '0');
            dur += sec;

            return dur;

        }

    }
}

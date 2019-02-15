using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Text;
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

                if(c is TabControl)
                {
                    TabControl tc = (TabControl)c;
                    foreach(TabPage tab in tc.TabPages)
                    {
                        tab.BackColor = Program.C_BACKGROUND;
                        tab.ForeColor = Program.C_TEXT;
                    }
                }

                if(c is TextBox)
                {
                    if (c.Name == "tbMsg")
                    {
                        c.BackColor = Program.C_BACKGROUND;
                        c.ForeColor = Program.C_TEXT;
                        continue;
                    }
                    c.BackColor = Color.White;
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

        public static string GetSQLiteDateFromDateTime(DateTime d)
        {
            return d.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }

        public static DateTime GetDateTimeFromSQLiteDate(string d)
        {
            return DateTime.ParseExact(d, "yyyy-MM-dd HH:mm:ss.fff", null);
        }

        public static DateTime MakeSimpleDate(DateTime d)
        {
            string new_date = d.Year.ToString() + "-" + d.Month.ToString().PadLeft(2, '0') + "-" + d.Day.ToString().PadLeft(2, '0') + " 01:00:00.000";
            return DateTime.ParseExact(new_date, "yyyy-MM-dd HH:mm:ss.fff", null);
        }

    }
}

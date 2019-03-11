using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
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
                        tab.ForeColor = Color.Black;

                        foreach(Control tcc in tab.Controls)
                        {
                            tcc.ForeColor = Color.Black;
                        }
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

        public static void WaitFor(int milliSeconds)
        {
            var sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < milliSeconds)
            {
                Application.DoEvents();
            }
            sw.Stop();
        }

        public static void AttmptWriteToLog(string text)
        {
            text = text.Substring(21);

            if (Properties.Settings.Default.LOGGING_FILE == "none") return;
            if (!Properties.Settings.Default.LOGGING) return;

            if (File.Exists(Properties.Settings.Default.LOGGING_FILE))
            {

                string old = File.ReadAllText(Properties.Settings.Default.LOGGING_FILE);

                string new_text = old + Environment.NewLine + text;

                File.WriteAllText(Properties.Settings.Default.LOGGING_FILE, new_text);

            }
            else
            {
                File.WriteAllText(Properties.Settings.Default.LOGGING_FILE, text);
            }
        }

        public static string FormatDateToExportCSVFormat(DateTime d)
        {
            return d.ToString("MM/dd hh:mm tt");
        }

        public static DialogResult MessageBox(string title, string message, bool use_btn1, DialogResult btn1_result_type, bool use_btn2, DialogResult btn2_result_type, bool use_btn3, DialogResult btn3_result_type, string btn1_text, string btn2_text, string btn3_text, int default_button)
        {
            DialogResult result;
            using (var fMsgBox = new FrmMessageBox(title, Environment.NewLine + Environment.NewLine + message, use_btn1, btn1_result_type, use_btn2, btn2_result_type, use_btn3, btn3_result_type, btn1_text, btn2_text, btn3_text, default_button))
            {
                result = fMsgBox.ShowDialog();

            }
            return result;
        }
    }
}

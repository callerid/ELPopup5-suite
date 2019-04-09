using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ELPopup5.Classes
{
    class Common
    {

        public enum APP_SETTING{

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

        public static void InitializeSettings()
        {
            Program.AppSettings.Add("POPUP_INBOUND", "True");
            Program.AppSettings.Add("POPUP_TIME", "5");
            Program.AppSettings.Add("RELAY_IP", "0.0.0.0");
            Program.AppSettings.Add("LOGGING_FILE", "none");
            Program.AppSettings.Add("MAIN_WINDOW_Y", "316");
            Program.AppSettings.Add("START_MINIMIZED", "False");
            Program.AppSettings.Add("CAPTURING_LINE_FILES", "none");
            Program.AppSettings.Add("DISPLAY_RECORD_COUNT", "500");
            Program.AppSettings.Add("USE_CUSTOM_MAIN_WINDOW_SIZING", "True");
            Program.AppSettings.Add("POPUP_OUTBOUND", "False");
            Program.AppSettings.Add("MAIN_WINDOW_HEIGHT", "511");
            Program.AppSettings.Add("MAX_LINE_NUMBER", "12");
            Program.AppSettings.Add("LOGGING", "False");
            Program.AppSettings.Add("MAIN_WINDOW_WIDTH", "777");
            Program.AppSettings.Add("USE_COMPUTER_TIME", "True");
            Program.AppSettings.Add("USE_CUSTOM_POSITION", "True");
            Program.AppSettings.Add("SS_COM_PORT", "None");
            Program.AppSettings.Add("MAIN_WINDOW_X", "370");

            Program.AppSettings["POPUP_INBOUND"]
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

            if (Program.AppSettings["LOGGING_FILE"] == "none") return;
            if (!(bool.Parse(Program.AppSettings["LOGGING"]))) return;

            if (File.Exists(Program.AppSettings["LOGGING_FILE"]))
            {

                string old = File.ReadAllText(Program.AppSettings["LOGGING_FILE"]);

                string new_text = old + Environment.NewLine + text;

                File.WriteAllText(Program.AppSettings["LOGGING_FILE"], new_text);

            }
            else
            {
                File.WriteAllText(Program.AppSettings["LOGGING_FILE"], text);
            }
        }

        public static string FormatDateToExportCSVFormat(DateTime d)
        {
            return d.ToString("MM/dd/yyyy hh:mm tt");
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

        public static string FormatPhoneNumber(string text)
        {
            var simpleNumber = "";

            foreach (var c in text)
            {
                if (char.IsDigit(c))
                {
                    simpleNumber += c;
                }
            }

            var formatted = false;
            if (simpleNumber.Length == 10)
            {
                simpleNumber = simpleNumber.Substring(0, 3) + @"-" + simpleNumber.Substring(3, 3) + @"-" +
                               simpleNumber.Substring(6, 4);
                formatted = true;
            }
            else if(simpleNumber.Length == 11)
            {
                simpleNumber = simpleNumber.Substring(1, 3) + @"-" + simpleNumber.Substring(4, 3) + @"-" +
                               simpleNumber.Substring(7, 4);
                formatted = true;
            }

            if (string.IsNullOrEmpty(simpleNumber))
            {
                return "";
            }

            return formatted ? simpleNumber : text;

        }

        public static string MakeStringSqlSafe(string unsafeString)
        {
            return unsafeString.Replace("\'", "&#39;").Replace("%%", "&#37;");
        }

        // Convert safe string back to display string
        public static string GetUnsafeSqlString(string safeString)
        {
            return safeString.Replace("&#39;", "\'").Replace("&#37;", "%%");
        }

        public static void SaveSettings()
        {
            SaveSettings();

            if (!Directory.Exists(Program.ConfigFile.Replace("config.dat", "")))
            {
                Directory.CreateDirectory(Program.ConfigFile.Replace("config.dat", ""));
            }

            List<string> output = new List<string>();

            foreach (string app_setting_key in Program.AppSettings.Keys)
            {
                output.Add(app_setting_key + "=" + Program.AppSettings[app_setting_key]);
            }

            File.WriteAllLines(Program.ConfigFile, output.ToArray());

        }

        public static void LoadSettings()
        {
            List<string> settings = new List<string>();
            if (File.Exists(Program.ConfigFile))
            {
                string[] read = File.ReadAllLines(Program.ConfigFile);

                if(read.Length != Program.AppSettings.Count)
                {
                    if (File.Exists(Program.ConfigFile)) File.Delete(Program.ConfigFile);
                    SaveSettings();
                    return;
                }

                foreach(string setting in read)
                {
                    string key = setting.Substring(0, setting.IndexOf("="));
                    string val = setting.Substring(setting.IndexOf("=")+1);

                    Program.AppSettings[key] = val;
                }
            }
            else
            {
                SaveSettings();
            }

        }

        public static void OpenManual(int page = 1)
        {
            if (Program.fManual != null)
            {
                if (Program.fManual.Visible) Program.fManual.Close();
            }

            if (Program.fManual == null)
            {
                Program.fManual = new FrmManual(page);
                Program.fManual.Show();
                Program.fManual.Focus();
                return;
            }
            if (Program.fManual.Visible)
            {
                Program.fManual.WindowState = FormWindowState.Normal;
                Program.fManual.Focus();
                return;
            }
            else
            {
                Program.fManual = new FrmManual(page);
                Program.fManual.Show();
                Program.fManual.Focus();
                return;
            }
        }

        public static void WriteOutSingleLog(int line, string number, string name)
        {

            if (Program.AppSettings["CAPTURING_LINE_FILES"] == "none") return;

            string filename = Program.AppSettings["CAPTURING_LINE_FILES"] + "\\Line" + line.ToString() + ".txt";
            string to_write = number + name;

            File.WriteAllText(filename, to_write);

        }
    }
}

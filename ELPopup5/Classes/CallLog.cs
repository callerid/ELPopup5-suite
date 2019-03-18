using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace ELPopup5.Classes
{
    class CallLog
    {

        public static string DatabaseFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\CallerID.com\ELPopup5\call_log.db3";

        public static void CreateDatabase()
        {

            //--------------------------- Log File database---------------------
            if (!File.Exists(DatabaseFile))
            {
                // Create new SQLite (db3) file for new database since none exist
                // You could use any database type for logging.  We used SQLite since one only one DLL file
                // is required for installation of this database type. 
                if(!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\CallerID.com\ELPopup5")){
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\CallerID.com\ELPopup5");
                }

                SQLiteConnection.CreateFile(DatabaseFile);

                // Connect to database
                SQLiteConnection myConnection = new SQLiteConnection();
                myConnection.ConnectionString = @"Data Source=" + DatabaseFile;

                // Log into log database
                try
                {
                    myConnection.Open();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
                }

                // Create all needed columns in new table called 'calls'
                SQLiteCommand myCommand = new SQLiteCommand("CREATE TABLE calls(id INTEGER PRIMARY KEY AUTOINCREMENT, DateAndTime varchar(40),Line varchar(10),Type varchar(10),Indicator varchar(10),Duration varchar(10),Checksum varchar(10),Rings varchar(10),Number varchar(15),Name varchar(20), UID varchar(80));", myConnection);
                if (myConnection.State == ConnectionState.Open)
                {
                    myCommand.ExecuteNonQuery();
                }

                try
                {
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
                }

            }

        }

        public static void DeleteDatabase()
        {
            if (File.Exists(DatabaseFile))
            {
                // Backup
                File.Copy(DatabaseFile, DatabaseFile.Replace(".db3", "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".db3"));

                // Connect to database
                SQLiteConnection myConnection = new SQLiteConnection();
                myConnection.ConnectionString = @"Data Source=" + DatabaseFile;

                // Log into log database
                try
                {
                    myConnection.Open();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
                }

                SQLiteCommand myCommand = new SQLiteCommand("DELETE FROM calls;", myConnection);
                if (myConnection.State == ConnectionState.Open)
                {
                    myCommand.ExecuteNonQuery();
                }

                try
                {
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
                }
            }
        }

        public static void AddCall(string line, string type, string indicator, string duration, string checksum, string rings, DateTime date, string number, string name, string id)
        {
            // Create connection to database
            SQLiteConnection myConnection = new SQLiteConnection();
            myConnection.ConnectionString = @"Data Source=" + DatabaseFile;

            // Log into log database
            try
            {
                myConnection.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }

            // Insert new data into database
            SQLiteCommand myCommand = new SQLiteCommand("INSERT INTO calls(Line, Type, Indicator, Duration, Checksum, Rings, DateAndTime, Number, Name, UID) Values ('" + line + "','" + type + "','" + indicator + "','" + duration + "','" + checksum + "','" + rings + "','" + Common.GetSQLiteDateFromDateTime(date) + "','" + number + "','" + name + "', '" + id + "')", myConnection);
            if (myConnection.State == ConnectionState.Open)
            {
                myCommand.ExecuteNonQuery();
            }

            // Close connection to database
            try
            {
                myConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
        }

        public static DataTable GetCallLog(int limit, string import_file = "none")
        {
            // Create connection to database
            SQLiteConnection myConnection = new SQLiteConnection();

            if (import_file == "none")
            {
                myConnection.ConnectionString = @"Data Source=" + DatabaseFile;
            }
            else
            {
                myConnection.ConnectionString = @"Data Source=" + import_file;
            }

            // Log into log database
            try
            {
                myConnection.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }

            DataTable rtn = new DataTable();
            rtn.Columns.Add("name");
            rtn.Columns.Add("number");
            rtn.Columns.Add("time");
            rtn.Columns.Add("dur");
            rtn.Columns.Add("line");
            rtn.Columns.Add("io");
            rtn.Columns.Add("rings");
            rtn.Columns.Add("type");
            rtn.Columns.Add("checksum");
            rtn.Columns.Add("uid");

            string query = "SELECT * FROM calls ORDER BY DateAndTime DESC LIMIT " + limit + ";";

            if (import_file != "none") query = "SELECT * FROM CallRecords ORDER BY Time DESC LIMIT " + limit + ";";

            try
            {
                SQLiteCommand command = new SQLiteCommand(query, myConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                if (import_file == "none")
                {
                    while (reader.Read())
                    {
                        rtn.Rows.Add(reader["Name"], reader["Number"], reader["DateAndTime"], reader["Duration"], reader["Line"], reader["Indicator"], reader["Rings"], reader["Type"], reader["Checksum"], reader["UID"]);
                    }
                }
                else
                {
                    while (reader.Read())
                    {
                        rtn.Rows.Add(reader["Name"].ToString(), reader["Phone"].ToString(), reader["Time"].ToString(), reader["Duration"].ToString(), reader["Line"].ToString(), (reader["Inbound"].ToString() == "1" ? "I" : "O"), "0", "I", "G", reader["UID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            

            try
            {
                myConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }

            return rtn;
        }

        public static DataTable FilterCallLog(string filter, int limit)
        {
            string query = "SELECT * FROM calls ORDER BY id DESC LIMIT " + limit + ";";

            DateTime today = Common.MakeSimpleDate(DateTime.Now);
            DateTime yesterday = Common.MakeSimpleDate(today.Subtract(new TimeSpan(1, 0, 0, 0)));
            DateTime two_days_back = Common.MakeSimpleDate(today.Subtract(new TimeSpan(2, 0, 0, 0)));

            string today_str = Common.GetSQLiteDateFromDateTime(today);
            string yesterday_str = Common.GetSQLiteDateFromDateTime(yesterday);
            string two_days_back_str = Common.GetSQLiteDateFromDateTime(two_days_back);

            switch (filter)
            {

                case "Inbound":

                    query = "SELECT * FROM calls WHERE Indicator = 'I' ORDER BY id DESC LIMIT " + limit + ";";

                    break;

                case "Outbound":

                    query = "SELECT * FROM calls WHERE Indicator = 'O' ORDER BY id DESC LIMIT " + limit + ";";

                    break;

                case "Today":

                    query = "SELECT * FROM calls WHERE DateAndTime > date('now', '-1 days') LIMIT " + limit + ";";

                    break;

                case "Yesterday":

                    query = "SELECT * FROM calls WHERE DateAndTime BETWEEN date('now', '-2 days') AND date('now') LIMIT " + limit + ";";

                    break;

                case "This Morning":

                    query = "SELECT * FROM calls WHERE DateAndTime > datetime('now','start of day') AND DateAndTime < datetime('now','start of day', '+12 hours') LIMIT " + limit + ";";

                    break;

                case "This Afternoon":

                    query = "SELECT * FROM calls WHERE DateAndTime > datetime('now','start of day', '+12 hours') AND DateAndTime < datetime('now','start of day','+24 hours') LIMIT " + limit + ";";

                    break;

                case "Morning":

                    query = "SELECT * FROM calls WHERE TIME(DateAndTime) > TIME('now','start of day') AND TIME(DateAndTime) < TIME('now','start of day','+12 hours') LIMIT " + limit + ";";

                    break;

                case "Afternoon":

                    query = "SELECT * FROM calls WHERE TIME(DateAndTime) > TIME('now','start of day','+12 hours') AND TIME(DateAndTime) < TIME('now','start of day','+23 hours','+59 minutes','+59 seconds') LIMIT " + limit + ";";

                    break;

                case "This week":

                    query = "SELECT * FROM calls WHERE DateAndTime BETWEEN date('now', 'weekday 0', '-7 days') AND date('now', 'weekday 0', '-1 days') LIMIT " + limit + ";";

                    break;

                case "Last week":

                    query = "SELECT * FROM calls WHERE DateAndTime BETWEEN date('now', 'weekday 0', '-14 days') AND date('now', 'weekday 0', '-7 days') LIMIT " + limit + ";";

                    break;

                case "This month":

                    query = "SELECT * FROM calls WHERE DateAndTime BETWEEN date('now','start of month') AND date('now','start of month','+1 month','-1 day') LIMIT " + limit + ";";

                    break;

                case "Last month":

                    query = "SELECT * FROM calls WHERE DateAndTime BETWEEN date('now','start of month', '-1 month') AND date('now','start of month') LIMIT " + limit + ";";

                    break;

                default:

                    filter = Common.MakeStringSqlSafe(filter);
                    query = "SELECT * FROM calls WHERE Name LIKE '%" + filter + "%' OR Number LIKE '%" + filter + "%' LIMIT " + limit + ";";
                    break;


            }

            // Create connection to database
            SQLiteConnection myConnection = new SQLiteConnection();
            myConnection.ConnectionString = @"Data Source=" + DatabaseFile;

            // Log into log database
            try
            {
                myConnection.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }

            DataTable rtn = new DataTable();
            rtn.Columns.Add("name");
            rtn.Columns.Add("number");
            rtn.Columns.Add("time");
            rtn.Columns.Add("dur");
            rtn.Columns.Add("line");
            rtn.Columns.Add("io");
            rtn.Columns.Add("rings");
            rtn.Columns.Add("uid");

            SQLiteCommand command = new SQLiteCommand(query, myConnection);
            command.CommandText = query;
            
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                rtn.Rows.Add(reader["Name"], reader["Number"], reader["DateAndTime"], reader["Duration"], reader["Line"], reader["Indicator"], reader["Rings"], reader["UID"]);
            }

            try
            {
                myConnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }

            return rtn;

        }

        public static string GetNameFromNumberInDatabase(string phone_number)
        {
            // Create connection to database
            SQLiteConnection myConnection = new SQLiteConnection();
            myConnection.ConnectionString = @"Data Source=" + DatabaseFile;

            // Log into log database
            try
            {
                myConnection.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }

            DataTable rtn = new DataTable();
            rtn.Columns.Add("name");

            string query = "SELECT * FROM calls WHERE TRIM(Number) = '" + phone_number + "' OR TRIM(Number) = '" + Common.FormatPhoneNumber(phone_number) + "';";

            SQLiteCommand command = new SQLiteCommand(query, myConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            string name = "";
            while (reader.Read())
            {
                name = reader["Name"].ToString();
                if (!string.IsNullOrEmpty(name)) break;
            }

            try
            {
                myConnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }

            return name;
        }
    }
}

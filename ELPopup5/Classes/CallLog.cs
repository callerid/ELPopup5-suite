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
                SQLiteCommand myCommand = new SQLiteCommand("CREATE TABLE calls(id INTEGER PRIMARY KEY AUTOINCREMENT, DateAndTime varchar(40),Line varchar(10),Type varchar(10),Indicator varchar(10),Duration varchar(10),Checksum varchar(10),Rings varchar(10),Number varchar(15),Name varchar(20));", myConnection);
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

        public static void AddCall(string line, string type, string indicator, string duration, string checksum, string rings, string date_and_time, string number, string name)
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
            SQLiteCommand myCommand = new SQLiteCommand("INSERT INTO calls(Line, Type, Indicator, Duration, Checksum, Rings, DateAndTime, Number, Name) Values ('" + line + "','" + type + "','" + indicator + "','" + duration + "','" + checksum + "','" + rings + "','" + date_and_time + "','" + number + "','" + name + "')", myConnection);
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

        public static DataTable GetCallLog()
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
            rtn.Columns.Add("number");
            rtn.Columns.Add("time");
            rtn.Columns.Add("dur");
            rtn.Columns.Add("line");
            rtn.Columns.Add("io");
            rtn.Columns.Add("rings");

            SQLiteCommand command = new SQLiteCommand("SELECT * FROM calls ORDER BY id DESC;", myConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                rtn.Rows.Add(reader["Name"], reader["Number"], reader["DateAndTime"], reader["Duration"], reader["Line"], reader["Indicator"], reader["Rings"]);
            }

            return rtn;
        }
    }
}

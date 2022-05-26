//Created by and copyright of Nicholas Edward Bailey 01/11/2020
//Pulls MySQL server connection settings from XML file

//Create an instance of this class
//public static MySQLdb mySqlSettings = new MySQLdb("#12dCCdaW0@11", AppDomain.CurrentDomain.BaseDirectory + "\\settings\\MySQLSettings.xml");

/* XML settings file structure
<? xml version = "1.0" encoding = "utf-8" ?>
   <MySQL>
     <server>localhost</server>
     <port>3306</port>
     <username>user</username>
     <password>pass</password>
     <database>db_schema_name</database>
   </MySQL>
*/
using Newtonsoft.Json;
using SimpleEncryption;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Xml;

namespace MySQLExtra
{
    public class MySQLdb
    {
        private string? dbServer;
        private string? dbPort;
        private string? dbUser;
        private string? dbPassword;
        private string? dbDatabase;
        public string? dbConnectionStr;

        public string? DbDatabase { get { return dbDatabase; } }

        public MySQLdb(string identifier, string filePath) //identifier is unique identifier used during encryption via encryption.cs
        {
            //Open XML file
            XmlDocument xmlDoc = new XmlDocument();
            FileStream fs = new(filePath, FileMode.Open, FileAccess.Read);
            xmlDoc.Load(fs);

            //Get correct nodes from XML file
            XmlNodeList? xmlNodeList = xmlDoc.SelectNodes("MySQL");
            if (xmlNodeList is not null)
            {
                foreach (XmlNode xmlChildNode in xmlNodeList) //Get child nodes
                {
                    dbServer = xmlChildNode["server"].InnerText;
                    dbPort = xmlChildNode["port"].InnerText;
                    dbUser = Encryption.Decrypt(xmlChildNode["username"].InnerText, identifier);
                    dbPassword = Encryption.Decrypt(xmlChildNode["password"].InnerText, identifier);
                    dbDatabase = xmlChildNode["database"].InnerText;
                }

                dbConnectionStr = //Setup MySQL database connection string
                    "Server=" + dbServer + ";"
                    + "Port=" + dbPort + ";"
                    + "Uid=" + dbUser + ";"
                    + "Pwd=" + dbPassword + ";"
                    + "Database=" + dbDatabase + ";"
                    + "Pooling = true;";
            }
        }

        /// <summary>
        /// Tests the database connection. Can be used early in program execution to make sure that the database is reachable and that user and pass are correct
        /// </summary>
        public void TestConnection()
        {
            try
            {
                MySql.Data.MySqlClient.MySqlConnection dbConnection = new(dbConnectionStr);
                Debug.WriteLine("Connecting to MySQL...");
                dbConnection.Open();
                dbConnection.Close();
                Debug.WriteLine("Connection test successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect to database.Contact your system administrator.\nError code: 0001 \n" + ex, "Database Error.", MessageBoxButton.OK, MessageBoxImage.Warning);
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Query MySQL database and return deserialized class object of any type
        /// </summary>
        /// <param name="obj">Required return type</param>
        /// <param name="sqlStr">SQL string to execute (ex. "SELECT * FROM table_name;"</param>
        /// <returns>Type of object supplied in arguments, initialised with MySQL query data</returns>
        public dynamic? Query(Type t, string sqlStr)
        {
            //Figure out what object type has been passed in and prepare the result object to be of the same type
            object result = Activator.CreateInstance(t);

            //Temporary container for the MySQL data
            DataTable dataTable = new();

            //Connect to database, execute query and fill dataTable with data
            try
            {
                MySql.Data.MySqlClient.MySqlConnection dbConnection = new(dbConnectionStr);
                dbConnection.Open();
                MySql.Data.MySqlClient.MySqlDataAdapter adapter = new();
                adapter.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand(sqlStr, dbConnection);
                adapter.Fill(dataTable);

                //If required return type is anything other than DataTable serialize the data and then deserialize it into the correct data type / user created class
                if (result is DataTable)
                {
                    result = dataTable;
                }
                else
                {
                    string serializedDataTable = JsonConvert.SerializeObject(dataTable, Newtonsoft.Json.Formatting.Indented);
                    result = JsonConvert.DeserializeObject(serializedDataTable, t);
                }
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect to database.Contact your system administrator." +
                    "\nError code: 0002" +
                    "\n" + ex,
                    "Database Error.", MessageBoxButton.OK, MessageBoxImage.Error);
                Debug.WriteLine(ex.ToString());
            }
            return result;
        }

        /// <summary>
        /// Update MySQL database. Can also be used in many cases for INSERT or most other operations that don't require reading of database.
        /// </summary>
        /// <param name="sqlStr">SQL string to execute (ex. "UPDATE table_name SET column1 = val1 WHERE column2 = val2;"</param>
        /// <returns></returns>
        public bool Update(string sqlStr)
        {
            try
            {
                MySql.Data.MySqlClient.MySqlConnection dbConnection = new(dbConnectionStr);
                dbConnection.Open();
                MySql.Data.MySqlClient.MySqlCommand sqlCommand = new MySql.Data.MySqlClient.MySqlCommand(sqlStr, dbConnection);
                sqlCommand.ExecuteNonQuery();
                dbConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to update to database.Contact your system administrator." +
                    "\nError code: 0003" +
                    "\n" + ex,
                    "Database Error.", MessageBoxButton.OK, MessageBoxImage.Error);
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}


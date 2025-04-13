using System.Data;
using System.Data.SqlClient;


public class Dal
{
    private const string DBName = "DB.mdf";   //Name of the MSSQL Database.
    private const string usersTblName = "Users";      // Name of the user Table in the Database
    private const string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\"
                                    + DBName + ";Integrated Security=True";   // The Data Base is in the App_Data = |DataDirectory|

    private static SqlConnection ConnectToDb()
    {
        SqlConnection conn = new SqlConnection(conString);
        return conn;
    }

    /// <summary>
    /// To Execute update / insert / delete queries
    ///  הפעולה מקבלת פקודה לביצוע ומחזירה את מספר השורות שהושפעו מביצוע הפעולה
    /// </summary>
    public static int DoQuery(string sql)
    {
        SqlConnection conn = ConnectToDb();
        conn.Open();
        SqlCommand com = new SqlCommand(sql, conn);
        int rowsAffected = com.ExecuteNonQuery();
        com.Dispose();
        conn.Close();
        return rowsAffected;
    }

    /// <summary>
    /// הפעולה מקבלת פקודה לחיפוש ערך - מחזירה אמת אם הערך נמצא ושקר אחרת
    /// </summary>
    private static bool IsExist(string sql)
    {
        SqlConnection conn = ConnectToDb();
        conn.Open();
        SqlCommand com = new SqlCommand(sql, conn);
        SqlDataReader data = com.ExecuteReader();
        bool found;
        found = (bool)data.Read();// אם יש נתונים לקריאה יושם אמת אחרת שקר - הערך קיים במסד הנתונים
        conn.Close();
        return found;
    }

    /// <summary>
    /// הפעולה מקבלת מזהה משתמש ומחזירה אמת אם קיים ערך זהה בטבלה ושקר אחרת
    /// </summary>
    public static bool ExistUser(string email)
    {
        string sql =
            $" SELECT * FROM {usersTblName} " +
            $" WHERE Email = N'{email}';";

        return IsExist(sql);
    }

    /// <summary>
    /// הפעולה מקבלת מזהה משתמש וסיסמה 
    /// ומחזירה אמת אם קיים בטבלה מזהה משתמש שזוהי ססמתו ושקר אחרת
    /// </summary>
    public static bool IsValidUserPassword(string email, string psw)
    {
        string sql =
            " SELECT * FROM " + usersTblName +
            " WHERE Email = N'" + email + "'" +
            " AND Password = N'" + psw + "';";

        return IsExist(sql);
    }

    /// <summary>
    /// הפעולה מקבלת מזהה משתמש ומחזירה את שמו הפרטי מהטבלה
    /// </summary>
    public static string GetUserName(string email)
    {
        string sql =
            " SELECT Name FROM " + usersTblName +
            " WHERE Email = N'" + email + "';";

        DataTable tbl = RetrieveTable(sql);
        string name = (string)tbl.Rows[0]["Name"];

        return name;
    }

    /// <summary>
    /// הפעולה מקבלת פרטי משתמש ומוסיפה אותו לטבלה במסד הנתונים
    /// הפעולה מחזירה אמת אם הצליחה ושקר אם המשתמש כבר קיים בטבלה
    /// </summary>
    public static bool InsertUser(string email, string psw,
        string name)
    {
        if (ExistUser(email))
            return false;

        string sql =
            $" INSERT INTO {usersTblName} " +
            " (email, password, Name) " +
            $" VALUES(N'{email}', N'{psw}', N'{name}');";

        DoQuery(sql);
        return true;
    }

    public static void InsertTask(string title, string content,
        string date, string user, bool importat)
    {
        int isImportantBit = importat ? 1 : 0;
        string sql =
            "INSERT INTO Tasks " +
            "(User_Id, Title, Content, Date, IsImportant) " +
            "VALUES " +
            $"(N'{user}', N'{title}', N'{content}', N'{date}', {isImportantBit});";
        DoQuery(sql);
    }

    public static void DeleteTask(string title)
    {
        string sql =
            "DELETE FROM Tasks " +
            $"WHERE Title LIKE N'{title}';";
        DoQuery(sql);
    }

    /// <summary>
    /// Gets A table from the data base acording to the SELECT Command in SQLStr;
    /// Returns DataTable with the Table.
    /// </summary>
    private static DataTable RetrieveTable(string SQLStr)
    {
        // connect to DataBase
        SqlConnection con = ConnectToDb();
        con.Open();
        SqlDataAdapter tableAdapter = new SqlDataAdapter(SQLStr, con);
        DataTable dt = new DataTable();
        tableAdapter.Fill(dt);
        return dt;
    }


    /// <summary>
    /// Gets A table from the data base acording to the SELECT Command in SQLStr;
    /// Returns an HTML table string table data in it.
    /// </summary>
    public static string UsersDataTableToHTML(string filter)
    {
        string sql = "SELECT Title, Content, Date FROM Tasks";
        if (filter != "")
        {
            sql += $" WHERE User_Id LIKE '%{filter}%'";
        }
        DataTable dt = RetrieveTable(sql);

        string printStr = "<table class='dataTable'>";
        foreach (DataColumn column in dt.Columns)
        {
            printStr += "<th>" + column.Caption + "</th>";
        }
        
        foreach (DataRow row in dt.Rows)
        {
            printStr += "<tr>";
            foreach (object item in row.ItemArray)
            {
                printStr += "<td>" + item.ToString() + "</td>";
            }
            printStr += "</tr>";
        }
        printStr += "</table>";

        return printStr;
    }

    //only importants
    public static string UsersDataTableToHTMLFilter(string filter)
    {
        string sql = "SELECT Title, Content, Date FROM Tasks";
        if (filter != "")
        {
            sql += $" WHERE User_Id LIKE '%{filter}%' AND IsImportant = 1";
        }
        DataTable dt = RetrieveTable(sql);

        string printStr = "<table class='dataTable'>";
        foreach (DataColumn column in dt.Columns)
        {
            printStr += "<th>" + column.Caption + "</th>";
        }

        foreach (DataRow row in dt.Rows)
        {
            printStr += "<tr>";
            foreach (object item in row.ItemArray)
            {
                printStr += "<td>" + item.ToString() + "</td>";
            }
            printStr += "</tr>";
        }
        printStr += "</table>";

        return printStr;
    }

}
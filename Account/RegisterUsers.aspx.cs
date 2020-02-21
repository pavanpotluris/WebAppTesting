using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Account_RegisterUsers : System.Web.UI.Page
{    
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        string userName = UserName.Text;
        string password = Password.Text;

        string connetionString = null;
        SqlConnection connection;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = null;
        connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        connection = new SqlConnection(connetionString);
        sql = "insert into Users (UserName,Password,DateStamp) values('" + userName + "','" + password + "',getdate())";
        try
        {
            connection.Open();
            adapter.InsertCommand = new SqlCommand(sql, connection);
            adapter.InsertCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
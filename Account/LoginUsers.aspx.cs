using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Account_LoginUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LogIn(object sender, EventArgs e)
    {
        // Validate the user password
        string userName = UserName.Text;
        string password = Password.Text;

        string connetionString = null;
        connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        if (userName != null)
        {
            //Verify Users
            
            SqlConnection cnn;
            SqlCommand cmd;
            string sql = null;            

            sql = "select count(*) from users where username = '" + userName + "'";

            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                cmd = new SqlCommand(sql, cnn);
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                cnn.Close();

                if (count > 0)
                {
                    string sqlUsers = "SELECT * FROM users";
                    SqlConnection connection = new SqlConnection(connetionString);
                    SqlDataAdapter dataadapter = new SqlDataAdapter(sqlUsers, connection);
                    DataSet ds = new DataSet();
                    connection.Open();
                    dataadapter.Fill(ds, "Users_table");
                    connection.Close();
                    gvUsersList.DataSource = ds;
                    gvUsersList.DataMember = "Users_table";
                    gvUsersList.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else
        {
            FailureText.Text = "Invalid username or password.";
            ErrorMessage.Visible = true;
        }
    }
}
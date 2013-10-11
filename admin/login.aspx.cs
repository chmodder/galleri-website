using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        // opret forbindelse til databasen
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        // SQL strengen
        cmd.CommandText = "SELECT * FROM [brugere] WHERE [brugernavn] = @brugernavn AND [passwd] LIKE @password";

        // Tilføj parametrer (input fra brugeren / TextBox fra .aspx siden) til din SQL streng
        cmd.Parameters.Add("@brugernavn", SqlDbType.NVarChar).Value = inputBrugernavn.Text;
        cmd.Parameters.Add("@password", SqlDbType.NText).Value = inputPassword.Text;

        // Åben for forbindelsen til databasen
        conn.Open();

        // Udfør SQL komandoen
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            // Gem informationer om login i Session
            Session["bruger_id"] = reader["id"];
            // Send brugeren videre
            Response.Redirect("default.aspx");
        }
        else
        {
            // Vis fejlmeddelelse
            PanelMsgFejl.Visible = true;
        }

        // Luk for forbindelsen til databasen
        conn.Close();
    }

    protected void ButtonOpret_Click(object sender, EventArgs e)
    {
        //Response.Redirect("opretbruger.aspx");
    }
}
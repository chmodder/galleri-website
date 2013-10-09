using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class admin_opretAlbum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void gemAlbumBtn_Click(object sender, EventArgs e)
    {
        {

        // opret forbindelse til databasen
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        // SQL strengen
        cmd.CommandText = "INSERT INTO Album (navn) VALUES (@navn)";

        // Tilføj parametrer (input fra brugeren / TextBox fra .aspx siden) til din SQL streng
        cmd.Parameters.Add("@navn", SqlDbType.NVarChar).Value = newAlbumInput.Text;
        // Åben for forbindelsen til databasen
        conn.Open();

        // Udfør SQL komandoen
        cmd.ExecuteNonQuery();

        // Luk for forbindelsen til databasen
        conn.Close();

        // Besked til brugeren om at brugeren er oprettet
        PanelMsgSuccess.Visible = true;

        // reset form
        newAlbumInput.Text = "";

        Page_Load(null, null);
        }
    }
}
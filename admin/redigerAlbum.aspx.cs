using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class admin_redigerAlbum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // opret forbindelse til databasen
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        //if (@urlId == null)
        //{
        //    @urlId = "1";
        //}
        // SQL strengen
        cmd.CommandText = "SELECT * FROM Album WHERE Id = @urlId";
        cmd.Parameters.Add("@urlId", SqlDbType.Int).Value = Request.QueryString["id"];
        //ben for forbindelsen til databasen
        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            redigerID.Text = reader["Id"].ToString();
            redigernavn.Text = reader["navn"].ToString();
            redigeroprettetDen.Text = reader["oprettetDen"].ToString();
            redigerredigeretDen.Text = reader["redigeretDen"].ToString();
        }


        // Luk for forbindelsen til databasen
        // reader.Close();
        conn.Close();

    }
    protected void redigerButton_Click(object sender, EventArgs e)
    {
        //	opret	forbindelsen	til	databasen
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

        //	opret	et	SqlCommand	object
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        //Sql	sætningen
        cmd.CommandText = "UPDATE [album] SET [navn] = @albumnavn, [redigeretDen] = @redigeretDen WHERE [Id] = @urlId";
        
        //	Parametrene	@brugernavn	og	@password	i	sql	sætningen	ovenover	tilføjes
        cmd.Parameters.Add("@urlId", SqlDbType.Int).Value = Request.QueryString["id"];
        cmd.Parameters.Add("@albumnavn", SqlDbType.NVarChar).Value = redigernavn.Text;
        cmd.Parameters.Add("@redigeretDen", SqlDbType.DateTime).Value = DateTime.Now;

        //	åben	forbindelsen	til	databasen
        conn.Open();

        //	Udfør	sql	komandoen
        cmd.ExecuteNonQuery();

        //	luk	forbindelsen til databasen
        conn.Close();

        ////Udskriver beskeden om at beskeden er slettet.
        //albumSletAlbum.Text = "<div class='span8'><div class='alert alert-success'>Beskeden er slettet</div></div>";

        ////sletter indholdet fra tekstboksene.
        //redigerID.Text = "";
        //redigernavn.Text = "";
        //redigeroprettetDen.Text = "";
        //redigerredigeretDen.Text = "";
    }
}
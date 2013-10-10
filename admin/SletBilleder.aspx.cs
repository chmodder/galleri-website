using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class admin_SletBilleder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label_msg.Text = "<div class='span6 offset1'><div class='alert alert-success'>Er du sikker på, at du vil slette billedet</div></div>";
        }


        // opret forbindelse til databasen
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        //string urlId = Request.QueryString["id"];

        //if (urlId == null || urlId == "")
        //{
        //    urlId = "6";
        //}

        // SQL strengen
        cmd.CommandText = "SELECT * FROM [billeder] WHERE ([fkAlbumId] = @fkAlbumId)";
        cmd.Parameters.Add("@fkAlbumId", SqlDbType.Int).Value = Request.QueryString["id"];

        //åben for forbindelsen til databasen
        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            billedenavn.Text = reader["imgnavn"].ToString();
            billedeID.Text = reader["Id"].ToString();
        }


        // Luk for forbindelsen til databasen
        // reader.Close();
        conn.Close();


    }

    protected void sletBtn_Click(object sender, EventArgs e)
    {
        try
        {
            // slet Originalfilen i image/upload/Original/ mappen
            File.Delete(Server.MapPath("~/img/upload/originals/" + Request.QueryString["id"].ToString()));

            // Slet Thumbsfilen i /Images/Upload/Thumbs/
            File.Delete(Server.MapPath("~/img/upload/thumbs/" + Request.QueryString["id"].ToString()));

            // Slet Resized_Original i /Images/Upload/Resized_Original/ mappen
            File.Delete(Server.MapPath("~/img/upload/originalsResized/" + Request.QueryString["id"].ToString()));

            // slet filen i databasen
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Media WHERE ImageName = @ImageName";
            cmd.Parameters.Add("@ImageName", SqlDbType.NVarChar).Value = Request.QueryString["id"].ToString();
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            //Redirect til Galleri
            Response.Redirect("default.aspx");
        }

        catch (Exception)
        {
            Label_msg.Text = "<div class='span6 offset1'><div class='alert alert-success'>Billedet blev desværre <b>ikke</b> slettet</div></div>";

        }

    }
    protected void tilAlbumBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("visBilleder.aspx?id=" + Request.QueryString["id"]);
    }
}

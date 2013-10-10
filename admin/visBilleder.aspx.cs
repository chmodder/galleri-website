using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class admin_visBilleder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
        RepeaterAlbum.DataSource = reader;
        RepeaterAlbum.DataBind();

        //if (reader.Read())
        //{
        //    albumnavn.Text = reader["imgnavn"].ToString();
        //    albumID.Text = reader["Id"].ToString();
        //    albumoprettetDen.Text = String.Format("{0:yyyy'/'MM'/'dd}", reader["oprettetDen"]);
        //    albumredigeretDen.Text = String.Format("{0:yyyy'/'MM'/'dd}", reader["redigeretDen"]);
        //}


        // Luk for forbindelsen til databasen
        // reader.Close();
        conn.Close();
    }


    protected void opretImgBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("opretBillede.aspx?id=" + Request.QueryString["id"]);
    }

    //protected void sletButton_Click(object sender, EventArgs e)
    //{
    //    //Get the reference of the clicked button.
    //    Button sletButton = (sender as Button);

    //    //Get the command argument
    //    string commandArgument = sletButton.CommandArgument;

    //    //Get the Repeater Item reference
    //    RepeaterItem item = sletButton.NamingContainer as RepeaterItem;

    //    //Get the repeater item index
    //    int index = item.ItemIndex;

        
    //    //Response.Redirect("SletBilleder.aspx?id=" + Request.QueryString["id"]);
    //}

}
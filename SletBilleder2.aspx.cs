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

public partial class SletBilleder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // slet Originalfilen i image/upload/Original/ mappen
            File.Delete(Server.MapPath("~/img/upload/original/" + Request.QueryString["navn"].ToString()));

            // Slet Thumbsfilen i /Images/Upload/Thumbs/
            File.Delete(Server.MapPath("~/img/upload/Thumbs/" + Request.QueryString["navn"].ToString()));

            // Slet Resized_Original i /Images/Upload/Resized_Original/ mappen
            File.Delete(Server.MapPath("~/img/upload/originalsResized/" + Request.QueryString["navn"].ToString()));

            // slet filen i databasen
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Media WHERE ImageFileName = @ImageFileName";
            cmd.Parameters.Add("@ImageFileName", SqlDbType.NVarChar).Value = Request.QueryString["navn"].ToString();
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            //Redirect til Galleri
            Response.Redirect("default.aspx");
        }
        catch (Exception)
        {
            Label_slet_msg.Text = "<div class='span6 offset1'><div class='alert alert-success'>Billedet blev desværre <b>ikke</b> slettet</div></div>";

        }
    }

}
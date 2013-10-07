using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //int i = 1;
        //while (i <= 8)
        //{
        //    Response.Write("linje nr. " + i + "<br />");
        //    i++;
        //}
        //if (!IsPostBack)
        //{
        //    // opret forbindelse til databasen
        //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = conn;

            
        //    // SQL strengen
        //    cmd.CommandText = "SELECT [Id], [navn] FROM Billeder WHERE Id = @random";
        //    string random = ;
        //    //ben for forbindelsen til databasen
        //    conn.Open();

        //    SqlDataReader reader = cmd.ExecuteReader();

        //    if (reader.Read())
        //    {
        //        redigerOverskrift.Text = reader["overskrift"].ToString();
        //        redigerManchet.Text = reader["manchet"].ToString();
        //        redigerTekst.Text = reader["tekst"].ToString();
        //        redigerForfatter.Text = reader["forfatter"].ToString();
        //        redigerImg.Text = reader["img"].ToString();
        //    }


        //    // Luk for forbindelsen til databasen
        //    // reader.Close();
        //    conn.Close();
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Hvis bruger er logget ind vises logout-knappen
        if (Session["bruger_id"] != null)
        {
            logout.Visible = true;
        }
    }

    protected void admin_Click(object sender, EventArgs e)
    {
        // Hvis brugeren ikke er logget ind stilles brugeren videre til login-siden

        if (Session["Bruger_id"] == null)
        {
            Response.Redirect("~/admin/login.aspx");
        }

        // Hvis bruger er logget ind stilles brugeren videre til admin forsiden
        if (Session["bruger_id"] != null)
        {
            Response.Redirect("~/admin/default.aspx");
        }
    }
    protected void logoutClick(object sender, EventArgs e)
    {
        Session["Bruger_id"] = null;
        Response.Redirect(Request.RawUrl);

    }
}

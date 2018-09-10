using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApp.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Caminho"] != null)
            {
                Response.ContentType = "text/plain";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Session["Caminho"]);
                Response.WriteFile(Session["Caminho"].ToString());
                Response.Flush();
                Session.Remove("Caminho");

            }
            else
            {
                Response.Redirect("ScriptBanco.aspx");

            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
           // base.Render(writer);
        }
    }
}
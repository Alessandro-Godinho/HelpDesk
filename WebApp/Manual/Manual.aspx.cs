using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApp.Manual
{
    public partial class Manual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
         }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\gleison\Documents\Visual Studio 2010\Projects\Projeto doctus\manual usuariO_NOVO\manual_usuario.pdf");
       
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\gleison\Documents\Visual Studio 2010\Projects\Projeto doctus\manual usuariO_NOVO\manual_usuario.pdf");
       
       
        }
       
    }
}
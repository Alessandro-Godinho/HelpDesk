using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AccessDeniedModule
/// </summary>
public class AccessDeniedModule : IHttpModule
{
    public void Init(HttpApplication context)
    {
        context.EndRequest += new EventHandler(context_EndRequest);
    }

    private void context_EndRequest(object sender, EventArgs e)
    {
        HttpApplication app = (HttpApplication)sender;

        if (app.Response.StatusCode == 401 && app.User.Identity.IsAuthenticated)
        {
            app.Response.Redirect("~/AcessoNegado.aspx");
        }
    }

    public void Dispose() { }
}

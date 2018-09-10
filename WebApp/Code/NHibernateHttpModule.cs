using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Web;

// <summary>
/// NHibernateHttpModule
/// </summary>
public class NHibernateHttpModule : IHttpModule
{
    public const string KEY = "_TheSession_";
    private static ISession _session;

    public void Dispose() { }
    public void Init(HttpApplication application) 
    {
        application.BeginRequest += (new EventHandler(this.context_BeginRequest));
        application.EndRequest += (new EventHandler(this.context_EndRequest));

    }

    private void context_BeginRequest(object sender, EventArgs e)
    {
        HttpApplication application = (HttpApplication)sender;
        HttpContext context = application.Context;
        context.Items[KEY] = NHibernateHelper.GetSession(); // SessionHelper.OpenSession();
    }

    private void context_EndRequest(object sender, EventArgs e)
    {
        HttpApplication application = (HttpApplication)sender;
        HttpContext context = application.Context;

        ISession session = context.Items[KEY] as ISession;
        if (session != null)
        {
            try
            {
                session.Flush();
                session.Close();
            }
            catch { }
        }
        context.Items[KEY] = null;
    }

    public static ISession CurrentSession
    {
        get
        {
            if (HttpContext.Current == null)
            {
                if (_session != null)
                    return _session;

                _session = NHibernateHelper.GetSession(); // SessionHelper.OpenSession();
                return _session;
            }
            else
            {
                HttpContext currentContext = HttpContext.Current;
                ISession session = currentContext.Items[KEY] as ISession;
                if (session == null)
                {
                    session = NHibernateHelper.GetSession(); // SessionHelper.OpenSession();
                    currentContext.Items[KEY] = session;
                }
                return session;
            }
        }
    }
}

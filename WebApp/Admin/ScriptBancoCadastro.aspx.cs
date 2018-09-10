using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelpDesk.Dominio;
using HelpDesk.Repositorio;
using System.IO;


namespace WebApp.Admin
{
    public partial class ScriptBancoCadastro : System.Web.UI.Page
    {
        private RepositorioScriptBanco _repositorio;
        public RepositorioScriptBanco Repositorio
        {
            get
            {
                if (_repositorio == null)
                    _repositorio = new RepositorioScriptBanco(NHibernateHttpModule.CurrentSession);

                return _repositorio;
            }
            set { _repositorio = value; }
        }
        private Int64 ID;

         HelpDesk.Dominio.Entidades.ScriptBanco script;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ID = int.Parse(Request.QueryString["ID"]);
            }
            catch (Exception)
            {
               
            }
            if (!IsPostBack)
            {
                if (!ID.Equals(0))
                {
                    script = Repositorio.ObterPorId(ID);
                    txtdescricao.Text = script.Descricao;
                    txtscript.Text = script.Script;
                }
            }
           
        }

        protected void lnkOK_Click(object sender, EventArgs e)
        {
            
            try
            {
               
                script = new HelpDesk.Dominio.Entidades.ScriptBanco();         
                script.Descricao = txtdescricao.Text.Trim();
                script.Situacao = HelpDesk.Dominio.ObjetosValor.Situacao.Ativo;
                script.Script = txtscript.Text.Trim();
                script.DataScript = DateTime.Now;

                if (ID == 0)
                    Repositorio.Salvar(script);
                else
                {
                    script.ID = ID;
                    Repositorio.Alterar(script);
                }

                Response.Redirect("ScriptBanco.aspx");
            }
            catch (ArgumentException ex)
            {

                lnkOK.Text = "erro ao cadastrar";
                return;
            }
        }

        
    }
}
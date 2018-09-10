using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelpDesk.Repositorio;
using HelpDesk.Dominio.ObjetosValor;

namespace WebApp.Admin
{
    public partial class UsuarioCadastro : System.Web.UI.Page
    {
        private RepositorioUsuario _repositorio;
        public RepositorioUsuario Repositorio
        {
            get
            {
                if (_repositorio == null)
                    _repositorio = new RepositorioUsuario(NHibernateHttpModule.CurrentSession);

                return _repositorio;
            }
            set { _repositorio = value; }
        }

        private Int64 ID;
        HelpDesk.Dominio.Entidades.Usuario usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
            if (Request.QueryString["id"] != null)
                ID = Int64.Parse(Request.QueryString["id"].ToString());


            if (!IsPostBack)
            {
                if (ID != 0)
                {
                    usuario = Repositorio.ObterPorId(ID);
                    txtNome.Text = usuario.Nome;
                    txtLogin.Text = usuario.Login;
                    
                }
            }

        }

        protected void lnkOK_Click(object sender, EventArgs e)
        {
            if (ID != 0)
                usuario = Repositorio.ObterPorId(ID);
            else
                usuario = new HelpDesk.Dominio.Entidades.Usuario();


            usuario.Nome = txtNome.Text;
            usuario.Login = txtLogin.Text;
            usuario.Situacao = HelpDesk.Dominio.ObjetosValor.Situacao.Ativo;

            if (ID == 0)
                Repositorio.Salvar(usuario);
            else
                Repositorio.Alterar(usuario);

            Response.Redirect("Usuario.aspx");
        }
    }
}
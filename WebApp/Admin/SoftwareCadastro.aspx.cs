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
    public partial class SoftwareCadastro : System.Web.UI.Page
    {
        private RepositorioSoftware _repositorio;
        public RepositorioSoftware Repositorio
        {
            get
            {
                if (_repositorio == null)
                    _repositorio = new RepositorioSoftware(NHibernateHttpModule.CurrentSession);

                return _repositorio;
            }
            set { _repositorio = value; }
        }

        private Int64 ID;
        HelpDesk.Dominio.Entidades.Software software;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
            Label_erro.Visible = false;
            Label_erro_Software.Visible = false;

            if (Request.QueryString["id"] != null)
                ID = Int64.Parse(Request.QueryString["id"].ToString());


            if (!IsPostBack)
            {
                cmbLinguagem.DataSource = Enum.GetValues(typeof(Linguagem));
                cmbLinguagem.DataBind();

                if (ID != 0)
                {
                    software = Repositorio.ObterPorId(ID);
                    txtNome.Text = software.Nome;
                    cmbLinguagem.SelectedIndex = software.Linguagem.GetHashCode();

                }
            }

        }

        protected void lnkOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID != 0)
                    software = Repositorio.ObterPorId(ID);
                else
                    
                software = new HelpDesk.Dominio.Entidades.Software();
                software.Nome = txtNome.Text.Trim();
                software.Linguagem = (Linguagem)cmbLinguagem.SelectedIndex;
                software.Situacao = HelpDesk.Dominio.ObjetosValor.Situacao.Ativo;

                if (ID == 0)
                    Repositorio.Salvar(software);
                else
                    Repositorio.Alterar(software);

                Response.Redirect("Software.aspx");
            }
            catch (ArgumentException ex)
            {

                Label_erro.Visible = true;
                Label_erro_Software.Visible = true;
                Label_erro.Text = String.Format("Não foi possível completar o cadastro.\n{0}", ex.Message);
                txtNome.Focus();
                return;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
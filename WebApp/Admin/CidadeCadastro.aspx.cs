using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelpDesk.Repositorio;

namespace WebApp.Admin
{
    public partial class CidadeCadastro : System.Web.UI.Page
    {
        private RepositorioCidade _repositorio;
        public RepositorioCidade Repositorio
        {
            get
            {
                if (_repositorio == null)
                    _repositorio = new RepositorioCidade(NHibernateHttpModule.CurrentSession);

                return _repositorio;
            }
            set { _repositorio = value; }
        }

        private Int64 ID;
        HelpDesk.Dominio.Entidades.Cidade cidade;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label_Erro_nome.Visible = false;
            Label_Erro_cidade.Visible = false;
            txtNome.Focus();

            if (Request.QueryString["id"] != null)
                ID = Int64.Parse(Request.QueryString["id"].ToString());


            if (!IsPostBack)
            {
                if (ID != 0)
                {
                    cidade = Repositorio.ObterPorId(ID);
                    txtNome.Text = cidade.Nome;
                    cmbUF.Text = cidade.UF;

                }
            }

        }

        protected void lnkOK_Click(object sender, EventArgs e)
        {
            try
            {
                    if (ID != 0)
                        cidade = Repositorio.ObterPorId(ID);
                    else
                        cidade = new HelpDesk.Dominio.Entidades.Cidade();


                    cidade.Nome = txtNome.Text.Trim();
                    cidade.UF = cmbUF.Text.Trim();
                    cidade.Situacao = HelpDesk.Dominio.ObjetosValor.Situacao.Ativo;

                    if (ID == 0)
                        Repositorio.Salvar(cidade);
                    else
                        Repositorio.Alterar(cidade);

                    Response.Redirect("Cidade.aspx");
                
            }
            catch (ArgumentException ex)
            {

                Label_Erro_nome.Visible = true;
                Label_Erro_cidade.Visible = true;
                Label_Erro_nome.Text = String.Format("Não foi possível completar o cadastro.\n{0}", ex.Message);
                txtNome.Focus();
                return;
            }
            //catch (Exception ex)
            //{

            //}
           
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cidade.aspx");
        }
    }
}
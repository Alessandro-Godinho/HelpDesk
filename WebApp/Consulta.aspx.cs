using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelpDesk.Repositorio;
using HelpDesk.Dominio.ObjetosValor;
using System.Web.Security;


namespace WebApp.Consultas
{
    public partial class Default : System.Web.UI.Page
    {
        private RepositorioChamado _repositorio;
        public RepositorioChamado Repositorio
        {
            get
            {
                if (_repositorio == null)
                    _repositorio = new RepositorioChamado(NHibernateHttpModule.CurrentSession);

                return _repositorio;
            }
            set { _repositorio = value; }

        }

        private Int64 ID;
        HelpDesk.Dominio.Entidades.Historico historico;
        HelpDesk.Dominio.Entidades.Usuario usuario;
        HelpDesk.Dominio.Entidades.Chamado chamado;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label_Erro_Consulta.Visible = false;

            if (Request.QueryString["id"] != null)
                ID = Int64.Parse(Request.QueryString["id"].ToString());

            if (!IsPostBack)
            {
                try
                {
                    cmbSituacaoChamado.DataSource = Enum.GetValues(typeof(SituacaoChamado));//carrega o combobox da situacao do chamado 
                    cmbSituacaoChamado.DataBind();

                    cmbUsuario.DataSource = Membership.GetAllUsers();//carrega o combobox com o usuario que esta logado

                    cmbUsuario.DataBind();
                    cmbUsuario.SelectedValue = Page.User.Identity.Name;

                }
                catch (Exception ex)
                {
                    Label_Erro_Mesagem.Text = (ex.Message);

                }
            }
            CarregaGrid();

        }
        public void CarregaGrid()
        {

            gvwDados.DataSource = Repositorio.ObterTodos(Situacao.Ativo);
            gvwDados.DataBind();
        }


        protected void btnPesquisarHistorico_Click(object sender, EventArgs e)
        {
            try
            {
                //--------------------------- Data inicio ------------------------------------------
                IDictionary<String, Object> parametros = new Dictionary<String, Object>();
                IDictionary<String, String> ordenacao = new Dictionary<String, String>();


                //----------------------------Data Fechamento-----------------------------------
                if ((!String.IsNullOrEmpty(dateDataFechamento.Text)) && (!String.IsNullOrEmpty(dateDataFechamentoFim.Text)))
                    parametros.Add("DataFechamento[<>]", new DateTime[] { dateDataFechamento.Date.AddHours(23).AddMinutes(59).AddSeconds(59), dateDataFechamentoFim.Date.AddHours(23).AddMinutes(59).AddSeconds(59) });
                else
                {
                    if (!String.IsNullOrEmpty(dateDataFechamento.Text))
                        parametros.Add("DataFechamento[>=]", dateDataFechamento.Date.AddHours(23).AddMinutes(59).AddSeconds(59));

                    if (!String.IsNullOrEmpty(dateDataFechamento.Text))
                        parametros.Add("DataFechamento[<=]", dateDataFechamentoFim.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                }
                //---------------------------Combobox situação do chamado----------------------------------------

                if (cmbSituacaoChamado.SelectedIndex != -1)
                    parametros.Add("SituacaoChamado", Enum.Parse(typeof(SituacaoChamado), cmbSituacaoChamado.SelectedValue));


                if (!String.IsNullOrEmpty(cmbUsuario.Text))
                    parametros.Add("Usuario ", cmbUsuario.SelectedValue);


                ordenacao.Add("Asc", "DataAbertura");

                gvwDados.DataSource = Repositorio.ObterPorParametros(parametros, ordenacao);
                gvwDados.DataBind();
            }
            catch (ArgumentException ex)
            {

                Label_Erro_Mesagem.Visible = true;
                Label_Erro_Consulta.Visible = true;
                Label_Erro_Mesagem.Text = String.Format("Não foi possivel completar o cadastro {0}", ex.Message);
                return;
            }
        }
    }
}
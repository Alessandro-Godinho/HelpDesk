using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelpDesk.Repositorio;
using HelpDesk.Dominio.ObjetosValor;
using HelpDesk.Dominio.Entidades;

namespace WebApp
{
    public partial class AlterarChamado : System.Web.UI.Page
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
        HelpDesk.Dominio.Entidades.Chamado chamado;
        HelpDesk.Dominio.Entidades.Cliente cliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
                ID = Int64.Parse(Request.QueryString["id"].ToString());


            if (!IsPostBack)
            {
                RepositorioCliente RepCliente = new RepositorioCliente(NHibernateHttpModule.CurrentSession);
                IList<HelpDesk.Dominio.Entidades.Cliente> clientes = RepCliente.ObterTodos(Situacao.Ativo);//mudei aqui a situacao nao tinha
                cmbcliente.DataSource = clientes;
                cmbcliente.DataBind();
                
                ddownSituacaoChamado.DataSource = Enum.GetValues(typeof(SituacaoChamado));
                ddownSituacaoChamado.DataBind();
            
                chamado = Repositorio.ObterPorId(ID);
                lblDataAbertura.Text = chamado.DataAbertura.ToString("dd/MM/yyyy hh:mm");
                cmbcliente.SelectedIndex = clientes.IndexOf(chamado.Cliente);
                //lblUsuario.Text = chamado.Usuario.ToString();
                ddownSituacaoChamado.SelectedIndex = chamado.SituacaoChamado.GetHashCode();

            }

            CarregaGrid();

            }
        public void CarregaGrid()
        {
            //gvwDados.DataSource = Repositorio.ObterTodos();

            gvwDados.DataSource = Repositorio.ObterTodos(Situacao.Ativo);
            gvwDados.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            chamado = Repositorio.ObterPorId(ID);

            SituacaoChamado situacao = (SituacaoChamado)Enum.Parse(typeof(SituacaoChamado), ddownSituacaoChamado.SelectedValue.ToString());
            if ((String.IsNullOrEmpty(txtNovoHistorico.Text)) && (situacao == chamado.SituacaoChamado))
            {
                lblErro.Text = "Informe um histórico para atualizar!";
                return;   
            }
            if ((String.IsNullOrEmpty(txtNovoHistorico.Text)) && (situacao == SituacaoChamado.Fechado))
            {
                lblErro.Text = "Para fechar o chamado é necessário informar um histórico!";
                return;
            }
           
            Historico historico = new Historico();
            historico.Chamado = chamado;
            historico.DataHistorico = DateTime.Now;
            historico.Descricao = txtNovoHistorico.Text;
           
            if (chamado.SituacaoChamado != situacao)
                historico.Descricao = String.Format("{0}<br/>O usuário mudou a situação do chamado de {1} para {2}", txtNovoHistorico.Text, chamado.SituacaoChamado, situacao);
           // User.Identity.Name;
            //historico.Usuario = 
            chamado.Historicos.Add(historico);

            chamado.SituacaoChamado = situacao;

            if (situacao == SituacaoChamado.Fechado)
            {
                chamado.DataFechamento = DateTime.Now;
            }

            Repositorio.Alterar(chamado);
            Response.Redirect("Chamado.aspx");
        
        }

        
    }
}
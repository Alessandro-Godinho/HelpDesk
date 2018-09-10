using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelpDesk.Repositorio;

namespace WebApp.Admin
{
    public partial class EstacoesCadastro : System.Web.UI.Page
    {

        private RepositorioEstacao _repositorio;
        public RepositorioEstacao Repositorio
        {
            get
            {
                if (_repositorio == null)
                    _repositorio = new RepositorioEstacao(NHibernateHttpModule.CurrentSession);

                return _repositorio;
            }
            set { _repositorio = value; }
        }
        private Int64 ID;
        HelpDesk.Dominio.Entidades.Estacao estacao;
        protected void Page_Load(object sender, EventArgs e)
        {
         
            CarregaClientes();
            PanelServidor.Visible = false;
            if (chkServidor.Checked)
            {
                PanelServidor.Visible = true;
            }

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
                    estacao = Repositorio.ObterPorId(ID);
                    txtAdicionais.Text = estacao.Adicionais;
                    txtIdentificacaoRemota.Text = estacao.IdentificacaoRemota;
                    txtIP.Text = estacao.IP;
                    txtNomeComputador.Text = estacao.NomeComputador;
                    txtSenhaManger.Text = estacao.SenhaAdministrador;
                    txtSenhaRoot.Text = estacao.SenhaRoot;
                    txtSolicitante.Text = estacao.Solicitante;
                    txtUserManager.Text = estacao.UsuarioAdministrador;
                    txtUserRoot.Text = estacao.UsuarioRoot;
                    cmbCliente.SelectedValue = estacao.Clientes.Nome;
                    cmbSO.SelectedValue = estacao.SistemaOperacional;
                }
            }
        }
        private void CarregaClientes()
        {
            RepositorioCliente RepClientes = new RepositorioCliente(NHibernateHttpModule.CurrentSession);
            IList<HelpDesk.Dominio.Entidades.Cliente> clientes = RepClientes.ObterTodos();
            cmbCliente.DataSource = clientes;
            cmbCliente.DataBind();
        }

        protected void lnkOK_Click(object sender, EventArgs e)
        {
            RepositorioCliente RepClientes = new RepositorioCliente(NHibernateHttpModule.CurrentSession);
            try
            {
                if (ID != 0)
                    estacao = Repositorio.ObterPorId(ID);
                else
    
                estacao = new HelpDesk.Dominio.Entidades.Estacao();
                estacao.NomeComputador = txtNomeComputador.Text;
                estacao.Situacao = HelpDesk.Dominio.ObjetosValor.Situacao.Ativo;
                estacao.Solicitante = txtSolicitante.Text;
                estacao.Clientes = RepClientes.ObterPorId(Int64.Parse(cmbCliente.SelectedValue.ToString()));
                estacao.IP = txtIP.Text;
                estacao.SistemaOperacional = cmbSO.SelectedValue.ToString();
                estacao.UsuarioRoot = txtUserRoot.Text;
                estacao.SenhaRoot = txtSenhaRoot.Text;
                estacao.UsuarioAdministrador = txtUserManager.Text;
                estacao.SenhaAdministrador = txtSenhaManger.Text;
                estacao.IdentificacaoRemota = txtIdentificacaoRemota.Text;
                estacao.Adicionais = txtAdicionais.Text;

                if (ID == 0)
                    Repositorio.Salvar(estacao);
                else
                {
                    estacao.ID = ID;
                    Repositorio.Alterar(estacao);
                }

                Response.Redirect("Estacao.aspx");
            }
            catch (ArgumentException ex)
            {
               
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Estacao.aspx");
        }
 
    }
}
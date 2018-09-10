using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelpDesk.Repositorio;
using HelpDesk.Dominio.ObjetosValor;
using HelpDesk.Repositorio.Mapeamento;

namespace WebApp.Admin
{
    public partial class ClienteCadastro : System.Web.UI.Page
    {
        private RepositorioCliente _repositorio;
        public RepositorioCliente Repositorio
        {
            get
            {
                if (_repositorio == null)
                    _repositorio = new RepositorioCliente(NHibernateHttpModule.CurrentSession);

                return _repositorio;
            }
            set { _repositorio = value; }
        }

        private Int64 ID;
        HelpDesk.Dominio.Entidades.Cliente cliente;
        HelpDesk.Dominio.Entidades.Cidades cidade;

        protected void Page_Load(object sender, EventArgs e)
        {

            CarregaCidades();

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
                    cliente = Repositorio.ObterPorId(ID);
                    txtBairro.Text = cliente.Bairro;
                    txtCelular.Text = cliente.Celular;
                    txtCep.Text = cliente.Cep;
                    txtCnpj.Text = cliente.Cnpj;
                    txtEmail.Text = cliente.Email;
                    txtEndereco.Text = cliente.Endereco;
                    txtFax.Text = cliente.Fax;
                    txtIEstadual.Text = cliente.InscricaoEstadual;
                    txtNome.Text = cliente.Nome;
                    txtTelefone.Text = cliente.Telefone;
                    RepositorioCidade RepClientes = new RepositorioCidade(NHibernateHttpModule.CurrentSession);
                    IList<HelpDesk.Dominio.Entidades.Cidades> cidade = RepClientes.ObterTodos();
                    cliente = Repositorio.ObterPorId(ID);
                    cmbCidade.SelectedIndex = cidade.IndexOf(cliente.Cidade);
                }
            }

        }
        
       
        protected void lnkOK_Click(object sender, EventArgs e)
        {
            RepositorioCidade RepCidade= new RepositorioCidade(NHibernateHttpModule.CurrentSession);
            try
            {
               
                cliente = new HelpDesk.Dominio.Entidades.Cliente();
                cidade = new HelpDesk.Dominio.Entidades.Cidades();



                cidade = new HelpDesk.Dominio.Entidades.Cidades();


                cliente.Nome = txtNome.Text.Trim(); //trim ele tira o espaço
                cliente.Bairro = txtBairro.Text.Trim();
                cliente.Celular= txtCelular.Text.Trim();
                cliente.Cep = txtCep.Text.Trim();
                cliente.Cidade = RepCidade.ObterPorId(Int64.Parse(cmbCidade.SelectedValue.ToString()));
                cliente.Cnpj= txtCnpj.Text.Trim();
                cliente.Email= txtEmail.Text.Trim();
                cliente.Endereco= txtEndereco.Text.Trim();
                cliente.Fax = txtFax.Text.Trim();
                cliente.InscricaoEstadual = txtIEstadual.Text.Trim();
                cliente.Telefone = txtTelefone.Text.Trim();
                cliente.Situacao = HelpDesk.Dominio.ObjetosValor.Situacao.Ativo;


                if (ID == 0)
                    Repositorio.Salvar(cliente);
                else
                {
                    cliente.ID = ID;
                    Repositorio.Alterar(cliente);
                }

                Response.Redirect("Cliente.aspx");

            }
            catch (ArgumentException ex)
            {
              
                return;
            }

        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cliente.aspx");
        }

        private void CarregaCidades()
        {
            RepositorioCidade RepCidades = new RepositorioCidade(NHibernateHttpModule.CurrentSession);
            IList<HelpDesk.Dominio.Entidades.Cidades> cidades = RepCidades.ObterTodos();
            cmbCidade.DataSource = cidades;
            cmbCidade.DataBind();
        }
       
        




    }
}
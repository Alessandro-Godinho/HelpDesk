using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelpDesk.Repositorio;
using HelpDesk.Dominio.ObjetosValor;

namespace WebApp
{
    public partial class ChamadoCadastro : System.Web.UI.Page
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
        HelpDesk.Dominio.Entidades.Atualizacao software;
        HelpDesk.Dominio.Entidades.Usuario usuario;
        HelpDesk.Dominio.ObjetosValor.TipoOcorrencia tipoOcorrencia;

        protected void Page_Load(object sender, EventArgs e)
        {

            LbeErro.Visible = false;//aqui meu label esta inativo

            dateDataFechamento.Visible = false;
            cmbUsuarioChamado.Visible = false;
            Label_Erro_chamado.Visible = false;
            cmbUsuarioChamado.Visible = false;
            dateDataAbertura.Focus();
            dateDataAbertura.Focus();


            if (Request.QueryString["id"] != null)
                ID = Int64.Parse(Request.QueryString["id"].ToString());

            if (!IsPostBack)
            {
                RepositorioCliente RepCliente = new RepositorioCliente(NHibernateHttpModule.CurrentSession);
                IList<HelpDesk.Dominio.Entidades.Cliente> clientes = RepCliente.ObterTodos(Situacao.Ativo);//mudei aqui a situacao nao tinha

                cmbClienteChamado.DataSource = clientes;
                cmbClienteChamado.DataBind();

               

                //RepositorioUsuario RepUsuario = new RepositorioUsuario(NHibernateHttpModule.CurrentSession);
                //IList<HelpDesk.Dominio.Entidades.Usuario> usuarios = RepUsuario.ObterTodos(Situacao.Ativo);

                //cmbUsuarioChamado.DataSource = usuarios;
                //cmbUsuarioChamado.DataBind();

                cmbTipoOcorrencia.DataSource = Enum.GetValues(typeof(TipoOcorrencia));
                cmbTipoOcorrencia.DataBind();

                dropSituacaoChamado.DataSource = Enum.GetValues(typeof(SituacaoChamado));
                dropSituacaoChamado.DataBind();

                if (ID != 0)
                {
                    chamado = Repositorio.ObterPorId(ID);
                    dateDataAbertura.Date = chamado.DataAbertura;
                    cmbClienteChamado.SelectedIndex = clientes.IndexOf(chamado.Cliente);
                   
                    //cmbUsuarioChamado.SelectedIndex = usuarios.IndexOf(chamado.Usuario);
                    cmbTipoOcorrencia.SelectedIndex = chamado.TipoOcorrencia.GetHashCode();
                    dropSituacaoChamado.SelectedIndex = chamado.SituacaoChamado.GetHashCode();
                    txtHistoricoChamado.Text = chamado.Descricao;
                }
            }
        }

        protected void btnIncluirChamado_Click(object sender, EventArgs e)
        {

            try
            {

                if (ID != 0)
                    chamado = Repositorio.ObterPorId(ID);
                else
                    chamado = new HelpDesk.Dominio.Entidades.Chamado();
                cliente = new HelpDesk.Dominio.Entidades.Cliente();
                software = new HelpDesk.Dominio.Entidades.Atualizacao();
                usuario = new HelpDesk.Dominio.Entidades.Usuario();

                // chamado.DataAbertura = dateDataAbertura.Date;
                chamado.DataAbertura = DateTime.Now;//aqui pega a data atual do conputador automatico...
                // chamado.DataFechamento = dateDataFechamento.Date;//aqui pega a data no dia que for fechado o chamado do cliente...
                chamado.DataFechamento = DateTime.Now;
                chamado.Cliente = new RepositorioCliente(NHibernateHelper.GetSession()).ObterPorId(Int64.Parse(cmbClienteChamado.SelectedValue));
                 //chamado.Usuario = new RepositorioUsuario(NHibernateHelper.GetSession()).ObterPorId(Int64.Parse(cmbUsuarioChamado.SelectedValue));
                chamado.Usuario = User.Identity.Name;
                chamado.TipoOcorrencia = (TipoOcorrencia)cmbTipoOcorrencia.SelectedIndex;

                chamado.Descricao = txtHistoricoChamado.Text;
                chamado.SituacaoChamado = (SituacaoChamado)dropSituacaoChamado.SelectedIndex;

                chamado.Situacao = HelpDesk.Dominio.ObjetosValor.Situacao.Ativo;

                if (ID == 0)
                    Repositorio.Salvar(chamado);
                else
                    Repositorio.Alterar(chamado);

                Response.Redirect("Chamado.aspx");

            }
            catch (ArgumentException ex)
            {
                Label_Erro_chamado.Visible = true;
                LbeErro.Visible = true;
                LbeErro.Text = String.Format("Não foi possível completar o cadastro.{0}", ex.Message);
                dateDataAbertura.Focus();
                return;
            }
            //catch (Exception ex)
            //{

            //}

        }

    }
}



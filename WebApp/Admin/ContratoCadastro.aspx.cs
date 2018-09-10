using System;
using System.Collections.Generic;
using HelpDesk.Repositorio;
using HelpDesk.Dominio.ObjetosValor;

namespace WebApp.Admin
{
    public partial class ContratoCadastro : System.Web.UI.Page
    {
        private RepositorioContrato _repositorio;
        public RepositorioContrato Repositorio
        {
            get
            {
                if (_repositorio == null)
                    _repositorio = new RepositorioContrato(NHibernateHttpModule.CurrentSession);

                return _repositorio;
            }
            set { _repositorio = value; }
        }

        private Int64 ID;
        HelpDesk.Dominio.Entidades.Contrato contrato;
        HelpDesk.Dominio.Entidades.Cliente cliente;
        HelpDesk.Dominio.Entidades.Atualizacao software;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            datadeInicio.Focus();
         
            
            if (Request.QueryString["id"] != null)
                ID = Int64.Parse(Request.QueryString["id"].ToString());


            if (!IsPostBack)
            {
                RepositorioCliente RepCliente = new RepositorioCliente(NHibernateHttpModule.CurrentSession);
                IList<HelpDesk.Dominio.Entidades.Cliente> clientes = RepCliente.ObterTodos(Situacao.Ativo);//mudei aqui a situacao nao tinha

                cmbCliente.DataSource = clientes;
                cmbCliente.DataBind();
                
               /* RepositorioAtualizacao RepSoftware = new RepositorioAtualizacao(NHibernateHttpModule.CurrentSession);
                IList<HelpDesk.Dominio.Entidades.Atualizacao> softwares = RepSoftware.ObterTodos(Situacao.Ativo);//mudei aqui a situacao nao tinha

                cmbSoftware.DataSource = softwares;
                cmbSoftware.DataBind();*/
                

                if (ID != 0)
                {
                    contrato = Repositorio.ObterPorId(ID);
                    datadeInicio.Date = contrato.DataInicio;
                    //contrato.DataInicio = datadeInicio.Date;
                    datadeTermino.Date = contrato.DataTermino;
                   // contrato.DataTermino = datadeTermino.Date;
                    cmbCliente.SelectedIndex = clientes.IndexOf(contrato.Cliente);
                    //cmbSoftware.SelectedIndex = softwares.IndexOf(contrato.Software);
                    txtDescricao.Text = contrato.Descricao;

                }
            }

        }

        protected void lnkOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID != 0)
                    contrato = Repositorio.ObterPorId(ID);
                else
                    contrato = new HelpDesk.Dominio.Entidades.Contrato();


                cliente = new HelpDesk.Dominio.Entidades.Cliente();

                contrato.DataInicio = DateTime.Parse(datadeInicio.Date.ToShortDateString());
                contrato.DataTermino = DateTime.Parse(datadeTermino.Date.ToShortDateString());
                contrato.Cliente = new RepositorioCliente(NHibernateHelper.GetSession()).ObterPorId(Int64.Parse(cmbCliente.SelectedValue.Trim()));
                contrato.Descricao = txtDescricao.Text.Trim();
                contrato.Situacao = HelpDesk.Dominio.ObjetosValor.Situacao.Ativo;

              
                if (ID == 0)
                    Repositorio.Salvar(contrato);
                else
                    Repositorio.Alterar(contrato);

                Response.Redirect("Contrato.aspx");
            }
            catch (ArgumentException ex)
            {
               
                
                //Label_erro.Text = String.Format("Não foi possível completar o cadastro.{0}", ex.Message);
                datadeInicio.Focus();
                return;
            }
            catch (Exception ex)
            { 
            
            }
        }

      
      



    }
}
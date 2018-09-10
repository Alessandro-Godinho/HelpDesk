using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using HelpDesk.Dominio;
using HelpDesk.Repositorio;
using HelpDesk.Dominio.ObjetosValor;
using System.Drawing;


namespace WebApp.Admin
{
    public partial class ScriptBanco : System.Web.UI.Page
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
        HelpDesk.Dominio.Entidades.ScriptBanco script;
        private Int64 ID;
        string NomeArquivo =null;
        TextWriter arquivo;
        bool b=false;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            gvwDados.Visible = false;
            if (chkVerTodos.Checked)
            {
                gvwDados.Visible = true;
                CarregaGrid();
            }

            
        }
        private void CarregaGrid()
        {
            
            script = new HelpDesk.Dominio.Entidades.ScriptBanco();
            // ID = Int64.Parse( Request.QueryString["Clientes_id"]);
            // IDictionary<String, Object> lista = new Dictionary<String, Object>();
            //lista.Add("Descricao",clientes.Descricao);

            if (!chkMostraInativos.Checked)
                gvwDados.DataSource = Repositorio.ObterTodos(Situacao.Ativo);
            else
                gvwDados.DataSource = Repositorio.ObterTodos(Situacao.Inativo);

            gvwDados.DataBind();

        }
        private void GerarScripts()
        {
            
             //NomeArquivo =  Server.MapPath("~/temp/script.txt");
             NomeArquivo = String.Format("{0}{1}.txt", Server.MapPath("~/Temp/"), Path.GetFileName(Path.GetRandomFileName()));
             using (StreamWriter arquivo = new StreamWriter(NomeArquivo, false))
             {

                   //if (!File.Exists(NomeArquivo))
                    //   File.Create(NomeArquivo);

                 foreach (var Scripts in Repositorio.ObterTodos())
                 {                         
                         if (Scripts.DataScript.Date >= datainicio.Date && Scripts.DataScript.Date <= datafim.Date ||
                             Scripts.DataScript.ToLongDateString().Equals(datainicio.Date.ToLongDateString()) && Scripts.DataScript.ToLongDateString()
                             .Equals(datafim.Date.ToLongDateString()))
                         {
                             if (Scripts.Situacao.Equals(Situacao.Ativo)&&b.Equals(false))
                                  arquivo.WriteLine(Scripts.Script);
                             if(b.Equals(true) && datainicio.Date.Equals(Scripts.DataScript))
                            arquivo.WriteLine(Scripts.Script);
                         }
                     
                 }
                 b = false;
                 arquivo.Flush();
                 arquivo.Close();
             }

        }
        private void Download()
        {
            Session.Add("Caminho",NomeArquivo);
            Response.Redirect("Default.aspx");

        }

        

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            gvwDados.Visible = true;
            CarregaGrid();
        }

        protected void btngerarscript_Click(object sender, EventArgs e)
        {
            if (datafim.Date >= datainicio.Date)
            {

                GerarScripts();

                if (datainicio.Value != null && datafim.Value != null)
                    Download();

            }


        }

        protected void btndownload_Click(object sender, ImageClickEventArgs e)
        {
            String DataLinhaEscolhida = "DataScript";
            DataLinhaEscolhida =  gvwDados.GetRowValues(gvwDados.FocusedRowIndex,DataLinhaEscolhida).ToString();
            datainicio.Date = DateTime.Parse(DataLinhaEscolhida);
            datafim.Date = datainicio.Date;
            b = true; 
            GerarScripts();
            Download();
        }

        protected void btneditar_Click(object sender, ImageClickEventArgs e)
        {
            int teste = gvwDados.FocusedRowIndex;
           // HelpDesk.Dominio.Entidades.ScriptBanco script = new HelpDesk.Dominio.Entidades.ScriptBanco();
            HelpDesk.Dominio.Entidades.ScriptBanco script = gvwDados.GetRow(gvwDados.FocusedRowIndex) as HelpDesk.Dominio.Entidades.ScriptBanco;
            Response.Redirect(String.Format("~/Admin/ScriptBancoCadastro.aspx?id={0}", script.ID));
        }

        protected void btnexcluir_Click(object sender, ImageClickEventArgs e)
        {
            HelpDesk.Dominio.Entidades.ScriptBanco script = gvwDados.GetRow(gvwDados.FocusedRowIndex) as HelpDesk.Dominio.Entidades.ScriptBanco;
            script.Situacao = (script.Situacao.Equals(Situacao.Ativo) ? Situacao.Inativo : Situacao.Ativo);
            try
            {
                Repositorio.Alterar(script);
                CarregaGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnexcluir_Load(object sender, EventArgs e)
        {
            ((ImageButton)sender).Visible = !chkMostraInativos.Checked;
        }

        protected void btnrecuperar_Load(object sender, EventArgs e)
        {
            ((ImageButton)sender).Visible = chkMostraInativos.Checked;
        }
    }
}
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="AtualizacaoCadastro.aspx.cs" Inherits="WebApp.Admin.AtualizacaoCadastro" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">

        function validate() {
            if (document.getElementById("<%=data_atualizacao.ClientID%>").value == "") {
                alert("O campo DATA não podera ficar em branco ");
                document.getElementById("<%=data_atualizacao.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=cmbCliente.ClientID%>").value == "") {
                alert("O campo CLIENTE não podera ficar em branco ");
                document.getElementById("<%=cmbCliente.ClientID%>").focus();
                return false;
            }
        }

    </script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="organizaPanelSoftwaretudo">
        <!----  <div id="organizaPanelSoftware">
      --->
        <fieldset>
            <!---crei a borda do formulario -->
            <legend>Cadastro de Atualização</legend>
            <p>
                &nbsp;Data:<br />
                <dx:aspxdateedit ID="data_atualizacao" runat="server" ClientIDMode="AutoID">
                </dx:aspxdateedit>
          
            <p>
                Cliente:<br />
                <asp:DropDownList ID="cmbCliente" runat="server" Width="112px" 
                    DataMember="Nome" DataTextField="Nome" DataValueField="ID">
                </asp:DropDownList>
            </p>
            <p>
                <asp:LinkButton ID="lnkOK" runat="server" OnClick="lnkOK_Click" OnClientClick="return validate()">OK</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lnkCancelar" runat="server" 
                    PostBackUrl="~/Admin/Atualizacao.aspx" onclick="lnkCancelar_Click">Cancelar</asp:LinkButton>
            </p>
        </fieldset>
        <!---aqui fecho a minha borda---->
    </div>
    <!----</div>
    --->
</asp:Content>

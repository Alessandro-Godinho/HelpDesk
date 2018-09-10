<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="CidadeCadastro.aspx.cs" Inherits="WebApp.Admin.CidadeCadastro" %>

<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">
        function validate() {

            //Nome da Cidade
            if (document.getElementById("<%=txtNome.ClientID%>").value == "") {
                alert("O campo Nome não podera ficar em branco ");
                document.getElementById("<%=txtNome.ClientID%>").focus();
                return false;
            }
            //Unidade Federal
            if (document.getElementById("<%=cmbUF.ClientID%>").value == "") {
                alert("O campo UNIDADE FEDERAL não podera ficar em branco ");
                document.getElementById("<%=cmbUF.ClientID%>").focus();
                return false;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="organizapanelcidadetudo">
        <fieldset>
            <legend>Cadastro de Cidades</legend>
            <!--- <div id="organizaPanelCidade">--->
            <p>
                &nbsp;Cidade:<br />
                <asp:TextBox ID="txtNome" runat="server" Width="266px" MaxLength="100"></asp:TextBox>
            </p>
            <div id="organizaLabelErroCidade">
                <asp:Label ID="Label_Erro_cidade" runat="server" Text="Erro:" ForeColor="Red"></asp:Label>&nbsp;
                <asp:Label ID="Label_Erro_nome" runat="server" Text="Label" ForeColor="Red"></asp:Label>
            </div>
            <p>
                Estado:<br />
                <asp:DropDownList ID="cmbUF" runat="server" Height="20px" Width="52px">
                    <asp:ListItem>AC</asp:ListItem>
                    <asp:ListItem>AL</asp:ListItem>
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>AP</asp:ListItem>
                    <asp:ListItem>BA</asp:ListItem>
                    <asp:ListItem>CE</asp:ListItem>
                    <asp:ListItem>DF</asp:ListItem>
                    <asp:ListItem>ES</asp:ListItem>
                    <asp:ListItem>GO</asp:ListItem>
                    <asp:ListItem>MA</asp:ListItem>
                    <asp:ListItem>MG</asp:ListItem>
                    <asp:ListItem>MS</asp:ListItem>
                    <asp:ListItem>MT</asp:ListItem>
                    <asp:ListItem>PA</asp:ListItem>
                    <asp:ListItem>PB</asp:ListItem>
                    <asp:ListItem>PE</asp:ListItem>
                    <asp:ListItem>PI</asp:ListItem>
                    <asp:ListItem>PR</asp:ListItem>
                    <asp:ListItem>RJ</asp:ListItem>
                    <asp:ListItem>RN</asp:ListItem>
                    <asp:ListItem>RO</asp:ListItem>
                    <asp:ListItem>RR</asp:ListItem>
                    <asp:ListItem>RS</asp:ListItem>
                    <asp:ListItem>SC</asp:ListItem>
                    <asp:ListItem>SE</asp:ListItem>
                    <asp:ListItem>SP</asp:ListItem>
                    <asp:ListItem>TO</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:LinkButton ID="lnkOK" runat="server" OnClick="lnkOK_Click">OK</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lnkCancelar" runat="server" PostBackUrl="~/Admin/Cidade.aspx"
                    OnClick="lnkCancelar_Click">Cancelar</asp:LinkButton>
            </p>
            <!--- </div>---->
        </fieldset>
    </div>
</asp:Content>

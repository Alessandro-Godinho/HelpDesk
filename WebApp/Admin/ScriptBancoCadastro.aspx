<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ScriptBancoCadastro.aspx.cs" Inherits="WebApp.Admin.ScriptBancoCadastro" %>
<%@ Register assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDataView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="organizaPanelCliente">
        <fieldset>
            <legend>Adicionar Script </legend>
            DESCRICAO: <br />
            <dx:ASPxTextBox ID="txtdescricao" runat="server" Width="335px" 
                    ClientIDMode="AutoID"></dx:ASPxTextBox><br />
            SCRIPT:<br />
            <asp:TextBox ID="txtscript" runat="server" Height="288px" TextMode="MultiLine" 
                    Width="70%"></asp:TextBox><br />

                 <xxxxelmt></xxxxelmt> <asp:LinkButton ID="lnkOK" runat="server" onclick="lnkOK_Click">OK</asp:LinkButton> 
                 <asp:LinkButton ID="lnkCancelar" runat="server" PostBackUrl="~/Admin/ScriptBanco.aspx">Cancelar</asp:LinkButton> </fieldset> </div> 
</asp:Content>
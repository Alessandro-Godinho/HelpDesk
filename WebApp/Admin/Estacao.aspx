<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Estacao.aspx.cs" Inherits="WebApp.Admin.Estacao" %>

<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="gvwDados" runat="server" AutoGenerateColumns="False" Width="95%"
        KeyFieldName="ID" Style="text-align: right" ClientIDMode="AutoID">
        <Templates>
            <StatusBar>
                <asp:LinkButton ID="lnkNovo" runat="server" OnClick="lnkNovo_Click">Incluir
 Novo Item</asp:LinkButton>
            </StatusBar>
        </Templates>
        <SettingsBehavior AllowFocusedRow="True" />
        <SettingsText EmptyDataRow="..." />
        <Columns>
            <dx:GridViewDataTextColumn Caption="Cliente" FieldName="Clientes.Nome" 
                VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Id Remoto" FieldName="IdentificacaoRemota" 
                VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Usuario Root" FieldName="UsuarioRoot" 
                VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Senha Root" FieldName="SenhaRoot" 
                VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataImageColumn VisibleIndex="4" Width="100px" Caption="Opções">
                <DataItemTemplate>
                    <asp:ImageButton ID="btnAlterar" CssClass="ImageButton" runat="server" ImageUrl="~/Images/Document 2 Edit 2.gif"
                        ToolTip="Alterar" EnableViewState="False" OnClick="btnAlterar_Click" />
                    &nbsp;<asp:ImageButton ID="btnExluir" CssClass="ImageButton" runat="server" ImageUrl="~/Images/Symbol Delete.gif"
                        ToolTip="Excluir" OnClientClick="return window.confirm('Confirma Exclusão?')"
                        OnClick="btnExluir_Click" Style="height: 16px" OnLoad="btnExcluir_Load" />
                    <asp:ImageButton ID="btnRecuperar" CssClass="ImageButton" runat="server" ImageUrl="~/Images/Symbol Check.gif"
                        ToolTip="Recuperar" OnClientClick="return window.confirm('Confirma Recuperar registro excluído?')"
                        OnClick="btnExluir_Click" OnLoad="btnRecuperar_Load" />
                    &nbsp;
                </DataItemTemplate>
            </dx:GridViewDataImageColumn>
        </Columns>
        <SettingsPager PageSize="25" Mode="ShowAllRecords">
        </SettingsPager>
        <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
    </dx:ASPxGridView>
    <br />
    <asp:CheckBox ID="chkMostrarInativos" runat="server" Text="Ver Excluídos" AutoPostBack="true" />
    <br />
</asp:Content>

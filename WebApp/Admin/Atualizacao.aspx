<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Atualizacao.aspx.cs" Inherits="WebApp.Admin.Atualizacao" %>
<%@ Register assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDataView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
        <dx:aspxgridview ID="gvwDados" runat="server" AutoGenerateColumns="False" 
            Width="100%" KeyFieldName="ID" style="text-align: right" 
            ClientIDMode="AutoID">
            <Templates>
                <StatusBar>
                    <asp:LinkButton ID="lnkNovo" runat="server" onclick="lnkNovo_Click">Incluir
 Novo Item</asp:LinkButton>
                </StatusBar>
            </Templates>
            <SettingsBehavior AllowFocusedRow="True" />
            <SettingsText EmptyDataRow="..." />
            <Columns>
                <dx:gridviewdatatextcolumn Caption="Clientes" FieldName="Clientes.Nome" 
                    VisibleIndex="0" Width="400px">
                </dx:gridviewdatatextcolumn>
                <dx:gridviewdatatextcolumn Caption="Data" FieldName="DataAtualizacao" 
                    VisibleIndex="1">
                </dx:gridviewdatatextcolumn>
                <dx:gridviewdatatextcolumn Caption="Usuario" FieldName="Usuario" 
                    VisibleIndex="2">
                </dx:gridviewdatatextcolumn>
                <dx:gridviewdataimagecolumn VisibleIndex="3" Width="100px" Caption="Opções">
                    <DataItemTemplate>
                        <asp:ImageButton ID="btnAlterar" CssClass="ImageButton" runat="server" 
                            ImageUrl="~/Images/Document 2 Edit 2.gif" ToolTip="Alterar" 
                            EnableViewState="False" onclick="btnAlterar_Click" />
                        &nbsp;<asp:ImageButton ID="btnExluir" CssClass="ImageButton" runat="server" 
                            ImageUrl="~/Images/Symbol Delete.gif" ToolTip="Excluir" 
                            OnClientClick="return window.confirm('Confirma Exclusão?')" 
                            onclick="btnExluir_Click" style="height: 16px" 
                            onload="btnExcluir_Load"/>
                            <asp:ImageButton ID="btnRecuperar" CssClass="ImageButton" runat="server" 
                            ImageUrl="~/Images/Symbol Check.gif" ToolTip="Recuperar" 
                            OnClientClick="return window.confirm('Confirma Recuperar registro excluído?')" 
                            onclick="btnExluir_Click" 
                            onload="btnRecuperar_Load"/>
                        &nbsp;
                    </DataItemTemplate>
                </dx:gridviewdataimagecolumn>
            </Columns>
            <SettingsPager PageSize="25" Mode="ShowAllRecords">
            </SettingsPager>
            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
        </dx:aspxgridview>
        <br />
        <asp:CheckBox ID="chkMostrarInativos" runat="server" Text="Ver Excluídos" 
        AutoPostBack="true"  />        
        <br />
        <asp:CheckBox ID="chkVerTodos" runat="server" Text="Ver Todos" AutoPostBack="true" />        
        <br />
</asp:Content>

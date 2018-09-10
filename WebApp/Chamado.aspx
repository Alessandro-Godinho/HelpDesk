<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Chamado.aspx.cs" Inherits="WebApp.Chamado" %>
<%@ Register assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDataView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table class="style1">
            <tr>
                <td colspan="2">
        <dx:ASPxGridView ID="gvwDados" runat="server" AutoGenerateColumns="False" 
            Width="99%" KeyFieldName="ID" style="text-align: right" 
            ClientIDMode="AutoID">

            <SettingsText EmptyDataRow="..." />

<SettingsBehavior AllowFocusedRow="True"></SettingsBehavior>

            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
            <Columns>
                <dx:GridViewDataTextColumn Caption="Cliente" FieldName="Clientes.Nome" 
                    VisibleIndex="0">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Descricao" FieldName="Descricao" 
                    VisibleIndex="0">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="DataAbertura" FieldName="DataAbertura" 
                    VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="DataFechamento" FieldName="DataFechamento" 
                    VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn ShowInCustomizationForm="True" VisibleIndex="3" 
                    Caption="Opções">
                   <DataItemTemplate><center>

                       <asp:ImageButton ID="btnAlterar" CssClass="ImageButton" runat="server" 
                            ImageUrl="~/Images/Document 2 Edit 2.gif" ToolTip="Alterar" 
                            EnableViewState="False" onclick="btnAlterar_Click" />
                            </center>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsBehavior AllowFocusedRow="True" />

            <SettingsPager PageSize="25" Mode="ShowAllRecords">
            </SettingsPager>

<Settings ShowFilterRow="True" ShowStatusBar="Visible"></Settings>

<SettingsText EmptyDataRow="..."></SettingsText>

            <Templates>
                <StatusBar>
                    <asp:LinkButton ID="lnkNovo" runat="server" onclick="lnkNovo_Click">Incluir
 Novo Item</asp:LinkButton>
                </StatusBar>
            </Templates>
        </dx:ASPxGridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </p>
</asp:Content>

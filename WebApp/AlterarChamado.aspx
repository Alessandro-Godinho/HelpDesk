<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AlterarChamado.aspx.cs" Inherits="WebApp.AlterarChamado" %>

<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="OrganizaPanelAlterarChamado">
        <p>
            <br />
            <table class="style1">
                <tr>
                    <td>
                        Data Abertura
                    </td>
                    <td>
                        <asp:Label ID="lblDataAbertura" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Cliente
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbcliente" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Software
                    </td>
                    <td>
                        <asp:Label ID="lblSoftware" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Usuário
                    </td>
                    <td>
                        <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblErro" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <dx:ASPxGridView ID="gvwDados" runat="server" AutoGenerateColumns="False" Width="99%"
                            KeyFieldName="ID" Style="text-align: right" ClientIDMode="AutoID">
                            <Settings ShowFilterRow="True" ShowStatusBar="Visible"></Settings>
                            <SettingsText EmptyDataRow="..."></SettingsText>
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsText EmptyDataRow="..." />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="Data" VisibleIndex="0" FieldName="DataAbertura">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Usuário" VisibleIndex="1" 
                                    FieldName="Usuario">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Descrição" VisibleIndex="1" FieldName="Descricao">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Situação" VisibleIndex="2" FieldName="Situacao">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsBehavior AllowFocusedRow="True"></SettingsBehavior>
                            <SettingsPager PageSize="25" Mode="ShowAllRecords">
                            </SettingsPager>
                            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                        </dx:ASPxGridView>&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        Novo Histórico
                    </td>
                    <td>
                        <asp:TextBox ID="txtNovoHistorico" runat="server" Rows="6" Style="margin-bottom: 0px"
                            TextMode="MultiLine" Width="778px"></asp:TextBox>&nbsp;
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        Situação Chamado
                    </td>
                    <td>
                        <asp:DropDownList ID="ddownSituacaoChamado" runat="server" Width="300px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="BtnAlteraChamado" runat="server" Text="Atualizar Chamado" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </p>
    </div>
</asp:Content>

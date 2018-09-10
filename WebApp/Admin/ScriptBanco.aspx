<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ScriptBanco.aspx.cs" Inherits="WebApp.Admin.ScriptBanco" %>
<%@ Register assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDataView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

Data Inicial:
    <dx:ASPxDateEdit ID="datainicio"  runat="server" ClientIDMode="AutoID">
    </dx:ASPxDateEdit>
    Data Final:
&nbsp;<dx:ASPxDateEdit ID="datafim"  runat="server" ClientIDMode="AutoID">
    </dx:ASPxDateEdit><br />
    <dx:ASPxButton ID="btngerarscript" runat="server" Text="Gerar Script" 
        onclick="btngerarscript_Click" Height="21px" Width="120px">
    </dx:ASPxButton>
    <br />
    <dx:ASPxGridView ID="gvwDados" runat="server" AutoGenerateColumns="False" 
        ClientIDMode="AutoID" KeyFieldName="ID" Width="100%">
        <Columns>
            <dx:GridViewDataTextColumn Caption="Descricao" FieldName="Descricao" 
                ShowInCustomizationForm="True" VisibleIndex="0" Width="55%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="DataLançamento" FieldName="DataScript" 
                ShowInCustomizationForm="True" VisibleIndex="1" Width="15%">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Opcoes" ShowInCustomizationForm="True" 
                VisibleIndex="3" Width="15%">
                <DataItemTemplate>
                    <asp:ImageButton ID="btndownload" runat="server" 
                        ImageUrl="~/Images/donwload.gif" onclick="btndownload_Click" />
                    <asp:ImageButton ID="btneditar" runat="server"  
                        ImageUrl="~/Images/Document 2 Edit 2.gif" onclick="btneditar_Click" 
                        ToolTip="Alterar" EnableViewState="False" />
                    <asp:ImageButton ID="btnexcluir" runat="server" 
                        ImageUrl="~/Images/Symbol Delete.gif" onclick="btnexcluir_Click" 
                        onload="btnexcluir_Load" ToolTip="Excluir" OnClientClick="return window.confirm('Confirma Exclusão?')"
                        Style="height: 16px" />
                    <asp:ImageButton ID="btnrecuperar" runat="server" 
                        ImageUrl="~/Images/Symbol Check.gif" onclick="btnexcluir_Click" 
                        onload="btnrecuperar_Load"  ToolTip="Recuperar" OnClientClick="return window.confirm('Confirma Recuperar registro excluído?')" />
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsBehavior AllowFocusedRow="True" />
        <SettingsPager Mode="ShowAllRecords" PageSize="25">
        </SettingsPager>
        <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
        <SettingsText EmptyDataRow="..." />
        <Templates>
            <StatusBar>

                <asp:LinkButton ID="lnkNovo" runat="server"
                    PostBackUrl="~/Admin/ScriptBancoCadastro.aspx">Incluir
 Novo Item</asp:LinkButton>
                <br />
            </StatusBar>
        </Templates>
    </dx:ASPxGridView>
     <br />
        <asp:CheckBox ID="chkMostraInativos" runat="server" Text="Ver Excluídos" 
        AutoPostBack="true" />        
        <br />
        <asp:CheckBox ID="chkVerTodos" runat="server" Text="Ver Todos" 
        AutoPostBack="true" Checked="True"  />        
        <br />
</asp:Content>

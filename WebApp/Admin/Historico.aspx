<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Historico.aspx.cs" Inherits="WebApp.Admin.Historico" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx1" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 44px;
        }
        .dataFechamento
        {
            width: 30px;
        }
        .style9
        {
            width: 139px;
        }
        .style10
        {
            width: 149px;
        }
        .style11
        {
            width: 38px;
        }
        .style12
        {
            width: 125px;
        }
        .style13
        {
            width: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="OrganizaPanelChamadoCadastro">
        <fieldset>
            <legend>Pesquisa Historico</legend>
            <p>
                <br />
                <table class="style1">
                    <tr>
                        <td class="style10">
                            &nbsp;Data Inicial&nbsp;
                        </td>
                        <td>
                            &nbsp;
                            <dx:ASPxDateEdit ID="dateDataInicial" runat="server" Width="192px">
                            </dx:ASPxDateEdit>
                            &nbsp;
                        </td>
                        <td class="style11">
                            Final
                        </td>
                        <td>
                            &nbsp;
                            <dx:ASPxDateEdit ID="dateDataInicialFim" runat="server" Width="192px">
                            </dx:ASPxDateEdit>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <!------------------------------------------------------------>
                <table class="style1">
                    <tr>
                        <td class="style10">
                            Cliente</td>
                        <td>
                           &nbsp;
                            <dx:ASPxDateEdit ID="dateDataFechamento" runat="server" Width="192px">
                            </dx:ASPxDateEdit>
                            &nbsp;
                        </td>
                        <td class="style11">
                            &nbsp;</td>
                        <td>
                           &nbsp;
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <!---------------------------------------------------------->
                <table class="style1">
                    <tr>
                        <td class="style9">
                            &nbsp;Usuário &nbsp;
                         </td>
                        <td>
                            &nbsp;
                            <asp:DropDownList ID="cmbUsuario" runat="server" Height="20px" Width="255px" DataValueField="UserName"
                                DataTextField="UserName">
                            </asp:DropDownList>
                            &nbsp;
                        </td>
                        <td class="style12">
                            &nbsp;</td>
                        <td>
                            &nbsp;
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style9">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td class="style12">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                    <td class="style9"> </td>
                    <td> </td>
                    <td class="style12"> </td>
                    </tr>
                </table>
                <!-------------------------------------------------------------------->
                <table>
                    
                    <tr>
                        <td class="style13">
                            <div id="OrganizaPanelErro">
                                <div id="OrganizalabelErro">
                                    <asp:Label ID="Label_Erro_Consulta" runat="server" Text="Erro:" ForeColor="Red"></asp:Label>&nbsp;
                                    <asp:Label ID="Label_Erro_Mesagem" runat="server" ForeColor="Red" 
                                        Visible="False"></asp:Label>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <dx:ASPxGridView ID="gvwDados" runat="server" Width="820px" AutoGenerateColumns="False"
                    ClientIDMode="AutoID" ClientVisible="False" Visible="False">
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="DataAbertura" FieldName="DataAbertura" ShowInCustomizationForm="True"
                            VisibleIndex="0">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="DataFechamento" FieldName="DataFechamento" 
                            VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Usuario" FieldName="Usuario" 
                            VisibleIndex="2" UnboundType="Object">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Descrição" FieldName="Descricao" ShowInCustomizationForm="True"
                            VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="SituaçãoChamado" 
                            FieldName="SituacaoChamado" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowFilterRow="True" />
                </dx:ASPxGridView>
                <td class="style5">
                    <br />
                </td>
                <table>
                    <tr>
                        <td>
                            <center>
                                <asp:Button ID="btnPesquisarHistorico" runat="server" 
                                    Text="Pesquisar Chamado" />
                            </center>
                        </td>
                    </tr>
                </table>
        </fieldset>
    </div>
</asp:Content>

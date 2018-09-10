<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ChamadoCadastro.aspx.cs" Inherits="WebApp.ChamadoCadastro" %>

<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        
      
    </style>
    <script type="text/javascript" language="javascript">

        function valida() {

            //data de abertura
            if (document.getElementById("<%=dateDataAbertura.ClientID%>").value == "0") {
                alert("O campo Data Abertura não podera ficar em branco ");
                document.getElementById("<%=dateDataAbertura.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=dateDataFechamento.ClientID%>").value == "0") {
                alert("O campo Data Abertura não podera ficar em branco ");
                document.getElementById("<%=dateDataFechamento.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtHistoricoChamado.ClientID%>").value == "") {
                alert("O campo HISTORICO não podera ficar em branco ");
                document.getElementById("<%=txtHistoricoChamado.ClientID%>").focus();
                return false;
            }
        }
    
    
    
    
    
    
    
    
    
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="OrganizaPanelChamadoCadastro">
        <fieldset>
            <legend>Cadastro de Chamado</legend>
            <p>
                <br />
                <table class="style1">
                    <tr>
                        <td>
                            Data Abertura
                        </td>
                        <td>
                            <dx:ASPxDateEdit ID="dateDataAbertura" runat="server" Width="192px">
                            </dx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Cliente
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbClienteChamado" runat="server" Height="21px" Width="665px"
                                DataValueField="ID" DataTextField="Nome">
                            </asp:DropDownList>
                        </td>
                    </tr>
                  
                    <tr>
                        <td>

                            <%--Usuário--%>

                            <%--     Usuário--%>

                        </td>
                        <td>
                            <asp:DropDownList ID="cmbUsuarioChamado" runat="server" Height="16px" Width="665px"
                                DataValueField="ID" DataTextField="Nome">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tipo Ocorrência
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbTipoOcorrencia" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%--Data Fechamento--%>
                        </td>
                        <td>
                            <dx:ASPxDateEdit ID="dateDataFechamento" runat="server" Width="192px">
                            </dx:ASPxDateEdit>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <div id="OrganizaPanelErro">
                                <div id="OrganizalabelErro">
                                    <asp:Label ID="Label_Erro_chamado" runat="server" Text="Erro:" ForeColor="Red"></asp:Label>&nbsp;
                                    <dx:ASPxLabel ID="LbeErro" runat="server" ForeColor="Red" Text="ASPxLabel">
                                    </dx:ASPxLabel>
                                    
                                </div>
                            </div>
                        </td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Novo Histórico
                        </td>
                        <td>
                            <asp:TextBox ID="txtHistoricoChamado" runat="server" Rows="6" Style="margin-bottom: 0px"
                                TextMode="MultiLine" Width="762px"></asp:TextBox>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Situação Chamado
                        </td>
                        <td>
                            <asp:DropDownList ID="dropSituacaoChamado" runat="server" Width="300px">
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
                            <asp:Button ID="btnIncluirChamado" runat="server" Text="Atualizar Chamado" OnClick="btnIncluirChamado_Click" />
                        </td>
                    </tr>
                </table>
            </p>
        </fieldset>
    </div>
</asp:Content>

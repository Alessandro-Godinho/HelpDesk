<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="ContratoCadastro.aspx.cs" Inherits="WebApp.Admin.ContratoCadastro" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="organizaPanelContrato">
        <fieldset>
            <legend>Cadastro de Contratos</legend>
                Data Início:
                <dx:ASPxDateEdit ID="datadeInicio" runat="server" ClientIDMode="AutoID">
                </dx:ASPxDateEdit>
                <asp:RequiredFieldValidator ID="Label_erro" runat="server" 
                ControlToValidate="datadeInicio" ErrorMessage="Informe uma data inicial" 
                style="z-index: 1; left: 216px; top: 64px; position: absolute"></asp:RequiredFieldValidator>
                </br>
                Data Término:<dx:ASPxDateEdit ID="datadeTermino" 
                runat="server" ClientIDMode="AutoID">
                </dx:ASPxDateEdit>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="datadeTermino" ErrorMessage="Informe uma data final" 
                style="z-index: 1; left: 216px; top: 116px; position: absolute"></asp:RequiredFieldValidator>
                <br/>
                Cliente:<br />
                <asp:DropDownList ID="cmbCliente" runat="server" Height="20px" Width="619px" DataTextField="Nome"
                    DataValueField="ID">
                </asp:DropDownList>
                <br/><br/>
                Observações:<br />
                <asp:TextBox ID="txtDescricao" runat="server" Height="71px" TextMode="MultiLine"
                    Width="627px" MaxLength="200"></asp:TextBox>
                    <br />
                <asp:LinkButton ID="lnkOK" runat="server" OnClick="lnkOK_Click" OnClientClick="return validate()">OK</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lnkCancelar" runat="server" PostBackUrl="~/Admin/Contrato.aspx">Cancelar</asp:LinkButton>
            <br>
        </fieldset>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="EstacoesCadastro.aspx.cs" Inherits="WebApp.Admin.EstacoesCadastro" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="organizaPanelCliente">
        <fieldset>
            <legend>Cadastro de Estações de Clientes </legend>     
             Cliente:<br /><br />
                <asp:DropDownList ID="cmbCliente" runat="server" DataMember="Nome" 
                DataTextField="Nome" DataValueField="ID">
                </asp:DropDownList><br />

                Solicitante:<asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSolicitante" 
                ErrorMessage="Informe o solicitante" 
                style="z-index: 1; left: 467px; top: 117px; position: absolute"></asp:RequiredFieldValidator>
            <br />
                <dx:ASPxTextBox ID="txtSolicitante" runat="server" Width="400px" MaxLength="100">
                    <ValidationSettings CausesValidation="True" SetFocusOnError="True">
                        <RequiredField ErrorText="Informe a identificacao Remota do computador cliente" 
                            IsRequired="True" />
                    </ValidationSettings>
            </dx:ASPxTextBox>
            <br />   

                Nome Computador:<br />
                <dx:ASPxTextBox ID="txtNomeComputador" runat="server" Width="400px" MaxLength="100">
                    <ValidationSettings>
                        <RequiredField ErrorText="" />
                    </ValidationSettings>
            </dx:ASPxTextBox>
              <div>
                  <br />
                Ident. Remota: 
             <dx:ASPxTextBox ID="txtIdentificacaoRemota" runat="server" Width="120px" ClientIDMode="AutoID">
                 <ValidationSettings CausesValidation="True" Display="Dynamic" 
                     ValidateOnLeave="False">
                     <RequiredField ErrorText="Informar o ID" IsRequired="True" />
                 </ValidationSettings>
                </dx:ASPxTextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                      ControlToValidate="txtIdentificacaoRemota" 
                      ErrorMessage="Informe a identificacao Remota do computador cliente" 
                      style="z-index: 1; left: 175px; top: 235px; position: absolute"></asp:RequiredFieldValidator>
            </div>
            <br />    
                SISTEMA OPERACIONAL:<br />
                <asp:DropDownList ID="cmbSO" runat="server">
                    <asp:ListItem>Windows XP Service Pack 2</asp:ListItem>
                    <asp:ListItem>Windows XP Service Pack 2</asp:ListItem>
                    <asp:ListItem>Windows Seven</asp:ListItem>
                </asp:DropDownList><br /><br />
                IP:&nbsp;<dx:ASPxTextBox ID="txtIP" runat="server" Width="120px" ClientIDMode="AutoID">
                </dx:ASPxTextBox><br />

                <asp:CheckBox ID="chkServidor" Text="Servidor" runat="server" 
                AutoPostBack="True" /><br /><br />

                <asp:Panel ID="PanelServidor" runat="server">
                 Usuario Local: <br />
                <dx:ASPxTextBox ID="txtUserRoot" runat="server" Width="120px" ClientIDMode="AutoID">
                </dx:ASPxTextBox><br /> 
                 Senha Local: 
                    <br />
                 <dx:ASPxTextBox ID="txtSenhaRoot" runat="server" Width="120px" ClientIDMode="AutoID">
                </dx:ASPxTextBox><br />
                Usuario Admin: <br />
                <dx:ASPxTextBox ID="txtUserManager" runat="server" Width="120px" ClientIDMode="AutoID">
                </dx:ASPxTextBox><br />
                Senha Admin: <br />
                 <dx:ASPxTextBox ID="txtSenhaManger" runat="server" Width="120px" ClientIDMode="AutoID">
                </dx:ASPxTextBox>
                </asp:Panel><br />

             Adicionais:<br />
             <asp:TextBox ID="txtAdicionais" runat="server" Height="92px" 
                TextMode="MultiLine" Width="430px"></asp:TextBox><br />
 
                <asp:LinkButton ID="lnkOK" runat="server" OnClick="lnkOK_Click">OK</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lnkCancelar" runat="server" PostBackUrl="~/Admin/Cliente.aspx"
                    OnClick="lnkCancelar_Click">Cancelar</asp:LinkButton>
        </fieldset>
    </div>
</asp:Content>

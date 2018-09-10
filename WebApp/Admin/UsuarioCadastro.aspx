<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="UsuarioCadastro.aspx.cs" Inherits="WebApp.Admin.UsuarioCadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">
        function validate() {
            //NOME DO USUARIO
            if (document.getElementById("<%=txtNome.ClientID%>").value == "") {
                alert("O campo NOME não podera ficar em branco ");
                document.getElementById("<%=txtNome.ClientID%>").focus();
                return false;
            }
            //LOGIN DO USUARIO
            if (document.getElementById("<%=txtLogin.ClientID%>").value == "") {
                alert("O campo LOGIN não podera ficar em branco ");
                document.getElementById("<%=txtLogin.ClientID%>").focus();
                return false;
            }
            //SENHA USUARIO
            if (document.getElementById("<%=txtSenha.ClientID%>").value == "") {
                alert("O campo SENHA não podera ficar em branco ");
                document.getElementById("<%=txtSenha.ClientID%>").focus();
                return false;
            }
            //verifica se esta em sequencia numerada 
            if (document.getElementById("<%=txtSenha.ClientID%>").value == "123456") {
                alert("A seuquencia 123456 não é permitida como senha!");
                document.getElementById("<%=txtSenha.ClientID%>").focus();
                return false;
            } //verifica se a senha do campo 1 esta igual a senha do campo 2
            if (document.getElementById("<%=txtSenha.ClientID%>").value != document.getElementById("<%=txtSenhaConfirmacao.ClientID%>").value) {
                alert("A confirmacao da senha esta diferente do campo senha !");
                document.getElementById("<%=txtSenhaConfirmacao.ClientID%>").focus();
                return false;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="organizaPanelUsuariotudo">
        <div id="organizaPanelUsuario">
            <fieldset>
                <legend>Cadastro de Usuarios</legend>
                <p>
                    &nbsp;Nome:<br />
                    <asp:TextBox ID="txtNome" runat="server" Width="429px" MaxLength="100"></asp:TextBox>
                </p>
                <p>
                    Login:<br />
                    <asp:TextBox ID="txtLogin" runat="server" MaxLength="20" Width="309px"></asp:TextBox>
                </p>
                <p>
                    Senha:<br />
                    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
                </p>
                <p>
                    Confirmação de Senha:<br />
                    <asp:TextBox ID="txtSenhaConfirmacao" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
                </p>
                <p>
                    <asp:LinkButton ID="lnkOK" runat="server" OnClick="lnkOK_Click" OnClientClick="return validate()">OK</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="lnkCancelar" runat="server" PostBackUrl="~/Admin/Usuario.aspx">Cancelar</asp:LinkButton>
                </p>
            </fieldset>
        </div>
    </div>
</asp:Content>

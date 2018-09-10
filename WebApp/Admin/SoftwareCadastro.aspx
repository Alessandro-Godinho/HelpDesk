<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="SoftwareCadastro.aspx.cs" Inherits="WebApp.Admin.SoftwareCadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">

        function validate() {
            if (document.getElementById("<%=txtNome.ClientID%>").value == "") {
                alert("O campo NOME não podera ficar em branco ");
                document.getElementById("<%=txtNome.ClientID%>").focus();
                return false;
            }

            if (document.getElementById("<%=cmbLinguagem.ClientID%>").value == "") {
                alert("O campo LINGUAGEM não podera ficar em branco ");
                document.getElementById("<%=cmbLinguagem.ClientID%>").focus();
                return false;
            }
        }

    </script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="organizaPanelSoftwaretudo">
        <!----  <div id="organizaPanelSoftware">
      --->
        <fieldset>
            <!---crei a borda do formulario -->
            <legend>Cadastro de Software</legend>
            <p>
                &nbsp;Nome:<br />
                <asp:TextBox ID="txtNome" runat="server" MaxLength="100" Width="267px"></asp:TextBox>
                </p>
                <div id="organizaLabelErroSoftware">
                    <asp:Label ID="Label_erro_Software" runat="server" ForeColor="Red" Text="Erro:"></asp:Label>&nbsp;
                    <asp:Label ID="Label_erro" runat="server" ForeColor="Red" Text="Label"></asp:Label>
                </div>
          
            <p>
                Linguagem:<br />
                <asp:DropDownList ID="cmbLinguagem" runat="server" Width="112px">
                </asp:DropDownList>
            </p>
            <p>
                <asp:LinkButton ID="lnkOK" runat="server" OnClick="lnkOK_Click" OnClientClick="return validate()">OK</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lnkCancelar" runat="server" PostBackUrl="~/Admin/Software.aspx">Cancelar</asp:LinkButton>
            </p>
        </fieldset>
        <!---aqui fecho a minha borda---->
    </div>
    <!----</div>
    --->
</asp:Content>

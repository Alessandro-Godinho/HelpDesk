<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="ClienteCadastro.aspx.cs" Inherits="WebApp.Admin.ClienteCadastro" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">
        function validate() {
            //nome
            if (document.getElementById("<%=txtNome.ClientID%>").value == "") {
                alert("O campo Nome não podera ficar em branco ");
                document.getElementById("<%=txtNome.ClientID%>").focus();
                return false;
            }
            //CNPJ
            if (document.getElementById("<%=txtCnpj.ClientID%>").value == "") {
                alert("O campo CNPJ não podera ficar em branco");
                document.getElementById("<%=txtCnpj.ClientID%>").focus();
                return false;
            }
            //        //Inscricao estadual
            //        if (document.getElementById("<%=txtIEstadual.ClientID%>").value == "") {
            //            alert("O campo INSCRIÇÃO ESTADUAL não podera ficar em branco");
            //            document.getElementById("<%=txtIEstadual.ClientID%>").focus();
            //            return false;
            //        }
            //ENDERECO
            if (document.getElementById("<%=txtEndereco.ClientID%>").value == "") {
                alert("O campo ENDEREÇO não podera ficar em branco");
                document.getElementById("<%=txtEndereco.ClientID%>").focus();
                return false;
            }
            //BAIRRO
            if (document.getElementById("<%=txtBairro.ClientID%>").value == "") {
                alert("O campo BAIRRO não podera ficar em branco");
                document.getElementById("<%=txtBairro.ClientID%>").focus();
                return false;
            }
            //CEP
            if (document.getElementById("<%=txtCep.ClientID%>").value == "") {
                alert("O campo CEP não podera ficar em branco");
                document.getElementById("<%=txtCep.ClientID%>").focus();
                return false;
            }
            var digits = "0123456789";
            var temp;
            for (var i = 0; i < document.getElementById("<%=txtCep.ClientID %>").value; i++) {
                temp = document.getElementById("<%=txtCep.ClientID%>").value.substring(i, i + 1);
                if (digits.indexOf(temp) == -1) {
                    alert("Informe o CEP no formato correto");
                    document.getElementById("<%=txtCep.ClientID%>").focus();
                    return false;
                }
            }
            //CIDADE
            if (document.getElementById("<%=cmbCidade.ClientID%>").value == "") {
                alert("O campo CIDADE não podera ficar em branco");
                document.getElementById("<%=cmbCidade.ClientID%>").focus();
                return false;
            }
            //Email
            if (document.getElementById("<%=txtEmail.ClientID %>").value == "") {
                alert("O campo EMAIL não podera ficar em branco");
                document.getElementById("<%=txtEmail.ClientID %>").focus();
                return false;
            }
            var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
            var emailid = document.getElementById("<%=txtEmail.ClientID %>").value;
            var matchArray = emailid.match(emailPat);
            if (matchArray == null) {
                alert("O campo Email esta no formato incorreto. Por favor Tente novamente.");
                document.getElementById("<%=txtEmail.ClientID %>").focus();
                return false;
            }
            //TELEFONE
            //            if (document.getElementById("<%=txtTelefone.ClientID%>").value == "") {
            //                alert("O campo TELEFONE não podera ficar em branco");
            //                document.getElementById("<%=txtTelefone.ClientID%>").focus();
            //                return false;
            //            }


        }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="organizaPanelCliente">
        <fieldset>
            <legend>Cadastro de Clientes </legend>
                NOME:<br />
                <asp:TextBox ID="txtNome" runat="server" Width="400px" MaxLength="100"></asp:TextBox><br />
                <div id="OrganizaPanelErro">
                    <div id="OrganizalabelErro">
                        &nbsp;
                        </div>
                </div>

                CNPJ:
                <dx:ASPxTextBox ID="txtCnpj" runat="server" Width="120px" ClientIDMode="AutoID">
                    <MaskSettings Mask="00.000.000/0000-00" />
                </dx:ASPxTextBox><br />
                <%---------------------------------------------------------------------------------%>

                INSCRIÇÃO ESTADUAL:
                <br />
                <dx:ASPxTextBox ID="txtIEstadual" runat="server" Width="150px" ClientIDMode="AutoID">
                </dx:ASPxTextBox>
                &nbsp;&nbsp;
                <br />
                <%-- <asp:Label ID="Label_erro_telefone" runat="server" Text="Label" ForeColor="Red"></asp:Label>--%>

                ENDEREÇO:<br />
                <asp:TextBox ID="txtEndereco" runat="server" Width="400px" MaxLength="100"></asp:TextBox><br />
                <%-- <asp:Label ID="Label_erro_telefone" runat="server" Text="Label" ForeColor="Red"></asp:Label>--%>

                BAIRRO:<br />
                <asp:TextBox ID="txtBairro" runat="server" Width="300px" MaxLength="100"></asp:TextBox><br />
                <%---------------------------------------------------------------------------------%>
  
                CEP:<dx:ASPxTextBox ID="txtCep" runat="server" Width="100px">
                    <MaskSettings Mask="00000-000" />
                </dx:ASPxTextBox>
                <%-- <asp:Label ID="Label_erro_telefone" runat="server" Text="Label" ForeColor="Red"></asp:Label>--%>
     
            <div>
                <br />
                <asp:UpdatePanel ID="cdadepanel" runat="server">
                    <ContentTemplate>
                    Cidade:<br />
                        <asp:DropDownList ID="cmbCidade" AutoPostBack="true" AppendDataBoundItems="true"
                            runat="server" Height="20px" Width="155px" DataTextField="Nome" 
                            DataValueField="ID" DataMember="Nome">
                        </asp:DropDownList><br />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="cmbCidade" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <%---------------------------------------------------------------------------------%>
                EMAIL:<br />
                <asp:TextBox ID="txtEmail" runat="server" Width="300px" MaxLength="100"></asp:TextBox><br />
                <%-- <asp:Label ID="Label_erro_telefone" runat="server" Text="Label" ForeColor="Red"></asp:Label>--%>

                TELEFONE:<br />
                <dx:ASPxTextBox ID="txtTelefone" runat="server" Width="100px">
                    <MaskSettings Mask="(99) 0000-0000" />
                </dx:ASPxTextBox><br />
                <%-- <asp:Label ID="Label_erro_telefone" runat="server" Text="Label" ForeColor="Red"></asp:Label>--%>

                FAX:<br />
                <dx:ASPxTextBox ID="txtFax" runat="server" Width="100px">
                    <MaskSettings Mask="(99) 0000-0000" />
                </dx:ASPxTextBox><br />
 
                CELULAR:<dx:ASPxTextBox ID="txtCelular" runat="server" Width="100px">
                    <MaskSettings Mask="(99) 0000-0000" />
                </dx:ASPxTextBox><br />

                <asp:LinkButton ID="lnkOK" runat="server" OnClick="lnkOK_Click">OK</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lnkCancelar" runat="server" PostBackUrl="~/Admin/Cliente.aspx"
                    OnClick="lnkCancelar_Click">Cancelar</asp:LinkButton>
        </fieldset>
    </div>
</asp:Content>

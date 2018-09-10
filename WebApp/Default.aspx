
<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Bem-vindo ao Sistema de Gerênciamento e Controle de Versão!
    </h2>
    <p>
        Visite nosso site: <a href="http://www.doctus.com.br" title="Doctus Tecnologia Website">www.doctus.com.br</a>.
    </p>
    <p style="text-align:center;">
        
        <img src="Images/Doctus.png" width="350px" />
   </p>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manual.aspx.cs" Inherits="WebApp.Manual.Manual" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LinkButton ID="Link_Usuario" runat="server" onclick="LinkButton1_Click">Manual do Usuario</asp:LinkButton>
    
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" 
    onclick="LinkButton1_Click1">Manual do Sistema</asp:LinkButton>
</asp:Content>

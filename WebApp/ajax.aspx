<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajax.aspx.cs" Inherits="WebApp.ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:Label ID="Label1" runat="server" Text="">
        </asp:Label>
        <br />
        <asp:Button ID="Button1"
            runat="server" Text="Button" onclick="Button1_Click" />
        <br />
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
                <br />
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>

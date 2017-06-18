<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student.aspx.cs" Inherits="Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Aplikacja Studenta</title>
    <link href="ustyle.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="leftdiv">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Twoj plan zajec :"></asp:Label>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br /><br />
            <asp:Label ID="Label6" runat="server" Text="Nieobecnosci :"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <asp:GridView ID="GridView3" runat="server"></asp:GridView> 
        </div>
        <div class="rightdiv">
            <asp:Button ID="Button1" runat="server" Text="Wyloguj" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Oceny :"></asp:Label>
            <asp:GridView ID="GridView2" runat="server"></asp:GridView>
        </div> 
    </div>
    </form>
</body>
</html>

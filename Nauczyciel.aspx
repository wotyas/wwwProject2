<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Nauczyciel.aspx.cs" Inherits="Nauczyciel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Aplikacja Nauczyciela</title>
    <link href="tstyle.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">

        <div class="leftdiv">
            <asp:Label ID="welcomeLabel" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Twoj plan zajec :"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />
            <asp:Label ID="infoLabel" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="infoLabel2" runat="server" Text=""></asp:Label>
        </div>
        <div class="rightdiv">
            <asp:Button ID="Button1" runat="server" Text="Dodaj Ocene" OnClick="Button1_Click"/>
            <br />
            <asp:Button ID="Button3" runat="server" Text="Wpisz nieobecnosc" OnClick="Button3_Click"/>
            <br />
            <br />
            <asp:Label ID="Labelx" runat="server" Text="Pensja: "></asp:Label>
            <asp:Label ID="Pensja" runat="server" Text="Label"></asp:Label>
            <hr />
            <asp:Button ID="Button2" runat="server" Text="Wyloguj" OnClick="Button2_Click" />
        </div>
    


    </div>
    </form>
</body>
</html>

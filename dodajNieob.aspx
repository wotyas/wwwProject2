<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dodajNieob.aspx.cs" Inherits="dodajNieob" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Wpisywanie nieobecnosci</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="klasy" runat="server" AutoPostBack="True" OnSelectedIndexChanged="klasy_SelectedIndexChanged"></asp:DropDownList>
        <asp:Label ID="Label1" runat="server" Text="Klasa"></asp:Label>
        <br />
        <asp:DropDownList ID="uczniowie" runat="server" AutoPostBack="True"></asp:DropDownList> 
        <asp:Label ID="Label2" runat="server" Text="Uczen"></asp:Label>
        <br />
        <asp:TextBox ID="dzienTB" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Dzien"></asp:Label>
        <br />
        <asp:TextBox ID="miesiacTB" runat="server"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="Miesiac"></asp:Label>
        <br />
        <asp:TextBox ID="rokTB" runat="server"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Text="Rok"></asp:Label>
        <br />
        <asp:Button ID="Generuj" runat="server" Text="Generuj lekcje" OnClick="Generuj_Click" />
        <br />
        <asp:DropDownList ID="lekcje" runat="server" AutoPostBack="True"></asp:DropDownList> 
        <asp:Label ID="Label6" runat="server" Text="Lekcja"></asp:Label>
        <br />
        <asp:Button ID="Zatwierdz" runat="server" Text="Zatwierdz" OnClick="Zatwierdz_Click" />
        <hr />
        <asp:Button ID="Wroc" runat="server" Text="Wroc" OnClick="Wroc_Click" />
        <br />
        <asp:Label ID="infoLabel" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dodajOcene.aspx.cs" Inherits="dodajOcene" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Dodawanie oceny</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="klasy" runat="server" OnSelectedIndexChanged="klasy_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        <asp:Label ID="Label1" runat="server" Text="Klasa"></asp:Label>
        <br />
        
       
        
        <asp:DropDownList ID="uczniowie" runat="server" AutoPostBack="True"></asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="Uczen"></asp:Label>
        <br />
        <asp:DropDownList ID="przedmioty" runat="server" AutoPostBack="True"></asp:DropDownList>
        <asp:Label ID="Label3" runat="server" Text="Przedmiot"></asp:Label>
        <br />
        <asp:DropDownList ID="typy" runat="server" AutoPostBack="True"></asp:DropDownList>
        <asp:Label ID="Label5" runat="server" Text="Typ"></asp:Label>
        <br />
        <asp:TextBox ID="ocena" runat="server"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="Ocena"></asp:Label>
        <br />
        <asp:TextBox ID="dzienTB" runat="server"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="Dzien"></asp:Label>
        <br />
        <asp:TextBox ID="miesiacTB" runat="server"></asp:TextBox>
        <asp:Label ID="Label7" runat="server" Text="Miesiac"></asp:Label>
        <br />
        <asp:TextBox ID="rokTB" runat="server"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" Text="Rok"></asp:Label>
        <br />
        <asp:TextBox ID="komentarzTB" runat="server"></asp:TextBox>
        <asp:Label ID="Label9" runat="server" Text="*Komentarz"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Zatwierdz" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Wroc" OnClick="Button2_Click" />
        <br />
        <asp:Label ID="infoLabel" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>

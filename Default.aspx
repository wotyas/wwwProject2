<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="mainstyle.css" rel="stylesheet" type="text/css" />
    <title>e-dzienniczek [www2]</title>

</head>
<body>
   
     <form runat="server">
         <div class="default container" >
                <asp:TextBox ID="peselTextBox" runat="server" CssClass="username" ></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="Pesel" CssClass="label"></asp:Label>
                <br />
                <asp:TextBox ID="pwdTextBox" runat="server" CssClass="password"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="Haslo" CssClass="label"></asp:Label>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Logowanie" OnClick="Button1_Click" />
                <br />
                <asp:Label ID="Label3" runat="server" Text="" CssClass="label"></asp:Label>
        </div>
    </form>

    
</body>
</html>

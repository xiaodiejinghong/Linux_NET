<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color:pink;height:40px;width:600px;padding:10px;">
        <asp:TextBox ID="Addend1" runat="server"></asp:TextBox>  +
        <asp:TextBox ID="Addend2" runat="server"></asp:TextBox>
        <asp:Button ID="Sum" runat="server" Text="=" OnClick="Add" />
        <asp:TextBox ID="Result" runat="server" ReadOnly="true"></asp:TextBox>
    </div>
    </form>
</body>
</html>

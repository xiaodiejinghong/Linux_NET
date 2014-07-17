<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Select" />
        <hr />
        <asp:Button ID="Button2" runat="server" Text="插入" OnClick="Insert" />
        <hr />
        <asp:Button ID="Button3" runat="server" Text="更新" OnClick="Update" />
        <hr />
        <asp:Button ID="Button4" runat="server" Text="删除" OnClick="Delete" />
        
    </div>
    </form>
</body>
</html>

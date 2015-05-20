<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p><a href="ClientApplication:<% Response.Write(Request.Url.Authority.ToString()); %>/document.docx">document.docx</a></p>
        <p><a href="ClientApplication:<% Response.Write(Request.Url.Authority.ToString()); %>/document2.docx">document2.docx</a></p>
        <p><a href="ClientApplication:<% Response.Write(Request.Url.Authority.ToString()); %>/document3.docx">document3.docx</a></p>
    </div>
    </form>
</body>
</html>

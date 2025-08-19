<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="Application.Post" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>All Posts</title></head>
<body>
<form id="form1" runat="server">
  <h2>Danh sách Post</h2>
  <asp:Repeater ID="repAllPosts" runat="server">
    <HeaderTemplate><ul></HeaderTemplate>
    <ItemTemplate>
      <li>[%# Eval("PostId") %] - <%# Eval("Title") %> (BlogId=%# Eval("BlogId") %>)</li>
    </ItemTemplate>
    <FooterTemplate></ul></FooterTemplate>
  </asp:Repeater>
</form>
</body>
</html>

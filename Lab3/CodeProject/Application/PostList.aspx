<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostList.aspx.cs" Inherits="Application.PostList" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Posts by Blog</title></head>
<body>
<form id="form1" runat="server">
  <asp:Literal ID="litHeader" runat="server" />
  <asp:Repeater ID="repPosts" runat="server">
    <HeaderTemplate><ul></HeaderTemplate>
    <ItemTemplate>
      <li>[%# Eval("PostId") %] - <%# Eval("Title") %> (BlogId=%# Eval("BlogId") %>)</li>
    </ItemTemplate>
    <FooterTemplate></ul></FooterTemplate>
  </asp:Repeater>
  <p><a href="Blog.aspx">← Quay lại Blogs</a></p>
</form>
</body>
</html>

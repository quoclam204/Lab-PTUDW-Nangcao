<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="Application.Blog" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Blogs</title></head>
<body>
<form id="form1" runat="server">
  <h2>Danh sách Blog</h2>
  <asp:Repeater ID="repBlogs" runat="server">
    <HeaderTemplate><ul></HeaderTemplate>
    <ItemTemplate>
      <li>
        <%# Eval("BlogId") %> - <%# Eval("Name") %>
        [<a href='<%# "PostList.aspx?BlogID=" + Eval("BlogId") %>'>Xem bài viết</a>]
      </li>
    </ItemTemplate>
    <FooterTemplate></ul></FooterTemplate>
  </asp:Repeater>
</form>
</body>
</html>

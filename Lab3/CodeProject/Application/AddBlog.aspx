<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBlog.aspx.cs" Inherits="Application.AddBlog" %>
<!DOCTYPE html>
<html>
<head runat="server"><title>Thêm Blog</title></head>
<body>
<form id="form1" runat="server">
  <h2>Thêm Blog</h2>
  <p>
    <asp:Label runat="server" Text="Tên Blog: " AssociatedControlID="txtName" />
    <asp:TextBox runat="server" ID="txtName" />
    <asp:Button runat="server" ID="btnAdd" Text="Thêm" OnClick="btnAdd_Click" />
  </p>
  <asp:Literal runat="server" ID="litMsg" />
  <p><a href="Blog.aspx">← Danh sách Blogs</a></p>
</form>
</body>
</html>

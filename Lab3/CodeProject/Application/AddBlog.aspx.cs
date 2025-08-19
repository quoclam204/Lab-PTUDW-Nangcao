using System;
using EntityController;
using EntityModel;

namespace Application
{
    public partial class AddBlog : System.Web.UI.Page
    {
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var name = txtName.Text?.Trim();
            if (string.IsNullOrEmpty(name))
            {
                litMsg.Text = "<p>Vui lòng nhập tên blog.</p>";
                return;
            }

            var blogCtl = new BlogController();
            var ok = blogCtl.Insert(new EntityModel.Blog { Name = name });
            litMsg.Text = ok ? "<p>Thêm thành công!</p>" : "<p>Thêm thất bại!</p>";
            if (ok) txtName.Text = "";
        }
    }
}

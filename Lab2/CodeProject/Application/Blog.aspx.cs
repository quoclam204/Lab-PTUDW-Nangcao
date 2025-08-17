using System;
using EntityController;

namespace Application
{
    public partial class Blog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var blogCtl = new BlogController();
                repBlogs.DataSource = blogCtl.SelectAll("BlogId"); // sắp xếp tăng dần
                repBlogs.DataBind();
            }
        }
    }
}

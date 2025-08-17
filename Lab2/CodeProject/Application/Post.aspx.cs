using System;
using EntityController;

namespace Application
{
    public partial class Post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var postCtl = new PostController();
                // Fix: SelectAll does not accept a lambda, use the overload with string for ordering
                repAllPosts.DataSource = postCtl.SelectAll("PostId");
                repAllPosts.DataBind();
            }
        }
    }
}

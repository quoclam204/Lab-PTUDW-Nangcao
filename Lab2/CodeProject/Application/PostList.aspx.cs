using System;
using EntityController;

namespace Application
{
    public partial class PostList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.QueryString["BlogID"], out int blogId))
                {
                    var postCtl = new PostController();
                    // Fix: Use string conditions and order expressions as required by SelectOrderWhere
                    string conditions = $"BlogId = {blogId}";
                    string orders = "PostId";
                    repPosts.DataSource = postCtl.SelectOrderWhere(conditions, orders);
                    repPosts.DataBind();

                    litHeader.Text = $"<h2>Post của BlogID = {blogId}</h2>";
                }
                else
                {
                    litHeader.Text = "<p>BlogID không hợp lệ.</p>";
                }
            }
        }
    }
}

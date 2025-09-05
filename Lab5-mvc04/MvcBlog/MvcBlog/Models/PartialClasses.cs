using System.ComponentModel.DataAnnotations;

namespace MvcBlog.Models
{
    [MetadataType(typeof(BlogMetadata))]
    public partial class Blog { }

    [MetadataType(typeof(PostMetadata))]
    public partial class Post { }
}

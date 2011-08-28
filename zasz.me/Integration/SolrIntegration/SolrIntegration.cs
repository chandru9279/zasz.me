using SolrNet;
using SolrNet.Mapping;
using SolrNet.Utils;
using zasz.me.Areas.Shared.Models;

namespace zasz.me.Integration.SolrIntegration
{
    public class SolrIntegration
    {
        public static void Bootstrap()
        {
//            var Container = new Container(Startup.Container);
//            Container.RemoveAll<IReadOnlyMappingManager>();
//            Container.Register<IReadOnlyMappingManager>(C => GetMappings());
            Startup.Init<Post>("http://localhost:5000/solr");
        }

        public static MappingManager GetMappings()
        {
            var Manager = new MappingManager();
            var PostType = typeof(Post);
            var IdentityProperty = PostType.GetProperty("Id");
            Manager.SetUniqueKey(IdentityProperty);
            Manager.Add(IdentityProperty, "Id");
            Manager.Add(PostType.GetProperty("Content"), "Post_Content");
            Manager.Add(PostType.GetProperty("Tags"), "Post_Tags", 1.5f);
            Manager.Add(PostType.GetProperty("Slug"), "Post_Slug");
            Manager.Add(PostType.GetProperty("Title"), "Post_Title", 2.0f);
            return Manager;
        }

    }
}
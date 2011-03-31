using System.Reflection;
using Raven.Client.Document;
using Raven.Client.Indexes;
using zasz.me.Models;

namespace zasz.me.Integration.RavenDB
{
    public class RavenIntegration
    {
        public static void Bootstrap()
        {
            var DocumentStore = new DocumentStore {ConnectionStringName = "RavenConnection"};
            DocumentStore.Initialize();
            IndexCreation.CreateIndexes(Assembly.GetExecutingAssembly(), DocumentStore);
            DocumentStore.Conventions.FindIdentityProperty =
                Property =>
                    {
                        var IdAttributes = Property.GetCustomAttributes(typeof (IDAttribute), false) as IDAttribute[];
                        return IdAttributes != null && IdAttributes.Length > 0;
                    };
            HugeBox.Swallow(DocumentStore);
        }
    }
}
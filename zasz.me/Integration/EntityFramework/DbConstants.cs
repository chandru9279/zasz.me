namespace zasz.me.Integration.EntityFramework
{
    public class DbConstants
    {
        public static string DbConnectionStringName = "FullContext";
        public static string TestDbConnectionStringName = "TestContext";
        
        public const string PostTagMappingTable = "MapPostTag";
        public const string PostTagMappingSchema = "Blog";

        public static string PostTagMapping = string.Format("[{0}].[{1}]", PostTagMappingSchema, PostTagMappingTable);
    }
}
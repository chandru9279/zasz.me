namespace zasz.me.ViewModels
{
    public class FallbackModel
    {
        public FallbackModel(string lib, string condition, string local)
        {
            Lib = lib;
            Condition = condition;
            Local = local;
        }

        public string Lib { get; set; }
        public string Condition { get; set; }
        public string Local { get; set; }
    }
}
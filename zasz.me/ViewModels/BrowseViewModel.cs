using zasz.me.Services;

namespace zasz.me.ViewModels
{
    public class BrowseViewModel
    {
        public Pairs<string, string> ThumbsAndFiles { get; set; }
        public int CkEditorFuncNum { get; set; }
        public string Message { get; set; }
    }
}
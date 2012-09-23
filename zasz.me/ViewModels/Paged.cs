using System.Collections.Generic;

namespace zasz.me.ViewModels
{
    public class Paged<T>
    {
        public List<T> Set { get; set; }
        public long NumberOfPages { get; set; }
    }
}
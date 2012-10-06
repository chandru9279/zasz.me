using System;
using System.Collections.Generic;

namespace zasz.me.Models
{
    public class Paged<T>
    {
        public List<T> Set { get; set; }
        public long NumberOfPages { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public int Count
        {
            get { return Set.Count; }
        }

        public T this[int index]
        {
            get { return Set[index]; }
            set { Set[index] = value; }
        }

        public void Each(Action<T> action)
        {
            Set.ForEach(action);
        }
    }
}
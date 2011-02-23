using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zasz.me.Models
{
    public abstract class Stored<T> where T : Stored<T>, new() 
    {
        public Guid ID { get; private set; }

        public Stored()
        {
            ID = Guid.NewGuid();
        }
    }
}
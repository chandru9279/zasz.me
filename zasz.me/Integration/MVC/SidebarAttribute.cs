using System;

namespace zasz.me.Integration.MVC
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class SidebarAttribute : Attribute
    {
    }
}
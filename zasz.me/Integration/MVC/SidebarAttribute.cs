using System;

namespace zasz.me.Integration.MVC
{
    [AttributeUsage(
        AttributeTargets.Method | AttributeTargets.Class, 
        AllowMultiple = false, 
        Inherited = true)]
    public class SidebarAttribute : Attribute
    {
    }
}
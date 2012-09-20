using System;

namespace zasz.me.Integration.MVC
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NaturalKeyAttribute : Attribute
    {
    }
}
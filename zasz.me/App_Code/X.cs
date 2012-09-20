using System;
using System.Linq.Expressions;
using System.Reflection;
using zasz.me.Models;

namespace zasz.me
{
    public class X
    {
        public static string Name<T>(Expression<Func<Post, T>> expression)
        {
            return ((MemberExpression)expression.Body).Member.Name;
        }

        public static PropertyInfo PropertyInfo<T>(Expression<Func<Post, T>> expression)
        {
            return ((MemberExpression)expression.Body).Member as PropertyInfo;
        } 
    }
}
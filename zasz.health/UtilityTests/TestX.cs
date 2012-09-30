using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using zasz.me;
using zasz.me.Integration.MVC;

namespace zasz.health.UtilityTests
{
    public static class TestX
    {
        public static bool HasOneDefaultAction(this Type controllerType)
        {
            return (from method in controllerType.GetMethods()
                    where Attribute.IsDefined(method, typeof(DefaultActionAttribute))
                    select method).Count() == 1;
        }

        public static bool HasOneNaturalKey(this Type controllerType)
        {
            return (from property in controllerType.GetProperties()
                    where Attribute.IsDefined(property, typeof(NaturalKeyAttribute))
                    select property).Count() == 1;
        }

        public static string RepoPath
        {
            get { return Directory.GetParent(X.ProjectPath).FullName; }
        }

        public static bool PublicInstancePropertiesEqual<T>(this T self, T to, params string[] ignore) where T : class
        {
            if (self != null && to != null)
            {
                var type = typeof(T);
                var ignoreList = new List<string>(ignore);
                var unequalProperties =
                    from pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    where !ignoreList.Contains(pi.Name)
                    let selfValue = type.GetProperty(pi.Name).GetValue(self, null)
                    let toValue = type.GetProperty(pi.Name).GetValue(to, null)
                    where selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue))
                    select selfValue;
                var unequalPropertyList = unequalProperties.ToList();
                Debug.WriteLine(string.Join(" | ", unequalPropertyList));
                return !unequalPropertyList.Any();
            }
            return self == to;
        }

        public static IQueryable<T> TraceSql<T>(this IQueryable<T> query)
        {
            var sql = ((System.Data.Objects.ObjectQuery)query).ToTraceString();
            Debug.WriteLine("SQL : " + sql);
            return query;
        }
    }
}
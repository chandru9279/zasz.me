using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using zasz.me.Integration.MVC;
using zasz.me.Models;
using zasz.me.Services;

namespace zasz.me
{
    public static class X
    {
        public static string ProjectPath
        {
            get
            {
                var pathToDll = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", string.Empty);
                return pathToDll.Remove(pathToDll.IndexOf("/bin/"));
            }
        }

        public static string Name<T>(Expression<Func<Post, T>> expression)
        {
            return ((MemberExpression)expression.Body).Member.Name;
        }

        public static Pair<string, string> TableAndSchemaName(this Type type)
        {
            var tableAttribute = type.GetCustomAttributes(true).OfType<TableAttribute>().First();
            return new Pair<string, string>(tableAttribute.Name, tableAttribute.Schema);
        }

        public static PropertyInfo PropertyInfo<T>(Expression<Func<Post, T>> expression)
        {
            return ((MemberExpression)expression.Body).Member as PropertyInfo;
        }

        public static T Enumize<T>(this string enumValue)
        {
            return (T)Enum.Parse(typeof(T), enumValue);
        }

        public static IEnumerable<SelectListItem> ToSelectList(this List<string> anyList)
        {
            return anyList.Select(x => new SelectListItem { Text = x, Value = x });
        }

        public static bool Sidebar(this ViewContext context)
        {
            var action = context.Controller.ValueProvider.GetValue("action").AttemptedValue;
            return Attribute.IsDefined(context.Controller.GetType(), typeof(SidebarAttribute)) ||
                   Attribute.IsDefined(context.Controller.GetType().GetMethod(action), typeof(SidebarAttribute));
        }

        public static void Validate(this object obj)
        {
            var type = obj.GetType();
            var meta = type.GetCustomAttributes(false).OfType<MetadataTypeAttribute>().FirstOrDefault();
            if (meta != null)
            {
                type = meta.MetadataClassType;
            }
            var propertyInfo = type.GetProperties();
            foreach (var info in propertyInfo)
            {
                var attributes = info.GetCustomAttributes(false).OfType<ValidationAttribute>();
                foreach (var attribute in attributes)
                {
                    var objPropInfo = obj.GetType().GetProperty(info.Name);
                    attribute.Validate(objPropInfo.GetValue(obj, null), info.Name);
                }
            }
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            var forEach = source as List<T> ?? source.ToList();
            foreach (var element in forEach)
                action(element);
            return forEach;
        }

        public static void Done(this Stream stream)
        {
            stream.Flush();
            stream.Close();
            stream.Dispose();
        }

        public static void Done(this TextWriter stream)
        {
            stream.Flush();
            stream.Close();
            stream.Dispose();
        }

        // To be called for debugging only.
        public static IQueryable<T> TraceSql<T>(this IQueryable<T> query)
        {
            Debug.WriteLine("SQL : " + ((System.Data.Objects.ObjectQuery)query).ToTraceString());
            return query;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using zasz.me.Integration.MVC;
using zasz.me.Models;

namespace zasz.me
{
    public static class X
    {
        public static string Name<T>(Expression<Func<Post, T>> expression)
        {
            return ((MemberExpression) expression.Body).Member.Name;
        }

        public static PropertyInfo PropertyInfo<T>(Expression<Func<Post, T>> expression)
        {
            return ((MemberExpression) expression.Body).Member as PropertyInfo;
        }

        public static T Enumize<T>(this string enumValue)
        {
            return (T) Enum.Parse(typeof (T), enumValue);
        }

        public static IEnumerable<SelectListItem> ToSelectList(this List<string> anyList)
        {
            return anyList.Select(x => new SelectListItem {Text = x, Value = x});
        }

        public static bool Sidebar(this ViewContext context)
        {
            var action = context.Controller.ValueProvider.GetValue("action").AttemptedValue;
            return Attribute.IsDefined(context.Controller.GetType(), typeof (SidebarAttribute)) ||
                   Attribute.IsDefined(context.Controller.GetType().GetMethod(action), typeof (SidebarAttribute));
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

        public static string ValidateErrors(this object obj)
        {
            try
            {
                obj.Validate();
            }
            catch (ValidationException e)
            {
                return string.Format("{0} | {1}", e.GetType(), e.Message);
            }
        }
    }
}
﻿using System;
using System.Linq;

namespace SharpGrip.FluentValidation.AutoValidation.Shared.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsCustomType(this Type? type)
        {
            var builtInTypes = new[]
            {
                typeof(string),
                typeof(decimal),
                typeof(DateTime),
                typeof(DateTimeOffset),
                typeof(TimeSpan),
                typeof(Guid),
                typeof(Enum)
            };

            return type != null && type.IsClass && !type.IsEnum && !type.IsValueType && !type.IsPrimitive && !builtInTypes.Contains(type);
        }

        public static bool HasCustomAttribute<TAttribute>(this Type type) where TAttribute : Attribute
        {
            return type.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(TAttribute));
        }

        public static bool InheritsFromTypeWithNameEndingIn(this Type type, string name)
        {
            while (type.BaseType != null)
            {
                type = type.BaseType;

                if (type.Name.EndsWith(name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
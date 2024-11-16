using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Framework.Contracts.DataMappers
{
    public static class PropertyResolver
    {

        public static string ResolveProperty<Object>(Expression<Func<Object, object>> expression)
        {
            var exp = expression.Body;
            string property = string.Empty;
            if (exp.NodeType == ExpressionType.MemberAccess)
            {
                var splitProperty = exp.ToString().Split('`');
                if (splitProperty != null)
                {
                    property = splitProperty[0].Split('.')[1];
                }
            }
            else if (exp.NodeType == ExpressionType.Convert)
            {
                property = exp.ToString().Split('.')[1];
            }

            return property;
        }

        public static bool TryGetTypeOfProprty(Type type, string property, out PropertyInfo propertyInfo)
        {
            propertyInfo = type.GetProperty(property);
            return propertyInfo == null ? false : true;
        }

        public static string ResolveComplexProperty<EntityType>(PropertyInfo propertyInfo)
        {
            var propertyTypeFullName = propertyInfo.PropertyType.FullName.Split('`')[0];

            return $"{propertyTypeFullName}<{typeof(EntityType).FullName}>";
        }
    }
}

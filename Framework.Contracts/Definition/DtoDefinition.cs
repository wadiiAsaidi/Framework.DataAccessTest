using Framework.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Framework.Contracts.DataMappers
{
    public abstract class DtoDefinition<TDto> : DefinitionBase where TDto : class, new()
    {



        protected void AddProperty(Expression<Func<TDto, object>> expression)
        {
            PropertyInfo propertyInfo;
            var property = PropertyResolver.ResolveProperty<TDto>(expression);
            if (PropertyResolver.TryGetTypeOfProprty(typeof(TDto), property, out propertyInfo))
            {
                var definictionItem = new DefinictionItem();
                definictionItem.PropertyInfo = propertyInfo;
                definictionItem.Property = property;
                definictionItem.FullName = propertyInfo.PropertyType.FullName.Split('`')[0] + " " + property + " {get;set;}";
                Definictions.Add(definictionItem);
            }
        }

        protected void AddComplexProperty<EntityType>(Expression<Func<TDto, object>> expression)
        {
            var property = PropertyResolver.ResolveProperty<TDto>(expression);
            PropertyInfo propertyInfo;

            if (PropertyResolver.TryGetTypeOfProprty(typeof(TDto), property, out propertyInfo))
            {
                var definictionItem = new DefinictionItem();
                definictionItem.Property = property;
                definictionItem.PropertyInfo = propertyInfo;
                definictionItem.FullName = PropertyResolver.ResolveComplexProperty<EntityType>(propertyInfo) + " " + property + " {get;set;}"; ;
                Definictions.Add(definictionItem);
            }

        }

    }
}

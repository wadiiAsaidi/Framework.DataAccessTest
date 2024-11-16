using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Framework.Contracts.Data
{
    public class DefinictionItem
    {
        public string Property { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
        public string FullName { get; set; }

    }

    public class PropertiesCollection : List<DefinictionItem>
    {

        public void Add(string property, PropertyInfo propertyInfo, string fullName)
        {
            var definictionItem = new DefinictionItem()
            {
                Property = property,
                PropertyInfo = propertyInfo,
                FullName = fullName
            };

            this.Add(definictionItem);
        }
    }


}

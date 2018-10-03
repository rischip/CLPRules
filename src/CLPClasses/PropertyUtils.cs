using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace CLPClasses
{
    public class PropertyUtils
    {
        public static object GetRootPropName(object src)
        {
            var objectRoot = (IDictionary<string, object>)src;
            var val = objectRoot.Keys.First();
            return val;
        }

        public static object GetPropValue(object src, string propName)
        {
            var objectRoot = (IDictionary<string, object>)src;
            var byName = (IDictionary<string, object>)objectRoot.Values.First();
            var val = byName[propName];
            return val;
        }

        public static void SetPropValue(object src, object dest, string propName, string propValue)
        {
            PropertyInfo propertyInfo = dest.GetType().GetProperty(propName);
            if (propertyInfo != null)
                propertyInfo.SetValue(dest, Convert.ChangeType(propValue, propertyInfo.PropertyType), null);
        }

        public static Type[] GetTypeByName(string className)
        {
            List<Type> returnVal = new List<Type>();

            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type[] assemblyTypes = a.GetTypes();
                for (int j = 0; j < assemblyTypes.Length; j++)
                {
                    if (assemblyTypes[j].Name == className)
                    {
                        returnVal.Add(assemblyTypes[j]);
                    }
                }
            }

            return returnVal.ToArray();
        }

        public static void MapProperties(ExpandoObject src, object dest)
        {
            foreach (var propertyInfo in dest.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                try
                {
                    var propValue = GetPropValue(src, propertyInfo.Name);
                    SetPropValue(src, dest, propertyInfo.Name, propValue.ToString());
                }
                finally
                {
                }
            }
        }
        public static object GetPropertyValueByName(object src, string propertyName)
        {
            object propValue = new object();

            if (src.GetType().ToString() == "System.Dynamic.ExpandoObject")
            {
                foreach (var pair in (ExpandoObject)src)
                {
                    if (pair.Key.ToLower() == propertyName.ToLower())
                    {
                        propValue = pair.Value.ToString();
                    }
                }

            }
            else
            {
                foreach (var propertyInfo in src.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (propertyInfo.Name.ToLower() == propertyName.ToLower())
                    {
                        try
                        {
                            propValue = propertyInfo.GetValue(src);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }

            return propValue;
        }
    }
}
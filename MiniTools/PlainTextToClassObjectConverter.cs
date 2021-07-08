using System;

namespace MiniTools
{
    /// <summary>
    ///    Convert a plain text instead of Json/XML result into a class object
    /// </summary>    
    public static class PlainTextToClassObjectConverter
    {
        /*
         * propertyDelimiter = a split delimiter for split different property inside plain text
         * propertyValueDelimiter = a split delimiter for split property and value for each set of property array.
         */
        public static T ConvertPlainTextToClass<T>(string text, string propertyDelimiter = "\r\n", string propertyValueDelimiter = ":")
        {
            var type = typeof(T);
            T instance = (T)Activator.CreateInstance(type);

            string[] inputList = text.Split(propertyDelimiter);

            foreach (var inputValue in inputList)
            {
                string[] classProperty = inputValue.Split(propertyValueDelimiter);
                var property = type.GetProperty(classProperty[0].Trim());
                string propertyValue = classProperty[1].Trim();

                try
                {
                    switch (property.PropertyType.Name.ToLower())
                    {
                        case "double":
                            property.SetValue(instance, double.Parse(propertyValue));
                            break;
                        case "decimal":
                            property.SetValue(instance, decimal.Parse(propertyValue));
                            break;
                        case "float":
                            property.SetValue(instance, float.Parse(propertyValue));
                            break;
                        case "int":
                            property.SetValue(instance, int.Parse(propertyValue));
                            break;
                        case "string":
                            property.SetValue(instance, propertyValue);
                            break;
                    }
                }
                catch
                {
                    continue;
                }
            }

            return instance;
        }
    }
}

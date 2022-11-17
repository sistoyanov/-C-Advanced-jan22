using System;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties().Where(p => p.CustomAttributes.Any(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.AttributeType))).ToArray();

            foreach (PropertyInfo validationProperty in properties)
            {
                object[] customAttributes = validationProperty.GetCustomAttributes().Where(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.GetType())).ToArray();
                object propValue = validationProperty.GetValue(obj);

                foreach (object customAttribute in customAttributes)
                {
                    MethodInfo isValidMethod = customAttribute.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(mi => mi.Name == "IsValid");

                    if (isValidMethod == null)
                    {
                        throw new InvalidOperationException("No such method");
                    }

                    bool result = (bool)isValidMethod.Invoke(customAttribute, new object[] { propValue });

                    if (!result)
                    {
                        return false;
                    }
                }


            }

            return true;
        }
    }
}


namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    public class Spy
    {

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);
            object instance = Activator.CreateInstance(type);
            StringBuilder output = new StringBuilder();

            FieldInfo[] typeFields = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] typePublicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] tyepNonPublicMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in typeFields)
            {
                output.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in tyepNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                output.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in typePublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                output.AppendLine($"{method.Name} have to be private!");
            }

            return output.ToString().TrimEnd();
        }
    }
}

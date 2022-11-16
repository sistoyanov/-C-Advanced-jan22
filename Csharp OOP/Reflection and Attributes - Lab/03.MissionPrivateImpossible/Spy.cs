
namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] fieldsToInvestigate)
        {
            Type classType = Type.GetType(investigatedClass);
            object classInstance = Activator.CreateInstance(classType);

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            StringBuilder output = new StringBuilder();

            
            output.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                output.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return output.ToString().TrimEnd();
        }


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

        public string RevealPrivateMethods(string className)
        {
            Type typeOfClass = Type.GetType(className);
            object clasInstance = Activator.CreateInstance(typeOfClass);
            StringBuilder output = new StringBuilder();

            MethodInfo[] methods = typeOfClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            output.AppendLine($"All Private Methods of Class: {className}");
            output.AppendLine($"Base Class: {typeOfClass.BaseType.Name}");

            foreach (MethodInfo method in methods)
            {
                output.AppendLine(method.Name);
            }

            return output.ToString().TrimEnd();
        }
    }
}


namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Xml.Linq;

    public class Spy
    {

        public string CollectGettersAndSetters(string className)
        {
            Type typeOfClass = Type.GetType(className);
            object clasInstance = Activator.CreateInstance(typeOfClass);
            StringBuilder output = new StringBuilder();

            MethodInfo[] methods = typeOfClass.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("get")))
            {
                output.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("set")))
            {
                output.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            return output.ToString().TrimEnd();
        }
    }
}


namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    public class Spy
    {

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

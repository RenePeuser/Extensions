using System.Diagnostics.Contracts;
using System.Reflection;

namespace Extensions
{
    public static class AssemblyExtensions
    {
        public static string GetManifestResourceString(this Assembly assembly, string resourcePath)
        {
            Contract.Requires(assembly.IsNotNull());
            Contract.Requires(resourcePath.IsNotNullOrEmpty());

            var resourceFullName = $"{assembly.GetName().Name}.{resourcePath}";

            string result;
            using (var stream = assembly.GetManifestResourceStream(resourceFullName))
            {
                result = stream.ReadToEnd();
            }

            return result;
        }
    }
}

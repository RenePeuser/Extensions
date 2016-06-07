using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Extensions
{
    public static class DirectoryInfoExtensions
    {
        public static bool FullNameEqual(this DirectoryInfo source, DirectoryInfo target, CultureInfo cultureInfo)
        {
            Contract.Requires(source.IsNotNull());
            Contract.Requires(target.IsNotNull());
            Contract.Requires(cultureInfo.IsNotNull());

            return source.FullName.ToLower(cultureInfo) == target.FullName.ToLower(cultureInfo);
        }

        public static IEnumerable<DirectoryInfo> GetDirectoriesWithAccess(this DirectoryInfo directoryInfo)
        {
            Contract.Requires(directoryInfo.IsNotNull());

            return directoryInfo.EnumerateDirectories().Where(item => !item.GetAccessControl().AreAccessRulesProtected);
        }

        public static bool IsNullOrNotExists(this DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null)
            {
                return true;
            }

            return !directoryInfo.Exists;
        }
    }
}
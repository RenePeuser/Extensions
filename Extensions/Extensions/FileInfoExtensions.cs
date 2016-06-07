using System;
using System.Diagnostics.Contracts;
using System.IO;

namespace Extensions
{
    public static class FileInfoExtensions
    {
        public static string NameWithoutExtension(this FileInfo fileInfo)
        {
            Contract.Requires(fileInfo.IsNotNull());

            return Path.GetFileNameWithoutExtension(fileInfo.Name);
        }

        public static string ExtractPatternName(this FileInfo fileInfo)
        {
            Contract.Requires(fileInfo.IsNotNull());

            var fileNameWihtoutExtension = fileInfo.NameWithoutExtension();
            int startIndex = fileNameWihtoutExtension.IndexOf(".", StringComparison.Ordinal);
            if (startIndex <= 0)
            {
                return null;
            }

            var extractIndex = startIndex + 1;
            return fileNameWihtoutExtension.Substring(extractIndex, fileNameWihtoutExtension.Length - extractIndex);
        }

        public static bool NotExists(this FileInfo fileInfo)
        {
            Contract.Requires(fileInfo.IsNotNull());

            return !fileInfo.Exists;
        }

        public static bool IsNotNullAndExists(this FileInfo fileInfo)
        {
            return !fileInfo.IsNullOrNotExists();
        }

        public static bool IsNullOrNotExists(this FileInfo fileInfo)
        {
            if (fileInfo == null)
            {
                return true;
            }

            return !fileInfo.Exists;
        }

        public static bool DirectoryNotExists(this FileInfo fileInfo)
        {
            Contract.Requires(fileInfo.IsNotNull());

            return !fileInfo.Directory.Exists;
        }
    }
}
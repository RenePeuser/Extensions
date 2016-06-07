using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Extensions
{
    public static class StringExtensions
    {
        public static double ToDouble(this string value, NumberFormatInfo numberFormatInfo = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                return default(double);
            }

            double result;
            double.TryParse(value, NumberStyles.Float, numberFormatInfo, out result);
            return result;
        }

        public static decimal ToDecimal(this string value, NumberFormatInfo numberFormatInfo = null)
        {
            if (string.IsNullOrEmpty(value))
            {
                return default(decimal);
            }

            decimal result;
            decimal.TryParse(value, NumberStyles.Float, numberFormatInfo, out result);
            return result;
        }

        public static Guid ToGuid(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Guid.Empty;
            }

            Guid result;
            Guid.TryParse(value, out result);
            return result;
        }

        public static int ToInt(this string value)
        {
            return string.IsNullOrEmpty(value) ? 0 : Convert.ToInt32(value);
        }

        public static CultureInfo ToCultureInfo(this string cultureName)
        {
            var allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.SpecificCultures);
            return allCultures.FirstOrDefault(ci => ci.Name == cultureName);
        }

        public static bool FileExists(this string filePath)
        {
            return File.Exists(filePath);
        }

        public static bool DirectoryExists(this string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);
            return directory != null && Directory.Exists(directory);
        }

        public static bool DirectoryNotExists(this string filePath)
        {
            return !Directory.Exists(filePath);
        }

        public static DirectoryInfo ToDirectoryInfo(this string folderPath)
        {
            return IsNullOrEmpty(folderPath) ? null : new DirectoryInfo(folderPath);
        }

        public static DirectoryInfo ToDirectoryInfoWihtoutEndSeperator(this string folderPath)
        {
            if (IsNullOrEmpty(folderPath))
            {
                return null;
            }

            var correctedFullPath = folderPath.TrimEnd(Path.DirectorySeparatorChar);
            return correctedFullPath.ToDirectoryInfo();
        }

        public static FileInfo ToFileInfo(this string filePath)
        {
            return IsNullOrEmpty(filePath) ? null : new FileInfo(filePath);
        }

        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        public static bool IsNotNullOrEmpty(this string source)
        {
            return !IsNullOrEmpty(source);
        }

        public static bool IsEmpty(this string source)
        {
            return source == string.Empty;
        }

        public static bool IsNotEmpty(this string source)
        {
            return !source.IsEmpty();
        }

        public static bool Contains(this string source, string serachString, StringComparison stringComparison)
        {
            if (IsNullOrEmpty(source))
            {
                return false;
            }

            return source.IndexOf(serachString, stringComparison) >= 0;
        }

        public static bool NotEquals(this string source, string target)
        {
            return !source.Equals(target);
        }

        public static bool NotEquals(this string source, params string[] targets)
        {
            return IsNullOrEmpty(source) || targets.All(item => item.NotEquals(source));
        }

        public static T ToEnum<T>(this string value) where T : struct
        {
            T result;
            if (!Enum.TryParse(value, out result))
            {
                throw new Exception("Can not parse enum value");
            }
            return result;
        }

        public static T ConvertToEnum<T>(string value) where T : struct
        {
            return value.ToEnum<T>();
        }

        public static FileInfo ConvertToFileInfo(string value)
        {
            return value.ToFileInfo();
        }
    }
}
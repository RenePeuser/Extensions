using System.Diagnostics.Contracts;
using System.IO;

namespace Extensions
{
    public static class StreamExtensions
    {
        public static string ReadToEnd(this Stream stream)
        {
            Contract.Requires(stream.IsNotNull());

            string result;
            using (var sr = new StreamReader(stream))
            {
                result = sr.ReadToEnd();
            }

            return result;
        }
    }
}

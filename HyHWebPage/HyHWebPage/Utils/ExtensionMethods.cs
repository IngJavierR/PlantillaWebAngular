using System.IO;

namespace HyHWebPage.Utils
{
    public static class ExtensionMethods
    {
        public static string StreamAsString(this Stream requestStream)
        {
            using (var reader = new StreamReader(requestStream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}

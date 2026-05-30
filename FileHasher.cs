using System;
using System.IO;
using System.Security.Cryptography;

namespace cyber_tool
{
    public class FileHasher
    {
        public static string GetSha256Hash(Stream stream)
        {
            try
            {
                if (stream.CanSeek)
                    stream.Position = 0;

                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(stream);
                    return Convert.ToHexString(hashBytes).ToLowerInvariant();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"I/O Exception: {e.Message}");
                return string.Empty;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Access Exception: {e.Message}");
                return string.Empty;
            }
        }
    }
}
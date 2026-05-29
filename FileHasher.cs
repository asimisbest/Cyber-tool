using System;
using System.Security.Cryptography;
using System.IO;
using System.Linq.Expressions;
namespace cyber_tool;


 public class FileHasher
    {
      
    
        public static string GetSha256Hash(Stream stream)
{
  try{
    // Ensure the stream is at the start
    if (stream.CanSeek) stream.Position = 0;

    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] hashBytes = sha256.ComputeHash(stream);
        // Convert to hex string
        return Convert.ToHexString(hashBytes).ToLowerInvariant();
       

    }
  }catch (IOException e)
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
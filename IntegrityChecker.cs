using System;
using System.IO;
using System.Collections.Generic;

namespace cyber_tool
{
    public class IntegrityChecker
    {
        public static Dictionary<string, string> LoadBaseline(string path)
        {
            string json = File.ReadAllText(path);
            return System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(json);
        }

        public static void Verify(string folderPath, string baselinePath)
        {
            var baseline = LoadBaseline(baselinePath);
            string[] currentFiles = Directory.GetFiles(folderPath);

            var currentState = new Dictionary<string, string>();

            foreach (string file in currentFiles)
            {
                try
                {
                    using (FileStream stream = File.OpenRead(file))
                    {
                        string hash = FileHasher.GetSha256Hash(stream);
                        currentState[file] = hash;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading {file}: {ex.Message}");
                }
            }

            Console.WriteLine("\n--- Integrity Report ---\n");

            foreach (var oldFile in baseline)
            {
                if (!currentState.ContainsKey(oldFile.Key))
                {
                    Console.WriteLine($"[DELETED] {oldFile.Key}");
                }
                else if (currentState[oldFile.Key] != oldFile.Value)
                {
                    Console.WriteLine($"[MODIFIED] {oldFile.Key}");
                }
            }

            foreach (var newFile in currentState)
            {
                if (!baseline.ContainsKey(newFile.Key))
                {
                    Console.WriteLine($"[NEW] {newFile.Key}");
                }
            }

            Console.WriteLine("\n--- Scan Complete ---");
        }
    }
}
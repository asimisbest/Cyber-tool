using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace cyber_tool
{
    public class Baseline
    {
        public static void CreateBaseline(string folderPath)
        {
            

            // Get all files
            string[] files = Directory.GetFiles(folderPath);

            // Dictionary to store filepath -> hash
            Dictionary<string, string> baselineData = new Dictionary<string, string>();

            // Hash each file
           foreach (string file in files)
{
    using (FileStream stream = File.OpenRead(file))
    {
        string hash = FileHasher.GetSha256Hash(stream);
        baselineData[file] = hash;
    }
}

            // Convert dictionary to JSON
            string json = JsonSerializer.Serialize(
                baselineData,
                new JsonSerializerOptions { WriteIndented = true }
            );

            // Save JSON to file
            File.WriteAllText("baseline.json", json);

            Console.WriteLine("Baseline created successfully.");
        }
    }
}
using cyber_tool;

class Program
{
    static void Main(string[] args)
    {
string folderPath = @"C:\Users\moham\Downloads\cyber-tool\TestFolder";
string baselinePath = "baseline.json";
     Console.WriteLine("=== File Integrity Monitor ===");
Console.WriteLine("[1] Create Baseline");
Console.WriteLine("[2] Verify");
Console.Write("Choice: ");
string choice = Console.ReadLine();

if (choice == "1")
{
    Baseline.CreateBaseline(folderPath);
}
else if (choice == "2")
{
    IntegrityChecker.Verify(folderPath, baselinePath);
}

    }
}
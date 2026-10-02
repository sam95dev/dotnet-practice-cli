namespace App.Service;

partial class CommonService
{
    /// <summary>
    /// Reads the file and prints its contents to the console.
    /// </summary>
    /// <param name="file">The file to read.</param>
    /// <param name="maxReadLines">The maximum number of lines to read.</param>
    public static void ReadFile(FileInfo file, int maxLines)
    {
        for (int i = 0; i < maxLines; i++)
        {
            string line = File.ReadLines(file.FullName).ElementAt(i);
            Console.WriteLine(line);
        }
    }
}

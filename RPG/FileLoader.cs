using System.Text;

namespace RPG.Backend;

public class FileLoader
{
    public static string GetFileContent(string filename)
    {
        string pwd = "resources/";
        return File.ReadAllText(pwd + filename + ".txt", Encoding.UTF8);
    }

    public static string GetDirectoryContents(string directory)
    {
        DirectoryInfo dirInfo = new DirectoryInfo(directory);
        FileInfo[] files = dirInfo.GetFiles();
        
        return string.Join(Environment.NewLine, files.Select(file => file.Name));
    }
}

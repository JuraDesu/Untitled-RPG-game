using System.Text;
using ANSIConsole;

namespace RPG;

public class Decorations
{
    public static string Separator(int width)
    {
        return new string('-', width);
    }

    public static string Titlebar(string title, int width, ConsoleColor titleColor)
    {
        string separator = new string( '-',(width - title.Length - 2 ) / 2);
        string separator2 = new string( '-',(width - title.Length - 2 ) / 2 + title.Length % 2);
        StringBuilder titleBarBuilder = new StringBuilder();
        titleBarBuilder.Append(separator);
        titleBarBuilder.Append($"[{title.Color(titleColor)}]");
        titleBarBuilder.Append(separator2);
        return titleBarBuilder.ToString();
    }
    public static string ProgressBar(float value, float compared, ConsoleColor PBcolor)
    {
        char empty = '-';
        char full = '#';
        string progressbar = "";
        int progressBarWidth = 20;
        
        double progress = Math.Ceiling(value / compared * progressBarWidth);

        for (int i = 0; i < progressBarWidth; i++)
        {
            if (i < progress) progressbar += full;
            else progressbar += empty;
        }

        return $"[{progressbar.Color(PBcolor)}] {value / compared * 100f} %";
    }
}
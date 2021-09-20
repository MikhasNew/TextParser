using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace TextParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string resPath = assemblyPath + "\\Resource\\Sample.txt";

            using (var sr = new StreamReader(resPath))
            {

                //(?<!Dr|Mr|Ms|St|aet|Fig|pp|(?:[A-Za-z]\.[A-Za-z])| [A-Z]|[A-Z]{2,})([\.?!]{1,})(?=(?:["*)}\]]{0,}[\s]{1,}["]{0,1}[A-Z0-9*#_({[=]))
                var text = sr.ReadToEnd();
                string pattern = $"[\"]?[A-Z][\\S\\s]+?(?:[\\S][^A-Z\\.])+(?:\\.+|[?!])[\"]?(?!(\\s*[a-z)\\-\"«0-9\\?!.][\"]))"; //шаблон регулярного выражения
                MatchCollection mc = Regex.Matches(text, pattern, RegexOptions.Multiline);

                string patern2 = @"(?<!Dr|Mr|Ms|St|aet|Fig|pp|(?:[A-Za-z]\.[A-Za-z])| [A-Z]|[A-Z]{2,})([\.?!]{1,})(?=(?:[""*)}\]]{0,}[\s]{1,}[""]{0,1}[A-Z0-9*#_({[=]))";
                var ggg = Regex.Split(text, patern2);

                //string[] splitSentences = Regex.Split(text, $"[\"]?[A-Z][\\S\\s]+?(?:[\\S][^A-Z\\.])+(?:\\.+|[?!])[\"]?(?!(\\s*[a-z)\\-\"«0-9\\?!.][\"]))");

            }
        }
    }
}

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

            //string resPath = assemblyPath + "\\Resource\\SampleBig.txt";

            List<string> offersList = new List<string>();
            StringBuilder concatSb = new StringBuilder();
            


            string offersSplitPattern = @"(?<=(?<!Dr|Mr|Ms|St|aet|Fig|pp|(?:[A-Za-z]\.[A-Za-z])| [A-Z]|[A-Z]{2,})(?:[\.?!]{1,})(?=(?:[""*)}\]]{0,}[\s]{1,}[""]{0,1}[A-Z0-9*#_({[=])))";
            Regex offersSplitRegex = new Regex(offersSplitPattern);
            

            string wordsPattern = @"(?:[\w<>|+=&_@#$%*(){}[\]]{1,})";
            Regex wordsRegex = new Regex(wordsPattern);
            Dictionary<int, string> wordsDictyonary = new Dictionary<int, string>();

            string punctPattern = @"(?:[\s,.?!:;\-""']{1,})";
            Regex punctRegex = new Regex(punctPattern);
            Dictionary<int, string> punctDictionary = new Dictionary<int, string>();

            // Dictionary<int, Dictionary<int, string>> linesDictionary = new Dictionary<int, Dictionary<int, string>>();
            Dictionary<Key, string> linesDictionary = new Dictionary<Key, string>();

            using (var sr = new StreamReader(resPath))
            {
                String tempString = "";
                //var stringLine = sr.ReadLine() + "\n";
                var stringLine = sr.ReadLine();
                int linesNumber =0;
                while (stringLine != null)
                {
                    //var words = wordsRegex.Matches(stringLine);
                    //foreach (Match word in words)
                    //{
                    //    linesDictionary.Add(new Key(linesNumber, word.Index, true), word.Value);
                    //   // wordsDictyonary.Add(word.Index, word.Value);
                    //}

                    //var punctSimbls = punctRegex.Matches(stringLine);
                    //foreach (Match simbl in punctSimbls)
                    //{
                    //    linesDictionary.Add(new Key(linesNumber, simbl.Index, false), simbl.Value);
                    //    // punctDictionary.Add(simbl.Index, simbl.Value);
                    //}

                    
                    var offersItems = offersSplitRegex.Split(string.Concat(tempString, stringLine)); // in dictionary test dell  + "\n"
                    for (int i = 0; i < offersItems.Length-1; i++)
                    {
                        //offersList.Add(offersItems[i]);

                        var words = wordsRegex.Matches(offersItems[i]);
                        foreach (Match word in words)
                        {
                            linesDictionary.Add(new Key(linesNumber, word.Index, true), word.Value);
                            // wordsDictyonary.Add(word.Index, word.Value);
                        }

                        var punctSimbls = punctRegex.Matches(offersItems[i]);
                        foreach (Match simbl in punctSimbls)
                        {
                            linesDictionary.Add(new Key(linesNumber, simbl.Index, false), simbl.Value);
                            // punctDictionary.Add(simbl.Index, simbl.Value);
                        }

                        linesNumber++;
                    }

                   
                        

                    tempString = offersItems.Last();
                    stringLine = sr.ReadLine();

                    //linesNumber++;
                }


                var longstOffers = linesDictionary.Where(l => l.Key.IsWord == true);




                //(?<!Dr|Mr|Ms|St|aet|Fig|pp|(?:[A-Za-z]\.[A-Za-z])| [A-Z]|[A-Z]{2,})([\.?!]{1,})(?=(?:["*)}\]]{0,}[\s]{1,}["]{0,1}[A-Z0-9*#_({[=]))
                var text = sr.ReadToEnd();
               // string pattern = $"[\"]?[A-Z][\\S\\s]+?(?:[\\S][^A-Z\\.])+(?:\\.+|[?!])[\"]?(?!(\\s*[a-z)\\-\"«0-9\\?!.][\"]))"; //шаблон регулярного выражения
                MatchCollection mc = Regex.Matches(text, offersSplitPattern, RegexOptions.Multiline);


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

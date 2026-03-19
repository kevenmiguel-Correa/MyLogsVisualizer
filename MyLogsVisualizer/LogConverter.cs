using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyLogsVisualizer
{
    public class LogConverter
    {
        private static readonly Regex regex = new Regex(
           @"\[(.*?) (.*?)\] (.*)",
           RegexOptions.Compiled);

        public static List<LogDto> Parse(string path)
        {
            var lines = File.ReadAllLines(path);
            var result = new List<LogDto>();

            foreach (var line in lines)
            {
                var match = regex.Match(line);
                var rawLevel = match.Groups[2].Value;

                // "00:00:24 WRN"
                var parts = rawLevel.Split(' ');
                var levelShort = parts.Last(); // WRN
                var time = parts.First();      // 00:00:24

                if (match.Success)
                {
                    result.Add(new LogDto
                    {
                        Timestamp = match.Groups[1].Value,
                        Level = ConvertLevel(levelShort),
                        Message = match.Groups[3].Value,
                        RawLine = line
                    });
                }
                else
                {
                    // Si no matchea, lo agregamos crudo
                    result.Add(new LogDto
                    {
                        Timestamp = "",
                        Message = line,
                        Level = "Unknown",
                        RawLine = line
                    });
                }
            }

            return result;
        }

        private static string ConvertLevel(string shortLevel)
        {
            return shortLevel switch
            {
                "INF" => "Information",
                "WRN" => "Warning",
                "ERR" => "Error",   
                "DBG" => "Debug",
                _ => shortLevel
            };
        }
    }
}

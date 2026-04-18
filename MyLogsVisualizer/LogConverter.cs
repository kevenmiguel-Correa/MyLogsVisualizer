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
    @"\[(\d{4}-\d{2}-\d{2}) (\d{2}:\d{2}:\d{2}) (\w{3})\] (.*)",
    RegexOptions.Compiled);

        public static List<LogDto> Parse(string path)
        {
            var lines = File.ReadAllLines(path);
            var result = new List<LogDto>();

            foreach (var line in lines)
            {
                var match = regex.Match(line);
                var rawLevel = match.Groups[2].Value;


                if (match.Success)
                {
                    var date = match.Groups[1].Value;
                    var time = match.Groups[2].Value;
                    var levelShort = match.Groups[3].Value;
                    result.Add(new LogDto
                    {
                        Timestamp = $"{date} {time}",
                        Level = ConvertLevel(levelShort),
                        Message = match.Groups[4].Value,
                        RawLine = line
                    });
                }
                else
                {
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

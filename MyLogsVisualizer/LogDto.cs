using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogsVisualizer
{
    public class LogDto
    {
        public string? Timestamp { get; set; }
        public string? Level { get; set; }
        public string? Message { get; set; }
        public string? RawLine { get; set; }
    }
}

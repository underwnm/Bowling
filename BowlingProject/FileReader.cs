using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingProject
{
    class FileReader
    {
        public string[] lines;
        private string textFile;

        public FileReader(string textFile)
        {
            this.textFile = textFile;
        }
        public string[] ReadFromFile()
        {
            lines = File.ReadAllLines(textFile);
            return lines;
        }
    }
}
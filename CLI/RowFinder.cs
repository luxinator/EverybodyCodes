using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace CLI
{
    public class RowFinder
    {
        private readonly string dataFile;

        public RowFinder(string dataFile)
        {
            this.dataFile = dataFile;
        }

        public void PrintMatchedRow(string searchString)
        {
            var pattern = new Regex(searchString);
            foreach (var line in GetLines())
            {
                var m = pattern.Match(line);
                if (m.Success)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void PrintContainingRow(string searchString)
        {
            foreach (var line in GetLines())
            {
                if (line.Contains(searchString))
                    Console.WriteLine(line);
            }
        }

        public void DumpFileToStdOut()
        {
            foreach (var line in GetLines())
                Console.WriteLine(line);
        }


        private IEnumerable<string> GetLines()
        {
            using (var data = File.OpenRead(dataFile))
            using (var reader = new StreamReader(data))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
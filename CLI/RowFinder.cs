using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace CLI
{
    public class RowFinder : IDisposable
    {
        private readonly FileStream data;
        
        public RowFinder(string dataFile)
        {
            data = File.OpenRead(dataFile);
        }
        
        public void PrintMatchedRow(string searchString)
        {
            var pattern = new Regex(searchString);
            
            using (var reader = new StreamReader(data))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    var m = pattern.Match(line);
                    if (m.Success)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }

        public void PrintContainingRow(string searchString)
        {
            using (var reader = new StreamReader(data))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(searchString))
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            
        }

        public void DumpFileToStdOut()
        {
            using (var reader = new StreamReader(data))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

            }

        }
        
        public void Dispose()
        {
            data?.Dispose();
        }
    }
}
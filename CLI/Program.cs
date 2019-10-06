using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using CommandLine;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(opts => Start(opts));
        }

        private static void Start(Options opts)
        {
            var file = opts.File;

            if (!File.Exists(file))
            {
                Console.WriteLine($"Could not open {file}");
                return;
            }

            var rf = new RowFinder(file);

            if (!string.IsNullOrEmpty(opts.Search))
            {
                rf.PrintContainingRow(opts.Search);
            }
            else if (!string.IsNullOrEmpty(opts.Regex))
            {
                rf.PrintMatchedRow(opts.Regex);
            }
            else
            {
                rf.DumpFileToStdOut();
            }
        }
    }
}
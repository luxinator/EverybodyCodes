using CommandLine;

namespace DatabaseLoader
{
    public class Options
    {
        [Option('d', "dbPath", Required = true, HelpText = "Path to sqlite db")]
        public string dbPath { get; set; }
        
        [Option('c', "csvPath", Required = true, HelpText = "Path to csv")]
        public string csvPath { get; set; }
    }
}
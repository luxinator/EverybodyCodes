using CommandLine;

namespace CLI
{
    public class Options
    {
        [Option('s', "search", Required = false, HelpText = "Search for a given string")]
        public string Search { get; set; }

        [Option('r', "regex", Required = false, HelpText = "Fine a line matching given regex")]
        public string Regex { get; set; }


        [Option('f', "file", Required = false, HelpText = "File to check")]
        public string File { get; set; } = "data/cameras-defb.csv";
    }
}
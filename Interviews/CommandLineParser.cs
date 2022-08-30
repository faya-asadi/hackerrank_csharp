using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    // -g -h -name faya saya -numbers 6758 90987

    public class CommandLineParser
    {

        Dictionary<string, List<string>> _arguemnts;
        List<String> _flags;

        public CommandLineParser(string[] args)
        {
            _arguemnts = new Dictionary<string, List<string>>();
            _flags = new List<string>();

        }

        public List<string> GetArgumentNames()
        {
            return new List<string>(_arguemnts.Keys);
        }

        public List<string> GetArgumentValue(string name)
        {
            List<string> value;
            if (_arguemnts.TryGetValue(name, out value))
            {
                return value;
            }
            return null;
        }

        public List<string> GetFlags()
        {
            return _flags;
        }

        private void Map(string[] args)
        {
            int index = 0;
            while (index < args.Length)
            {
                if (args[index].StartsWith("_") && index < args.Length && !args[index + 1].StartsWith("_"))
                {
                    var key = args[index];
                    _arguemnts[key] = new List<string>();
                    index++;
                    while (index < args.Length && !args[index].StartsWith("_"))
                    {
                        _arguemnts[key].Add(args[index]);
                        index++;
                    }
                }
                else
                {
                    _flags.Add(args[index]);
                    index++;
                }
            }
        }


    }
}

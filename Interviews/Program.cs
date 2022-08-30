using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnitLite;
using System.Reflection;


// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    static void Main(string[] args)
    {
        new AutoRun(Assembly.GetCallingAssembly()).Execute(new String[] { "--labels=All" });

        Console.Out.WriteLine("started the test");
        string[] args_ = new string[] { "-g", "-h", "-name", "faya", "saya", "-numbers", "6758", "90987" };
        var cmdp = new CommandLineParser(args_);
        var flags = cmdp.GetFlags();
        Console.Out.WriteLine("Flags are:");
        flags.ForEach(s => Console.Out.WriteLine(s));
        var argsNames = cmdp.GetArgumentNames();
        Console.Out.WriteLine("name of parameters are:");
        argsNames.ForEach(s => Console.Out.WriteLine(s));
    }
}


// -g -h -name faya saya -numbers 6758 90987
public class CommandLineParser
{

    Dictionary<string, List<string>> _arguemnts;
    List<String> _flags;

    public CommandLineParser(string[] args)
    {
        _arguemnts = new Dictionary<string, List<string>>();
        _flags = new List<string>();
        Map(args);
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

    public bool ExistFlag(string flag)
    {
        return _flags.Contains(flag);
    }

    private void Map(string[] args)
    {
        int index = 0;
        while (index < args.Length)
        {
            if (args[index].StartsWith("-") && index+1 < args.Length && !args[index + 1].StartsWith("-"))
            {
                var key = args[index];
                _arguemnts[key] = new List<string>();
                index++;
                while (index < args.Length && !args[index].StartsWith("-"))
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



[TestFixture]
public class UnitTests
{

    CommandLineParser cmdp;
    [SetUp]
    public void Init()
    {
        string[] args_ = new string[] { "-g", "-h", "-name", "faya", "saya", "-numbers", "6758", "90987" };
        cmdp = new CommandLineParser(args_);
    }

    [Test]
    public void TestFlags()
    {
        var flags = cmdp.GetFlags();
        Assert.AreEqual(flags.Count, 2);
        Assert.IsTrue(flags.Contains("-g"));
        Assert.IsFalse(flags.Contains("-numbers"));
    }

    [Test]
    public void TestArgNames()
    {
        var names = cmdp.GetArgumentNames();
        Assert.AreEqual(names.Count, 2);
        Assert.IsTrue(names.Contains("-name"));
    }

    [Test]
    public void CheckFlagExist()
    {
        Assert.IsTrue(cmdp.ExistFlag("-g"));
        Assert.IsFalse(cmdp.ExistFlag("-p"));
    }

}
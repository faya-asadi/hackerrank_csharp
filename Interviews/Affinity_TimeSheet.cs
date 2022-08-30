using System;
using System.Collections.Generic;

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    static void Main(string[] args)
    {
        var test = new SpreadSheet();
        test.Set("A20", "faya");
        test.Set("M9", "57");
        Console.WriteLine(test.Get("M9"));
        Console.WriteLine(test.Get("B77"));
        // Mimi:
        test.Set("A23", "= 10 + 23 - 2");
        Console.WriteLine(test.Get("A23")); // "31"

    }
}


class SpreadSheet
{

    Dictionary<string, string> sp;

    public SpreadSheet()
    {
        sp = new Dictionary<string, string>();
    }

    public void Set(string location, string value)
    {
        sp[location] = value;
    }

    public string Get(string location)
    {
        string value;
        if (sp.TryGetValue(location, out value))
        {
            return ParseAndCalculate(value);
        }
        return "";
    }

    private string ParseAndCalculate(string str)
    {
        //"= 10 + 23 - 2"  all even indexes have operator
        int result = 0;
        var splitStr = str.Split(" ");
        if (!splitStr[0].Equals("="))
        {
            return str;
        }
        result = Int16.Parse(splitStr[1]);
        int index = 2;
        string lastOPerator = "";
        while (index < splitStr.Length)
        {
            if (index % 2 == 0)
            {
                lastOPerator = splitStr[index];
            }
            else
            {
                switch (lastOPerator)
                {
                    case "+":
                        result += Int16.Parse(splitStr[index]);
                        break;
                    case "-":
                        result -= Int16.Parse(splitStr[index]);
                        break;
                }
            }
            index++;
        }
        return result.ToString(); ;
    }
}

// Your previous Plain Text content is preserved below:

// Implement a spreadsheet where cells need to support string values like “Sunday” and “10”. Cell locations are identified by "A1" or "C3". You can assume at most 26 columns, namely A to Z, but no bounds exist for the number of rows. You can assume all input to the API will be valid.

// Implement an API to: 
//   A. Set a cell value. Accepts a string value and a cell location.
//   B. Get a cell value. Accepts a cell location. Returns a string value.

// Implement the ability to enter formulas into cells. 
// You can assume simple expressions of the form “= 10 + 23 - 2” and only integer operands. There will always be a single space between an operator and an operand.
// You only need to support +/- and you can assume a left-to-right order of evaluation.
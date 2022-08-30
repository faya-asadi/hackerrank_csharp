using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



public class Solution {
    public List< List<int> > Subsets(int[] nums) {
        return subset(nums);
    }
    
    public List< List<int> > subset(int[] nums){
       List< List<int> > subsets = new List< List<int> >();
        subsets.Add(new List<int>());
        foreach(var n in nums){
            var tempSubset = new List<List<int>>();
            foreach(var sub in subsets){
                var s = new List<int>();
                s.AddRange(sub);
                s.Add(n);
                tempSubset.Add(s);
            }   
            subsets.AddRange(tempSubset);
        }
        return subsets;
    }
    
}

class Program
{
    public static void Main(string[] args)
    {
      var solution = new Solution();
    //  int[] nums = new int[1, 3, 4, 7,9];
      var result = solution.Subsets(new int[]{1, 3, 4, 7,9});
      foreach(var ss in result){
        ss.ForEach( a=> Console.Write($"{a}, " ) );
        Console.WriteLine();
      }

      //Console.WriteLine(Convert.ToString(5, 2) );
    }

    
}

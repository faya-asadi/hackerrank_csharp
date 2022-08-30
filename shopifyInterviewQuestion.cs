// # Write a function that takes a list of integers and outputs a list of pairs
// # representing the consecutive ranges contained in the inputlist
// #
// # test_list1 = [1,3,4]
// # test_output1 = [(1,1),(3,4)]
// #
// # test_list2 = [1,2,3,4,5]
// # test_output2 = [(1,5)]
// #
// # test_list3 = [1,3,4,5,6,7,9]
// # test_output3 = [(1,1), (3,7), (9,9)]



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


public class Shopify{
    
    public List<(int, int)> consecutivePairs(int[] input){
        var output = new List<(int, int)>();
        var beginIndex = 0;
        var lastIndex = 0;
        while(beginIndex < input.Length && lastIndex< input.Length ){
            var begin = input[beginIndex];
            var end = input[lastIndex];           
            while(lastIndex+1 <input.Length &&   input[lastIndex+1] == input[lastIndex]+1){
               lastIndex++;
            }
            output.Add((input[beginIndex], input[lastIndex]));
            lastIndex++;
            beginIndex = lastIndex;
            
        }
        return output;
        
//         for(int i=0; i<input.Length; i++){
            
//             var begin = input[i];
//             Console.WriteLine($"i: {i}, begin: {begin}");
//             var end = begin;
//             for(int j = i+1; j< input.Length; j++){
//                 if(input[j] == end+1){
//                     end++;
//                 }
//                 else{
//                     Console.WriteLine($"begin: {begin}, end: {end}");
//                     output.Add((begin, end));
//                     continue;
//                 }
//             }
//         }
        
//         return output;
        
        
    }
    
}


// To execute C#, please define "static void Main" on a class
// named Solution.

class Program
{
    static void Main(string[] args)
    {
             
        var entity = new Shopify();
        var result = entity.consecutivePairs( new int[]{1,3,4} );
        
        result.ForEach( o => Console.WriteLine($" ( {o.Item1}, {o.Item2} ) "));
        
    }
}






















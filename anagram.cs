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

class Result
{

    /*
     * Complete the 'sherlockAndAnagrams' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

     //abba
     
    private static string reverse(string s){
        char[] charArray = s.ToCharArray();
        Array.Reverse( charArray );
        return new string( charArray );
    }
    
   
    
     
    public static int sherlockAndAnagrams(string s)
    {
        int counter = 0;
        var dic = new Dictionary<string, int>();
        for(int i=0; i<= s.Count(); i++){
            for(var j = 1; i+j<= s.Count(); j++){
                var substr = s.Substring(i, j);  
                var sorted = new string(substr.OrderBy(c=> c).ToArray() );
                if(dic.ContainsKey(sorted)){
                    if(dic[sorted] == 0){
                        dic[sorted]++;
                    }else{
                        dic[sorted]+= 2* dic[sorted];
                    }
                }else{
                    dic[sorted] = 0;
                }                
            }
        }
       
        return  dic.Values.Sum(v=>v);
    }
    
    

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = Result.sherlockAndAnagrams(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}

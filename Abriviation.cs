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
     * Complete the 'abbreviation' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING a
     *  2. STRING b
     */

    public static string abbreviation(string a, string b)
    {
        var isValid = new bool[a.Length+1, b.Length+1];
        isValid[0, 0] = true;
        
        
        for (int i= 1; i <= a.Length; i++) {
            if (char.IsUpper(a[i - 1]) ) {
                isValid[i, 0] = false;
            }
            else isValid[i, 0] = true;
        }
        
        
        for(int i=1; i<=a.Length; i++){
            for(int j = 1; j<=b.Length; j++){
                 if(String.Compare(a[i-1].ToString(), b[j-1].ToString(), StringComparison.InvariantCultureIgnoreCase) == 0){
                     isValid[i, j] = isValid[i-1, j-1];
                 }
                 else if( char.IsLower(a[i-1])){
                      isValid[i, j] = isValid[i-1, j];
                 }
                 else{
                     isValid[i, j] = false;
                 }
            }
        }
        return (isValid[a.Length, b.Length]) ? "YES" : "NO";
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
            string a = Console.ReadLine();

            string b = Console.ReadLine();

            string result = Result.abbreviation(a, b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}

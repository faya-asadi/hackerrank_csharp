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

class Program {

    public class Player{
      public int Score {
        get;
      }
      public string Name{
        get;
      }
      public Player(string name, int score){
             Name= name;
             Score = score;
      }
    }
    

    public class PlayerComparar : IComparer<Player>{
      public int Compare(Player x, Player y){
        if(x== y){
          return 0;
        }
        // if(x.Score == y.Score && string.Compare(x.Name, y.Name) == 0){
        //   return 0;
        // }

        if(x.Score > y.Score){
          return -1;
        }
        if (x.Score < y.Score){
          return 1;
        }

        // //x.Score = y.Score
        // var strcmpr = string.Compare(x.Name, y.Name); 

        // return strcmpr == 0? 0 : -1*strcmpr;

       return string.Compare(x.Name, y.Name);
       

      }
    }
    


 
    static void Main(string[] args) {
      List<Player> ps= new List<Player> {
        new Player("amy", 100),
        new Player("david", 100),
        new Player("heraldo", 50),
        new Player("aakansha", 75),
        new Player("aleksa", 150)
      };

      Console.WriteLine("before sort: ");
      ps.ForEach(p=> Console.WriteLine($"{p.Name} , {p.Score}"));

      ps.Sort(new PlayerComparar());

      

       Console.WriteLine("\n\nafter sort: ");
      ps.ForEach(p=> Console.WriteLine($"{p.Name} , {p.Score}"));
      





      // var list = new List<int>{1,2,3,4,5};
      // list.ForEach(l=> Console.WriteLine(l));
      //  long result = substrCount("abcbaba".Length, "abcbaba");
      // Console.WriteLine($"reuslt: {result}");
    }
}

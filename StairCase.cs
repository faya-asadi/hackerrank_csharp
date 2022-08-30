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




public class Staircase {

  public int goUp(int n){
    if(n==1){
      return 1;
    }
    if(n==2){
      return 2;
    }
    if(n==3){
      return 3;
    }
    return goUp(n-1)+goUp(n-2)+goUp(n-3);
  }

}

class Program
{
    public static void Main(string[] args)
    {
      Console.WriteLine( new Staircase().goUp(4) );
    }

    
}

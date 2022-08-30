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




public class LRUCache {

   public LinkedList<(int, int)> _cash ;
    Dictionary<int, LinkedListNode<(int, int)> > _dic;
    int _capacity;

    public LinkedListNode<(int, int)> First {
      get{ return _cash.First;}
    }

    public LinkedListNode<(int, int)> Last {
        get{ return _cash.Last;}
    }

    public int Count{
      get{return _cash.Count;}
    }  

    public LRUCache(int capacity) {
      _cash = new LinkedList<(int, int)>();
      _dic = new Dictionary<int,LinkedListNode<(int, int)> >(); 
      _capacity = capacity;
    }
    
    public int Get(int key) {

      if(!_dic.ContainsKey(key)){
        return -1;
      }
      
      var node = _dic[key];
      _cash.Remove(node);
      _cash.AddFirst(node);
      var (a,b) = node.Value;  
      return b;
    }
    
    public void Put(int key, int value) {
      if(_dic.ContainsKey(key)){
        var node = _dic[key];
        _cash.Remove(node);
        node.Value = (key, value);
        _cash.AddFirst(node);
        return;
      }
      if(_cash.Count < _capacity){
         _cash.AddFirst( (key,value) ) ;
         _dic[key] = _cash.First;
         return;
      }
     var nodeLast = _cash.Last;
     var (a, b) = nodeLast.Value;
     Console.WriteLine($"removed: {a}, {b}");
     _dic.Remove(a);
     _cash.Remove(nodeLast);   
     _cash.AddFirst( (key,value) ) ;
     _dic[key] = _cash.First;     
    }
}

class Program
{
    public static void Main(string[] args)
    {
      int g;
      var lru = new LRUCache(3);
      g = lru.Get(2);
      Console.WriteLine(g);

      lru.Put(1,1);    
      Print(lru);  
      lru.Put(2,2);
      Print(lru);  
      Console.WriteLine (lru.Get(2));

      
      lru.Put(1,4);
      Print(lru);  

      lru.Put(3,3);

      Print(lru);  

       lru.Put(4,4);

      Print(lru);  



      //  string result = Result.abbreviation("daBcd", "ABC");
      //  Console.WriteLine(result);

    }

    static void Print(LRUCache lru){
      var first = lru.First;   
      var last = lru.Last;  
      var(a, b) = first.Value;
      var(c, d) = last.Value; 
      Console.WriteLine($"First:   {a} and {b}");
      Console.WriteLine($"First:   {c} and {d}");
      Console.WriteLine($"the size of the cash is {lru.Count}");
    }
}

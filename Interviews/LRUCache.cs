using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class LRUCache
    {

        Dictionary<int, int> cache;
        int cap;
        List<int> keys;

        public LRUCache(int capacity)
        {
            cache = new Dictionary<int, int>();
            keys = new List<int>();
            cap = capacity;
        }

        public int Get(int key)
        {
            if (cache.ContainsKey(key))
            {
                int index = keys.IndexOf(key);
                keys.RemoveAt(index);
                keys.Add(key);
                return cache[key];
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (cache.ContainsKey(key))
            {
                int index = keys.IndexOf(key);
                keys.RemoveAt(index);
                keys.Add(key);
                cache[key] = value;

            }
            else
            {
                if (keys.Count >= cap)
                {
                    key = keys[0];
                    cache.Remove(key);
                    keys.RemoveAt(0);
                }
                keys.Add(key);
                cache[key] = value;
            }
        }
    }
}

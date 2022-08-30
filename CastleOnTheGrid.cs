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
     * Complete the 'minimumMoves' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING_ARRAY grid
     *  2. INTEGER startX
     *  3. INTEGER startY
     *  4. INTEGER goalX
     *  5. INTEGER goalY
     */

    public static int minimumMoves(List<string> grid, int startX, int startY, int goalX, int goalY)
    {
        var row = grid.Count;
        var cols = grid[0].Length;
        var moves = new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0)};
        var q = new Queue<(int, int, int)>();
        var visited = new List<(int, int)>();
        var pathDic = new Dictionary<(int, int), (int, int)>();
        
        if(startX == goalX && startY == goalY){
            return 0;
        }
        
        
        q.Enqueue((startX, startY, 0));
        visited.Add((startX, startY));
        pathDic.Add((startX, startY), (-1, -1));
        
        while(q.Count > 0){            
            var(x, y, val) = q.Dequeue();
            
            for(int c = 0; c < moves.Count; c++){                
                var(i, j) = moves[c];
                var(nrow, ncol) = (x, y);
                
                while(true){
                    (nrow, ncol) = (nrow+i, ncol+j);
                    if( nrow >=0 && nrow < row && ncol>= 0 && ncol < cols && grid[nrow][ncol] == '.' ){                        
                        if(nrow == goalX && ncol == goalY ){
                            return val+1;
                        }
                        else if (!visited.Contains((nrow, ncol)) ) {
                            q.Enqueue((nrow, ncol, val+1));
                            visited.Add((nrow, ncol));
                            pathDic.Add((nrow, ncol), (x,y));
                        }
                        
                    }
                    else{
                        break;
                    }
                   
                }
               
            }
        }
        
        return -1;
        
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> grid = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int startX = Convert.ToInt32(firstMultipleInput[0]);

        int startY = Convert.ToInt32(firstMultipleInput[1]);

        int goalX = Convert.ToInt32(firstMultipleInput[2]);

        int goalY = Convert.ToInt32(firstMultipleInput[3]);

        int result = Result.minimumMoves(grid, startX, startY, goalX, goalY);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

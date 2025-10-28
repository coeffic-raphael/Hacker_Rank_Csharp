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
     * Complete the 'queensAttack' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER r_q
     *  4. INTEGER c_q
     *  5. 2D_INTEGER_ARRAY obstacles
     */
    
    static bool inBoard(int n, int x, int y)
    {
        return x >=1 && x <= n && y >= 1 && y <= n;
    }
    
    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        int total_possible_attack = 0;
        
        HashSet<(int, int)> obstacleSet = new HashSet<(int, int)>();
        
        foreach (var obstacle in obstacles)
        {
            obstacleSet.Add((obstacle[0], obstacle[1]));
        }
        
        List<(int, int)> directions = new List<(int, int)>
        {
            (0,1),
            (0,-1),
            (1,0),
            (-1,0),
            (1,1),
            (-1,-1),
            (1,-1),
            (-1,1)
        };
        
        foreach (var dir in directions)
        {
            int r = r_q + dir.Item1;
            int c = c_q + dir.Item2;
            
            while (inBoard(n, r, c))
            {
                if (obstacleSet.Contains((r,c)))
                {
                    break;
                }
                
                total_possible_attack++;
                
                r += dir.Item1;
                
                c+= dir.Item2;
                
                
            }
        }
        return total_possible_attack;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r_q = Convert.ToInt32(secondMultipleInput[0]);

        int c_q = Convert.ToInt32(secondMultipleInput[1]);

        List<List<int>> obstacles = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            obstacles.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp)).ToList());
        }

        int result = Result.queensAttack(n, k, r_q, c_q, obstacles);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

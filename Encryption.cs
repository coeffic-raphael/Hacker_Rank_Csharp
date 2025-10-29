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
     * Complete the 'encryption' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string encryption(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) 
            return "";
        
        s = s.Replace(" ", "");
        int L = s.Length;
        double root = Math.Sqrt(L);
        int rows = (int)Math.Floor(root);
        int cols = (int)Math.Ceiling(root);
        
        
        if (rows * cols < L) 
            rows++;
        
        var sb = new StringBuilder();
        for (int c = 0; c < cols; c++)
        {
            for (int i = c; i < L; i += cols)
            {
                sb.Append(s[i]);
            }
            
            if (c < cols - 1) sb.Append(' ');
        }
        
        return sb.ToString();
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

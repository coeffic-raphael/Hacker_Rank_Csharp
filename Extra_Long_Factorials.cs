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
using System.Numerics; // For use BigInteger


class Result
{

    /*
     * Complete the 'extraLongFactorials' function below.
     *
     * The function accepts INTEGER n as parameter.
     */
    
    public static void extraLongFactorials(int n)
    {
        BigInteger res = BigInteger.One;
        
        for (int i = 2; i <= n; i++)
        {
            res *= i;
        }
        
        Console.WriteLine(res);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        Result.extraLongFactorials(n);
    }
}

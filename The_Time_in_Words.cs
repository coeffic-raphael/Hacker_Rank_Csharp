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
     * Complete the 'timeInWords' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER h
     *  2. INTEGER m
     */
    static string NumToString(int num)
    {
        List<string> digits = new List<string>
        { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        List<string> teens = new List<string>
        { "ten", "eleven", "twelve", "thirteen", "fourteen",
          "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty" };
        if (num > 0 && num <= 9)
            return digits[num - 1];
        if (num >= 10 && num <= 19)
            return teens[num % 10];
        if (num >= 20 && num <= 60)
        {
            if (num % 10 == 0)
                return tens[num / 10];
            else
                return tens[num / 10] + " " + digits[(num % 10) - 1];
        }
        return "";
    }

    public static string timeInWords(int h, int m)
    {
        if (m == 0)
            return NumToString(h) + " o' clock";
        if (m == 15)
            return "quarter past " + NumToString(h);
        if (m == 30)
            return "half past " + NumToString(h);
        if (m == 45)
            return "quarter to " + NumToString(h + 1);
        if (m == 1)
            return NumToString(m) + " minute past " + NumToString(h);
        if (m < 30)
            return NumToString(m) + " minutes past " + NumToString(h);
        int rest = 60 - m;
        if (rest == 1)
            return NumToString(rest) + " minute to " + NumToString(h + 1);
        return NumToString(rest) + " minutes to " + NumToString(h + 1);
    }
    

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

using CTCI.CH1;
using System;

namespace CTCI
{
    class Program
    {
        // Test cases
        static void Main(string[] args)
        {
            var CH1 = new Chapter1();
            Console.WriteLine($"IsUnique: {CH1.IsUnique("abcd")}");
            Console.WriteLine($"IsUnique: {CH1.IsUnique("aacd")}");
            Console.WriteLine($"IsUnique: {CH1.IsUnique1("abcd")}");
            Console.WriteLine($"IsUnique: {CH1.IsUnique1("aacd")}");
            Console.WriteLine($"IsUnique: {CH1.IsUnique2("abcd")}");
            Console.WriteLine($"IsUnique: {CH1.IsUnique2("aacd")}");

            Console.WriteLine($"CheckPermutation: {CH1.CheckPermutation("abc", "bca")}");
            Console.WriteLine($"CheckPermutation1: {CH1.CheckPermulation2("abc", "bca")}");
          
            Console.WriteLine($"CheckPermutation: {CH1.CheckPermutation("abcdeg", "bcaegd")}");
            Console.WriteLine($"CheckPermutation1: {CH1.CheckPermulation2("abcdeg", "bcaegd")}");

            Console.WriteLine($"CheckPermutation: {CH1.CheckPermutation("abc", "cbd")}");
            Console.WriteLine($"CheckPermutation1: {CH1.CheckPermulation2("abcdeg", "bcaegp")}");

            Console.WriteLine($"UrLify: {CH1.URLify("Mr John Smith    ",13)}");

            Console.WriteLine($"Palindrome Permutation: {CH1.PalindomePermutation("atcctab")}");


        }
    }
}

using CTCI.CH1;
using CTCI.CH2;
using System;

namespace CTCI
{
    class Program
    {
        // Test cases
        static void Main(string[] args)
        {
            #region 
            // var CH1 = new Chapter1();
            // Console.WriteLine($"IsUnique: {CH1.IsUnique("abcd")}");
            // Console.WriteLine($"IsUnique: {CH1.IsUnique("aacd")}");
            // Console.WriteLine($"IsUnique: {CH1.IsUnique1("abcd")}");
            // Console.WriteLine($"IsUnique: {CH1.IsUnique1("aacd")}");
            // Console.WriteLine($"IsUnique: {CH1.IsUnique2("abcd")}");
            // Console.WriteLine($"IsUnique: {CH1.IsUnique2("aacd")}");

            // Console.WriteLine($"CheckPermutation: {CH1.CheckPermutation("abc", "bca")}");
            // Console.WriteLine($"CheckPermutation1: {CH1.CheckPermulation2("abc", "bca")}");
          
            // Console.WriteLine($"CheckPermutation: {CH1.CheckPermutation("abcdeg", "bcaegd")}");
            // Console.WriteLine($"CheckPermutation1: {CH1.CheckPermulation2("abcdeg", "bcaegd")}");

            // Console.WriteLine($"CheckPermutation: {CH1.CheckPermutation("abc", "cbd")}");
            // Console.WriteLine($"CheckPermutation1: {CH1.CheckPermulation2("abcdeg", "bcaegp")}");

            // Console.WriteLine($"UrLify: {CH1.URLify("Mr John Smith    ",13)}");

            // Console.WriteLine($"Palindrome Permutation: {CH1.PalindomePermutation("atcctab")}");

            #endregion
            Chapter2 CH2 = new Chapter2();
            Node ex1 = new Node(1);
            ex1.next = new Node(2);
            ex1.next.next = new Node(3);
            ex1.next.next.next = new Node(4);
            ex1.next.next.next.next = new Node(5);

            Node ex2 = new Node(1);
            ex2.next = new Node(2);
            ex2.next.next = new Node(3);
            ex2.next.next.next = new Node(3);
            ex2.next.next.next.next = new Node(4);

            Node ex3 = new Node(1);
            ex2.next = new Node(2);
            ex2.next.next = new Node(2);
            ex2.next.next.next = new Node(3);
            ex2.next.next.next.next = new Node(3);
            ex2.next.next.next.next.next = new Node(4);

            // CH2.RemoveDups1(ex1);
            // CH2.RemoveDups1(ex2);
            // CH2.RemoveDups1(ex3);

            // CH2.RemoveDups2(ex1);
            // CH2.RemoveDups2(ex2);
            // CH2.RemoveDups2(ex3);

            // Console.WriteLine($"RemoveDups: ");
            // CH2.PrintLinkedList(ex1);
            // Console.WriteLine();
            // CH2.PrintLinkedList(ex1);
            // Console.WriteLine();
            // CH2.PrintLinkedList(ex1);
            // Console.WriteLine();

            Node ans1 = CH2.ReturnKthToLast(ex1, 3);
            Node ans2 = CH2.ReturnKthToLast(ex1, 2);
            Node ans3 = CH2.ReturnKthToLast(ex1, 3);

            Console.WriteLine($"ReturnKthToLast: ");
            CH2.PrintLinkedList(ans1);

        }
    }
}

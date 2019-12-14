using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Wizkids
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------");
            Console.WriteLine("Is Palindrome");
            Console.WriteLine(IsPalindrome("civic"));
            Console.WriteLine("----------------");
            Console.WriteLine("Is not Palindrome");
            Console.WriteLine(IsPalindrome("civir"));
            Console.WriteLine("----------------");
            Console.WriteLine("FooBar");
            FooBar();
            Console.WriteLine("----------------");
            Console.WriteLine("Emails that are valid");
            Console.WriteLine();
            string text = "Christian has the email address christian+123@gmail.com." +
                          " Christian's friend, John Cave-Brown, has the email address john.cave-brown@gmail.com." +
                          " John's daughter Kira studies at Oxford University and has the email adress Kira123@oxford.co.uk." +
                          " Her Twitter handle is @kira.cavebrown.";
            Console.WriteLine(ValidEmail(text));
            Console.WriteLine("----------------");
            Console.ReadKey();
        }

        public static bool IsPalindrome(string value)
        {
            int min = 0;
            int max = value.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = value[min];
                char b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }

        static void FooBar()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FooBar");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Foo");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Bar");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        static string ValidEmail(string text)
        {
           string[] words = text.Split(" ");
           string finalword = "";
            List<string> Email = new List<string>();
            const string MatchEmailPattern =
                @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";
            Regex rx = new Regex(MatchEmailPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Find matches.
            MatchCollection matches = rx.Matches(text);
            Console.WriteLine("Matched to replace");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
            Console.WriteLine();
            foreach (var word in words)
            {
                finalword = ReplaceEmail(matches, word, finalword);

                if (finalword=="")
                {
                    finalword = word;
                }
                Email.Add(finalword);
                finalword = "";
                
            }
            return ConvertStringArrayToStringJoin(Email);
        }

        private static string ReplaceEmail(MatchCollection matches, string word, string finalword)
        {
            foreach (Match match in matches)
            {   
                if (word.StartsWith(match.Value))
                {
                    finalword = "replaced.";
                    break;
                }
            }

            return finalword;
        }

        static string ConvertStringArrayToStringJoin(List<string> array)
        {
            // Use string Join to concatenate the string elements.
            string result = string.Join(" ", array);
            return result;
        }
    }
}

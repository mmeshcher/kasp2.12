using System;
using System.Collections.Generic;

namespace test2
{
    class MainClass
    {
        public enum DataType
        {
            None = 0,
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4
        }

        public static int TryParseDigit(string s)
        {
            int n = -1;
            int.TryParse(s, out n);
            return n;
        }

        public static string Verify(string str)
        {
            int[] count = new int[Enum.GetNames(typeof(DataType)).Length];

            var strs = str.Split(',');
            string not_valid = "";
            foreach(var s in strs)
            {
                bool vaild = false;
                var res = TryParseDigit(s);
                if (res > 0 && Enum.IsDefined(typeof(DataType), res))
                {
                    count[res] += 1;
                    vaild = true;
                }

                if (Enum.IsDefined(typeof(DataType), s))
                {
                    var type = (int)Enum.Parse(typeof(DataType), s);
                    count[type] += 1;
                    vaild = true;
                }
                if (!vaild)
                {
                    not_valid += not_valid.Length > 0 ? $",{s}" : s;
                }
            }
            var result = $"Input data types:\nNone(0)-{count[0]}\nFirst(1)-{count[1]}\nSecond(2)-{count[2]}\nThird(3)-{count[3]}\nFourth(4)-{count[4]}\nNot valid input strings: {not_valid}";
            return result;
        }

        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            if (String.IsNullOrEmpty(text))
                Console.WriteLine("No data");
            var res = Verify(text);
            Console.WriteLine(res);
        }
    }
}
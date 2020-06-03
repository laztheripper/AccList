using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccList
{
    class Program
    {
        static readonly Dictionary<int, string> digits = new Dictionary<int, string>() {
            { 0, "O" },
            { 1, "I" },
            { 2, "Z" },
            { 3, "E" },
            { 4, "A" },
            { 5, "S" },
            { 6, "D" },
            { 7, "L" },
            { 8, "B" },
            { 9, "G" }
        };

        static string ToStr(int num)
        {
            string s = "";
            string numString = Convert.ToString(num);

            for (int i = 0; i < numString.Length; i++)
            {
                s = s + digits[Int32.Parse(numString[i].ToString())];
            }
                
            return s;
        }

        static void Main(string[] args)
        {
            Console.Title = "AccList 1.0";

            string temp = "\"{0}\": {{\n" +
            "\taccount: \"{1}\",\n" +
            "\tpassword: \"{2}\",\n" +
            "\tcharName: \"{3}\",\n" +
            "\trealm: \"{4}\",\n" +
            "\tladder: {5},\n" +
            "\texpansion: {6},\n" +
            "\thardcore: {7}\n" +
            "}},\n\n";

            Console.WriteLine("Number of accounts? ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Profile prefix? ");
            string profilepre = Console.ReadLine();

            Console.WriteLine("Realm? (useast, uswest, europe, asia) ");
            string realm = Console.ReadLine();

            Console.WriteLine("Account prefix? (empty for random) ");
            string accprefix = Console.ReadLine();

            Console.WriteLine("Password? (empty for random) ");
            string password = Console.ReadLine();

            Console.WriteLine("Char prefix? (empty for random) ");
            string charprefix = Console.ReadLine();

            Console.WriteLine("Ladder? (true, false) ");
            string ladder = Console.ReadLine();

            Console.WriteLine("Expansion? (true, false) ");
            string expansion = Console.ReadLine();

            Console.WriteLine("Hardcore? (true, false) ");
            string hardcore = Console.ReadLine();

            string output = "";

            for (int i = 1; i < num; i++)
            {
                string profile = profilepre + i;
                string acc = "";
                if (accprefix != "")
                {
                    acc = accprefix + i;
                }

                string charname = "";
                if (charprefix != "")
                {
                    charname = charprefix + ToStr(i);
                }

                output += string.Format(temp,
                    profile,
                    acc,
                    password,
                    charname,
                    realm,
                    ladder,
                    expansion,
                    hardcore
                );
            }

            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "out.txt", output);
            Console.WriteLine("Wrote account list to out.txt :)");
            Console.ReadLine();
        }
    }
}

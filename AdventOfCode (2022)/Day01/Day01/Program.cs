using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    class Program
    {
        public static int osszesites(string data)
        {
            string[] elfcalories = data.Split(' ');
            int allcalories = 0;
            for (int i = 0; i < elfcalories.Length; i++)
            {
                allcalories += int.Parse(elfcalories[i]);
            }
            return allcalories;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Day 1: Calorie Counting.");
            StreamReader DataReading = new StreamReader("data.txt", Encoding.UTF8);
            List<string> elves = new List<string>();
            string sor = "";
            while (!DataReading.EndOfStream)
            {
                elves.Add(DataReading.ReadLine());
            }
            for (int i = 0; i < elves.Count; i++)
            {
                if (elves[i] == "")
                {
                    sor += ",";
                }
                else
                {
                    sor += " " + elves[i];
                }
            }
            elves.Clear();
            elves = sor.Split(',').ToList();
            List<int> carriedcalories = new List<int>();
            for (int i = 0; i < elves.Count; i++)
            {
                carriedcalories.Add(osszesites(elves[i].Trim()));
            }
            int mostcalories = carriedcalories[1];
            int elf = 0;
            for (int i = 0; i < carriedcalories.Count; i++)
            {
                if (mostcalories < carriedcalories[i])
                {
                    mostcalories = carriedcalories[i];
                    elf = i + 1;
                }
            }
            Console.WriteLine("The Elf carrying the most Calories: " + elf + ". the quantity that the elf carried: " + mostcalories);
            for (int i = 0; i < carriedcalories.Count; i++)
            {
                for (int j = 0; j < carriedcalories.Count; j++)
                {
                    if (carriedcalories[i] > carriedcalories[j])
                    {
                        int temporary = carriedcalories[i];
                        carriedcalories[i] = carriedcalories[j];
                        carriedcalories[j] = temporary;
                    }
                }
            }
            Console.WriteLine("The three Elf carrying the most Calories:\n" + "1." + carriedcalories[0] + "\n2." + carriedcalories[1] + "\n3." + carriedcalories[2]);
            Console.ReadKey();
        }
    }
}

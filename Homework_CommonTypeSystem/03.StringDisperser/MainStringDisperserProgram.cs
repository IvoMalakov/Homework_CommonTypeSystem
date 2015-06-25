using System;

namespace Disperser
{
    public class MainStringDisperserProgram
    {
        public static void Main()
        {
            try
            {
                StringDisperser stringDisperser = new StringDisperser("gosho", "pesho", "tanio");

                Console.WriteLine("String disperser info: {0}", stringDisperser);

                StringDisperser clonedStringDisperser = (StringDisperser) stringDisperser.Clone();

                Console.WriteLine();
                Console.WriteLine("Cloned string disperser info before changes: {0}", clonedStringDisperser);
                Console.WriteLine("Is string disperser equal to cloned string disperser?: {0}",
                    stringDisperser.Equals(clonedStringDisperser));

                clonedStringDisperser.Name1 = "Sergei";
                clonedStringDisperser.Name2 = "Mestan";
                clonedStringDisperser.Name3 = "Koburgotski";

                Console.WriteLine();
                Console.WriteLine("Cloned string disperser info after changes: {0}", clonedStringDisperser);
                Console.WriteLine("Is string disperser equal to cloned string disperser?: {0}",
                    stringDisperser.Equals(clonedStringDisperser));

                Console.WriteLine();
                Console.WriteLine("Who is greater - string disperser or cloned string disperser?: {0}",
                    stringDisperser.CompareTo(clonedStringDisperser));

                Console.WriteLine();
                Console.WriteLine("Foreach test for string dispersers: ");
                Console.WriteLine();

                foreach (var ch in stringDisperser)
                {
                    Console.Write(ch + " ");
                }

                Console.WriteLine();

                foreach (var ch in clonedStringDisperser)
                {
                    Console.Write(ch + " ");
                }

                Console.WriteLine();
            }

            catch (ArgumentNullException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
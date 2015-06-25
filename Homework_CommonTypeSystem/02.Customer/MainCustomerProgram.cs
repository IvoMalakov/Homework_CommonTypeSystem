using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CustomerProgram
{
    public class MainCustomerProgram
    {
        public static void Main()
        {
            try
            {
                Payment payment1 = new Payment("Pechka", 100m);
                Payment payment2 = new Payment("Televizor", 1000m);

                List<Payment> peshoPaiments = new List<Payment>
                {
                    payment1,
                    payment2
                };

                Customer pesho = new Customer("Pesho", "Peshev", "Dimirov", 8510019001, "Pod mosta", "None", "None",
                    peshoPaiments, CustomerType.OneTime);

                Payment payment3 = new Payment("Vibrator", 15m);
                Payment payment4 = new Payment("Prashki", 5m);

                List<Payment> mariikaPayments = new List<Payment>
                {
                    payment3,
                    payment4
                };

                Customer mariika = new Customer("Mariika", "NaBatkoKuklata", "Obstata", 9501017805, "tam niakude",
                    "de da i znaeh telefona", "mariika@abv.bg", mariikaPayments, CustomerType.Diamond);

                Console.WriteLine("Client1: {0}\n \n Client2: {1}", pesho, mariika);

                Console.WriteLine();
                Console.WriteLine("Is Pesho equals to Mariika: {0}", pesho.Equals(mariika));
                Console.WriteLine("Is Pesho equals to Pesho: {0}", pesho.Equals(pesho));
                Console.WriteLine();
                Console.WriteLine("Pesho == Mariika?: {0}", pesho == mariika);
                Console.WriteLine("Pesho != Mariika?: {0}", pesho != mariika);

                Customer gosho = (Customer) pesho.Clone();
                Customer stela = (Customer) mariika.Clone();

                Console.WriteLine();
                Console.WriteLine("Cloned client: {0}", gosho);
                Console.WriteLine();
                Console.WriteLine("Is Pesho equals to Gosho: {0}", pesho.Equals(gosho));

                gosho.FirstName = "Gosho";
                gosho.MiddleName = "Stefanov";
                gosho.LastName = "Goshev";

                Console.WriteLine();
                Console.WriteLine("Cloned client1 after changes: {0}", gosho);
                Console.WriteLine();
                Console.WriteLine("Is Pesho equals to Gosho: {0}", pesho.Equals(gosho));
                Console.WriteLine();

                stela.FirstName = "Stela";
                stela.MiddleName = "Ivanova";
                stela.LastName = "Petkova";

                Console.WriteLine();
                Console.WriteLine("Cloned client2 after changes: {0}", stela);
                Console.WriteLine();
                Console.WriteLine("Is Mariika equals to Stela: {0}", mariika.Equals(stela));
                Console.WriteLine();

                Console.WriteLine("Mariika's Hash Code: {0}", mariika.GetHashCode());
                Console.WriteLine("Pesho's Hash Code: {0}", pesho.GetHashCode());
            }

            catch (ArgumentNullException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}

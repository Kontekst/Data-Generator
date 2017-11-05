using System;

namespace GeneratorHurtownieDanych
{
    class Program
    {
        static void Main(string[] args)
        {
            Waiters waiters = new Waiters();
            Meals meals = new Meals();
            Clients clients;
            Bills bills;

            Console.WriteLine("Witaj w generatorze danych do laboratorium z przedmiotu Hurtownie Danych");
            Console.WriteLine("Wprowadź liczbę rachunków które chcesz wygenerować w odniesieniu do pierwszego etapu - minimum 100");
            Console.WriteLine("Sugeruję 1000");
            
            //-------------------------//
            // First stage

            int firstAmount;
            bool argPassed = false;

            do {
                if (int.TryParse(Console.ReadLine(), out firstAmount) && firstAmount > 100)
                {
                    clients = new Clients(firstAmount);
                    bills = new Bills(firstAmount);
                    argPassed = true;
                }
                else
                {
                    Console.WriteLine("Nie podano liczby lub podano ją mniejszą niż 100");
                    Console.WriteLine("Spróbuj jeszcze raz :P");
                }
            } while (!argPassed);

            JsonQuestionnaires questionaries = new JsonQuestionnaires(firstAmount);
       
            //-------------------------//
            // Second stage

            Console.WriteLine("Czas na drugi etap, ile pragniesz dodać rachunków, sugeruję 9000");

            int secondAmount;
            argPassed = false;

            do
            {
                if (int.TryParse(Console.ReadLine(), out secondAmount))
                {
                    //Bills.generateNewBills(secondAmount); //TODO
                }
                else
                {
                    Console.WriteLine("Nie podano liczby, spróbuj jeszcze raz :P");
                }
            } while (!argPassed);
            //-------------------------//
            Console.WriteLine("SUPER, udało się, teraz możesz przetwarzać te dane do woli");

            //JsonQuestionnaires.generateNewQuestionnaires(secondAmount); //TODO

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(" <<!!! !!! ETL !!! !!!>>");
            }
        }
    }
}

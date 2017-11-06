using System;

namespace GeneratorHurtownieDanych
{
    class Program
    {
        static void Main(string[] args)
        {
            Waiters waiters = new Waiters();
            Meals meals = new Meals();
            Clients clients = null;
            Bills bills = null;

            Console.WriteLine("Witaj w generatorze danych do laboratorium z przedmiotu Hurtownie Danych");
            Console.WriteLine("Wprowadź liczbę rachunków które chcesz wygenerować w odniesieniu do pierwszego etapu - minimum 100");

            //-------------------------//
            // First stage

            int firstAmount;
            bool argPassed = false;

            do
            {
                if (int.TryParse(Console.ReadLine(), out firstAmount) && firstAmount > 99)
                {
                    clients = new Clients(firstAmount);
                    bills = new Bills(firstAmount);
                    argPassed = true;
                }
                else
                {
                    Console.WriteLine("Nie podano liczby lub podano ją mniejszą niż 100, ponów próbę");
                }
            } while (!argPassed);

            JsonQuestionnaires questionaries = new JsonQuestionnaires(firstAmount);

            //-------------------------//
            // Second stage
            
            Console.WriteLine("Podaj liczbę danych do wygenerowania w drugim etapie");
            
            int secondAmount;
            argPassed = false;

            do
            {
                if (int.TryParse(Console.ReadLine(), out secondAmount))
                {
                    waiters.addNewWaiters();
                    meals.addNewMeals();
                    clients.generateNewClients(secondAmount);
                    bills.generateNewBills(secondAmount);
                    argPassed = true;
                }
                else
                {
                    Console.WriteLine("Nie podano liczby, ponów próbę");
                }
            } while (!argPassed);

            questionaries.generateNewQuestionnaires(secondAmount);

            //-------------------------//

            Console.WriteLine("Udało się pomyślnie wygenerować wszystkie dane");
        }
    }
}

//TODO czy Math.Rounds(arg,2) to najlepszy sposób zaokrąglania??
//TODO zapewnić aby każdy klient na dowóz miał min.1 zamówienie poprzez dodanie go przed wywołaniem konstruktora klienta ??
using System;
using System.Collections.Generic;
using System.IO;

namespace GeneratorHurtownieDanych
{
    class Waiters
    {
        public static List<Waiter> waiters = new List<Waiter>();
        public static List<string> pesels = new List<string>();
        private static Random rnd = new Random();

        static List<string> FirstNames = new List<string>(){
            "Sergio","Daniel","Carolina","David","Reina","Saul",
            "Bernard","Danny","Dimas","Yuri","Ivan","Laura"
        };

        static List<string> LastNames = new List<string>(){
            "Tapia","Gutierrez","Rueda","Galviz","Yuli","Rivera",
            "Mamami","Saucedo","Dominguez","Escobar","Martin","Crespo"
        };

        //-------------------------//

        public Waiters()
        {
            File.WriteAllText("Waiters.csv", string.Empty);
            string pesel;
            DateTime birthDay;
            string firstName;
            string lastName;
            StreamWriter wr = new StreamWriter("./Waiters.csv");
            for (int i = 0; i < 100; i++)
            {
                pesel = randomPesel();
                firstName = FirstNames[randomIndexOfFirstName()];
                lastName = LastNames[randomIndexOfLastName()];
                birthDay = generateRandomDateTime();
                Waiter newWaiter = new Waiter(pesel, firstName, lastName, birthDay);
                waiters.Add(newWaiter);
                wr.WriteLine(pesel + ", " + birthDay.Year + "-" + birthDay.Month + "-" + birthDay.Day + ", " + firstName + ", " + lastName);
                wr.Flush();
            }
            wr.Close();

        }

        //-------------------------//

        private static string randomPesel()
        {
            string newPesel = "";
            int tempNumber;
            do
            {
                newPesel += rnd.Next(50, 100).ToString(); //Year

                tempNumber = rnd.Next(1, 12); //Month
                if (tempNumber < 10)
                {
                    newPesel += "0" + tempNumber.ToString();
                }
                else
                {
                    newPesel += tempNumber.ToString();
                }
                /////
                tempNumber = rnd.Next(1, 28); //Day
                if (tempNumber < 10)
                {
                    newPesel += "0" + tempNumber.ToString();
                }
                else
                {
                    newPesel += tempNumber.ToString();
                }
                /////
                for (int i = 0; i < 5; i++)
                {
                    newPesel += rnd.Next(0, 9).ToString(); //TODO uwzględnić płeć etc.
                }
                /////
            } while (pesels.Contains(newPesel));
            pesels.Add(newPesel);
            return newPesel;
        }

        //-------------------------//

        private static int randomIndexOfFirstName()
        {
            return rnd.Next(0, FirstNames.Count);
        }

        //-------------------------//

        private static int randomIndexOfLastName()
        {
            return rnd.Next(0, LastNames.Count);
        }

        //-------------------------//

        private static DateTime generateRandomDateTime()
        {
            DateTime start = new DateTime(2013, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }
    }
}
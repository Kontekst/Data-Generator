using System;
using System.Collections.Generic;
using System.IO;

namespace GeneratorHurtownieDanych
{
    struct FullName
    {
        public string firstName;
        public string lastName;
    }

    class Waiters
    {
        public static List<Waiter> waiters = new List<Waiter>();
        public static List<string> pesels = new List<string>();
        private static Random rnd = new Random();

        static Dictionary<FullName,string> listOfWaiters= new Dictionary<FullName, string>() {
            {new FullName { firstName = "Tomasz", lastName="Kowalski" } ,"M"}, {new FullName {firstName ="Wojciech", lastName="Nowak" },"M" },
            {new FullName {firstName ="Albert", lastName="Bobrowski" },"M" },{new FullName {firstName ="Dariusz", lastName="Gobel" },"M" },
            {new FullName {firstName ="Krzysztof", lastName="Sosnowski" },"M" },{new FullName {firstName ="Kacper", lastName="Adiunkt" },"M" },
            {new FullName {firstName ="Marcin", lastName="Wojciechowski" },"M" },{new FullName {firstName ="Jan", lastName="Jankowski" },"M" },
            {new FullName {firstName ="Zbigniew", lastName="Bobrowski" },"M" },{new FullName {firstName ="Piotr", lastName="Kowalski" },"M" },
            {new FullName {firstName ="Joanna", lastName="Mleczek" },"K" },{new FullName {firstName ="Dominika", lastName="Porzeczka" },"K" },
            {new FullName {firstName ="Katarzyna", lastName="Silka" },"K" },{new FullName {firstName ="Patrycja", lastName="Nowakowska" },"K" },
            {new FullName {firstName ="Magda", lastName="Sosnowska" },"K" },{new FullName {firstName ="Marta", lastName="Misiakowska" },"K" },
        };

        //-------------------------//

        public Waiters()
        {
            File.WriteAllText("Waiters.csv", string.Empty);
            StreamWriter wr = new StreamWriter("./Waiters.csv");

            string pesel;
            DateTime employmentDate;

            foreach (var element in listOfWaiters)
            {
                pesel = randomPesel(element.Value);
                employmentDate = generateRandomDateTime();
                Waiter newWaiter = new Waiter(pesel, element.Key.firstName, element.Key.lastName, employmentDate);
                waiters.Add(newWaiter);
                wr.WriteLine(pesel + ", " + employmentDate.Year + "-" + employmentDate.Month + "-" + employmentDate.Day + ", " + element.Key.firstName + ", " + element.Key.lastName);
                wr.Flush();
            }
            wr.Close();

        }

        public void addNewWaiters()
        {
            Dictionary<FullName, string> newWaiters = new Dictionary<FullName, string>() {
            {new FullName { firstName = "Arnold", lastName="Boczek" } ,"M"}, {new FullName {firstName ="Kamil", lastName="Ostrowski" },"M" },
            {new FullName {firstName = "Zuzanna", lastName="Fonuth" },"K" },{new FullName {firstName ="Marianna", lastName="Obuchowska" },"K" },
            {new FullName { firstName = "Tymek", lastName="Boczek" } ,"M"}, {new FullName {firstName ="Karol", lastName="Ostrowski" },"M" },
            {new FullName {firstName = "Stefania", lastName="Fonuth" },"K" },{new FullName {firstName ="Ilona", lastName="Obuchowska" },"K" }
            };

            StreamWriter wr = new StreamWriter("./Waiters.csv", append: true);

            string pesel;
            DateTime employmentDate;

            foreach (var element in newWaiters)
            {
                pesel = randomPesel(element.Value);
                employmentDate = generateRandomDateTime();
                Waiter newWaiter = new Waiter(pesel, element.Key.firstName, element.Key.lastName, employmentDate);
                waiters.Add(newWaiter);
                wr.WriteLine(pesel + ", " + employmentDate.Year + "-" + employmentDate.Month + "-" + employmentDate.Day + ", " + element.Key.firstName + ", " + element.Key.lastName);
                wr.Flush();
            }
            wr.Close();
        }

        //-------------------------//

        private static string randomPesel(string argGender)
        {
            string newPesel = "";
            int tempNumber;
            do
            {
                int controlSum = 0;
                // Year
                newPesel += rnd.Next(50, 100).ToString();
                controlSum += 9 * (newPesel[0] - '0') + 7 * (newPesel[1] - '0');


                // Month
                tempNumber = rnd.Next(1, 12); 
                if (tempNumber < 10)
                {
                    newPesel += "0" + tempNumber.ToString();
                }
                else
                {
                    newPesel += tempNumber.ToString();
                }
                controlSum += 3 * (newPesel[2] -'0') + 1 * (newPesel[3] - '0');
                
                // Day
                tempNumber = rnd.Next(1, 28); 
                if (tempNumber < 10)
                {
                    newPesel += "0" + tempNumber.ToString();
                }
                else
                {
                    newPesel += tempNumber.ToString();
                }
                controlSum += 9 * (newPesel[4] - '0') + 7 * (newPesel[5] - '0');
                
                for (int i = 0; i < 3; i++)
                {
                    newPesel += rnd.Next(0, 9).ToString();
                }
                controlSum += 3 * (newPesel[6] - '0') + 1 * (newPesel[7] - '0') + 9 * (newPesel[8] - '0');

                if(argGender == "M")
                {
                    newPesel += (rnd.Next(0, 5) * 2 + 1).ToString();
                }
                else
                {
                    newPesel += (rnd.Next(0, 5) * 2).ToString();
                }
                controlSum += 7 * (newPesel[9] - '0');

                newPesel += (controlSum % 10).ToString();
            } while (pesels.Contains(newPesel));
            pesels.Add(newPesel);
            return newPesel;
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
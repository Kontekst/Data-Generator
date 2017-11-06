using System;
using System.Collections.Generic;
using System.IO;

namespace GeneratorHurtownieDanych
{
    class Clients
    {
        static List<string> FirstNames = new List<string>(){
            "Sergio","Daniel","Carolina","David","Reina","Saul",
            "Bernard","Danny","Dimas","Yuri","Ivan","Laura"
        };

        static List<string> LastNames = new List<string>(){
            "Tapia","Gutierrez","Rueda","Galviz","Yuli","Rivera",
            "Mamami","Saucedo","Dominguez","Escobar","Martin","Crespo"
        };

        static List<string> StreetNames = new List<string>(){
            "Okopowa","Jutrzenki","Swobody","Kazimierza Wielkiego", "Dobrolistna",
            "Sosnowa","Lipna","Porzeczkowa","Truskawkoa","Ananasowa","Jana Pawla",
            "Piekarska","Szewcowa","Kosynierska"
        };

        private static Random rnd = new Random();
        public static List<Client> clients = new List<Client>();
        public static List<string> telephoneNumbers = new List<string>();
        private static int firstRange;

        public Clients(int argFirstRange)
        {
            firstRange = argFirstRange;
            File.WriteAllText("Clients.csv", string.Empty);
            string telephoneNumber;
            string firstName;
            string lastName;
            string streetName;
            string houseNumber;
            string apartmentNumber;
            StreamWriter wr = new StreamWriter("./Clients.csv");
            for (int i = 0; i < 50 + firstRange/5; i++)
            {
                telephoneNumber = randomTelephoneNumber();
                firstName = FirstNames[randomIndexOfFirstName()];
                lastName = LastNames[randomIndexOfLastName()];
                streetName = StreetNames[randomIndexOfStreetName()];
                houseNumber = rnd.Next(0, 50).ToString();
                apartmentNumber = rnd.Next(0, 40).ToString();

                if (apartmentNumber == "0")
                {
                    apartmentNumber = null;
                }
            
                Client newClient = new Client(firstName, lastName, telephoneNumber,streetName,houseNumber,apartmentNumber);
                clients.Add(newClient);
                wr.WriteLine(firstName + ", " + lastName + "," +telephoneNumber + ", " + streetName +", " +houseNumber +", " + apartmentNumber + ", " + newClient.registrationNumber);
                wr.Flush();
            }
            wr.Close();
        }

        public void generateNewClients( int argSecondAmount)
        {
            string telephoneNumber;
            string firstName;
            string lastName;
            string streetName;
            string houseNumber;
            string apartmentNumber;
            StreamWriter wr = new StreamWriter("./Clients.csv", append: true);
            for (int i = 0; i < argSecondAmount/5; i++)
            {
                telephoneNumber = randomTelephoneNumber();
                firstName = FirstNames[randomIndexOfFirstName()];
                lastName = LastNames[randomIndexOfLastName()];
                streetName = StreetNames[randomIndexOfStreetName()];
                houseNumber = rnd.Next(0, 50).ToString();
                apartmentNumber = rnd.Next(0, 40).ToString();

                if (apartmentNumber == "0")
                {
                    apartmentNumber = null;
                }

                Client newClient = new Client(firstName, lastName, telephoneNumber, streetName, houseNumber, apartmentNumber);
                clients.Add(newClient);
                wr.WriteLine(firstName + ", " + lastName + "," + telephoneNumber + ", " + streetName + ", " + houseNumber + ", " + apartmentNumber + ", " + newClient.registrationNumber);
                wr.Flush();
            }
            wr.Close();
        }

        //-------------------------//

        private static int randomIndexOfFirstName()
        {
            return rnd.Next(0, FirstNames.Count);
        }

        //-------------------------//

        private static string randomTelephoneNumber()
        {
            string telephoneNumber = "";
            telephoneNumber += rnd.Next(1, 9).ToString();
            for (int i = 1; i < 9; i++)
            {
                telephoneNumber += rnd.Next(0, 9).ToString();
            }
            return telephoneNumber;
        }

        //-------------------------//

        private static int randomIndexOfLastName()
        {
            return rnd.Next(0, LastNames.Count);
        }

        //-------------------------//

        private static int randomIndexOfStreetName()
        {
            return rnd.Next(0, StreetNames.Count);
        }
    }

    
}

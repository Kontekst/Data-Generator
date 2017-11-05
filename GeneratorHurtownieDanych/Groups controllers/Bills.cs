using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace GeneratorHurtownieDanych
{
    class Bills
    {
        private static int firstRange;
        private static Random rnd = new Random();
        public static List<Bill> bills = new List<Bill>();
        public Bills(int argFirstRange)
        {
            firstRange = argFirstRange;

            DateTime orderTime;
            DateTime realizationTime;
            string paymentForm;
            int? FK_ClientRegistrationNumber;
            string FK_WaiterPesel;

            File.WriteAllText("Bills.csv", string.Empty);
            File.WriteAllText("BillsPositions.csv", string.Empty);
            StreamWriter wr = new StreamWriter("./Bills.csv");
            StreamWriter positionsWr = new StreamWriter("./BillsPositions.csv");

            for (int i = 0; i < firstRange; i++)
            {
                FK_WaiterPesel = chooseRandomWaiterPesel();

                if (rnd.Next(0, 1) == 1)
                { // Zamowienie na miejscu
                    FK_ClientRegistrationNumber = null;
                }
                else
                { // Zamowienie na wynos
                    FK_ClientRegistrationNumber = Clients.clients[rnd.Next(1, Clients.clients.Count)].registrationNumber;
                }

                orderTime = generateRandomOrderTime(Waiters.waiters.Find(e => e.pesel == FK_WaiterPesel).employmentDate);
                realizationTime = generateRandomRealizationTime(orderTime);

                paymentForm = "";

                switch (rnd.Next(0, 2))
                {
                    case 0:
                        paymentForm = "G";
                        break;
                    case 1:
                        paymentForm = "K";
                        break;
                    case 2:
                        paymentForm = "P";
                        break;
                }

                Bill bill = new Bill(orderTime, realizationTime, paymentForm, FK_WaiterPesel, FK_ClientRegistrationNumber);
                bills.Add(bill);
                wr.WriteLine(
                    Math.Round(bill.cost, 2).ToString(CultureInfo.CreateSpecificCulture("en-US")) + ", "
                    + orderTime + ", "
                    + realizationTime + ","
                    + paymentForm + ", "
                    + Math.Round(bill.tip, 2).ToString(CultureInfo.CreateSpecificCulture("en-US")) + ", "
                    + FK_ClientRegistrationNumber + ","
                    + FK_WaiterPesel + ", "
                    + bill.registrationNumber);

                for (int k = 0; k < bill.positions.Count; k++)
                {
                    positionsWr.WriteLine(
                          Math.Round(bill.positions[k].cost, 2).ToString(CultureInfo.CreateSpecificCulture("en-US")) + ", "
                        + bill.positions[k].amount + ", "
                        + bill.positions[k].FK_RegistrationNumberOfBill + ", "
                        + bill.positions[k].FK_Name + ", "
                        + bill.positions[k].registrationNumber);
                }

                wr.Flush();
            }
            wr.Close();
        }

        //-------------------------//

        private static DateTime generateRandomOrderTime(DateTime argWaiterJobBeginDate)
        {
            int range = (DateTime.Today - argWaiterJobBeginDate).Days;
            return argWaiterJobBeginDate.AddDays(rnd.Next(range));
        }

        //-------------------------//

        private static string chooseRandomWaiterPesel()
        {
            return Waiters.waiters[rnd.Next(1, Waiters.waiters.Count)].pesel;
        }

        //-------------------------//

        private static DateTime generateRandomRealizationTime(DateTime argOrderTime)
        {
            argOrderTime.AddHours(rnd.Next(0, 4));
            argOrderTime.AddMinutes(rnd.Next(5, 60));
            return argOrderTime;
        }
    }
}
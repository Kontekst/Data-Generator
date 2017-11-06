using System;
using System.Collections.Generic;

namespace GeneratorHurtownieDanych
{
    class Bill
    {
        private static int registrationNumberIndexer = 1;
        private static Random rnd = new Random();

        public List<PositionInTheOrder> positions = new List<PositionInTheOrder>();

        public int registrationNumber;
        public decimal cost;
        public decimal tip;
        public DateTime orderTime;
        public DateTime realizationTime;
        public string paymentForm;
        public string FK_WaiterPesel;
        public int? FK_ClientRegistrationNumber = null;

        public Bill( DateTime argOrderTime, DateTime argRealizationTime, string argPaymentForm, string argFK_WaiterPesel, int? ArgFK_ClientRegistrationNumber)
        {
            registrationNumber = registrationNumberIndexer;
            registrationNumberIndexer++;
            orderTime = argOrderTime;
            realizationTime = argRealizationTime;
            paymentForm = argPaymentForm;
            FK_WaiterPesel = argFK_WaiterPesel;
            FK_ClientRegistrationNumber = ArgFK_ClientRegistrationNumber;
            cost = 0M;

            for (int j = 0; j < rnd.Next(1, 5); j++) // Between 1 and 4
            {
                PositionInTheOrder tempPosition = new PositionInTheOrder(registrationNumber);
                positions.Add(tempPosition);
                PositionsInTheOrders.allPositions.Add(tempPosition);
                cost += tempPosition.cost * tempPosition.amount;
            }

            tip = cost / 10M * rnd.Next(80, 121) / rnd.Next(80,121);
        }
    }
}

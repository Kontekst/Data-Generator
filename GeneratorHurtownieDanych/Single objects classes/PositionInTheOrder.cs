using System;

namespace GeneratorHurtownieDanych
{
    class PositionInTheOrder
    {
        private static int registrationNumberIndexer = 1;
        private static Random rnd = new Random();

        public int registrationNumber;
        public decimal cost;
        public int amount;
        public int FK_RegistrationNumberOfBill;
        public string FK_Name;

        public PositionInTheOrder(int argFK_RegistrationNumberOfBill)
        {
            registrationNumberIndexer++;
            registrationNumber = registrationNumberIndexer;

            FK_RegistrationNumberOfBill= argFK_RegistrationNumberOfBill;

            Meal tmpMeal = Meals.standardMeals[rnd.Next(0, Meals.standardMeals.Count)];
            FK_Name = tmpMeal.name;
            cost = tmpMeal.actualPrice * rnd.Next(80, 121) / rnd.Next(80, 121); // Between 2/3 and 3/2
            amount = rnd.Next(1, 6); // From 1 to 5
        }
    }
}

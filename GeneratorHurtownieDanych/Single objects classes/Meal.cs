namespace GeneratorHurtownieDanych
{
    class Meal
    {
        public string name;
        public string category;
        public decimal actualPrice;

        public Meal(string argName, string argCategory, decimal argActualPrice)
        {
            name = argName;
            category = argCategory;
            actualPrice = argActualPrice;
        }
    }
}
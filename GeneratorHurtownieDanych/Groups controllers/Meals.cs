using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace GeneratorHurtownieDanych
{
    class Meals
    {
        private static Random rnd = new Random();

        public static List<Meal> standardMeals = new List<Meal>(){
            new Meal("Kielbasa with Brussels","zestaw obiadowy",30.80M ), new Meal( "Spicy Thai Basil Chicken","zestaw obiadowy",35M ), new Meal( "Indian Chicken Curry","zestaw obiadowy",40M),
            new Meal("Apricot Mustard-Glazed Salmon","zestaw obiadowy", 36.25M ), new Meal( "Paleo Stuffed Cabbage","zestaw obiadowy",40M),new Meal("Dijon Pork with","zestaw obiadowy", 55M),
            new Meal("Barley water", "drink",25.50M),new Meal("Yorkshire Dragon", "drink", 15M),new Meal("Squash", "drink",22M),
            new Meal("Back bacon with fired bread","zestaw sniadaniowy", 20.50M ),new Meal("Scrambled Eggs","zestaw sniadaniowy", 18M ),new Meal("Bubble and squeak","zestaw sniadaniowy",13M),
            new Meal("Wodka Zubr 100ml","napoj alkoholowy", 7M ), new Meal("Wodka Mr Thadeo 100ml","napoj alkoholowy", 15M ), new Meal("Argus 500ml mojito ","napoj alkoholowy" ,2M),
            new Meal("Wino Fresco 700ml litra","napoj alkoholowy",50M ), new Meal("Piwo Tyskie 250ml","napoj alkoholowy",5M), new Meal("Piwo Harde 500 ml","napoj alkoholowy", 3M),
            new Meal("Capri 250ml","sok",6M ), new Meal("Pomidorowa","zupa",12.50M ), new Meal("Kabanosiki", "przystawka",8M), new Meal("Karpatka","deser",9M),
            new Meal("Salatka grecka","sałatka",15M ), new Meal("Capri","pizza",20.75M ), new Meal("Margharita","piza",15M ), new Meal("Prosciutto","pizza",35M),
            new Meal("Sandacz po szwedzku","ryba",65M )
        };

        //-------------------------//

        public Meals()
        {
            File.WriteAllText("Meals.csv", string.Empty);
            StreamWriter wr = new StreamWriter("./Meals.csv");
            for (int i = 0; i < standardMeals.Count; i++)
            {
                wr.WriteLine(standardMeals[i].name + ", " + Math.Round(standardMeals[i].actualPrice, 2).ToString(CultureInfo.CreateSpecificCulture("en-US")) + ", " + standardMeals[i].category);
                wr.Flush();
            }
            wr.Close();
        }
    }
}
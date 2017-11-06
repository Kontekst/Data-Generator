using System;
using System.IO;

namespace GeneratorHurtownieDanych
{
    class JsonQuestionnaires
    {
        private static Random rnd = new Random();
        private static int questionnaireID = 1;
        int firstAmount;

        public JsonQuestionnaires(int argFirstAmount)
        {
            firstAmount = argFirstAmount / 10;
            generateFirstJSON();
        }

        private void generateFirstJSON()
        {
            File.WriteAllText("JSON_Questionnaires.json", string.Empty);
            StreamWriter wr = new StreamWriter("./JSON_Questionnaires.json");
            wr.Write("[\n");

            for (int i = 0; i < firstAmount; i++)
            {
                int tmpJump = rnd.Next(0, 4);
                wr.Write(
                    "{\r\n\"id\": "
                  + questionnaireID
                  + ",\r\n\"numerRachunku\": "
                  + Bills.bills[i * 5 + tmpJump].registrationNumber
                  + ",\r\n\"kelner\": \""
                  + Bills.bills[i * 5 + tmpJump].FK_WaiterPesel
                  + "\",\r\n\"oceny\": {\r\n\"ocenaKelnera\": "
                  + rnd.Next(1, 10).ToString()
                  + ",\r\n\"ocenaRestauracji\": "
                  + rnd.Next(1, 10).ToString()
                  + ",\r\n\"ocenaPotraw\": "
                  + rnd.Next(1, 10).ToString()
                  + ",\r\n\"caloscioweZadowolenie\": "
                  + rnd.Next(1, 10).ToString()
                  + "\r\n}\r\n}"
                  );
                if (i < (firstAmount - 1))
                {
                    wr.Write(",");
                }
                wr.Flush();

                questionnaireID++;
            }
            wr.Write("]");
            wr.Close();
        }

        public void generateNewQuestionnaires(int secondAmount)
        {
           
        }
    }
}

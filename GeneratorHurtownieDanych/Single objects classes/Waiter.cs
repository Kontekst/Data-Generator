using System;

namespace GeneratorHurtownieDanych
{
    public class Waiter
    {
        public string pesel;
        public DateTime employmentDate;
        public string firstName;
        public string lastName;

        public Waiter(string argPesel, string argFirstName, string argLastName, DateTime argemploymentDate)
        {
            pesel = argPesel;
            firstName = argFirstName;
            lastName = argLastName;
            employmentDate = argemploymentDate;
        }
    }
}

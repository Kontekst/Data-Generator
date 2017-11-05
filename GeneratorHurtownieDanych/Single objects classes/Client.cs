namespace GeneratorHurtownieDanych
{
    class Client
    {
       private static int registrationNumberIndexer = 1;

        public int registrationNumber;
        public string firstName;
        public string lastName;
        public string telephoneNumber;
        public string streetName;
        public string houseNumber;
        public string apartmentNumber;

        public Client(string argFirstName, string argLastName, string argTelephoneNumber, string argStreetName, string argHouseNumber, string argApartmentNumber)
        {
            registrationNumber = registrationNumberIndexer;
            registrationNumberIndexer++;
            firstName = argFirstName;
            lastName = argLastName;
            telephoneNumber = argTelephoneNumber;
            streetName = argStreetName;
            houseNumber = argHouseNumber;
            apartmentNumber = argApartmentNumber;
        }
    }
}

namespace Api_Task_22.Model.Data
{
    public class PackagePerson
    {
        public Person person { get; set; }

        public PersonalData personalData { get; set; }

        public byte[] DataPhoto { get; set; }

        public PackagePerson()
        {
            person = new Person();
            personalData = new PersonalData();

        }
    }
}

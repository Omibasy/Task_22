using Task_22.Model.Data;

namespace Task_22.Model.Interface
{
    public interface IPhoneBook
    {
        IEnumerable<Person> GetPersonalities();

        Task<Person> GetPersonalities(int id);

        Task<PersonalData> GetPersonalData(int personId);

        Person DeleteAnEntry(int id, IWebHostEnvironment appEnvironment);

        string DataChanges(Person person, PersonalData personalData);

        void AddingNewData(Person person,PersonalData personalData, IFormFile file, IWebHostEnvironment appEnvironment);

        void EditPhoto(int id, IFormFile newPhoto, IWebHostEnvironment appEnvironment);

    }
}

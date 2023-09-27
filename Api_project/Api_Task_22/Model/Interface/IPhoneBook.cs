using Api_Task_22.Model.Data;

namespace Api_Task_22.Model.Interface
{
    public interface IPhoneBook
    {
        IEnumerable<Person> GetPersonalities();

        Task<PersonalData> GetPersonalData(int personId);

        Task<string> DeleteAnEntry(int id, IWebHostEnvironment appEnvironment);

        Task<string> DataChanges(PackagePerson packagea);

        Task<string> AddingNewData(PackagePerson package, IWebHostEnvironment appEnvironment);

        Task<string> EditPhoto(int id, byte[] file, IWebHostEnvironment appEnvironment);
    }
}

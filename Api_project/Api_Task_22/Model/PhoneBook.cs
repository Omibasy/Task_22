using Api_Task_22.Model.DBC;
using Api_Task_22.Model.Data;
using Api_Task_22.Model.Repository;
using Api_Task_22.Model.Interface;

namespace Api_Task_22.Model
{
    public class PhoneBook : IPhoneBook
    {
        private readonly DbPhoneBook PhoneBookContext;


        public PhoneBook(DbPhoneBook phoneBookContext)
        {
            PhoneBookContext = phoneBookContext;

            IEnumerable<Person> list = GetPersonalities();

            if (list == null || list.Count() <= 0)
            {

                FillingInDatav();
            }
        }

        public IEnumerable<Person> GetPersonalities()
        {
            return PhoneBookContext.Persons;
        }

        private void FillingInDatav()
        {
            var result = FakeData.GetPersonalities();

            foreach (var person in result.Item1)
            {
                PhoneBookContext.Persons.Add(person);

            }

            foreach (var personalData in result.Item2)
            {
                PhoneBookContext.PersonalDatas.Add(personalData);
            }

            PhoneBookContext.SaveChanges();
        }

        public Task<PersonalData> GetPersonalData(int personId)
        {
            return Task<PersonalData>.Factory.StartNew(() =>
            {
                return PhoneBookContext.PersonalDatas.FirstOrDefault(o => o.ID_Person == personId);

            });

        }

        private void DeletePhoto(int id, IWebHostEnvironment appEnvironment)
        {
            string str = appEnvironment.WebRootPath + "\\Photo";

            var path = Directory.GetFiles(str);

            foreach (var file in path) 
            {
                str = FaindPhoto(id, file);

                if (str != null)
                {
                    break;
                }            
            }

            if (str == null)             
            {
                return;            
            }
            else
            {
                FileInfo fileInfo = new FileInfo(str);

                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            }
        }

        private void DeletePersonalities(int id)
        {
            
            Person value = PhoneBookContext.Persons.FirstOrDefault(x => x.ID == id);

            if (value != null)
            {
                PhoneBookContext.Persons.Remove(value);

                PhoneBookContext.SaveChanges();
            }


       
        }

        public Task<string> DeleteAnEntry(int id, IWebHostEnvironment appEnvironment)
        {
            return Task<string>.Factory.StartNew(() =>
            {
                if (id > 0)
                {
                    DeletePhoto(id, appEnvironment);

                    DeletePersonalities(id);

                    return "Successfully";
                }

                return "Failed";
            });
        }

        public Task<string> DataChanges(PackagePerson packagea)
        {
            return Task<string>.Factory.StartNew(() =>
            {
                Person newPerson = PhoneBookContext.Persons.FirstOrDefault(o => o.ID == packagea.person.ID);

                newPerson.Surname = packagea.person.Surname;
                newPerson.Name = packagea.person.Name;
                newPerson.Patomic = packagea.person.Patomic;

                PersonalData newPersonalData = PhoneBookContext.PersonalDatas.FirstOrDefault(o => o.ID == packagea.personalData.ID);

                newPersonalData.Address = packagea.personalData.Address;
                newPersonalData.PhoneNumber = packagea.personalData.PhoneNumber;
                newPersonalData.Description = packagea.personalData.Description;

                PhoneBookContext.SaveChanges();

                return "Successfully";
            });
        }


        public Task<string> AddingNewData(PackagePerson package, IWebHostEnvironment appEnvironment)
        {
            return Task<string>.Factory.StartNew(() =>
            {
                package.personalData.PersonID = package.person;

                PhoneBookContext.Persons.Add(package.person);
                PhoneBookContext.PersonalDatas.Add(package.personalData);

                PhoneBookContext.SaveChanges();

                int id = PhoneBookContext.Persons.FirstOrDefault(o => o.Name == package.person.Name).ID;

                SavePhoto(id, package.DataPhoto, appEnvironment);

                return "Successfully";
            });
        }



        private void SavePhoto(int id, byte[] file, IWebHostEnvironment appEnvironment)
        {
            if (file != null)
            {
         
                string path = appEnvironment.WebRootPath + "/Photo/" +
                              $"photo_{id}.{DateTime.Now.Ticks}.jpg";
                
                File.WriteAllBytes(path, file);             
            }
        }


        public Task<string> EditPhoto(int id, byte[] file, IWebHostEnvironment appEnvironment)
        {
            return Task<string>.Factory.StartNew(() =>
            {
                DeletePhoto (id, appEnvironment);

                SavePhoto(id,file, appEnvironment);

                return "Successfully";
            });
       }

        

        private string FaindPhoto(int id, string photo)
        {
            string[] oneValue = photo.Split(".");

            if (oneValue.Length >= 3)
            {
                var twoValue = oneValue[oneValue.Length - 3].Split('\\'); ;

                if (twoValue[twoValue.Length - 1] == $"photo_{id}")
                {
                    return photo;
                }
            }

            return null;
        }

    
    }
}

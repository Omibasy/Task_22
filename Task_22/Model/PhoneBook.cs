using System.Data.Entity.Migrations;
using Task_22.Model.Data;
using Task_22.Model.DBContext;
using Task_22.Model.Interface;
using Task_22.Model.Repositorys;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;


namespace Task_22.Model
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

            var result = Repository.GetPersonalities();

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
    

    public Task<Person> GetPersonalities(int id)
        {
            return Task<Person>.Factory.StartNew(() =>
            {
            
                    return PhoneBookContext.Persons.FirstOrDefault(o => o.ID == id);
                
            });
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
            string str = appEnvironment.WebRootPath + "\\card";

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

        private Person DeletePersonalities(int id)
        {
            Person value;

                value = PhoneBookContext.Persons.FirstOrDefault(x => x.ID == id);

                if (value != null)
                {
                PhoneBookContext.Persons.Remove(value);

                PhoneBookContext.SaveChanges();
                }
            

            return value;
        }

        public Person DeleteAnEntry(int id, IWebHostEnvironment appEnvironment)
        {

            if (id > 0)
            {
                DeletePhoto(id, appEnvironment);

                return DeletePersonalities(id);

            }
            else
            {
                return null;
            }
        }

        public string DataChanges(Person person, PersonalData personalData)
        {
         
            personalData.PhoneNumber = EditPhoneNumber(personalData.PhoneNumber);

            Person newPerson =   PhoneBookContext.Persons.FirstOrDefault(o => o.ID == person.ID);

            newPerson.Surname = person.Surname;
            newPerson.Name = person.Name;
            newPerson.Patomic = person.Patomic;

            PersonalData newPersonalData = PhoneBookContext.PersonalDatas.FirstOrDefault(o => o.ID == personalData.ID);

            newPersonalData.Address = personalData.Address;
            newPersonalData.PhoneNumber = personalData.PhoneNumber;
            newPersonalData.Description = personalData.Description;

            PhoneBookContext.SaveChanges();
       
            return "Successfully";

        }


        public void AddingNewData(Person person,
                                        PersonalData personalData,
                                        IFormFile file,
                                        IWebHostEnvironment appEnvironment)
        {
            int id;

            personalData.PersonID = person;
            personalData.PhoneNumber = EditPhoneNumber(personalData.PhoneNumber);

            PhoneBookContext.Persons.Add(person);
            PhoneBookContext.PersonalDatas.Add(personalData);

            PhoneBookContext.SaveChanges();

            id = PhoneBookContext.Persons.FirstOrDefault(o => o.Name == person.Name).ID;
            
            SavePhoto(id, file, appEnvironment);
        }

        private string EditPhoneNumber(string phoneNumder)
        {
            phoneNumder = phoneNumder.Replace("(", string.Empty);
            phoneNumder = phoneNumder.Replace(")", string.Empty);
            phoneNumder = phoneNumder.Replace(" ", "-");
            phoneNumder = phoneNumder.Remove(0, 1);

            return phoneNumder;
        }

        private void SavePhoto(int id, IFormFile incomingFile, IWebHostEnvironment appEnvironment)
        {
                if (incomingFile != null)
                {
                    string path = "/card/" + $"photo_{id}.{DateTime.Now.Ticks}.jpg";

                    using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        incomingFile.CopyToAsync(fileStream);

                    }
                }
        }


        public void EditPhoto(int id, IFormFile newPhoto, IWebHostEnvironment appEnvironment)
        {

            DeletePhoto(id, appEnvironment);

            SavePhoto(id, newPhoto, appEnvironment);
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

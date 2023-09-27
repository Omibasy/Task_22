using System;
using System.Collections.Generic;
using Wpf_Task_22.Model.Data;
using Wpf_Task_22.Model;
using System.Windows.Input;
using Wpf_Task_22.Controller;
using Wpf_Task_22.View.ViewModel.RegistrationModel;
using Wpf_Task_22.View.ViewModel.StaticResources;

namespace Wpf_Task_22.View.ViewModel.DataModel.SourceModel
{
    internal class CharacterTableModel : BaseViewModel
    {
        public System.Windows.Visibility AdminControl { get; set; }

        public IEnumerable<Person> Persons { get; set; }

        public ICommand commandGetInfo { get; set; }

        public ICommand commandEditData { get; set; }

        public ICommand commandEditPhoto { get; set; }

        public ICommand commandDeleteData { get; set; }

        public event Action<int> GetInfoTransitio;
        public event Action<int> EditDataTransitio;
        public event Action<int> EditPhotoTransitio;

        public event Action Update;

        public CharacterTableModel()
        {
           Persons = PhoneBoockDataAPI.GetPersons();

           commandGetInfo = new Command(GetInfo, (o) => true);
           commandEditData = new Command(EditData, (o) => true);
           commandDeleteData = new Command(DeleteData, (o) => true);
           commandEditPhoto = new Command(EditPhoto, (o) => true);

           GetRole();
        }

        private void GetRole()
        {
            if (Role.userRole == Model.AuthPersonApp.AuthRepository.UserRole.Admin)
            {
                AdminControl = System.Windows.Visibility.Visible;
            }
            else
            {
                AdminControl = System.Windows.Visibility.Collapsed;
            }
        }

        private void GetInfo(object o)
        {         
            Use(GetInfoTransitio, o);
        }

        private void EditData(object o)
        {
            Use(EditDataTransitio, o);
        }

        private void EditPhoto(object o)
        {
            Use(EditPhotoTransitio, o);
        }

        private void Use(Action<int> action, object o)
        {
            Person person = o as Person;

            if (person != null)
            {   
                action?.Invoke(person.ID);
            }
        }

        private void DeleteData(object o)
        {
            Person person = o as Person;

            if (person != null)
            {
                PhoneBoockDataAPI.SendDelete(person.ID);

                Update?.Invoke();
            }
        }
    }
}

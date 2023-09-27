using System;
using System.Windows.Input;
using Wpf_Task_22.Controller;
using Wpf_Task_22.Model;
using Wpf_Task_22.Model.AuthPersonApp;
using Wpf_Task_22.View.ViewModel.RegistrationModel;

namespace Wpf_Task_22.View.ViewModel.DataModel.AdminModel
{
    internal class UserListModel : BaseViewModel
    {
        public DataUser[] Users { get; set; }

        public ICommand commandDeleteUser { get; set; }

        public event Action<object> Updete;

        public UserListModel() 
        {
            Users =  PhoneBoockDataAPI.GetUsers();

            commandDeleteUser = new Command(DeleteUser, (o)=> true);
        }

        private void DeleteUser(object o)
        {
            DataUser dataUser = o as DataUser;

            if (dataUser != null) 
            {
                PhoneBoockDataAPI.DeleteUser(dataUser.Name);

                Updete?.Invoke(o);

            }


        }
    }
}

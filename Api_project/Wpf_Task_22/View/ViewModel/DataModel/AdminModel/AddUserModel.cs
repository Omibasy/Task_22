using System;
using System.Windows.Input;
using Wpf_Task_22.Controller;
using Wpf_Task_22.Model;
using Wpf_Task_22.Model.AuthPersonApp.AuthRepository;
using Wpf_Task_22.View.ViewModel.RegistrationModel;

namespace Wpf_Task_22.View.ViewModel.DataModel.AdminModel
{
    internal class AddUserModel : BaseViewModel
    {
        public UserRegistration userRegistration { get; set; }
        public event Action<object> Back;

        public ICommand SendRegistrationCommand { get; set; }

        public AddUserModel()
        {
            userRegistration = new UserRegistrationValidates()
            {
                LoginProp = "",
                Password = "",
                ConfirmPassword = ""
            };

            SendRegistrationCommand = new Command(SendRegistration, (o) => true);
        }

        public void SendRegistration(object o)
        {
            if ((userRegistration as UserRegistrationValidates).TrueValidates())
            {
                ChacRole((int)o);

                string str = PhoneBoockDataAPI.AddUser(userRegistration);

                Info(str);
            }
            else
            {
                UserStatus = "Поля не прошли валидацию";
            }
        }


        private void ChacRole(int value)
        {
            if (value == 0)
            {
                userRegistration.Role = UserRole.Admin;
            }
            else
            {
                userRegistration.Role = UserRole.User;
            }
        }

        private void Info(string str)
        {
            if (str == "Нет соединения с сервером")
            {
                UserStatus = str;
            }
            else if (str.Length >= 6 && str != "" && str != null)
            {
                UserStatus = "Такой акаунт уже есть";
            }
            else
            {
                Back?.Invoke(str);
            }
        }
    }
}

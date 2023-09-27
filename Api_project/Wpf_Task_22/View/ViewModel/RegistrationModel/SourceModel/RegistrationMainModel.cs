using System;
using System.Windows.Input;
using Wpf_Task_22.Controller;
using Wpf_Task_22.Model;
using Wpf_Task_22.Model.AuthPersonApp.AuthRepository;


namespace Wpf_Task_22.View.ViewModel.RegistrationModel
{
    internal class RegistrationMainModel : BaseViewModel
    {
        public UserRegistration userRegistration { get; set; }

        public event Action BackCommandCompleted;
        public event Action<string> LoginCommandCompleted;

        public ICommand SendRegistrationCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public RegistrationMainModel() 
        {
            userRegistration = new UserRegistrationValidates()
            { 
                 LoginProp = "",
                 Password = "",
                 ConfirmPassword = ""           
            };

            SendRegistrationCommand = new Command(SendRegistration, (o) => true);
            BackCommand = new Command(Back, (o)  => true);
        }

        public void SendRegistration(object o)
        {
            if ((userRegistration as UserRegistrationValidates).TrueValidates())
            {
                ChacRole((int)o);            

                string str = PhoneBoockDataAPI.SendRegistration(userRegistration);

                GoToNextWindow(str);
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

        private void GoToNextWindow(string str)
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
                LoginCommandCompleted?.Invoke(GetStrUser(userRegistration.Role.ToString()));
            }
        }

        private string GetStrUser(string role)
        {
            if (role == "Admin")
            {
                return $"Администаратор {userRegistration.LoginProp} в системе";
            }
            else if (role == "User")
            {
                return $"Пользователь {userRegistration.LoginProp} в системе";
            }

            return null;
        }

        public void Back(object o)
        {
            BackCommandCompleted?.Invoke();
        }
    }
}

using System;
using System.Windows.Input;
using Wpf_Task_22.Controller;
using Wpf_Task_22.Model;
using Wpf_Task_22.Model.AuthPersonApp;
using Wpf_Task_22.Model.AuthPersonApp.AuthRepository;
using Wpf_Task_22.View.ViewModel.StaticResources;

namespace Wpf_Task_22.View.ViewModel.RegistrationModel
{
    internal class EnterPhoneBookModel : BaseViewModel
    {
        public UserLogin User { get; set; }


        public event Action TransitioCommandCompleted;
        public event Action<string> LoginCommandCompleted;

        public ICommand LoginCommand { get; set; }
        public ICommand TransitionCommand { get; set; }

        public EnterPhoneBookModel()
        {
            User = new UserLogin();

            Role.userRole = UserRole.NotRole;

            TransitionCommand = new Command(Transition,(o) => true);
            LoginCommand = new Command(Login, (o) => true);
        }


        public void Transition(object o)
        {
             TransitioCommandCompleted?.Invoke();
        }

        public void  Login(object o)
        {
     

            string role = PhoneBoockDataAPI.SendLogIn(User);

            if (role.Length >= 15)
            {
                UserStatus = role;
            }
            else if (role != null && role != "")
            {

                role = ToUpperFirstLetter(role);

                LoginCommandCompleted?.Invoke(GetStrUser(role));
            }
            else
            {
                UserStatus = "Пользователь не найден";
            }
        }

        private string ToUpperFirstLetter(string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
       
            char[] letters = source.ToCharArray();
 
            letters[0] = char.ToUpper(letters[0]);
       
            return new string(letters);
        }

        private string GetStrUser(string role)
        {
            if (role == "Admin")
            {
                Role.userRole = UserRole.Admin;

                return $"Администаратор {User.loginProp} в системе";
            }
            else if (role == "User")
            {

                Role.userRole =  UserRole.User;

                return $"Пользователь {User.loginProp} в системе";
            }

            return null;
        }
    }
}



namespace Wpf_Task_22.Model.AuthPersonApp.AuthRepository
{
    internal class UserRegistration 
    {


        public string LoginProp { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public UserRole Role { get; set; }


        public string GetRole()
        {
            switch (Role)
            {
                case UserRole.Admin:
                    return "admin";

                case UserRole.User:
                    return "user";

                default:
                    return "Not role";
            }
        }
    }
}

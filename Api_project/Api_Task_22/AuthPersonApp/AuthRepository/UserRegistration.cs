using System.ComponentModel.DataAnnotations;

namespace Api_Task_22.AuthPersonApp.Repository
{
    public class UserRegistration
    {
        [Required, MaxLength(20)]
        public string LoginProp { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
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

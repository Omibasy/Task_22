using System.ComponentModel.DataAnnotations;

namespace Api_Task_22.AuthPersonApp
{
    public class UserLogin
    {
        [Required, MaxLength(20)]
        public string loginProp { get; set; }

        [Required, DataType(DataType.Password)]
        public string password { get; set; }

        public string returnUrl { get; set; }
    }
}

namespace Web_Task_22.Model.AuthPersonApp
{
    public class DataUser
    {
        public string Name { get; set; }

        public string Role { get; set; }

        public DataUser(string name, string role)
        {
            Name = name;
            Role = role;

        }
    }
}

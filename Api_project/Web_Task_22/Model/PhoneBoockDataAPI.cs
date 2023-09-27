using System.Text;
using Web_Task_22.Model.AuthPersonApp.AuthRepository;
using Web_Task_22.Model.AuthPersonApp;
using Web_Task_22.Model.Data.Source;
using Web_Task_22.Model.Data;
using Newtonsoft.Json;

namespace Web_Task_22.Model
{
    internal static class PhoneBoockDataAPI
    {
        private static readonly HttpClient httpClient;

        private static readonly string UrlResource;

        static PhoneBoockDataAPI()
        {
            httpClient = new HttpClient();

            UrlResource = "https://localhost:7218/";
        }


        public static IEnumerable<Person> GetPersons()
        {
            string url = $@"{UrlResource}GetRange";

            try
            {
                string json = httpClient.GetStringAsync(url).Result;

                return JsonConvert.DeserializeObject<IEnumerable<Person>>(json);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static DataUser[] GetUsers()
        {
            string url = $@"{UrlResource}GetUserList";

            try
            {
                string json = httpClient.GetStringAsync(url).Result;

                return JsonConvert.DeserializeObject<DataUser[]>(json);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static BoxPerson GetPersonsInfo(int id)
        {
            string url = $@"{UrlResource}GetInfo/{id}";

            try
            {
                string json = httpClient.GetStringAsync(url).Result;

                BoxPerson box = JsonConvert.DeserializeObject<BoxPerson>(json);

                box.HepfImg = UrlResource + box.HepfImg;

                return box;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static string SendPut(PackagePerson package)
        {
            var json = JsonConvert.SerializeObject(package);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage answer = httpClient.PutAsync($@"{UrlResource}DataChanges", content).Result;

                return answer.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                return "Нет соединения с сервером";
            }

        }


        public static string DeleteUser(string name)
        {
            try
            {
                HttpResponseMessage answer = httpClient.DeleteAsync($@"{UrlResource}DeleteUser/{name}").Result;

                return answer.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                return "Нет соединения с сервером";
            }

        }

        public static string SendDelete(int id)
        {
            try
            {
                HttpResponseMessage answer = httpClient.DeleteAsync($@"{UrlResource}DataDelete/{id}").Result;

                return answer.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                return "Нет соединения с сервером";
            }

        }

        public static string SendPhoto(PackagePerson package)
        {
            var json = JsonConvert.SerializeObject(package);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


            try
            {
                HttpResponseMessage answer = httpClient.PostAsync($@"{UrlResource}ChangePhoto", content).Result;

                return answer.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                return "Нет соединения с сервером";
            }

        }


        public static string SendBox(PackagePerson package)
        {
            var json = JsonConvert.SerializeObject(package);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


            try
            {
                HttpResponseMessage answer = httpClient.PostAsync($@"{UrlResource}AddPerson", content).Result;

                return answer.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                return "Нет соединения с сервером";
            }

        }


        public static string SendLogIn(UserLogin user)
        {

            var json = JsonConvert.SerializeObject(user);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage answer = httpClient.PostAsync($@"{UrlResource}EnterLogin", content).Result;


                return answer.Content.ReadAsStringAsync().Result;
            }
            catch (AggregateException)
            {
                return "Нет соединения с сервером";
            }

        }

        public static string AddUser(UserRegistration userRegistration)
        {
            var json = JsonConvert.SerializeObject(userRegistration);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage answer = httpClient.PostAsync($@"{UrlResource}AddUser", content).Result;

                return answer.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                return "Нет соединения с сервером";
            }

        }


        public static string SendRegistration(UserRegistration userRegistration)
        {
            var json = JsonConvert.SerializeObject(userRegistration);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage answer = httpClient.PostAsync($@"{UrlResource}EnterRegistration", content).Result;

                return answer.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                return "Нет соединения с сервером";
            }

        }

        public static string SendOut()
        {

            try
            {
                return httpClient.GetStringAsync($@"{UrlResource}Logout").Result;

            }
            catch (AggregateException)
            {
                return "Нет соединения с сервером"; ;
            }
        }
    }
}

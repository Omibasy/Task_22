using Task_22.Model.Data;

namespace Task_22.Model.Repositorys
{
    public static class Repository
    {
        public static (List<Person>, List<PersonalData>) GetPersonalities()
        {
            List<Person> personalities = new List<Person>();
            List<PersonalData> personalDatas = new List<PersonalData>();

            personalities.Add(new Person()
            {

                Name = "Андрей",
                Surname = "Голубев",
                Patomic = "Сергеевич",
            });
            personalities.Add(new Person()
            {
              
                Name = "Кристина",
                Surname = "Боброва",
                Patomic = "Андреевна",
            });
            personalities.Add(new Person()
            {
              
                Name = "Татьяна",
                Surname = "Ершова",
                Patomic = "Павловна",
            });
            personalities.Add(new Person()
            {
             
                Name = "Юлия",
                Surname = "Михайлова",
                Patomic = "Артуровна",
            });
            personalities.Add(new Person()
            {
               
                Name = "Владимир",
                Surname = "Маслов",
                Patomic = "Маркович",
            });


            personalDatas.Add(new PersonalData()
            {

                PersonID = personalities[0],
                PhoneNumber = GetPhoneNumber(1),
                Address = "Новосибирская область, город Ступино, пл. Балканская,19",
                Description = GetText(),
            }) ;
            personalDatas.Add(new PersonalData()
            {


                PersonID = personalities[1],
                PhoneNumber = GetPhoneNumber(2),
                Address = "Калининградская область, город Серебряные Пруды, проезд Ленина, 82",
                Description = GetText(),
            });
            personalDatas.Add(new PersonalData()
            {


                PersonID = personalities[2],
                PhoneNumber = GetPhoneNumber(3),
                Address = "Новгородская область, город Ступино, бульвар Ладыгина, 98",
                Description = GetText(),
            });
            personalDatas.Add(new PersonalData()
            {


                PersonID = personalities[3],
                PhoneNumber = GetPhoneNumber(4),
                Address = "Кировская область, город Павловский Посад, спуск Славы, 60",
                Description = GetText(),
            });
            personalDatas.Add(new PersonalData()
            {


                PersonID = personalities[4],
                PhoneNumber = GetPhoneNumber(5),
                Address = "Мурманская область, город Егорьевск, пл. Гагарина, 35",
                Description = GetText(),
            });

            return (personalities, personalDatas);
        }

       

        private static string GetText()
        {
            return " Lorem ipsum dolor sit amet consectetur, adipisicing elit. Molestias ducimus dignissimos optio,\r\ndolores cupiditate culpa eveniet placeat nihil, deleniti ab dicta? Illum et at possimus aliquid";
        }

        private static string GetPhoneNumber(int id)
        {
            if (id > 9)
            {
                Random random = new Random();
                id = random.Next(0, 9);

            }

            return $"8-{id}{id}{id}-{id}{id}{id}-{id}{id}-{id}{id}";

        }
    }
}

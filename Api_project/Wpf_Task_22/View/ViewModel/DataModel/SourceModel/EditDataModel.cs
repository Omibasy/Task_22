using System;
using System.Windows.Input;
using Wpf_Task_22.Controller;
using Wpf_Task_22.Model;
using Wpf_Task_22.Model.Data;
using Wpf_Task_22.Model.Data.Validates;
using Wpf_Task_22.View.ViewModel.RegistrationModel;

namespace Wpf_Task_22.View.ViewModel.DataModel.SourceModel
{
    internal class EditDataModel : BaseViewModel
    {
        public event Action Back;

        public ICommand commandSendEditData { get; set; }

        public PackagePerson Package { get; set; }

        public EditDataModel(int id)
        {
            BoxPerson box = PhoneBoockDataAPI.GetPersonsInfo(id);

            Package = new PackagePerson()
            {
                person = new PersonValidates()
                {
                    ID = box.Data.PersonID.ID,
                    Name = box.Data.PersonID.Name,
                    Surname = box.Data.PersonID.Surname,
                    Patomic = box.Data.PersonID.Patomic
                },

                personalData = new PersonalDataValidates()
                {
                    ID = box.Data.ID,
                    Address = box.Data.Address,
                    Description = box.Data.Description,
                    PhoneNumber = GetPhoneNumber(box.Data.PhoneNumber),
                    PersonID = box.Data.PersonID,
                }
            };

            commandSendEditData = new Command(SendEditData,(o) => true);
        }

        private string GetPhoneNumber(string oldPhoneNumner) 
        {
            string[] str = oldPhoneNumner.Split('-');

            string newPhoneNumber = String.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                newPhoneNumber += str[i];
            }

            return newPhoneNumber;
        }


        private void SendEditData(object o)
        {
            if ((Package.person as PersonValidates).Validates() &&
                (Package.personalData as PersonalDataValidates).Validates())
            {
                Package.personalData.PhoneNumber =
                     new string(ChangingPhone(Package.personalData.PhoneNumber.ToCharArray()));

                PhoneBoockDataAPI.SendPut(Package);

                Back?.Invoke();
            }         
        }

        private char[] ChangingPhone(char[] oldPhone)
        {
            char[] newPhone = new char[(oldPhone.Length + 4)];

            for (int i = 0, j = 0; i < newPhone.Length; i++)
            {
                newPhone[i] = oldPhone[j];

                if (i == 1 ||
                    i == 5 ||
                    i == 9 ||
                    i == 12)
                {
                    newPhone[i] = '-';
                }
                else
                {
                    newPhone[i] = oldPhone[j];
                    j++;
                }
            }

            return newPhone;
        }
    }
}

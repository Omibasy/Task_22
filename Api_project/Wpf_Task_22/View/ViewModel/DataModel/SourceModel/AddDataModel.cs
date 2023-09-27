using System;
using System.IO;
using System.Windows.Input;
using Wpf_Task_22.Controller;
using Wpf_Task_22.Model;
using Wpf_Task_22.Model.Data;
using Wpf_Task_22.Model.Data.Validates;
using Wpf_Task_22.View.ViewModel.RegistrationModel;

namespace Wpf_Task_22.View.ViewModel.DataModel.SourceModel
{
    internal class AddDataModel : BaseViewModel
    {
        private string _UrlPhoto { get; set; }

        public string UrlPhoto 
        {
            get 
            { 
                return _UrlPhoto; 
            }
            set 
            {
               _UrlPhoto = value;
               OnPropertyChanged(nameof(UrlPhoto));
            } 
        }

        public event Action Back;

        public ICommand SendPackageCommand { get; set; }

        public PackagePerson package { get; set; }    

        public AddDataModel() 
        {
            UrlPhoto = "D:\\тест 2\\Wpf\\Wpf_Task_22\\Default_Photo\\Not_Photo.jpg";

            package = new PackagePerson()
            {
                person = new PersonValidates(),
                personalData = new PersonalDataValidates()
            };
            SendPackageCommand = new Command(SendPackage, (o) => true);
        }

        private void SendPackage(object o)
        {
            if ((package.personalData as PersonalDataValidates).Validates() &&
                (package.person as PersonValidates).Validates()) 
            {
        
                if (o == null)
                {
                    package.DataPhoto = GetBinaryFile(UrlPhoto); 
                }
                else
                {
                    string path = o.ToString();
                    package.DataPhoto = GetBinaryFile(path.Remove(0, 8));
                }

                package.personalData.PhoneNumber =
                    new string(ChangingPhone(package.personalData.PhoneNumber.ToCharArray()));

                PhoneBoockDataAPI.SendBox(package);

                Back?.Invoke();
            }
        }


        private byte[] GetBinaryFile(string filename)
        {
            byte[] bytes;
            using (FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
            }
            return bytes;
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

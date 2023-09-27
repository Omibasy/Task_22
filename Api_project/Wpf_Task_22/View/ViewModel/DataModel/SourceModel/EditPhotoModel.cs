using System;
using System.Windows.Input;
using Wpf_Task_22.Controller;
using Wpf_Task_22.Model.Data;
using Wpf_Task_22.Model;
using Wpf_Task_22.View.ViewModel.RegistrationModel;
using System.IO;

namespace Wpf_Task_22.View.ViewModel.DataModel.SourceModel
{
    internal class EditPhotoModel : BaseViewModel
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
        public PackagePerson Package { get; set; }
        public ICommand commandSendEditPhoto { get; set; }

        public EditPhotoModel(int id)
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

            };

            UrlPhoto = box.HepfImg;

            commandSendEditPhoto = new Command(SendEditPhoto, (o) => true);
        }

        private void SendEditPhoto(object o)
        {
            string path = o.ToString();

            Package.DataPhoto = GetBinaryFile(path.Remove(0, 8));

            PhoneBoockDataAPI.SendPhoto(Package);

            Back?.Invoke();
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
    }
}

using System;
using System.Windows.Input;
using Wpf_Task_22.Controller;
using Wpf_Task_22.Model;
using Wpf_Task_22.View.ViewModel.DataModel.AdminModel;
using Wpf_Task_22.View.ViewModel.DataModel.SourceModel;
using Wpf_Task_22.View.ViewModel.RegistrationModel;

namespace Wpf_Task_22.View.ViewModel.DataModel
{
    internal class MainDataModel : BaseViewModel
    {
        private BaseViewModel _SelectViewModel;

        public BaseViewModel SelectViewModel
        {
            get { return _SelectViewModel; }
            set { _SelectViewModel = value; }
        }

        public event Action CloseDataModel;


        public ICommand TransitioBackCommand { get; set; }
        public ICommand GetListUserCommand { get; set; }
        public ICommand AddDataCommand { get; set; }

        public ICommand AddUserCommand { get; set; }

        public MainDataModel() 
        {
            СreateToTableModel();


            TransitioBackCommand = new Command(TransitioBack, (o) => true);
            AddDataCommand = new Command(AddData, (o) => true);
            GetListUserCommand = new Command(GetListUser, (o)=> true);
            AddUserCommand = new Command(AddUser, (o) => true);

        }

        private void AddUser(object o)
        {
            AddUserModel model = new AddUserModel();

            model.Back += GetListUser;

            SelectViewModel = model;

            OnPropertyChanged(nameof(SelectViewModel));
        }

        private void GetListUser(object o)
        { 
             UserListModel model= new UserListModel();

             model.Updete += GetListUser;

             SelectViewModel = model;       

             OnPropertyChanged(nameof(SelectViewModel));
        }

        private void TransitioToInfoModel(int id)
        {
            CharacterInfoModel model = new CharacterInfoModel(id);

            SelectViewModel = model;

            OnPropertyChanged(nameof(SelectViewModel));
        }

        private void TransitioBack(object o)
        {
            if (SelectViewModel is CharacterTableModel)
            {
                PhoneBoockDataAPI.SendOut();

                CloseDataModel?.Invoke();
            }
            else if (SelectViewModel is CharacterInfoModel ||
                     SelectViewModel is AddDataModel ||
                     SelectViewModel is EditDataModel ||
                     SelectViewModel is EditPhotoModel ||
                     SelectViewModel is UserListModel ||
                     SelectViewModel is AddUserModel)
            {
                СreateToTableModel();
            }
        }

        private void СreateToTableModel()
        {
            CharacterTableModel model = new CharacterTableModel();

            model.GetInfoTransitio += TransitioToInfoModel;
            model.EditDataTransitio += EditData;
            model.EditPhotoTransitio += EditPhoto;
            model.Update += СreateToTableModel;   

            _SelectViewModel = model;

            OnPropertyChanged(nameof(SelectViewModel));
        }

        private void AddData(object o)
        {
            AddDataModel model = new AddDataModel();

            model.Back += СreateToTableModel;

            SelectViewModel = model;

            OnPropertyChanged(nameof(SelectViewModel));
        }

        private void EditData(int id)
        {
            EditDataModel model = new EditDataModel(id);

            model.Back += СreateToTableModel;

            SelectViewModel = model;

            OnPropertyChanged(nameof(SelectViewModel));

        }

        private void EditPhoto(int id)
        { 
        EditPhotoModel model = new EditPhotoModel(id);

            model.Back += СreateToTableModel;

            SelectViewModel = model;

            OnPropertyChanged(nameof(SelectViewModel));
        }

    }
}



namespace Wpf_Task_22.View.ViewModel.RegistrationModel
{
    internal class MainViewModel : BaseViewModel
    {
        private BaseViewModel _SelectViewModel;

        public BaseViewModel SelectViewModel
        {
            get { return _SelectViewModel; }
            set { _SelectViewModel = value; }
        }

        public MainViewModel() 
        {
           EnterPhoneBookModel model = new EnterPhoneBookModel();

           model.TransitioCommandCompleted += Transition;

           _SelectViewModel = model;
        }

        public void Transition()
        {
            (_SelectViewModel as EnterPhoneBookModel).TransitioCommandCompleted -= Transition;
 
            RegistrationMainModel model = new RegistrationMainModel();

            model.BackCommandCompleted += TransitionBack;

            _SelectViewModel = model;

            OnPropertyChanged(nameof(SelectViewModel));
        }

        public void TransitionBack()
        {
            (_SelectViewModel as RegistrationMainModel).BackCommandCompleted -= TransitionBack;

            EnterPhoneBookModel model = new EnterPhoneBookModel();

            model.TransitioCommandCompleted += Transition;

            _SelectViewModel = model;

            OnPropertyChanged(nameof(SelectViewModel));
        }
    }
}

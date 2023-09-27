using System.Windows;
using System.Windows.Controls;
using Wpf_Task_22.View.ViewModel.RegistrationModel;

namespace Wpf_Task_22.View.Views.RegistrationUserControl
{
   
    public partial class RegistrationViewMain : UserControl
    {
        public RegistrationViewMain()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as RegistrationMainModel).LoginCommandCompleted += Transition;
        }

        private void Transition(string role)
        {
            DataPhoneBook dataPhoneBook = new DataPhoneBook(role);

            (DataContext as RegistrationMainModel).LoginCommandCompleted -= Transition;

            Close();

            dataPhoneBook.Show();
        }

        private void Close()
        {
            var window = Window.GetWindow(this);
            window.Close();
        }

    }
}

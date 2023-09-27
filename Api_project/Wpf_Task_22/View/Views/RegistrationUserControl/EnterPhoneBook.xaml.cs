using System.Windows;
using System.Windows.Controls;
using Wpf_Task_22.View.ViewModel.RegistrationModel;

namespace Wpf_Task_22.View.Views.RegistrationUserControl
{

    public partial class EnterPhoneBook : UserControl
    {
        public EnterPhoneBook()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Default_Enter_Click(object sender, RoutedEventArgs e)
        {
            
            DataPhoneBook dataPhoneBook = new DataPhoneBook("Гость зашел в ситстему");

            Close();

            dataPhoneBook.Show();
        }

        private void Close()
        {
            var window = Window.GetWindow(this);
            window.Close();
        }

        private void Enter_Click(string role)
        {
            DataPhoneBook dataPhoneBook = new DataPhoneBook(role);

            (DataContext as EnterPhoneBookModel).LoginCommandCompleted -= Enter_Click;

            Close();

            dataPhoneBook.Show();
        }

        private void EnterPhoneBook_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as EnterPhoneBookModel).LoginCommandCompleted += Enter_Click;
        }

    }
}

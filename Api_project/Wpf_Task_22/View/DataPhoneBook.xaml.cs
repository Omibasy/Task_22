using System.Windows;
using Wpf_Task_22.Model.AuthPersonApp.AuthRepository;
using Wpf_Task_22.View.ViewModel.DataModel;
using Wpf_Task_22.View.ViewModel.StaticResources;

namespace Wpf_Task_22.View
{
 
    
    public partial class DataPhoneBook : Window
    {
       

        public DataPhoneBook(string role)
        {
            InitializeComponent();

            RoleUser.Text = role;

            FunctionalRoles();

        }

        private void  CloseView()
        {
            TestView testView = new TestView();

            Role.userRole = UserRole.NotRole;

            (DataContext as MainDataModel).CloseDataModel -= CloseView;

            Close();

            testView.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as MainDataModel).CloseDataModel += CloseView;
        }

        private void FunctionalRoles()
        {
            if (Role.userRole == UserRole.Admin)
            {
                return;
            }
            else if (Role.userRole == UserRole.User)
            {
                AddUser.Visibility = Visibility.Collapsed;
                GetUserList.Visibility = Visibility.Collapsed;
            }
            else
            {
                AddPerson.Visibility = Visibility.Collapsed;
                AddUser.Visibility = Visibility.Collapsed;
                GetUserList.Visibility = Visibility.Collapsed;
            }
        }
    }
}

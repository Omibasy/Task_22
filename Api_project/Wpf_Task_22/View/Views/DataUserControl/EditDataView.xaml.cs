using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Wpf_Task_22.View.Views.DataUserControl
{

    public partial class EditDataView : UserControl
    {
        public EditDataView()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PhoneNumberText.Text += "8";
        }

        private void PhoneNumberText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete ||
                e.Key == Key.Back)
            {
                if (PhoneNumberText.Text.Length <= 1)
                {
                    e.Handled = true;
                }
            }
        }

        private void PhoneNumberText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PhoneNumberText.Text[0] != '8')
            {
                if (PhoneNumberText.Text.Length <= 1)
                {
                    PhoneNumberText.Text = "8" + PhoneNumberText.Text.Remove(0, 1);
                }
                else
                {
                    PhoneNumberText.Text = "8" + PhoneNumberText.Text.Remove(0, 2);
                }
            }
        }
    }
}

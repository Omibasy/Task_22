using Microsoft.Win32;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace Wpf_Task_22.View.Views.DataUserControl
{

    public partial class AddDataView : UserControl
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        private bool _checked = false;

        public AddDataView()
        {
            InitializeComponent();
        }

        private void Add_Photo_Click(object sender, RoutedEventArgs e)
        {


            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Файлы рисунков (*.jpg)|*.jpg";

            openFileDialog.ShowDialog();

            var str = openFileDialog.FileName.Split('.');

            if (str[str.Length - 1].ToLower() == "jpg")
            {
                BitmapImage photo = new BitmapImage();

                photo.BeginInit();

                photo.UriSource = new Uri(openFileDialog.FileName);

                photo.EndInit();

                PhotoPerson.Source = photo;
            }

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
                else
                {
                    _checked = true;
                }
            }
        }

        private void PhoneNumberText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PhoneNumberText.Text == string.Empty)
            {
                PhoneNumberText.Text = "8";
            }
            else if (PhoneNumberText.Text[0] != '8')
            {
                if (PhoneNumberText.Text.Length <= 1)
                {
                    PhoneNumberText.Text = "8" + PhoneNumberText.Text.Remove(0, 1);
                }
                else if (_checked)
                {
                    if (PhoneNumberText.Text.Length <= 2)
                    {
                        PhoneNumberText.Text = "8" + PhoneNumberText.Text.Remove(0, 2);
                    }
                    else
                    {
                        PhoneNumberText.Text = "8" + PhoneNumberText.Text;
                    }

                    _checked  = false;
                }
                else
                {
                    PhoneNumberText.Text = "8" + PhoneNumberText.Text.Remove(0, 2);
                }
            }
        }



        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}

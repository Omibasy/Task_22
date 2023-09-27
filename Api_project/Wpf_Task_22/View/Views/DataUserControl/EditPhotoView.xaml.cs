using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace Wpf_Task_22.View.Views.DataUserControl
{
 
    public partial class EditPhotoView : UserControl
    {
        public EditPhotoView()
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
    }
}

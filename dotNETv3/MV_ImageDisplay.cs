using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace dotNETv3
{
    public partial class MainWindow
    {
        private void ButtonShowImage_Click(object sender, RoutedEventArgs e)
        {
            var fdialog = new OpenFileDialog();
            fdialog.InitialDirectory = @"C:\Users\Mariusz\Desktop\dotNet";
            fdialog.ShowDialog();
            var img = new BitmapImage(new Uri(fdialog.FileName));
            MyImage.Source = img;
            ImageLabelPicResolution.Content = img.Width + "x" + img.Height;
            TextBoxImagePath.Text = fdialog.FileName;
        }
        private void DBButtonImage_Click(object sender, RoutedEventArgs e)
        {
            var context = new PlayerContext();
            var x = TextBoxImagePath.Text;
            var fileInfo = new FileInfo(x);
            var img = new BitmapImage(new Uri(x));

            var image = new Image()
            {
                FileName = fileInfo.Name,
                AddedTime = DateTime.Now,
                Extension = fileInfo.Extension,
                FilePath = x,
                ImageHeight = (int)img.Height,
                ImageWidth = (int)img.Width
            };

            context.Images.Add(image);

            context.SaveChanges();

            //'odnów' listę autouzupełnianą na starcie
            ListaPlikowImg.Items.Clear();
            foreach (var item in context.Audios)
            {
                ListaPlikowImg.Items.Add(item.FilePath);
            }
        }

        private void ListaPlikowImg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var fullpath = ListaPlikowImg.SelectedItem.ToString();
            var img = new BitmapImage(new Uri(fullpath));
            MyImage.Source = img;
        }
    }
}

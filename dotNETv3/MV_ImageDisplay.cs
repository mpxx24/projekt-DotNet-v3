using System;
using System.Windows;
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
            MyImage.Source = new BitmapImage(new Uri(fdialog.FileName));
        }
    }
}

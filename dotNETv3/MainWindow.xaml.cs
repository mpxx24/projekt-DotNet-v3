using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace dotNETv3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            VideoWindow.Volume = 100;
            var c = new PlayerContext();
            //ListaPlikow.Items.Add("Lista plików w bazie danych: ");
            foreach (var x in c.Videos)
            {
                ListaPlikow.Items.Add(x.FilePath);
            }
            foreach (var y in c.Audios)
            {
                ListaPlikowAudio.Items.Add(y.FilePath);
            }
            foreach (var y in c.Images)
            {
                ListaPlikowImg.Items.Add(y.FilePath);
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            var fullpath = TextBoxFileDirectory.Text;
            if (fullpath == "")
            {
                MessageBox.Show("nie wybrano pliku");
            }
            else
            {
                VideoWindow.Source = new Uri(fullpath);
                VideoWindow.Play();
            }
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var fdialog = new OpenFileDialog();
            fdialog.InitialDirectory = @"C:\Users\Mariusz\Desktop\dotNet";
            fdialog.ShowDialog();
            TextBoxFileDirectory.Text = fdialog.FileName;
        }

        private void ListaPlikow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var fullpath = ListaPlikow.SelectedItem.ToString();
            VideoWindow.Source = new Uri(fullpath);
            LabelSongName.Content = Path.GetFileName(fullpath);
            VideoWindow.Play();
        }

        private void DBButton_Click(object sender, RoutedEventArgs e)
        {
            var context = new PlayerContext();
            var x = TextBoxFileDirectory.Text;
            var fileInfo = new FileInfo(x);

            var vid = new Video()
            {
                FileName = fileInfo.Name,
                AddedTime = DateTime.Now,
                Extension = fileInfo.Extension,
                Lenght = fileInfo.Length,
                FilePath = x
            };

            context.Videos.Add(vid);

            context.SaveChanges();


            //'odnów' listę autouzupełnianą na starcie
            ListaPlikow.Items.Clear();
            foreach (var item in context.Videos)
            {
                ListaPlikow.Items.Add(item.FilePath);
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            VideoWindow.Stop();
        }
        
    }
}

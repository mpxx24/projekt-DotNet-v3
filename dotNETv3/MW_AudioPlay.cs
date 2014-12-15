using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace dotNETv3
{
    public partial class MainWindow
    {
        private void ButtonPlayAudio_Click(object sender, RoutedEventArgs e)
        {
            var fullpath = TextBoxAudioFileDirectory.Text;

            if (fullpath == "")
            {
                MessageBox.Show("nie wybrano pliku");
            }
            else
            {
                AudioWindow.Source = new Uri(fullpath);
                LabelSongName.Content = Path.GetFileName(fullpath);
                LabelSongExtension.Content = Path.GetExtension(fullpath);
                VideoWindow.Play();
            }
        }

        private void ButtonStopAudio_Click(object sender, RoutedEventArgs e)
        {
            AudioWindow.Stop();
            TextBoxAudioFileDirectory.Text = "";
        }

        private void BrowseAudioButton_Click(object sender, RoutedEventArgs e)
        {
            var fdialog = new OpenFileDialog();
            fdialog.InitialDirectory = @"C:\Users\Mariusz\Desktop\dotNet";
            fdialog.ShowDialog();
            TextBoxAudioFileDirectory.Text = fdialog.FileName;
        }

        private void BDAudioButton_Click(object sender, RoutedEventArgs e)
        {
            var context = new PlayerContext();
            var x = TextBoxAudioFileDirectory.Text;
            var fileInfo = new FileInfo(x);

            var song = new Audio()
            {
                FileName = fileInfo.Name,
                AddedTime = DateTime.Now,
                Extension = fileInfo.Extension,
                Lenght = fileInfo.Length,
                FilePath = x
            };

            context.Audios.Add(song);

            context.SaveChanges();

            //'odnów' listę autouzupełnianą na starcie
            ListaPlikowAudio.Items.Clear();
            foreach (var item in context.Audios)
            {
                ListaPlikowAudio.Items.Add(item.FilePath);
            }
        }

        private void ListaPlikowAudio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AudioWindow.Source = new Uri(ListaPlikowAudio.SelectedItem.ToString());
            var fullpath = ListaPlikowAudio.SelectedItem.ToString();
            LabelSongName.Content = Path.GetFileName(fullpath);
            LabelSongExtension.Content = Path.GetExtension(fullpath);
            AudioWindow.Play();
        }
    }
}

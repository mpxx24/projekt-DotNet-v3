using System.Windows;

namespace dotNETv3
{
    //ADUIO: SZUKAJ
    public partial class MainWindow
    {
        private void SzukajAudio_Click(object sender, RoutedEventArgs e)
        {
            var context = new PlayerContext();
            WyszukaneDaneAudio.Document.Blocks.Clear();
            if (RButtonAudioFileName.IsChecked == true)
            {
                foreach (var item in context.Audios)
                {
                    if (DoWyszukaniaAudio.Text != null)
                    {
                        if (item.FileName.Contains(DoWyszukaniaAudio.Text))
                        {
                            WyszukaneDaneAudio.AppendText("\n" + item.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("przed wyszukaniem, należy wpisać treść którą chce się wyszukać");
                    }
                }
            }
            else if (RButtonAudioFileExt.IsChecked == true)
            {
                foreach (var item in context.Audios)
                {
                    if (DoWyszukaniaAudio.Text != null)
                    {
                        if (item.Extension == DoWyszukaniaAudio.Text)
                        {
                            WyszukaneDaneAudio.AppendText("\n" + item.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("przed wyszukaniem, należy wpisać treść którą chce się wyszukać");
                    }
                }
            }
            else if (RButtonAudioFileLengthMoreThan.IsChecked == true)
            {
                foreach (var item in context.Audios)
                {
                    if (DoWyszukaniaAudio.Text != null)
                    {
                        if (item.Lenght >= long.Parse(DoWyszukaniaAudio.Text))
                        {
                            WyszukaneDaneAudio.AppendText("\n" + item.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("przed wyszukaniem, należy wpisać treść którą chce się wyszukać");
                    }
                }
            }
            else if (RButtonAudioFileLengthLessThan.IsChecked == true)
            {
                foreach (var item in context.Audios)
                {
                    if (DoWyszukaniaAudio.Text != null)
                    {
                        if (item.Lenght <= long.Parse(DoWyszukaniaAudio.Text))
                        {
                            WyszukaneDaneAudio.AppendText("\n" + item.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("przed wyszukaniem, należy wpisać treść którą chce się wyszukać");
                    }
                }
            }
            else
            {
                MessageBox.Show("musisz zaznaczyć konkretnego checkboxa!");
            }
        } 
    }
}

using System.Windows;

namespace dotNETv3
{
    //VIDEO: SZUKAJ
    public partial class MainWindow
    {
        private void Szukaj_Click(object sender, RoutedEventArgs e)
        {
            var context = new PlayerContext();
            WyszukaneDane.Document.Blocks.Clear();
            if (RButtonFileName.IsChecked == true)
            {
                foreach (var item in context.Videos)
                {
                    if (DoWyszukania.Text != null)
                    {
                        if (item.FileName.Contains(DoWyszukania.Text))
                        {
                            WyszukaneDane.AppendText("\n" + item.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("przed wyszukaniem, należy wpisać treść którą chce się wyszukać");
                    }
                }
            }
            else if (RButtonFileExt.IsChecked == true)
            {
                foreach (var item in context.Videos)
                {
                    if (DoWyszukania.Text != null)
                    {
                        if (item.Extension == DoWyszukania.Text)
                        {
                            WyszukaneDane.AppendText("\n" + item.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("przed wyszukaniem, należy wpisać treść którą chce się wyszukać");
                    }
                }
            }
            else if (RButtonFileLengthMoreThan.IsChecked == true)
            {
                foreach (var item in context.Videos)
                {
                    if (DoWyszukania.Text != null)
                    {
                        if (item.Lenght >= long.Parse(DoWyszukania.Text))
                        {
                            WyszukaneDane.AppendText("\n" + item.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("przed wyszukaniem, należy wpisać treść którą chce się wyszukać");
                    }
                }
            }
            else if (RButtonFileLengthLessThan.IsChecked == true)
            {
                foreach (var item in context.Videos)
                {
                    if (DoWyszukania.Text != null)
                    {
                        if (item.Lenght <= long.Parse(DoWyszukania.Text))
                        {
                            WyszukaneDane.AppendText("\n" + item.FileName);
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

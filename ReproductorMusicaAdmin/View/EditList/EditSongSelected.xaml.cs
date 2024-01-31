using ReproductorMusicaAdmin.API;
using ReproductorMusicaAdmin.API.Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ReproductorMusicaAdmin
{
    /// <summary>
    /// Interaction logic for EditSongSelected.xaml
    /// </summary>
    public partial class EditSongSelected : Window
    {
        public EditSongSelected()
        {
            InitializeComponent();
        }

        private void MostrarMasOpciones_Click(object sender, RoutedEventArgs e)
        {
            ExtensionsPopup.IsOpen = !ExtensionsPopup.IsOpen;
        }

        private async void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            int duration;

            int.TryParse(Duration.Text, out duration);
            Song? songSeleccionada = this.DataContext as Song;
            if (songSeleccionada != null)
            {
                songSeleccionada.Title = this.Title.Text;
                songSeleccionada.Language = this.Language.Text;
                songSeleccionada.Duration = duration;
                using (var api = new Api())
                {
                    //Extension extensionSong = new Extension();
                    //extensionSong.Name = 
                    string uid = songSeleccionada.UID.ToString();
                    string updateResponse = await api.UpdateSong(uid, songSeleccionada);
                    Console.WriteLine(updateResponse);
                }
            }

            this.Close();
        }
    }
}

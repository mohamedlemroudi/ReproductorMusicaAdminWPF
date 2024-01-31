using ReproductorMusicaAdmin.API;
using ReproductorMusicaAdmin.API.Entitas;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ReproductorMusicaAdmin
{
    public partial class EditList : Window
    {
        private readonly Api api;

        public EditList()
        {
            InitializeComponent();
            api = new Api();
            LoadSong();
        }

        /// <summary>
        /// Carrega les cançons
        /// </summary>
        private async void LoadSong()
        {
            List<Song> songs = await api.GetSongs();
            ListBoxCanciones.ItemsSource = songs;
        }

        private void ListBoxCanciones_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Song selectedSong = (Song)ListBoxCanciones.SelectedItem;

            if (selectedSong != null)
            {
                EditSongSelected editSongSelected = new EditSongSelected();
                editSongSelected.DataContext = selectedSong;
                editSongSelected.ShowDialog();
            }
        }

        /// <summary>
        /// Buscar pel nom de música estat sense focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            textBox.Foreground = Brushes.Black;
            if (textBox.Text == "Buscar música...")
            {
                textBox.Text = "";
            }
        }

        /// <summary>
        /// Buscar pel nom de música estat amb focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = Brushes.Gray;
                textBox.Text = "Buscar música...";
            }
        }

        /// <summary>
        /// Tancar la finestra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            api.Dispose();
        }
    }
}

using Microsoft.Win32;
using System;
using System.Windows;

namespace ReproductorMusicaAdmin.View.DownSong
{
    public partial class DownSong : Window
    {
        string nomArxiu;

        public DownSong()
        {
            InitializeComponent();
        }

        private void SeleccionarCarpeta_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de música|*.mp3;*.wav;*.ogg|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Puedes mostrar el nombre del archivo seleccionado o realizar otras acciones.
                nomArxiu = openFileDialog.FileName;
            }
        }

        private void DescargarMusica_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para descargar música seleccionada desde la API
            // Utiliza ListBoxMusicaAPI.SelectedItem para obtener la música seleccionada
            // Utiliza CarpetaDescargaTextBox.Text para obtener la carpeta de descarga
            // Implementa la lógica de descarga aquí
        }
    }
}
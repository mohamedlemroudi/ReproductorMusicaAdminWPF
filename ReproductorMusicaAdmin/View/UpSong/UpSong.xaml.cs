using Microsoft.Win32;
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

namespace ReproductorMusicaAdmin.View.UpSong
{
    /// <summary>
    /// Interaction logic for UpSong.xaml
    /// </summary>
    public partial class UpSong : Window
    {
        string nomArxiu;

        public UpSong()
        {
            InitializeComponent();
        }

        private void SeleccionarArchivo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de música|*.mp3;*.wav;*.ogg|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Puedes mostrar el nombre del archivo seleccionado o realizar otras acciones.
                nomArxiu = openFileDialog.FileName;
            }
        }

        private void SubirMusica_Click(object sender, RoutedEventArgs e)
        {
            string nameSong = NombreCancionTextBox.Text;
        }
    }
}

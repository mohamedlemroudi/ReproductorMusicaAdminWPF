using System;
using System.Windows;

namespace ReproductorMusicaAdmin.View
{
    public partial class AlbumSong : Window
    {
        public AlbumSong()
        {
            InitializeComponent();
        }

        private void Crear_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para el botón "Crear"
            MessageBox.Show("Evento Crear clicado");
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para el botón "Editar"
            MessageBox.Show("Evento Editar clicado");
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            // Lógica para el botón "Eliminar"
            MessageBox.Show("Evento Eliminar clicado");
        }
    }
}

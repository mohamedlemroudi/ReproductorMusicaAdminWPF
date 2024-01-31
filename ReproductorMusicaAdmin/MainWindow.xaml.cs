using ReproductorMusicaAdmin.API.Entitas;
using ReproductorMusicaAdmin.View.Album;
using ReproductorMusicaAdmin.View.DownSong;
using ReproductorMusicaAdmin.View.UpSong;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReproductorMusicaAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listMusicButton.Click += ListMusicButton_Click;
            editListButton.Click += EditListButton_Click;
            configurationButton.Click += ConfigurationButton_Click;
            upSong.Click += upSongButtton_Click;
            downSong.Click += downSongButtton_Click;
            album.Click += albumButtton_Click;
        }

        // Open window ListMusic
        private void ListMusicButton_Click(object sender, RoutedEventArgs e)
        {
            //ListMusic listMusic = new ListMusic();

            // Ajustar la posición de la nueva ventana justo debajo de la ventana principal
            //listMusic.Top = this.Top + 100; 
            //listMusic.Left = this.Left + 100;

            //listMusic.Show();
        }

        // Open window EditList
        private void EditListButton_Click(object sender, RoutedEventArgs e)
        {
            EditList edit = new EditList();
            EditList editList = new EditList();

            // Ajustar la posición de la nueva ventana justo debajo de la ventana principal
            editList.Top = this.Top + 100;
            editList.Left = this.Left + 100;

            editList.Show();
        }

        // Open window Configuration
        private void ConfigurationButton_Click(object sender, RoutedEventArgs e)
        {
            Configuration configuration = new Configuration();

            // Ajustar la posición de la nueva ventana justo debajo de la ventana principal
            configuration.Top = this.Top + 100;
            configuration.Left = this.Left + 100;

            configuration.Show();
        }

        private void upSongButtton_Click(object sender, RoutedEventArgs e)
        {
            UpSong upSong = new UpSong();

            upSong.Top = this.Top + 100;
            upSong.Left = this.Left + 100;

            upSong.Show();
        }

        private void downSongButtton_Click(object sender, RoutedEventArgs e)
        {
            DownSong downSong = new DownSong();

            downSong.Top = this.Top + 100;
            downSong.Left = this.Left + 100;

            downSong.Show();
        }

        private void albumButtton_Click(object sender, RoutedEventArgs e)
        {
            AlbumSong album = new AlbumSong();

            album.Top = this.Top + 100;
            album.Left = this.Left + 100;

            album.Show();
        }
    }
}
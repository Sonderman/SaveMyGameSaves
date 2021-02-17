using SaveMyGameSaves.Services;
using System.Windows;


namespace SaveMyGameSaves
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = Auth.GetInstance();
            DService service = DService.GetInstance();
            auth.Authendicade();
            service.ListFiles();
        }


        /*
        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }
        */
    }
}

namespace TelefonRehberi
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

       

        private void OpenDirectoryPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Directory());
        }

        private void OpenNewPersonRegistrtionPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new newPersonRegistration());
        }
    }

}

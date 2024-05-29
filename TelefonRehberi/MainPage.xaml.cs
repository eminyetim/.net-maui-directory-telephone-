namespace TelefonRehberi
{
    public partial class MainPage : ContentPage
    {
      
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

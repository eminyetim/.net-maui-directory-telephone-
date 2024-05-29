namespace TelefonRehberi;
using TelefonRehberi.Models;
using TelefonRehberi.Data;

public partial class UpdateContactPage : ContentPage
{
    private readonly ContactDatabase _contactDatabase;
    private Contact _contact;

    public UpdateContactPage(Contact contact)
    {
        InitializeComponent();
        _contactDatabase = new ContactDatabase();
        _contact = contact;

        idEntry.Text = _contact.Id.ToString();
        nameEntry.Text = _contact.Name;
        phoneEntry.Text = _contact.PhoneNumber;
    }

    private async void OnUpdateButtonClicked(object sender, EventArgs e)
    {
        _contact.Name = nameEntry.Text;
        _contact.PhoneNumber = phoneEntry.Text;

        await _contactDatabase.SaveContactAsync(_contact);
        await DisplayAlert("Success","Güncelleme iþlemi baþarýlý.", "OK");
        await Navigation.PopAsync();
    }
}
namespace TelefonRehberi;

using Microsoft.Maui.Controls;
using TelefonRehberi.Data;
using TelefonRehberi.Models;

public partial class newPersonRegistration : ContentPage
{
    private ContactDatabase _contactDatabase;

    public newPersonRegistration()
    {
        InitializeComponent();
        _contactDatabase = new ContactDatabase();
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        string name = nameEntry.Text;
        string phoneNumber = phoneEntry.Text;

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phoneNumber))
        {
            await DisplayAlert("Hata", "L�tfen t�m alanlar� doldurun", "Tamam");
            return;
        }
        if (phoneNumber.Length != 11)
        {
            await DisplayAlert("Hata", "L�tfen 11 haneli telefon numaras� giriniz", "Tamam");
            return;
        }

        var newContact = new Contact
        {
            Name = name,
            PhoneNumber = phoneNumber
        };

        await _contactDatabase.SaveContactAsync(newContact);
        await DisplayAlert("Ba�ar�l�", "Ki�i ba�ar�yla kaydedildi", "Tamam");
        await Navigation.PopAsync();
    }

}
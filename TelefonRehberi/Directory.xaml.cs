
namespace TelefonRehberi;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using TelefonRehberi.Data;
using TelefonRehberi.Models;


public partial class Directory : ContentPage
{
    public ObservableCollection<Contact> Contacts { get; set; }
    public ICommand DeleteCommand { get; }
    private ContactDatabase _contactDatabase;

    public Directory()
    {
        InitializeComponent();
        _contactDatabase = new ContactDatabase();

        Contacts = new ObservableCollection<Contact>();
        contactsCollectionView.ItemsSource = Contacts;

        DeleteCommand = new Command<Contact>(async (contact) => await OnDelete(contact));

        BindingContext = this;
    }

    private async Task OnDelete(Contact contact)
    {
        bool confirm = await DisplayAlert("Onay", contact.Name + " adlý kiþiyi silmek istediðinizden emin misiniz?", "Evet", "Hayýr");
        if (confirm)
        {
            if (Contacts.Contains(contact))
            {
                Contacts.Remove(contact);
                await _contactDatabase.DeleteContactAsync(contact);
            }
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var contactList = await _contactDatabase.GetContactsAsync();
        Contacts.Clear();
        foreach (var contact in contactList)
        {
            Contacts.Add(contact);
        }
    }
}

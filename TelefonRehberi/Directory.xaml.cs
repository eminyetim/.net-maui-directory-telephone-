

namespace TelefonRehberi;
using Microsoft.Maui.Controls;
using TelefonRehberi.Models;
using System.Collections.ObjectModel;
using TelefonRehberi.Data;


public partial class Directory : ContentPage
{
    private ObservableCollection<Contact> contacts;
    private ContactDatabase _contactDatabase;

    public Directory()
    {
        InitializeComponent();
        _contactDatabase = new ContactDatabase();

        contacts = new ObservableCollection<Contact>();
        contactsCollectionView.ItemsSource = contacts;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var contactList = await _contactDatabase.GetContactsAsync();
        contacts.Clear();
        foreach (var contact in contactList)
        {
            contacts.Add(contact);
        }
    }
}

namespace TelefonRehberi;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using TelefonRehberi.Data;
using TelefonRehberi.Models;

public partial class Directory : ContentPage
{
    public ObservableCollection<Contact> Contacts { get; set; }
    public ObservableCollection<Contact> FilteredContacts { get; set; }
    public ICommand DeleteCommand { get; }
    private ContactDatabase _contactDatabase;

    public Directory()
    {
        InitializeComponent();
        _contactDatabase = new ContactDatabase();

        Contacts = new ObservableCollection<Contact>();
        FilteredContacts = new ObservableCollection<Contact>();
        contactsCollectionView.ItemsSource = FilteredContacts;

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
                FilteredContacts.Remove(contact);
                await _contactDatabase.DeleteContactAsync(contact);
            }
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var contactList = await _contactDatabase.GetContactsAsync();
        Contacts.Clear();
        FilteredContacts.Clear();
        foreach (var contact in contactList)
        {
            Contacts.Add(contact);
            FilteredContacts.Add(contact);
        }
    }

    private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
    {
        FilterContacts(e.NewTextValue);
    }

    private void FilterContacts(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            foreach (var contact in Contacts)
            {
                if (!FilteredContacts.Contains(contact))
                {
                    FilteredContacts.Add(contact);
                }
            }
        }
        else
        {
            var lowerCaseSearchText = searchText.ToLower();
            var filteredItems = Contacts.Where(c => c.Name.ToLower().Contains(lowerCaseSearchText) ||
                                                    c.PhoneNumber.Contains(searchText)).ToList();

            // Update the FilteredContacts collection
            FilteredContacts.Clear();
            foreach (var item in filteredItems)
            {
                FilteredContacts.Add(item);
            }
        }
    }

    private async void OnUpdateButtonClicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var contact = button?.BindingContext as Contact;
        if (contact != null)
        {
            await Navigation.PushAsync(new UpdateContactPage(contact));
        }
    }

}

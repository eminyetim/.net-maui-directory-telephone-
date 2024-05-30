
using SQLite;
namespace TelefonRehberi.Data;
using TelefonRehberi.Models; //Contact sınıfını içeri aktarır.

public class ContactDatabase
{
    private readonly SQLiteAsyncConnection _database;
    public ContactDatabase()
    {
        _database = DatabaseHelper.GetDatabaseConnection();
        _database.CreateTableAsync<Contact>().Wait();
    }
    public Task<List<Contact>> GetContactsAsync()
    {
        return _database.Table<Contact>().ToListAsync();
    }
    public Task<int> SaveContactAsync(Contact contact)
    {
        if (contact.Id != 0)
            return _database.UpdateAsync(contact);
        else
            return _database.InsertAsync(contact);
    }
    public Task<int> DeleteContactAsync(Contact contact)
    {
        return _database.DeleteAsync(contact);
    }
}


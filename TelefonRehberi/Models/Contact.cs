using System;
using SQLite;

namespace TelefonRehberi.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
    }
}
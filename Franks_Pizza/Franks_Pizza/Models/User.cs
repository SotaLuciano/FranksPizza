using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Franks_Pizza.Models
{
    // User Table
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Phone { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(255)]
        public string Login { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

        [MaxLength(10)]
        public string Sex { get; set; }

        [MaxLength(100)]
        public string  AvatarSource { get; set; }
    }
}

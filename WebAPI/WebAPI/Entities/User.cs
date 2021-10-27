using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class User
    {
        public User()
        {
            Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DoB { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}

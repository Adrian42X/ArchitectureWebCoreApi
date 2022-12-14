using ProjectDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class UserList
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }

        public UserList()
        {

        }
        public UserList(ApplicationUser user)
        {
            Id = user.Id;
            FirstName= user.FirstName;
            LastName= user.LastName;
            UserName = user.UserName;
        }
    }
}

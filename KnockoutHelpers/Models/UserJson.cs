using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutHelpers.Models
{
    public class UserJson : JsonViewModel
    {

        public UserJson()
        { }

        public int Id { get; set; }
        public string Name { get; set; }
        public AccountProvider Account { get; set; }

        public List<HobbyJson> Hobbies { get; set; }

    }
}
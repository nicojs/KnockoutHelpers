using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutHelpers.Models
{
    public class HobbyJson : JsonViewModel
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
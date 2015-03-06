using KnockoutHelpers.Helpers;
using KnockoutHelpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnockoutHelpers.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View(new KnockoutViewModel<UserJson>());
        }

        public virtual ActionResult Gebruiker()
        {
            return Json(new UserJson
                {
                    Id = 1,
                    Name = "NicoJS",
                    Account = AccountProvider.Google,
                    Hobbies = new List<HobbyJson>
		                {
                            new HobbyJson
                            {
			                    Name= "To code",
			                    Score= 10
		                    },
                            new HobbyJson
                            {
			                    Name= "Sports",
			                    Score= 5
		                    }
                        }
                }, JsonRequestBehavior.AllowGet);
        }

    }
}
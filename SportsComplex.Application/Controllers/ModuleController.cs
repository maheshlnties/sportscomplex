using System.Collections.Generic;
using System.Web.Mvc;
using SportsComplex.Application.Filters;
using SportsComplex.Application.ViewModels;

namespace SportsComplex.Application.Controllers
{
    [UserAuthorize(Roles = "Admin , Employee")]
    public class ModuleController : Controller
    {
        //
        // GET: /Module/
        public ActionResult ResourceBooking()
        {
            return View();
        }

        //
        // GET: /Module/
        [HttpGet]
        [ActionName("Badminton")]
        public ActionResult Badminton()
        {
            var resourceViewModel = new ResourceViewModel
            {
                Headers = new List<string>
                {
                    "5PM - 6PM",
                    "6PM - 7PM",
                    "7PM - 8PM",
                    "8PM - 9PM"
                },
                Rows = 3
            };
            return View(resourceViewModel);
        }

        [HttpPost]
        [ActionName("Badminton")]
        public ActionResult BadmintonPost(ResourceViewModel resources)
        {
            var resourceViewModel = new ResourceViewModel
            {
                Headers = new List<string>
                {
                    "5PM - 6PM",
                    "6PM - 7PM",
                    "7PM - 8PM",
                    "8PM - 9PM"
                },
                Rows = 3
            };
            return View(resourceViewModel);
        }

        public class Demo
        {
            public string Headers { get; set; }
            public string Rows { get; set; }
        }
        //
        // GET: /Module/
        public ActionResult Billiards()
        {
            var resourceViewModel = new ResourceViewModel
            {
                Headers = new List<string>
                {
                    "5PM - 6PM",
                    "6PM - 7PM",
                    "7PM - 8PM",
                    "8PM - 9PM"
                },
                Rows = 6
            };
            return View(resourceViewModel);
        }
	}
}
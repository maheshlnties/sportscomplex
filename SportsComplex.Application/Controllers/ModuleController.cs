using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using SportsComplex.Application.Filters;
using SportsComplex.Application.ViewModels;
using SportsComplex.DatabaseService.Interface;
using SportsComplex.Models;
using SportsComplex.Utilities;

namespace SportsComplex.Application.Controllers
{
    [UserAuthorize(Roles = "Admin , Employee")]
    public class ModuleController : Controller
    {
        private readonly IModuleService _moduleService;
        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

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
            var resource = _moduleService.GetBadmintonResource();
            var resourceViewModel = new ResourceViewModel
            {
                Headers = resource.Headers,
                Rows = resource.Rows,
                BookedList = resource.BookedList
            };
            return View(resourceViewModel);
        }

        [HttpPost]
        [ActionName("Badminton")]
        public ActionResult BadmintonPost(ResourceViewModel resource, string id)
        {
            var existingBookedList=_moduleService.GetBookedBadmintonList(DateTime.Today);
            resource.BookedList = existingBookedList ?? new List<BookingItem>();

            if (resource.BookedList.FirstOrDefault(x => x.Item == id) == null)
                resource.BookedList.Add(new BookingItem { Item = id, BookedBy = HttpContext.User.Identity.Name });

            var resourceModel = new Resource
            {
                Headers = resource.Headers,
                Rows = resource.Rows,
                BookedList = resource.BookedList,
                Date = DateTime.Today
            };
            if (_moduleService.BookBadmintonResource(resourceModel))
                EmailHandler.SendMail(new MailMessage("test@gmail.com", "maheshniec@gmail.com", "test", "hello test"));//TODO change template and TO address
            return View(resource);
        }

        [HttpGet]
        [ActionName("Billiards")]
        public ActionResult Billiards()
        {
            var resource = _moduleService.GetBilliardResource();
            var resourceViewModel = new ResourceViewModel
            {
                Headers = resource.Headers,
                Rows = resource.Rows,
                BookedList = resource.BookedList
            };
            return View(resourceViewModel);
        }

        [HttpPost]
        [ActionName("Billiards")]
        public ActionResult BilliardsPost(ResourceViewModel resource, string id)
        {
            var existingBookedList = _moduleService.GetBookedBilliardList(DateTime.Today);
            resource.BookedList = existingBookedList ?? new List<BookingItem>();

            if (resource.BookedList.FirstOrDefault(x => x.Item == id)==null)
                resource.BookedList.Add(new BookingItem { Item = id, BookedBy = HttpContext.User.Identity.Name });

            var resourceModel = new Resource
            {
                Headers = resource.Headers,
                Rows = resource.Rows,
                BookedList = resource.BookedList,
                Date = DateTime.Today
            };
            if(_moduleService.BookBilliardResource(resourceModel))
                EmailHandler.SendMail(new MailMessage("test@gmail.com", "maheshniec@gmail.com", "test", "hello test"));//TODO change template and TO address
            return View(resource);
        }
	}
}
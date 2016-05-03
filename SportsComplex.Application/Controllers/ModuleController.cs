using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class ModuleController : BaseController
    {
        #region Fields

        private readonly IModuleService _moduleService;

        #endregion

        #region Constructor

        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        #endregion

        #region Resource Booking

        public ActionResult ResourceBooking()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SelectEmployee(string psNumber)
        {
            if (string.IsNullOrWhiteSpace(psNumber))
            {
                return Json(false);
            }
            var result = _moduleService.IsUserExists(psNumber);
            return Json(result);
        }
        
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
            if (DateTime.Now.Hour < 16 || DateTime.Now.Hour > 21)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Booking can be done only between 4PM to 9PM");
            
            var psNumber = User.Role == UserRoles.Admin && !string.IsNullOrEmpty(resource.PsNumber)
               ? resource.PsNumber
               : User.PsNumber;

            var existingBookedList = _moduleService.GetBookedBadmintonList(DateTime.Today);
            resource.BookedList = existingBookedList;

            var userName = User.Role == UserRoles.Admin && !string.IsNullOrEmpty(resource.PsNumber)
                ? _moduleService.GetUserName(resource.PsNumber)
                : User.Name;

            if (resource.BookedList.FirstOrDefault(x => x.Item == id) == null)
                resource.BookedList.Add(new BookingItem { Item = id, BookedBy = psNumber, EmployeeName = userName });

            var resourceModel = new Resource
            {
                Headers = resource.Headers,
                Rows = resource.Rows,
                BookedList = resource.BookedList,
                Date = DateTime.Today
            };
            if (_moduleService.BookBadmintonResource(resourceModel))
            {
                var body = string.Format(EmailTemplates.ResourceBookingBody, id,Settings.BadmintonFee);
                EmailHandler.SendMail(new MailMessage(Settings.FromEmailId, User.Email, EmailTemplates.ResourceBookingSubject,body));

                var payrollbody = string.Format(EmailTemplates.PayrollResourceBookingBody, psNumber, "Badmiton" + id, Settings.BadmintonFee);
                EmailHandler.SendMail(new MailMessage(Settings.FromEmailId, Settings.PayrollEmailId, EmailTemplates.ResourceBookingSubject, payrollbody));
            }
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
            if (DateTime.Now.Hour < 16 || DateTime.Now.Hour > 21)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Booking can be done only between 4PM to 9PM");

            var psNumber = User.Role == UserRoles.Admin && !string.IsNullOrEmpty(resource.PsNumber)
                ? resource.PsNumber
                : User.PsNumber;

            var existingBookedList = _moduleService.GetBookedBilliardList(DateTime.Today);
            resource.BookedList = existingBookedList;

            var userName = User.Role == UserRoles.Admin && !string.IsNullOrEmpty(resource.PsNumber)
                ? _moduleService.GetUserName(resource.PsNumber)
                : User.Name;

            if (resource.BookedList.FirstOrDefault(x => x.Item == id) == null)
                resource.BookedList.Add(new BookingItem { Item = id, BookedBy = psNumber,EmployeeName=userName });

            var resourceModel = new Resource
            {
                Headers = resource.Headers,
                Rows = resource.Rows,
                BookedList = resource.BookedList,
                Date = DateTime.Today
            };
            if (_moduleService.BookBilliardResource(resourceModel))
            {
                var body = string.Format(EmailTemplates.ResourceBookingBody, id,Settings.BilliardFee);
                EmailHandler.SendMail(new MailMessage(Settings.FromEmailId, User.Email, EmailTemplates.ResourceBookingSubject, body));


                var payrollbody = string.Format(EmailTemplates.PayrollResourceBookingBody, psNumber, "Billiard" + id, Settings.BilliardFee);
                EmailHandler.SendMail(new MailMessage(Settings.FromEmailId, Settings.PayrollEmailId, EmailTemplates.ResourceBookingSubject, payrollbody));
            }
            return View(resource);
        }

        #endregion

        #region Gallery

        [HttpGet]
        public ActionResult Gallery()
        {
            var images = _moduleService.GetGalleryImages();
            var imageViewModels = images.Select(eachImages => new ImageViewModel
            {
                Id = eachImages.Id,
                Name = eachImages.Name,
                EncodedImage = eachImages.EncodedImage,
                UploadedOn = eachImages.UploadedOn
            }).ToList();

            return View(imageViewModels);
        }

        [HttpGet]
        public ActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImageMethod()
        {
            var result = false;
            if (Request.Files.Count != 0)
            {
                var images = new List<Image>();
                for (var i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];
                    if (file == null) continue;
                    images.Add(new Image
                    {
                        Name = file.FileName,
                        EncodedImage =
                            string.Concat(Constants.Base64Extender, StreamHelper.ToBase64String(file.InputStream)),
                        UploadedOn = DateTime.Now.ToShortDateString()
                    });
                }
                result = _moduleService.UploadImages(images);
            }
            return Content(result ? "success" : "failed");
        }

        [ActionName("Gallery")]
        [HttpDelete]
        public ActionResult DeleteImage(List<string> selectedList)
        {
            var result = false;
            if (selectedList != null)
            {
                result = _moduleService.DeleteImages(selectedList);
            }
            var images = _moduleService.GetGalleryImages();
            var imageViewModels = images.Select(eachImages => new ImageViewModel
            {
                Id = eachImages.Id,
                Name = eachImages.Name,
                EncodedImage = eachImages.EncodedImage,
                UploadedOn = eachImages.UploadedOn
            }).ToList();
            return View(imageViewModels);
        }

        #endregion

        #region Gym

        [HttpGet]
        public ActionResult Gym()
        {
            return View(GetGymDetails());
        }
        
        [ActionName("Gym")]
        [HttpPut]
        public ActionResult GymLeave(string id)
        {
            var result = _moduleService.LeaveGym(id);
            if (result)
            {
                EmailHandler.SendMail(new MailMessage(Settings.FromEmailId, User.Email, EmailTemplates.GymLeavingSubject, EmailTemplates.GymLeavingBody));

                var payrollBody = string.Format(EmailTemplates.PayrollGymLeavingBody, User.PsNumber,Settings.GymFee);
                EmailHandler.SendMail(new MailMessage(Settings.FromEmailId, Settings.PayrollEmailId, EmailTemplates.GymLeavingSubject, payrollBody));
            }
            return View(GetGymDetails());
        }

        [ActionName("Gym")]
        [HttpPost]
        public JsonResult GymJoin(string psNumber)
        {
            var bookingForOthers = User.Role == UserRoles.Admin && !string.IsNullOrEmpty(psNumber);
            var userPsNumber = bookingForOthers
              ? psNumber
              : User.PsNumber;

            if (bookingForOthers)
            {
                var gymDetails = _moduleService.GetGymDetails(userPsNumber);
                if (gymDetails!=null)
                {
                    return Json(string.Format("User with PS Number {0} already joined for gym", userPsNumber));
                }
            }

            var gym = new Gym
            {
                Joined = true,
                PsNumber = userPsNumber,
                JoinedOn = DateTime.Now,
                TransactionDate = DateTime.Now
            };
            var result = _moduleService.JoinGym(gym);
            if (result)
            {
                var body = string.Format(EmailTemplates.GymJoiningBody, Settings.GymFee);
                EmailHandler.SendMail(new MailMessage(Settings.FromEmailId, User.Email, EmailTemplates.GymJoiningSubject, body));
                
                var payrollbody= string.Format(EmailTemplates.PayrollGymJoiningBody, psNumber,Settings.GymFee);
                EmailHandler.SendMail(new MailMessage(Settings.FromEmailId, Settings.PayrollEmailId, EmailTemplates.GymJoiningSubject, payrollbody));
            }
            return Json(null);
        }

        #endregion

        #region Private Methods
        private GymViewModel GetGymDetails()
        {
            var principal = (PrincipalModel) User;
            var gym = _moduleService.GetGymDetails(principal.PsNumber);
            var gymViewModel = new GymViewModel();
            if (gym == null)
            {
                gymViewModel.Joined = false;
            }
            else
            {
                gymViewModel.Joined = true;
                gymViewModel.Id = gym.Id;
            }
            return gymViewModel;
        }

        #endregion
    }
}
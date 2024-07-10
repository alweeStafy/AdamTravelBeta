using adamtravelNet.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace adamtravelNet.Controllers
{
    //[Route("api/[controller]")]
    public class AdamTravelController : Controller
    {
        /*private readonly ILogger<AdamTravelController> _logger;*/
        private readonly IStringLocalizer<AdamTravelController> _localization;

        public AdamTravelController(IStringLocalizer<AdamTravelController> localization)
        {
            _localization = localization;
        }

        [HttpGet]
        public string Get()
        {
            return _localization["localization"];
        }

        [HttpPost]
        public IActionResult CultureManagement(string culture,string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires =  DateTimeOffset.Now.AddDays(30) });

            return LocalRedirect(returnUrl);
        }
        /*public AdamTravelController(ILogger<AdamTravelController> logger, IStringLocalizer<AdamTravelController> localization)
        {
            _logger = logger;
            _localization = localization;
        }*/

        //Localizer for view
        public IActionResult Index()
        {
            var localizerTitle = _localization["Title"];
                        
            return View();
         
        }
        
        public IActionResult Details() 
        {
            return Content("Policy details");
        }
        public IActionResult ShowDetails1(int id) 
        {
            return Content($"{id} details1");
        }
        public IActionResult Privacy()
        {
            var c1 = new Booking();

            c1.Id = 1;

            c1.Name = "Hot seasun Package";

            c1.Date = 2;

            var c2 = new Booking();

            c2.Id = 2;

            c2.Name = "Cool seasun Package";

            c2.Date = 3;

            var c3 = new Booking();

            c3.Id = 3;

            c3.Name = "Low season Package";

            c3.Date = 4;

            List<Booking> allBookings = new List<Booking>();
            allBookings.Add(c1);
            allBookings.Add(c2);
            allBookings.Add(c3);

            return View(allBookings);
        }
    }
}

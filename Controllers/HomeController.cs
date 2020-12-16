using System;
using Microsoft.AspNetCore.Mvc;

namespace Cors.Demo.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult Index()
        {
            var currentDate = DateTime.Now;
            var timeUntilNewYear = new DateTime(currentDate.Year + 1, 1, 1) - currentDate;
            return Json(new { CurrentYear = currentDate.Year,
                TimeUntilNewYear = new { Days = timeUntilNewYear.Days, Hours = timeUntilNewYear.Hours,
                    Minutes = timeUntilNewYear.Minutes, Seconds = timeUntilNewYear.Seconds } });
        }
    }
}

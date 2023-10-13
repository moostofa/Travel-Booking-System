using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Travel_Booking_System
{
    public class BookingController : Controller
    {
        // GET: /Booking
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Booking/Airfare
        public IActionResult Airfare()
        {
            return View();
        }

        // GET: /Booking/Hotel
        public IActionResult Hotel()
        {
            return View();
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playstore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            //if user==null redirect to login page or smth
            return View();
        }

        public IActionResult Register()
        {
            //if user!=null redirect to index
            return View();
        }
       
        public IActionResult Login()
        {
            //if user!=null redirect to index
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}

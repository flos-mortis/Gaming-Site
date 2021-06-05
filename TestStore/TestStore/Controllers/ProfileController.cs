using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestStore.Models;
using TestStore.ViewModels;
using System.Security.Claims;
using System.IO;
using System.Web;

namespace TestStore.Controllers
{
    public class ProfileController : Controller
    {
        ApplicationContext db;
        UserManager<User> userManager;
        public ProfileController(ApplicationContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            User user = await userManager.GetUserAsync(User);
            return View(user);
        }
        public IActionResult AllReviews()
        {
            List<Article> articles = db.Articles.Where(x => x.Author.UserName == User.Identity.Name).ToList();
            return View(articles);
        }
        public IActionResult Edit()
        {           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.GetUserAsync(User);
                if (user != null)
                {
                    user.About = model.About;
                    user.Country = model.Country;
                    user.UserName = model.UserName;
                    user.Year = model.Year;                    
                    user.Email = model.Email;                  

                    if(model.Picture != null)
                    {
                        if(model.Picture.Length > 0)
                        {
                            byte[] pic = null;
                            using (var fs = model.Picture.OpenReadStream()) 
                            using (var ms = new MemoryStream())
                            {
                                fs.CopyTo(ms);
                                pic = ms.ToArray();
                            }
                            user.Picture = pic;
                            model.OldPicture = pic;
                        }
                    }
                    var result = await userManager.UpdateAsync(user);
                    if(result.Succeeded)
                        return RedirectToAction("Index");
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }
    }
}

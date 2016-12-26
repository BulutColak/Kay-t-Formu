using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Uygulama.Models;

namespace Uygulama.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult RegistrationForm()
        {
            return View(new User());
        }
        [HttpPost]
        public ActionResult RegistrationForm(User user)
        {
            if (user.Gender.ToLower() != "erkek" && user.Gender.ToLower() != "kadın")
            {
                ModelState.AddModelError("Gender", "Erkek ya da kadın yazmalısınız!");
            }
            if (ModelState.IsValid)
            {
                if (HttpRuntime.Cache["UserList"] == null)
                {
                    List<User> Users = new List<User>();
                    User newUser = new User();
                    newUser.Name = user.Name;
                    newUser.Surname = user.Surname;
                    newUser.Email = user.Email;
                    newUser.Phone = user.Phone;
                    newUser.Age = user.Age;
                    newUser.Gender = user.Gender;
                    Users.Add(newUser);
                    HttpRuntime.Cache["UserList"] = Users;
                }
                else
                {
                    List<User> Users = (List<User>) HttpRuntime.Cache["UserList"];
                    User newUser = new User();
                    newUser.Name = user.Name;
                    newUser.Surname = user.Surname;
                    newUser.Email = user.Email;
                    newUser.Phone = user.Phone;
                    newUser.Age = user.Age;
                    newUser.Gender = user.Gender;
                    Users.Add(newUser);
                    HttpRuntime.Cache["UserList"] = Users;
                }
            }
            return View(user);
        }
        public ActionResult List()
        {
            var model = (List<User>)HttpRuntime.Cache["UserList"];
            return View(model);
        }
    }
}
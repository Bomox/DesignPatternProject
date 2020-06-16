using Project.Models;
using Project.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories;
using DataAccess;
using Repositories.Helpers;

namespace Project.Controllers
{
    
    public class UserController : Controller
    {
        UserRepository user = new UserRepository();
        

        public ActionResult Registration()
        {          
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationViewModel CreatedUser)
        {
            if (ModelState.IsValid)
            {
                User ExistingUser = user.GetUserByUsername(CreatedUser.Username);
                if (ExistingUser != null)
                {
                    ModelState.AddModelError("", "Invalid username and/or password");
                    return RedirectToAction("Registration");
                }

                User NewUser = new User();
                NewUser.Username = CreatedUser.Username;
                if(CreatedUser.Username == "Bomox")
                {
                    NewUser.IsAdministrator = true;
                }
                else
                {
                    NewUser.IsAdministrator = false;
                }
                            

                user.RegisterUser(NewUser, CreatedUser.Password);

                TempData["Registration"] = "User was registrated successfully";
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Registration");
            }
        }

        public ActionResult Login()
        {
            ViewBag.Messagea = TempData["Registration"];
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel ReturnedUser)
        {
            if (ModelState.IsValid)
            {
                User ExistingUser = user.GetUserByNameAndPassword(ReturnedUser.Username, ReturnedUser.Password);
                bool UserExists = ExistingUser != null;
                if (UserExists)
                {
                    LoginUserSession.Current.SetCurrentUser(ExistingUser.ID, ExistingUser.Username, ExistingUser.IsAdministrator);
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username and/or password");
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            LoginUserSession.Current.Logout();
            return RedirectToAction("Login");
        }
        [CustomAuthorize]
        public ActionResult Users()
        {    
            return View(user.GetAll());
        }

        public ActionResult Delete(int? id)
        {
            User userdelete = user.GetByID(id);
            return View(userdelete);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            user.DeleteByID(id);
            return RedirectToAction("Users");
        }

        public ActionResult Edit(int? id)
        {
            TempData["userid"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(RegistrationViewModel ReturnedUser)
        {
            User Compare = user.GetByID((int)TempData["userid"]);
            int IDData = Compare.ID;
            string UsernameData = Compare.Username;
            string SaltData = Compare.PasswordSalt;
            string HashData = Compare.PasswordHash;

            User CreatedUser = new User()
            {
                ID = IDData,
                Username = UsernameData,
                PasswordSalt = SaltData,
                PasswordHash = HashData,
                IsAdministrator = ReturnedUser.IsAdministrator
            };

            user.Save(CreatedUser);
            return RedirectToAction("Users");

        }

        public ActionResult ClearDatabase()
        {
            WarframeRepository warframe = WarframeRepository.getMethodTwo();
            WeaponRepository weapon = WeaponRepository.getMethodTwo();
            Mediator mediator = new Mediator(warframe, weapon);
            mediator.ClearDatabase();
            return RedirectToAction("Users");
        }

    }
}
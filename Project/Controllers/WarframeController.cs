using System;
using Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using DataAccess;
using Project.Helpers;

namespace Project.Controllers
{
    [LoginAttribure]
    public class WarframeController : Controller
    {
        public static WarframeRepository warframe = WarframeRepository.getMethod();        

        public ActionResult Warframes()
        {         
            return View(warframe.GetAll());
        }


        public ActionResult Create()
        {
            return View();            
        }

        [HttpPost]
        public ActionResult Create(WarframeViewModel ReturnedWarframe)
        {
            Warframe CreatedWarframe = new Warframe()
            {
                ID = ReturnedWarframe.ID,
                Name = ReturnedWarframe.Name,
                Health = ReturnedWarframe.Health,
                Energy = ReturnedWarframe.Energy,
                Armor = ReturnedWarframe.Armor,
            };
            warframe.Create(CreatedWarframe);
            return RedirectToAction("Warframes");
        }

        public ActionResult Details(int? id)
        {
            return View(warframe.GetByID(id));
        }

        public ActionResult Delete(int? id)
        {
            Warframe warframedelete = warframe.GetByID(id);
            return View(warframedelete);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            warframe.DeleteByID(id);
            return RedirectToAction("Warframes");
        }
        public ActionResult Edit(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(WarframeViewModel ReturnedWarframe)
        {
            Warframe CreatedWarframe = new Warframe()
            {
                ID = ReturnedWarframe.ID,
                Name = ReturnedWarframe.Name,
                Health = ReturnedWarframe.Health,
                Energy = ReturnedWarframe.Energy,
                Armor = ReturnedWarframe.Armor,
            };
            warframe.Save(CreatedWarframe);
            return RedirectToAction("Warframes");

        }
    }
}
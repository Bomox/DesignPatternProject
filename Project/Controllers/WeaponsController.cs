using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using Project.Helpers;
using Project.Models;
using Repositories;

namespace Project.Controllers
{
    [LoginAttribure]
    public class WeaponsController : Controller
    {
        public static WeaponRepository weapon = WeaponRepository.getMethod();
        WeaponDecorator decoratedweapon = new WeaponDecorator(weapon);
         
        public ActionResult Weapons()
        {
            return View(weapon.GetAll());           
        }

        public ActionResult GetAbove50()
        {
            return View(decoratedweapon.GetAllAbove50());
        }

 
        public ActionResult Details(int? id)
        {
            Weapon weapondetails = weapon.GetByID(id);
            return View(weapondetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(WeaponViewModel ReturnedWeapon)
        {
            Weapon CreatedWeapon = new Weapon()
            {
                ID = ReturnedWeapon.ID,
                Name = ReturnedWeapon.Name,
                Damage = ReturnedWeapon.Damage,
                Magazine = ReturnedWeapon.Magazine,
                Critical = ReturnedWeapon.Critical,
                Status = ReturnedWeapon.Status
            };
            weapon.Create(CreatedWeapon);            
            return RedirectToAction("Weapons");
        }

        public ActionResult Delete(int? id)
        {
            Weapon weapondelete = weapon.GetByID(id);
            return View(weapondelete);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            weapon.DeleteByID(id);
            return RedirectToAction("Weapons");
        }

         public ActionResult Edit(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(WeaponViewModel ReturnedWeapon)
        {
            Weapon CreatedWeapon = new Weapon()
            {
                ID = ReturnedWeapon.ID,
                Name = ReturnedWeapon.Name,
                Damage = ReturnedWeapon.Damage,
                Magazine = ReturnedWeapon.Magazine,
                Critical = ReturnedWeapon.Critical,
                Status = ReturnedWeapon.Status
            };
            weapon.Save(CreatedWeapon);
            return RedirectToAction("Weapons");

        }

        public ActionResult Search()
        {
            return View();
        }
    }
}

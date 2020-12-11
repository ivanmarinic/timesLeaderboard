using borealisMVC.Data;
using borealisMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace borealisMVC.Controllers
{
    public class TimeController : Controller
    {
        private readonly borealisMVCContext db;

        public TimeController(borealisMVCContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Time> objList = (from t in db.Times
                                         where t.Approved == true
                                         select t);

            var sortedObjList = objList.OrderBy(t => t.TimeValue);

            return View(sortedObjList);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            IEnumerable<Time> objList = (from t in db.Times
                                         where t.Approved == false
                                         select t);

            var sortedObjList = objList.OrderBy(t => t.TimeValue);

            return View(sortedObjList);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Approve(int id)
        {
            var obj = db.Times.Find(id);

            obj.Approved = true;

            if (obj == null)
            {
                return NotFound();
            }
            db.Times.Update(obj);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Time obj)
        {
            if (ModelState.IsValid)
            {
                db.Times.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = db.Times.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            //return View(obj);

            return PartialView("_TimeDeletePartial", obj);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? timeId)
        {
            var obj = db.Times.Find(timeId);
            if (obj == null)
            {
                return NotFound();
            }
            db.Times.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

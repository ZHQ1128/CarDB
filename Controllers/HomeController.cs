using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarAssignmentDB.Models;

namespace CarAssignmentDB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(Helpers.CarHelper.GetCars());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View(Helpers.CarHelper.GetCarById(id));
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Car car)
        {
            try
            {
                Helpers.CarHelper.CreateCar(car);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Helpers.CarHelper.GetCarById(id));
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Car car)
        {
            try
            {
                // TODO: Add update logic here
                Helpers.CarHelper.EditCar(car);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            Helpers.CarHelper.DeleteCar(id);
            return RedirectToAction("Index");
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Helpers.CarHelper.DeleteCar(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarAssignmentDB.Models;

namespace CarAssignmentDB.Helpers
{
    public class CarHelper
    {
        public static List<Car> GetCars()
        {
            var CarsDB = DBHelper.GetDB(); // Is carsDB a list?
            return CarsDB;
        }

        public static Car GetCarById(int id)
        {
            var CarsDB = DBHelper.GetDB();
            Car targetCar = CarsDB.Where(c => c.Id == id).FirstOrDefault();
            return targetCar;
        }

            //why can't I use ( int id)?
            // why do we need ToList()?
        public static void CreateCar(Car newCar)
        {
            var CarsDB = DBHelper.GetDB();
            List<Car> carsOrderedById = CarsDB.OrderByDescending(c => c.Id).ToList();


            int latestId = 0;
            if (carsOrderedById.Count != 0)
            {
                latestId = carsOrderedById.FirstOrDefault().Id;
            }
            newCar.Id = latestId + 1;

            CarsDB.Add(newCar);

            DBHelper.SaveDB(CarsDB);
        }

        public static void EditCar(Car car)
        {
            var CarsDB = DBHelper.GetDB();
            Car toUpdate = CarsDB.Where(s => s.Id == car.Id).FirstOrDefault();
            toUpdate.Name = car.Name;
            toUpdate.Model = car.Model;
            toUpdate.Year = car.Year;
            toUpdate.ImgUrl = car.ImgUrl;
            DBHelper.SaveDB(CarsDB);
        }
        public static void DeleteCar(int id)
        {
            var CarsDB = DBHelper.GetDB();
            Car targetCar = CarsDB.Where(c => c.Id == id).FirstOrDefault();
            CarsDB.Remove(targetCar);
            DBHelper.SaveDB(CarsDB);
        }



    }
}
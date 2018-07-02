using CarAssignmentDB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CarAssignmentDB.Helpers
{
    public class DBHelper
    {
        public static void SaveDB(List<Car> cars)
        {
            string FileLocation = ConfigurationManager.AppSettings["DBLocation"];
            string json = JsonConvert.SerializeObject(cars);
            System.IO.File.WriteAllText(FileLocation, json);

        }

        public static List<Car> GetDB()
        {
            string FileLocation = ConfigurationManager.AppSettings["DBLocation"];
            // string FileLocation = HttpRuntime.AppDomainAppPath + @"\App_Data\db.json";
            if (System.IO.File.Exists(FileLocation))
            {
                string json = System.IO.File.ReadAllText(FileLocation);
                List<Car> carsDB = JsonConvert.DeserializeObject<List<Car>>(json);
                return carsDB;
            }
            else
            {
                List<Car> carsDB = new List<Car>
                {
                    new Car { Id = 1, Name = "Volvo", Model = "V60", Year = 2015,ImgUrl = "https://www.bmw.com/content/dam/bmw/common/all-models/4-series/gran-coupe/2017/navigation/BMW-4-Series-Gran-Coupe-ModelCard.png" }};
                return carsDB;

            }
        }
    }
}
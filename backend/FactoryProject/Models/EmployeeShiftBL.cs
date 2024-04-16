using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryProject.Models
{
    public class EmployeeShiftBL
    {
        FactoryProjectEntities db = new FactoryProjectEntities();

        public List<EmployeeShift> getAllEmployeeShift()
        {
            return db.EmployeeShift.ToList();
        }
        public EmployeeShift getEmployeeShift(int id)
        {
            return db.EmployeeShift.Where(x => x.EmployeeID == id).First();
        }

        public void AddEmployeeShift(EmployeeShift EmployeeShift)
        {
            db.EmployeeShift.Add(EmployeeShift);
            db.SaveChanges();
            
        }
        public void RemoveEmployeeShift(int id)
        {
            var results = db.EmployeeShift.Where(x => x.EmployeeID == id).ToList();

            foreach (var result in results)
            {
                db.EmployeeShift.Remove(result);
            }

            db.SaveChanges();


        }
    }
}
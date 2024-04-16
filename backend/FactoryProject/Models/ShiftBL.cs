using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryProject.Models
{
    public class ShiftBL
    {
        FactoryProjectEntities db = new FactoryProjectEntities();

        public List<Shift> getAllShifts()
        {
            return db.Shift.ToList();
        }
        public Shift getShift(int id)
        {
            return db.Shift.Where(x => x.ID == id).First();
        }

        public string addShift(Shift shift)
        {
            db.Shift.Add(shift);
            db.SaveChanges();
            return "Shift added";
        }
        
    }
}
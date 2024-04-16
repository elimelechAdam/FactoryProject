using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryProject.Models
{
    public class DepartmentBL
    {
        FactoryProjectEntities db = new FactoryProjectEntities();

        public List<Department> getAllDepartments()
        {
            return db.Department.ToList();
        }
        public Department getDepartment(int id)
        {
            return db.Department.Where(x => x.ID == id).First();
        }

        public string AddDepartment(Department department)
        {
            db.Department.Add(department);
            db.SaveChanges();
            return "Department added";
        }
        public string UpdateDepartment(int id,Department department)
        {
            var result = db.Department.Where(x=> x.ID == id).First();
            result.Manager = department.Manager;
            result.Name = department.Name;
            db.SaveChanges();
            return "Department updated";
        }
        public string RemoveDepartment(int id)
        {
            var result = db.Department.Where(x => x.ID == id).First();
            db.Department.Remove(result);
            db.SaveChanges();
            return "Department removed";
        }
    }
}
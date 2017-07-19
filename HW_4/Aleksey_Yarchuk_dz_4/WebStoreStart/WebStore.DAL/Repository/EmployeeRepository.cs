using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.DAL.Interface;
using WebStore.Domain.Entities;



namespace WebStore.DAL.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        WebStoreContext db;
        public EmployeeRepository()
        {
            this.db = new WebStoreContext();
        }
        public IList<Employee> GetList()
        {
            return db.Employees.ToList();
        }

        public void Create(Employee item)
        {
            db.Employees.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Employee emp = db.Employees.FirstOrDefault(empl => empl.Id == id);
            if (emp != null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
            }

        }

        public Employee GetItem(int id)
        {
            var emp = db.Employees.FirstOrDefault(empl => empl.Id == id);
            if (emp != null)
            {
                return emp;
            }
            return null;
        }
            
        public void Update(Employee emp)
        {
            var employee = db.Employees.FirstOrDefault(empl => empl.Id == emp.Id);
            bool isModified = false;

            if (employee.FirstName != emp.FirstName)
            {
                employee.FirstName = emp.FirstName;
                isModified = true;
            }               

            if (employee.LastName != emp.LastName)
            {
                employee.LastName = emp.LastName;
                isModified = true;
            }
               

            if (employee.Partonymic != emp.Partonymic)
            {
                employee.Partonymic = emp.Partonymic;
                isModified = true;
            }
               

            if (employee.Age != emp.Age)
            {
                employee.Age = emp.Age;
                isModified = true;
            }
                

            if (employee.DateofBirth != emp.DateofBirth)
            {
                employee.DateofBirth = emp.DateofBirth;
                isModified = true;
            }
                

            if (employee.PositionId != emp.PositionId)
            {
                var employeeTmp = db.Positions.FirstOrDefault(id => id.Id == emp.PositionId);
                if (employeeTmp != null)
                {
                    employee.PositionId = emp.PositionId;
                    isModified = true;
                }
            }

            if (isModified)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
            }
                         
        }

        public string GetPosition(int id)
        {
            return db.Positions.FirstOrDefault(i => i.Id == id).Name;
        }

        public int GetPositionIdForPositionName(string name)
        {
            return db.Positions.FirstOrDefault(nam => nam.Name == name).Id;
        }
    }
}

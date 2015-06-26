using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DatabaseContext())
            {
                var employee = new Employee() {Name = "Quan", Address = "Ha Noi"};
                db.Employees.Add(employee);
                db.SaveChanges();
            } ;

        }
    }
}

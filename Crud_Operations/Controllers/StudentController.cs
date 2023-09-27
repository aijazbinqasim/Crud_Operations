using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud_Operations.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Operations.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _Db;

        public StudentController(StudentContext db)
        {
            _Db = db;
        }
    
        public IActionResult StudentList()
        {
            try
            {
                var stdList = from a in _Db.tbl_Student
                              join b in _Db.tbl_Departments
                              on a.DeptID equals b.ID
                              into Dep
                              from b in Dep.DefaultIfEmpty()

                              select new Student
                              {
                                  ID = a.ID,
                                  Name = a.Name,
                                  Fname = a.Fname,
                                  Mobile = a.Mobile,
                                  Email = a.Email,
                                  Description = a.Description,
                                  DeptID = a.DeptID,
                                  Department = b == null ? string.Empty : b.Department,
                              };

                return View(stdList);
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
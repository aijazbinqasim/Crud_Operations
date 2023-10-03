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



        public IActionResult Create()
        {
            loadDDL();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.ID == 0)
                    {
                        _Db.tbl_Student.Add(obj);
                        await _Db.SaveChangesAsync();
                    }

                    return RedirectToAction("StudentList");
                }
                return View();

            }
            catch (Exception)
            {
                return RedirectToAction("StudentList");
            }
        }


        private void loadDDL()
        {
            try
            {
                List<Departments> depList = new List<Departments>();
                depList = _Db.tbl_Departments.ToList();
                depList.Insert(0, new Departments { ID = 0, Department = "Please Select" });

                ViewBag.DepList = depList;
            }
            catch (Exception)
            {

            }
        }
    }
}
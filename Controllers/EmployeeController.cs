using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JasperGreen18.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace JasperGreen18.Controllers
{
    public class EmployeeController : Controller
    {
        private JasperGreenContext Context { get; set; }

        public EmployeeController(JasperGreenContext ctx)
        {
            Context = ctx; 
        }

        // Attribute Routing
        [Route("/Employees")]
        public ViewResult List()
        {
            List<Employee> employeeList = Context.Employees.ToList();

            EmployeeListViewModel listViewModel = new EmployeeListViewModel
            {
                Employees = employeeList
            };

            return View(listViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            EmployeeViewModel model = new EmployeeViewModel
            {
                CurrentEmployee = new Employee(),
                Action = "Add"
            };

            model.CurrentEmployee.HireDate = DateTime.Today;

            return View("AddEdit", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            EmployeeViewModel model = new EmployeeViewModel
            {
                Action = "Edit",
                CurrentEmployee = Context.Employees.Find(id)
            };

            return View("AddEdit", model);
        }

        [HttpPost]
        public IActionResult Save(Employee CurrentEmployee)
        {
            EmployeeViewModel model = new EmployeeViewModel();

            if (ModelState.IsValid)
            { 
                if (CurrentEmployee.EmployeeID == 0)
                {
                    
                    Context.Employees.Add(CurrentEmployee);
                }
                else
                {
                    Context.Employees.Update(CurrentEmployee);
                }
                    Context.SaveChanges();

                return RedirectToAction("List");
            }
            else
            {
                if (CurrentEmployee.EmployeeID == 0)
                {
                    model.Action = "Add";
                }
                else
                {
                    model.Action = "Edit";
                }

                model.CurrentEmployee = CurrentEmployee;

                return View("AddEdit", model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            EmployeeViewModel model = new EmployeeViewModel
            {
                Action = "Delete",
                CurrentEmployee = Context.Employees.Find(id)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Employee CurrentEmployee)
        {
            Context.Employees.Remove(CurrentEmployee);
            Context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
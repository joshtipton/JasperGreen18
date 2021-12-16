using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JasperGreen18.Models;
using Microsoft.EntityFrameworkCore;
using System;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JasperGreen18.Controllers
{
    public class CustomerController : Controller
    {
        private JasperGreenContext Context { get; set; }

        public CustomerController(JasperGreenContext ctx)
        {
            Context = ctx;
        }

        // Attribute Routing
        [Route("/Customers")]
        public ViewResult List()
        {
            List<Customer> customerList = Context.Customers.Include(c => c.CustomerProperties).ToList();

            CustomerListViewModel listViewModel = new CustomerListViewModel
            {
                Customers = customerList
            };

            foreach (Customer customer in listViewModel.Customers)
            {
                customer.CustomerPhone = $"{long.Parse(customer.CustomerPhone):(###)-###-####}";
            }

            return View(listViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CustomerViewModel model = new CustomerViewModel
            {
                CurrentCustomer = new Customer(),
                Action = "Add",
                GetStates = Context.States.OrderBy(s => s.Name).ToList()
            };

            return View("AddEdit", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CustomerViewModel model = new CustomerViewModel
            {
                Action = "Edit",
                CurrentCustomer = Context.Customers.Find(id),
                GetStates = Context.States.OrderBy(s => s.Name).ToList()
            };

            return View("AddEdit", model);
        }

        [HttpPost]
        public IActionResult Save(Customer CurrentCustomer)
        {
            CustomerViewModel model = new CustomerViewModel
            {
                CurrentCustomer = CurrentCustomer,
                GetStates = Context.States.OrderBy(s => s.Name).ToList()
            };

            if (ModelState.IsValid)
            {
                if (CurrentCustomer.CustomerID == 0)
                {
                    Context.Customers.Add(CurrentCustomer);

                    // Store the name of the added product
                    TempData["CustomerName"] = CurrentCustomer.CustomerFullName;
                    // Store the message 
                    TempData["AddMessage"] = $"The customer {TempData["CustomerName"]} has been added successfully.";
                }
                else
                {
                    Context.Customers.Update(CurrentCustomer);
                    TempData["CustomerName"] = CurrentCustomer.CustomerFullName;
                    TempData["EditMessage"] = $"The customer {TempData["CustomerName"]} has been updated successfully.";
                }

                Context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                
                if (CurrentCustomer.CustomerID == 0)
                {
                    model.Action = "Add";
                }
                else
                {
                    model.Action = "Edit";
                }

                model.CurrentCustomer = CurrentCustomer;

                return View("AddEdit", model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CustomerViewModel model = new CustomerViewModel
            {
                Action = "Delete",
                CurrentCustomer = Context.Customers.Find(id),
                GetStates = Context.States.OrderBy(s => s.Name).ToList()
            };

            TempData["CustomerName"] = model.CurrentCustomer.CustomerFullName;
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Customer CurrentCustomer)
        {
            Context.Customers.Remove(CurrentCustomer);

            TempData["DeleteMessage"] = $"The customer {TempData["CustomerName"]} has been removed successfully.";

            Context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
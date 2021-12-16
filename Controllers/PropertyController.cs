using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JasperGreen18.Models;
using Microsoft.EntityFrameworkCore;
using System;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JasperGreen18.Controllers
{
    public class PropertyController : Controller
    {
        private JasperGreenContext Context { get; set; }

        public PropertyController(JasperGreenContext ctx)
        {
            Context = ctx;
        }


        // Attribute Routing
        [Route("/Properties")]
        public ViewResult List()
        {
            List<Property> PropertyList = Context.Properties.Include(p => p.PropertyOwner).ToList();

            foreach (Property property in PropertyList)
            {
                property.PropertyOwner = Context.Customers.Find(property.CustomerID);
            }

            PropertyListViewModel listViewModel = new PropertyListViewModel
            {
                Properties = PropertyList
            };

            return View(listViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            PropertyViewModel model = new PropertyViewModel
            {
                CurrentProperty = new Property(),
                GetCustomers = Context.Customers.ToList(),
                Action = "Add"
            };

            return View("AddEdit", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PropertyViewModel model = new PropertyViewModel
            {
                Action = "Edit",
                GetCustomers = Context.Customers.ToList(),
                CurrentProperty = Context.Properties.Find(id)
            };

            return View("AddEdit", model);
        }

        [HttpPost]
        public IActionResult Save(Property CurrentProperty)
        {
            PropertyViewModel model = new PropertyViewModel();

            if (ModelState.IsValid)
            {
                Console.WriteLine("Model State Is Valid!");
                if (CurrentProperty.PropertyID == 0)
                {
                    Context.Properties.Add(CurrentProperty);
                }
                else
                {
                    Context.Properties.Update(CurrentProperty);
                }

                Context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                if (CurrentProperty.PropertyID == 0)
                {
                    model.Action = "Add";
                }
                else
                {
                    model.Action = "Edit";
                }

                model.CurrentProperty = CurrentProperty;

                return View("AddEdit", model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            PropertyViewModel model = new PropertyViewModel
            {
                Action = "Delete",
                GetCustomers = Context.Customers.ToList(),
                CurrentProperty = Context.Properties.Find(id)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Property CurrentProperty)
        {
            Context.Properties.Remove(CurrentProperty);
            Context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
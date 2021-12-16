using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JasperGreen18.Models;
using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JasperGreen18.Controllers
{
    public class PaymentController : Controller
    {
        private JasperGreenContext Context { get; set; }


        public PaymentController(JasperGreenContext ctx)
        {
            Context = ctx;
        }

        public IActionResult FilterList(int SelectedCustomer, int SelectedProperty, int SelectedCrew)
        {
            string customerFilter = JsonConvert.SerializeObject(SelectedCustomer);
            HttpContext.Session.SetString("customerFilter", customerFilter);

            return RedirectToAction("List");

        }

        public int GetFilter()
        {
            string customerFilter = HttpContext.Session.GetString("customerFilter");

            int customerID = JsonConvert.DeserializeObject<int>(customerFilter);

            return customerID;
        }

        // Attribute Routing
        [Route("/Payments")]
        public ViewResult List()
        {
            List<Payment> PaymentList = Context.Payments.OrderBy(p => p.PaymentDate).ToList();

            PaymentListViewModel model = new PaymentListViewModel
            {
                Payments = Context.Payments.ToList(),
                Customers = Context.Customers.ToList()
            };

            foreach (Payment payment in PaymentList)
            {
                payment.CurrentCustomer = Context.Customers.Find(payment.CustomerID);

                // Workaround for when JSON value is null, requires longer loading time
                try
                {
                    if (payment.CustomerID == GetFilter())
                    {
                        model.CurrentCustomer = Context.Customers.Find(GetFilter());
                        model.Payments = Context.Payments.Where(m => m.CustomerID.Equals(GetFilter())).ToList();
                    }
                }

                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Data);
                }
                
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            PaymentViewModel model = new PaymentViewModel
            {
                CurrentPayment = new Payment(),
                Customers = Context.Customers.ToList(),
                Action = "Add"
            };

            model.CurrentPayment.PaymentDate = DateTime.Today;

            return View("AddEdit", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PaymentViewModel model = new PaymentViewModel
            {
                Action = "Edit",
                Customers = Context.Customers.ToList(),
                CurrentPayment = Context.Payments.Find(id)
            };

            return View("AddEdit", model);
        }

        [HttpPost]
        public IActionResult Save(Payment CurrentPayment)
        {
            PaymentViewModel model = new PaymentViewModel();

            if (ModelState.IsValid)
            {
                if (CurrentPayment.PaymentID == 0)
                {
                    Context.Payments.Add(CurrentPayment);
                }
                else
                {
                    Context.Payments.Update(CurrentPayment);
                }

                Context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                if (CurrentPayment.PaymentID == 0)
                {
                    model.Action = "Add";
                }
                else
                {
                    model.Action = "Edit";
                }

                model.CurrentPayment = CurrentPayment;

                return View("AddEdit", model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            PaymentViewModel model = new PaymentViewModel
            {
                Action = "Delete",
                Customers = Context.Customers.ToList(),
                CurrentPayment = Context.Payments.Find(id)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Payment CurrentPayment)
        {
            Context.Payments.Remove(CurrentPayment);
            Context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
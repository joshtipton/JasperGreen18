using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JasperGreen18.Models;
using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace JasperGreen18.Controllers
{
    public class ProvideServiceController : Controller
    {
        private JasperGreenContext Context { get; set; }


        public ProvideServiceController(JasperGreenContext ctx)
        {
            Context = ctx;
        }

        public IActionResult FilterList(int SelectedCustomer, int SelectedProperty, int SelectedCrew)
        {
            string customerFilter = JsonConvert.SerializeObject(SelectedCustomer);
            string propertyFilter = JsonConvert.SerializeObject(SelectedProperty);
            string crewFilter = JsonConvert.SerializeObject(SelectedCrew);


            HttpContext.Session.SetString("customerFilter", customerFilter);
            HttpContext.Session.SetString("propertyFilter", propertyFilter);
            HttpContext.Session.SetString("crewFilter", crewFilter);

            return RedirectToAction("List");

        }

        public int[] GetFilter()
        {
            string customerFilter = HttpContext.Session.GetString("customerFilter");
            string propertyFilter = HttpContext.Session.GetString("propertyFilter");
            string crewFilter = HttpContext.Session.GetString("crewFilter");


            int customerID = JsonConvert.DeserializeObject<int>(customerFilter);
            int propertyID = JsonConvert.DeserializeObject<int>(propertyFilter);
            int crewID = JsonConvert.DeserializeObject<int>(crewFilter);

            int[] filters = new int[] { customerID, propertyID, crewID };

            return filters;
        }

        // Attribute Routing
        [Route("/Services")]
        public ViewResult List()
        {
            List<ProvideService> ServiceList = Context.ProvideServices.ToList();

            ServiceListViewModel listViewModel = new ServiceListViewModel
            {
                Services = ServiceList,
                Customers = Context.Customers.ToList(),
                Properties = Context.Properties.ToList(),
                Crews = Context.Crews.ToList(),
            };


            foreach (ProvideService service in ServiceList)
            {
                try
                {
                    if (service.CustomerID == GetFilter()[0] || service.PropertyID == GetFilter()[1] || service.CrewID == GetFilter()[2])
                    {
                        listViewModel.CurrentCustomer = Context.Customers.Find(GetFilter()[0]);
                        listViewModel.CurrentProperty = Context.Properties.Find(GetFilter()[1]);
                        listViewModel.CurrentCrew = Context.Crews.Find(GetFilter()[2]);

                        // multiple filter check
                        // 3 filters
                        if (GetFilter()[0] != 0 && GetFilter()[1] != 0 && GetFilter()[2] != 0)
                        {
                            listViewModel.Services = Context.ProvideServices.Where(m => m.CustomerID.Equals(GetFilter()[0]) && m.PropertyID.Equals(GetFilter()[1]) && m.CrewID.Equals(GetFilter()[2])).ToList();
                        }

                        // 2 filters - customer and property
                        else if (GetFilter()[0] != 0 && GetFilter()[1] != 0)
                        {
                            listViewModel.Services = Context.ProvideServices.Where(m => m.CustomerID.Equals(GetFilter()[0]) && m.PropertyID.Equals(GetFilter()[1])).ToList();
                        }
                        // 2 filters - customer and crew
                        else if (GetFilter()[0] != 0 && GetFilter()[2] != 0)
                        {
                            listViewModel.Services = Context.ProvideServices.Where(m => m.CustomerID.Equals(GetFilter()[0]) && m.CrewID.Equals(GetFilter()[2])).ToList();

                        }
                        // 2 filters - property and crew
                        else if (GetFilter()[1] > 0 && GetFilter()[2] != 0)
                        {
                            listViewModel.Services = Context.ProvideServices.Where(m => m.PropertyID.Equals(GetFilter()[1]) && m.CrewID.Equals(GetFilter()[2])).ToList();
                        }
                        else // no filter - show all
                        {
                            listViewModel.Services = Context.ProvideServices.Where(m => m.CustomerID.Equals(GetFilter()[0]) || m.PropertyID.Equals(GetFilter()[1]) || m.CrewID.Equals(GetFilter()[2])).ToList();
                        }
                    }
                }

                catch (ArgumentNullException e)
                {

                    Console.WriteLine(e.Data);
                }
            }

            return View(listViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ServiceViewModel model = new ServiceViewModel
            {
                CurrentService = new ProvideService(),
                Action = "Add",
                Crews = Context.Crews.ToList(),
                Properties = Context.Properties.ToList(),
                Customers = Context.Customers.ToList()
            };

            model.CurrentService.ServiceDate = DateTime.Today;

            return View("AddEdit", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ServiceViewModel model = new ServiceViewModel
            {
                Action = "Edit",
                CurrentService = Context.ProvideServices.Find(id),
                Crews = Context.Crews.ToList(),
                Properties = Context.Properties.ToList(),
                Customers = Context.Customers.ToList()
            };

            model.CurrentCustomer = Context.Customers.Find(model.CurrentService.CustomerID);

            return View("AddEdit", model);
        }

        [HttpPost]
        public IActionResult Save(ProvideService CurrentService)
        {
            ServiceViewModel model = new ServiceViewModel()
            {
                Crews = Context.Crews.ToList(),
                Properties = Context.Properties.ToList(),
                Customers = Context.Customers.ToList(),
            };

            CurrentService.CurrentCrew = Context.Crews.Find(CurrentService.CrewID);
            CurrentService.CurrentCustomer = Context.Customers.Find(CurrentService.CustomerID);
            CurrentService.CurrentProperty = Context.Properties.Find(CurrentService.PropertyID);
            CurrentService.CurrentPayment = Context.Payments.Find(CurrentService.PaymentID);

            if (!(CurrentService.ServiceFee >= CurrentService.CurrentProperty.ServiceFee))
            {
                ModelState.AddModelError("ServiceFee", "The service fee must be greater than or equal to: $" + CurrentService.CurrentProperty.ServiceFee);
            }

            if (ModelState.IsValid)
            {

                if (CurrentService.ServiceID == 0)
                {
                    CurrentService.CurrentPayment = Context.Payments.Find(Context.Payments.OrderBy(p => p.PaymentID).Last().PaymentID);
                    Context.ProvideServices.Add(CurrentService);
                }
                else
                {
                    Context.ProvideServices.Update(CurrentService);
                }

                Context.SaveChanges();

                return RedirectToAction("List");

            }
            else
            {
                if (CurrentService.ServiceID == 0)
                {
                    model.Action = "Add";
                }
                else
                {
                    model.Action = "Edit";
                }

                model.CurrentService = CurrentService;

                return View("AddEdit", model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ServiceViewModel model = new ServiceViewModel
            {
                Action = "Delete",
                CurrentService = Context.ProvideServices.Find(id),
                Crews = Context.Crews.ToList(),
                Properties = Context.Properties.ToList(),
                Customers = Context.Customers.ToList(),
            };


            model.CurrentService.CurrentCrew = Context.Crews.Find(model.CurrentService.CrewID);
            model.CurrentService.CurrentCustomer = Context.Customers.Find(model.CurrentService.CustomerID);
            model.CurrentService.CurrentProperty = Context.Properties.Find(model.CurrentService.PropertyID);
            model.CurrentService.CurrentPayment = Context.Payments.Find(model.CurrentService.PaymentID);

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(ProvideService CurrentService)
        {
            Context.ProvideServices.Remove(CurrentService);
            Context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
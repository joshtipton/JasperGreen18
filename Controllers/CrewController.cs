using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using JasperGreen18.Models;
using Microsoft.EntityFrameworkCore;
using System;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JasperGreen18.Controllers
{
    public class CrewController : Controller
    {
        private JasperGreenContext Context { get; set; }


        public CrewController(JasperGreenContext ctx)
        {
            Context = ctx;
        }

        // Attribute Routing
        [Route("/Crews")]
        public ViewResult List()
        {
            List<Crew> CrewList = Context.Crews
                .Include(c => c.CrewForeman)
                .Include(c => c.CrewMember1)
                .Include(c => c.CrewMember2)
                .ToList();

            CrewListViewModel listViewModel = new CrewListViewModel
            {
                Crews = CrewList
            };

            return View(listViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CrewViewModel model = new CrewViewModel
            {
                GetEmployees = Context.Employees.ToList(),
                Action = "Add",
                CurrentCrew = new Crew()
            };

            return View("AddEdit", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CrewViewModel model = new CrewViewModel
            {
                Action = "Edit",
                GetEmployees = Context.Employees.ToList(),
                CurrentCrew = Context.Crews.Find(id)
            };

            return View("AddEdit", model);
        }

        /// <summary>
        /// Determines if each value in the AddEdit page is a unique employee
        /// </summary>
        /// <param name="ForemanID"></param>
        /// <param name="Member1ID"></param>
        /// <param name="Member2ID"></param>
        /// <returns> True if all members are distinct, false if not. </returns>
        public void CheckDistinct(int ForemanID, int Member1ID, int Member2ID)
        {
            if (ForemanID == Member1ID || ForemanID == Member2ID)
            {
                ModelState.AddModelError("DistinctForeman", "The foreman must be a unique employee.");
            }

            if (Member1ID == Member2ID || Member1ID == ForemanID)
            {
                ModelState.AddModelError("DistinctMember1", "The first member must be a unique employee.");
            }

            if (Member2ID == Member1ID || Member2ID == ForemanID)
            {
                ModelState.AddModelError("DistinctMember2", "The second member must be a unique employee.");
            }
        }

        [HttpPost]
        public IActionResult Save(Crew CurrentCrew)
        {
            CrewViewModel model = new CrewViewModel()
            {
                CurrentCrew = CurrentCrew,
                GetEmployees = Context.Employees.ToList()
            };

                CheckDistinct(
                CurrentCrew.CrewForemanID,
                CurrentCrew.CrewMember1ID,
                CurrentCrew.CrewMember2ID);
            
            if (ModelState.IsValid)
            {
                if (CurrentCrew.CrewID == 0)
                {
                    Context.Crews.Add(CurrentCrew);
                }
                else
                {
                    Context.Crews.Update(CurrentCrew);
                }

                Context.SaveChanges();
                return RedirectToAction("List");
            }

            else
            {
                if (CurrentCrew.CrewID == 0)
                {
                    model.Action = "Add";
                }
                else
                {
                    model.Action = "Edit";
                }

                model.CurrentCrew = CurrentCrew;

                return View("AddEdit", model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CrewViewModel model = new CrewViewModel
            {
                Action = "Delete",
                GetEmployees = Context.Employees.ToList(),
                CurrentCrew = Context.Crews.Find(id)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Crew CurrentCrew)
        {
            Context.Crews.Remove(CurrentCrew);
            Context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

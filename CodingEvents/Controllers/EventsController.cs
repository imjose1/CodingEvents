using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;
using CodingEvents.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
     
        // GET: /<controller>/
        public IActionResult Index()
        {
            //ViewBag.events = EventData.GetAll();
            List<Event> events = new List<Event>(EventData.GetAll());
            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                };
                EventData.Add(newEvent);

                return Redirect("/Events");
            }
            return View(addEventViewModel);
        }
        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }
        
        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }
       
        //[HttpGet("/Events/Edit/{eventId}")]
        //public IActionResult Edit(int eventId)
        //{
        //    Event evtEdit = EventData.GetById(eventId);
        //    ViewBag.editEvt = evtEdit;
        //    ViewBag.title = $"Edit Event {evtEdit.Name} (id={evtEdit.Id})";
        //    return View();
        //}

        //[HttpPost("/Events/Edit")]
        //public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        //{
        //    Event evtEdit = EventData.GetById(eventId);
        //    evtEdit.Name = name;
        //    evtEdit.Description = description;

        //    return Redirect("/Events");
        //}
    }
}


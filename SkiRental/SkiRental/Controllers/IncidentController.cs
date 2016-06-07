using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SkiRental.Models;
using SkiRental.Services;
using SkiRental.ViewModels;

namespace SkiRental.Controllers
{
    public class IncidentController : Controller
    {
        private readonly IncidentService _incidentService = new IncidentService();

        // GET: Incident
        public ActionResult Index()
        {
            var incidents = _incidentService.GetAllIncidents();

            return View(incidents);
        }

        public ActionResult ListItems()
        {
            var items = _incidentService.GetItems();

            return PartialView(items);
        }

        public ActionResult AddIncident()
        {
            var selectItems = _incidentService.GetSelectItems();
            ViewBag.SelectItems = selectItems;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddIncident(IncidentViewModel incidentViewModel)
        {
            _incidentService.AddIncident(incidentViewModel);
            var incidents = _incidentService.GetAllIncidents();

            return RedirectToAction("Index", incidents);
        }
    }
}
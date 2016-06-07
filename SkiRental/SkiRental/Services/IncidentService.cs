using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SkiRental.DAL;
using SkiRental.Models;
using SkiRental.ViewModels;

namespace SkiRental.Services
{
    public class IncidentService : IDisposable
    {
        private SkiRentalContext _db = new SkiRentalContext();

        public List<Incident> GetAllIncidents()
        {
            // Sprawdzić co, jeśli Incidents jest puste

            return _db.Incidents.ToList();
        }

        public List<Item> GetItems()
        {
            var items = _db.Items.ToList();

            return items;
        }

        public IEnumerable<SelectListItem> GetSelectItems()
        {
            var selectItems = _db.IncidentTypes.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });

            return selectItems;
        }

        public void AddIncident(IncidentViewModel incidentViewModel)
        {
            var incident = new Incident()
            {
                //Id = incidentViewModel.Id,
                Description = incidentViewModel.Description,
                Cost = incidentViewModel.Cost,
                ItemId = incidentViewModel.ItemId,
                //IncidentTypeId = Int32.Parse(incidentViewModel.IncidentTypeId.ToString())
                IncidentTypeId = incidentViewModel.IncidentTypeId
            };

            _db.Incidents.Add(incident);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
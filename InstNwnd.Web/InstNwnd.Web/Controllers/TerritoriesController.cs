using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.Territories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InstNwnd.Web.Controllers
{
    public class TerritoriesController : Controller
    {
        private readonly ITerritoriesDb territoriesService;

        public TerritoriesController(ITerritoriesDb territoriesService)
        {
            this.territoriesService = territoriesService;
        }

        // GET: TerritoriesController
        public ActionResult Index()
        {
            var territories = territoriesService.GetTerritories();
            return View(territories);
        }

        // GET: TerritoriesController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var territory = territoriesService.GetTerritories(id);
                if (territory == null)
                {
                    return NotFound();
                }
                return View(territory);
            }
            catch (TerritoriesDbException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        // GET: TerritoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TerritoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TerritoriesSaveModel territorySave)
        {
            try
            {
                territoriesService.SaveTerritories(territorySave);
                return RedirectToAction(nameof(Index));
            }
            catch (TerritoriesDbException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(territorySave);
            }
        }

        // GET: TerritoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var territory = territoriesService.GetTerritories(id);
                if (territory == null)
                {
                    return NotFound();
                }
                var updateTerritory = new TerritoriesUpdateModel
                {
                    TerritoryID = territory.TerritoryID,
                    TerritoryDescription = territory.TerritoryDescription
                };
                return View(updateTerritory);
            }
            catch (TerritoriesDbException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        // POST: TerritoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TerritoriesUpdateModel territoryUpdate)
        {
            try
            {
                territoriesService.UpdateTerritories(territoryUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch (TerritoriesDbException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(territoryUpdate);
            }
        }

        // GET: TerritoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var territory = territoriesService.GetTerritories(id);
                if (territory == null)
                {
                    return NotFound();
                }
                return View(territory);
            }
            catch (TerritoriesDbException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        
        
    }
}

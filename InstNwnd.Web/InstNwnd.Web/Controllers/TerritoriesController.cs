using Microsoft.AspNetCore.Mvc;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.Territories;

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
            var territories = this.territoriesService.GetTerritories();
            return View(territories);
        }

        // GET: TerritoriesController/Details/5
        public ActionResult Details(string id)
        {
            var territory = this.territoriesService.GetTerritories(id);
            return View(territory);
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
                this.territoriesService.SaveTerritories(territorySave);
                return RedirectToAction(nameof(Index));
            }
            catch (TerritoriesDbException ex)
            {
                Console.WriteLine(ex.Message);
                return View(territorySave);
            }
        }

        // GET: TerritoriesController/Edit/5
        public ActionResult Edit(string id)
        {
            var territory = this.territoriesService.GetTerritories(id);
            var updateTerritory = new TerritoriesUpdateModel
            {
                TerritoryID = territory.TerritoryID,
                TerritoryDescription = territory.TerritoryDescription,
                RegionID = territory.RegionID
            };
            return View(updateTerritory);
        }

        // POST: TerritoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TerritoriesUpdateModel territoryUpdate)
        {
            try
            {
                this.territoriesService.UpdateTerritories(territoryUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch (TerritoriesDbException ex)
            {
                Console.WriteLine(ex.Message);
                return View(territoryUpdate);
            }
        }

        // GET: TerritoriesController/Delete/5
        public ActionResult Delete(string id)
        {
            var territory = this.territoriesService.GetTerritories(id);
            return View(territory);
        }

        // POST: TerritoriesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var territoryRemove = new TerritoriesRemoveModel { TerritoryID = id };
                this.territoriesService.RemoveTerritories(territoryRemove);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var territory = this.territoriesService.GetTerritories(id);
                return View(territory);
            }
        }
    }
}

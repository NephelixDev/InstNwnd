using Microsoft.AspNetCore.Mvc;
using InstNwnd.Web.Data.Exceptions;
using InstNwnd.Web.Data.Interfaces;
using InstNwnd.Web.Data.Models.Region;

namespace InstNwnd.Web.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionDb regionService;

        public RegionController(IRegionDb regionService)
        {
            this.regionService = regionService;
        }

        // GET: RegionController
        public ActionResult Index()
        {
            var regions = this.regionService.GetRegion();
            return View(regions);
        }

        // GET: RegionController/Details/5
        public ActionResult Details(int id)
        {
            var region = this.regionService.GetRegion(id);
            return View(region);
        }

        // GET: RegionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegionSaveModel regionSave)
        {
            try
            {
            
                this.regionService.SaveRegion(regionSave);
                return RedirectToAction(nameof(Index));
            }
            catch (RegionDbException exp)
            {
                Console.WriteLine(exp.Message);
                return View();
            }
        }

        // GET: RegionController/Edit/5
        public ActionResult Edit(int id)
        {
            var region = this.regionService.GetRegion(id);
            var updateRegion = new RegionUpdateModel
            {
                RegionID = region.RegionID,
                RegionDescription = region.RegionDescription
            };
            return View(updateRegion);
        }

        // POST: RegionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RegionUpdateModel regionUpdate)
        {
            try
            {
                this.regionService.UpdateRegion(regionUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch (RegionDbException exp)
            {
                Console.WriteLine(exp.Message);
                return View();
            }
        }

        // GET: RegionController/Delete/5
        public ActionResult Delete(int id)
        {
            var region = this.regionService.GetRegion(id);
            return View(region);
        }

        // POST: RegionController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var regionRemove = new RegionRemoveModel { RegionID = id };
                this.regionService.RemoveRegion(regionRemove);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var region = this.regionService.GetRegion(id);
                return View(region);
            }
        }
    }
}

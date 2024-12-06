using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;
using BLL.Services;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class ArtistsController : MvcController
    {
        // Service injections:
        private readonly IArtistsService _artistsService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        //private readonly IService<{Entity}, {Entity}Model> _{Entity}Service;

        public ArtistsController(
			IArtistsService artistsService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //, Service<{Entity}, {Entity}Model> {Entity}Service
        )
        {
            _artistsService = artistsService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //_{Entity}Service = {Entity}Service;
        }

        // GET: Artists
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _artistsService.Query().ToList();
            return View(list);
        }

        // GET: Artists/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _artistsService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //ViewBag.{Entity}Ids = new MultiSelectList(_{Entity}Service.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Artists/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Artists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArtistsModel artists)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _artistsService.Create(artists.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = artists.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(artists);
        }

        // GET: Artists/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _artistsService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Artists/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ArtistsModel artists)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _artistsService.Update(artists.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = artists.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(artists);
        }

        // GET: Artists/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _artistsService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Artists/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _artistsService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}

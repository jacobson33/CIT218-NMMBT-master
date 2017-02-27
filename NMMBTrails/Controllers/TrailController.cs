using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NMMBTrails.DAL;
using NMMBTrails.Models;

namespace NMMBTrails.Controllers
{
    public class TrailController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sortOrder)
        {
            TrailRepository trailRepository = new TrailRepository();

            //get distinct counties to use as a filter
            ViewBag.Counties = ListOfCounties();

            IEnumerable<Trail> trails;
            using (trailRepository)
            {
                trails = trailRepository.SelectAll() as IList<Trail>;
            }

            //sorting
            switch (sortOrder)
            {
                case "Name":
                    trails = trails.OrderBy(t => t.Name);
                    break;

                case "County":
                    trails = trails.OrderBy(t => t.County);
                    break;

                default:
                    trails = trails.OrderBy(t => t.Id);
                    break;
            }

            return View(trails);
        }

        [HttpPost]
        public ActionResult Index(string searchCriteria, string countyFilter)
        {
            TrailRepository trailRepository = new TrailRepository();

            //get distinct counties to use as a filter
            ViewBag.Counties = ListOfCounties();

            IEnumerable<Trail> trails;
            using (trailRepository)
            {
                trails = trailRepository.SelectAll() as IList<Trail>;
            }

            //filter
            if (searchCriteria != null)
                trails = trails.Where(t => t.Name.ToUpper().Contains(searchCriteria.ToUpper()));

            if (countyFilter != "" || countyFilter != null)
                trails = trails.Where(t => t.County == countyFilter);

            return View(trails);
        }

        [NonAction]
        private IEnumerable<string> ListOfCounties()
        {
            TrailRepository trailRepository = new TrailRepository();

            IEnumerable<Trail> trails;

            using (trailRepository)
            {
                trails = trailRepository.SelectAll() as IList<Trail>;
            }

            //get distinct counties
            var counties = trails.Select(t => t.County).Distinct().OrderBy(x => x);

            return counties;
        }

        // GET: Trail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Trail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trail/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Trail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trail/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

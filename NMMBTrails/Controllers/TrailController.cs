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
        public ActionResult ChangePermission(string permission)
        {
            if (permission == "Admin")
                Session["Permission"] = "Admin";
            else
                Session["Permission"] = "User";

            return RedirectToAction("Index");
        }
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

            //sorting setup
            ViewBag.NameSort = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewBag.CountySort = sortOrder == "County" ? "County_desc" : "County";

            //sorting
            switch (sortOrder)
            {
                case "Name":
                    trails = trails.OrderBy(t => t.Name);
                    ViewBag.NameSortArrow = "glyphicon-chevron-up";
                    ViewBag.CountySortArrow = null;
                    break;

                case "Name_desc":
                    trails = trails.OrderByDescending(t => t.Name);
                    ViewBag.NameSortArrow = "glyphicon-chevron-down";
                    ViewBag.CountySortArrow = null;
                    break;

                case "County":
                    trails = trails.OrderBy(t => t.County);
                    ViewBag.CountySortArrow = "glyphicon-chevron-up";
                    ViewBag.NameSortArrow = null;
                    break;

                case "County_desc":
                    trails = trails.OrderByDescending(t => t.County);
                    ViewBag.CountySortArrow = "glyphicon-chevron-down";
                    ViewBag.NameSortArrow = null;
                    break;

                default:
                    trails = trails.OrderBy(t => t.Id);
                    ViewBag.NameSortArrow = null;
                    ViewBag.CountySortArrow = null;
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
            if (!String.IsNullOrEmpty(searchCriteria))
            {
                trails = trails.Where(t => t.Name.ToUpper().Contains(searchCriteria.ToUpper()));
                ViewBag.SearchCriteria = searchCriteria;
            }

            if (!String.IsNullOrEmpty(countyFilter))
            {
                trails = trails.Where(t => t.County == countyFilter);
                ViewBag.CountyFilter = countyFilter;
            }

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
            TrailRepository trailRepository = new TrailRepository();
            Trail trail = new Trail();

            using (trailRepository)
            {
                trail = trailRepository.SelectOne(id);
            }

            return View(trail);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["Permission"] != "Admin")
                return RedirectToAction("Index");

            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Trail trail)
        {
            if (Session["Permission"] != "Admin")
                return RedirectToAction("Index");

            try
            {
                TrailRepository trailRepository = new TrailRepository();

                using (trailRepository)
                {
                    trailRepository.Insert(trail);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                // TODO Add view for error message
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["Permission"] != "Admin")
                return RedirectToAction("Index");

            TrailRepository trailRepository = new TrailRepository();
            Trail trail = new Trail();

            using (trailRepository)
            {
                trail = trailRepository.SelectOne(id);
            }

            return View(trail);
        }

        [HttpPost]
        public ActionResult Edit(Trail trail)
        {
            if (Session["Permission"] != "Admin")
                return RedirectToAction("Index");

            try
            {
                TrailRepository trailRepository = new TrailRepository();

                using (trailRepository)
                {
                    trailRepository.Update(trail);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                // TODO Add view for error message
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Permission"] != "Admin")
                return RedirectToAction("Index");

            TrailRepository trailRepository = new TrailRepository();
            Trail trail = new Trail();

            using (trailRepository)
            {
                trail = trailRepository.SelectOne(id);
            }

            return View(trail);
        }

        [HttpPost]
        public ActionResult Delete(int id, Trail trail)
        {
            if (Session["Permission"] != "Admin")
                return RedirectToAction("Index");

            try
            {
                TrailRepository trailRepository = new TrailRepository();

                using (trailRepository)
                {
                    trailRepository.Delete(id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                // TODO Add view for error message
                return View();
            }
        }
    }
}

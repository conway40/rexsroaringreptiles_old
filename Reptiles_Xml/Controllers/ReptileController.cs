using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reptiles_Xml.DAL;
using Reptiles_Xml.Models;

namespace Reptiles_Xml.Controllers
{
    public class ReptileController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sortOrder)
        {
            // instantiate a repository
            ReptileRepository reptileRepository = new ReptileRepository();

            // create a distinct list of levels for the experience filter
            ViewBag.Levels = ListOfExperienceLevels();

            // return the data context as an enumerable
            IEnumerable<Reptile> reptiles;
            using (reptileRepository)
            {
                reptiles = reptileRepository.SelectAll() as IList<Reptile>;
            }

            // sort by name unless posted as a new sort
            switch (sortOrder)
            {
                case "Species":
                    reptiles = reptiles.OrderBy(reptile => reptile.Species);
                    break;
                case "ExperienceLevel":
                    reptiles = reptiles.OrderBy(reptile => reptile.ExperienceLevel);
                    break;
                case "Price":
                    reptiles = reptiles.OrderBy(reptile => reptile.Price);
                    break;
                default:
                    reptiles = reptiles.OrderBy(reptile => reptile.Species);
                    break;
            }

            return View(reptiles);
        }

        [HttpPost]
        public ActionResult Index(string searchCriteria, string experienceFilter)
        {
            // instantiate a repository
            ReptileRepository reptileRepository = new ReptileRepository();

            // create a distinct list of levels for the experience filter
            ViewBag.Levels = ListOfExperienceLevels();

            // return the data context as an enumerable
            IEnumerable<Reptile> reptiles;
            using (reptileRepository)
            {
                reptiles = reptileRepository.SelectAll() as IList<Reptile>;
            }
            // if posted with a search on reptile name
            if (searchCriteria != null)
            {
                reptiles = reptiles.Where(reptile => reptile.Species.ToUpper().Contains(searchCriteria.ToUpper()));
            }

            // if posted with a filter by experience level
            if (experienceFilter != "" || experienceFilter == null)
            {
                reptiles = reptiles.Where(reptile => reptile.ExperienceLevel == experienceFilter);
            }

            return View(reptiles);
        }

        [NonAction]
        private IEnumerable<string> ListOfExperienceLevels()
        {
            // instantiate a repo
            ReptileRepository reptileRepository = new ReptileRepository();

            // return the data context as an enum
            IEnumerable<Reptile> reptiles;
            using (reptileRepository)
            {
                reptiles = reptileRepository.SelectAll() as IList<Reptile>;
            }

            // get a distinct list of levels
            var levels = reptiles.Select(reptile => reptile.ExperienceLevel).Distinct().OrderBy(x => x);

            return levels;
        }

        // GET: Reptile/Details/5
        public ActionResult Details(int id)
        {
            // repo
            ReptileRepository reptileRepository = new ReptileRepository();
            Reptile reptile = new Reptile();

            // get a reptile that has the matching id
            using (reptileRepository)
            {
                reptile = reptileRepository.SelectOne(id);
            }

            return View(reptile);
        }

        // GET: Reptile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reptile/Create
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

        // GET: Reptile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reptile/Edit/5
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

        // GET: Reptile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reptile/Delete/5
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

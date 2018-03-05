﻿using Demo_Nmm_Xml.DAL;
using Demo_Nmm_Xml.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace Demo_Nmm_Xml.Controllers
{
    public class BreweryController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sortOrder, int? page)
        {
            //
            // instantiate a repository
            //
            BreweryRepository breweryRepository = new BreweryRepository();

            //
            // create a distinct list of cities for the city filter
            //
            ViewBag.Cities = ListOfCities();

            //
            // return the data context as an enumerable
            //
            IEnumerable<Brewery> breweries;
            using (breweryRepository)
            {
                breweries = breweryRepository.SelectAll() as IList<Brewery>;
            }

            //
            // sort by name unless posted as a new sort
            //
            switch (sortOrder)
            {
                case "Name":
                    breweries = breweries.OrderBy(brewery => brewery.Name);
                    break;

                case "City":
                    breweries = breweries.OrderBy(brewery => brewery.City);
                    break;

                default:
                    breweries = breweries.OrderBy(brewery => brewery.Name);
                    break;
            }

            //
            // set parameters and paginate the breweries list
            //
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            breweries = breweries.ToPagedList(pageNumber, pageSize);

            return View(breweries);
        }

        [HttpPost]
        public ActionResult Index(string searchCriteria, string cityFilter, int? page)
        {
            //
            // instantiate a repository
            //
            BreweryRepository breweryRepository = new BreweryRepository();

            //
            // create a distinct list of cities for the city filter
            //
            ViewBag.Cities = ListOfCities();

            //
            // return the data context as an enumerable
            //
            IEnumerable<Brewery> breweries;
            using (breweryRepository)
            {
                breweries = breweryRepository.SelectAll() as IList<Brewery>;
            }

            //
            // if posted with a search on brewery name
            //
            if (searchCriteria != null)
            {
                breweries = breweries.Where(brewery => brewery.Name.ToUpper().Contains(searchCriteria.ToUpper()));
            }

            //
            // if posted with a filter by city
            //
            if (cityFilter != "" || cityFilter == null)
            {
                breweries = breweries.Where(brewery => brewery.City == cityFilter);
            }

            //
            // set parameters and paginate the breweries list
            //
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            breweries = breweries.ToPagedList(pageNumber, pageSize);

            return View(breweries);
        }

        [NonAction]
        private IEnumerable<string> ListOfCities()
        {
            //
            // instantiate a repository
            //
            BreweryRepository breweryRepository = new BreweryRepository();

            //
            // return the data context as an enumberable
            //
            IEnumerable<Brewery> breweries;
            using (breweryRepository)
            {
                breweries = breweryRepository.SelectAll() as IList<Brewery>;
            }

            //
            // get a distinct list of cities
            //
            var cities = breweries.Select(brewery => brewery.City).Distinct().OrderBy(x => x);

            return cities;
        }

        // GET: Brewery/Details/5
        public ActionResult Details(int id)
        {
            //
            // instantiate a repository
            //
            BreweryRepository breweryRepository = new BreweryRepository();
            Brewery brewery = new Brewery();

            //
            // get a brewery that has the matching id
            //
            using (breweryRepository)
            {
                brewery = breweryRepository.SelectOne(id);
            }

            return View(brewery);
        }

        // GET: Brewery/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Brewery/Create
        [HttpPost]
        public ActionResult Create(Brewery brewery)
        {
            try
            {
                BreweryRepository breweryRepository = new BreweryRepository();

                using (breweryRepository)
                {
                    breweryRepository.Insert(brewery);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                // TODO: Add view for error message
                return View();
            }
        }

        // GET: Brewery/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BreweryRepository breweryRepository = new BreweryRepository();
            Brewery brewery = new Brewery();

            using (breweryRepository)
            {
                brewery = breweryRepository.SelectOne(id);
            }

            return View(brewery);
        }

        // POST: Brewery/Edit/5
        [HttpPost]
        public ActionResult Edit(Brewery brewery)
        {
            try
            {
                BreweryRepository breweryRepository = new BreweryRepository();

                using (breweryRepository)
                {
                    breweryRepository.Update(brewery);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                // TODO: Add view for error message
                return View();
            }
        }

        // GET: Brewery/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            BreweryRepository breweryRepository = new BreweryRepository();
            Brewery brewery = new Brewery();

            using (breweryRepository)
            {
                brewery = breweryRepository.SelectOne(id);
            }

            return View(brewery);
        }

        // POST: Brewery/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Brewery brewery)
        {
            try
            {
                BreweryRepository breweryRepository = new BreweryRepository();

                using (breweryRepository)
                {
                    breweryRepository.Delete(id);
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                // TODO: Add view for error message
                return View();
            }
        }
    }
}

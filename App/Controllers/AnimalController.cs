using App.Models.Dominio;
using App.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class AnimalController : Controller
    {
        AnimalRepo repo = new AnimalRepo();

        // GET: Animal
        public ActionResult Index()
        {
            return View("Index_2");
        }

        public PartialViewResult PartialIndex(int page, string search)
        {
            ViewBag.selectedPage = page;

            if (search != "")
            {
                var searchResult = repo.Search(search);
                ViewBag.pageCount = repo.getPageCount(searchResult.Count());
                return PartialView("_Index_2", repo.GetPageItems(page, searchResult));
            }
            else
            {  
                var result = repo.GetAll();
                ViewBag.pageCount = repo.getPageCount(result.Count());
                return PartialView("_Index_2", repo.GetPageItems(page, result));
            }
        }

        // GET: Animal/Add/
        public ActionResult Add()
        {
            return View("formAnimal");
        }

        // POST: Animal/Add
        [HttpPost]
        public ActionResult Add(Animal animal)
        {
            repo.Add(animal);
            return View();
        }

        // GET: Animal/Edit/
        public ActionResult Edit(int id)
        {
            return View("FormAnimal", repo.Get(id));
        }
        // POST: Animal/Edit/
        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            repo.Update(animal);
            return View();
        }

        // DELETE: Animal/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Delete(int id)
        {
            repo.Delete(id);
        }
    }
}
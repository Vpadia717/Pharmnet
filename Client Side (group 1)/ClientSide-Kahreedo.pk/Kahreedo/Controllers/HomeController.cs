/*
This is the HomeController class that handles the logic for the home page of the Khareedo website.
It inherits from the Controller class of the System.Web.Mvc namespace.
*/
using Khareedo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Khareedo.Controllers
{
    public class HomeController : Controller
    {
        // Create an instance of the KhareedoEntities class to interact with the database.
        KhareedoEntities db = new KhareedoEntities();
        // GET: Home
        // This method is called when a user navigates to the home page.
        public ActionResult Index()
        {
            // Get products of specific categories and store them in ViewBag properties.
            ViewBag.MenProduct = db.Products.Where(x => x.Category.Name.Equals("Men")).ToList();
            ViewBag.WomenProduct = db.Products.Where(x => x.Category.Name.Equals("Women")).ToList();
            ViewBag.SportsProduct = db.Products.Where(x => x.Category.Name.Equals("Sports")).ToList();
            ViewBag.ElectronicsProduct = db.Products.Where(x => x.Category.Name.Equals("Phones")).ToList();

            // Get the data for the main slider and promo sections from the database and store them in ViewBag properties.
            ViewBag.Slider = db.genMainSliders.ToList();
            ViewBag.PromoRight = db.genPromoRights.ToList();

            // Call the GetDefaultData method to set default data such as the cart count and user login status.
            this.GetDefaultData();

            // Render the view for the home page.
            return View();
        }

    }
}

/*

In summary, this class handles the backend logic for the home page of the Khareedo website.
It retrieves and stores necessary data from the database and sets default values before rendering the view.
*/
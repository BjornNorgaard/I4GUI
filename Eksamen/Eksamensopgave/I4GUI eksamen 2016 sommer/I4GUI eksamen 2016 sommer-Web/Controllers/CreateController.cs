using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace I4GUI_eksamen_2016_sommer_Web.Controllers
{
    public class CreateController : Controller
    {
        // GET: Create
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(FormCollection collection)
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Redirect("/Browse/Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using I4GUI_eksamen_2016_sommer;
using Newtonsoft.Json;

namespace I4GUI_eksamen_2016_sommer_Web.Controllers
{
    public class CreateController : Controller
    {
        // GET: Create
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(string date, string joke, string source, string tags)
        {
            List<Joke> jokesInJsonFile = new List<Joke>();

            if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\jokes.json"))
            {
                string currentContent =
                    System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\jokes.json");
                jokesInJsonFile = JsonConvert.DeserializeObject<List<Joke>>(currentContent);
            }

            jokesInJsonFile.Add(new Joke(joke, date, source, tags));
            string newContent = JsonConvert.SerializeObject(jokesInJsonFile);

            using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\jokes.json"))
            {
                sw.Write(newContent);
                sw.Close();
            }

            return Redirect("/Browse/Index");
        }
    }
}
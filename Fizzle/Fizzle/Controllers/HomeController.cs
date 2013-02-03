using System.Collections.Generic;
using System.Web.Mvc;
using Fizzle.Models;

namespace Fizzle.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int first=1, int last=30)
        {
            var model = new FizzBuzzModel
                {
                    First = first,
                    Last = last,
                    Results = new List<string>()
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            int first = int.Parse(collection["first"]);
            int last = int.Parse(collection["last"]);

            var model = new FizzBuzzModel
            {
                First = first,
                Last = last,
                Results = new FizzBuzzer().Sequence(first, last)
            }; 

            return View(model);
        }

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }

}

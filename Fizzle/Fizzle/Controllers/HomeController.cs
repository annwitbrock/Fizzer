using System.Web.Mvc;

namespace Fizzle.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string first="1", string last="30")
        {
            string[] result = {};
            ViewBag.First = first;
            ViewBag.Last = last;
            ViewBag.Result = result;
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            int first = int.Parse(collection["first"]);
            int last = int.Parse(collection["last"]);
            ViewBag.First = collection["first"];
            ViewBag.Last = collection["last"];
            ViewBag.Result = new FizzBuzzer().Sequence(first, last).ToArray();

            return View();
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

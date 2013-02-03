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
        public ActionResult Index(FizzBuzzPostModel postModel)
        {
            var model = new FizzBuzzModel
            {
                First = postModel.First,
                Last = postModel.Last,
                Results = new FizzBuzzer().Sequence(postModel.First, postModel.Last)
            }; 

            return View(model);
        }
    }
}

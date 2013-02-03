using System.Web.Mvc;
using Fizzle.Controllers;
using NUnit.Framework;

namespace Fizzle.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void IndexExists()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.ToString());
        }
    }
}

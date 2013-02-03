using System.Web.Mvc;
using Fizzle.Controllers;
using Fizzle.Models;
using NUnit.Framework;

namespace Fizzle.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void IndexGetReturnsView()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;

            AssertValidFizzBuzzViewResult(result);
        }

        [Test]
        public void IndexGetWithValuesReturnsView()
        {
            var controller = new HomeController();
            var result = controller.Index(1, 100) as ViewResult;

            AssertValidFizzBuzzViewResult(result);
        }

        [Test]
        public void IndexGetEchoesDefaultFirstAndLast()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;
            var viewModel = result.Model as FizzBuzzModel;

            Assert.That(viewModel.First, Is.EqualTo(1));
            Assert.That(viewModel.Last, Is.EqualTo(30));
        }

        [Test]
        public void IndexGetEchoesNonDefaultFirstAndLast()
        {
            var controller = new HomeController();

            var result = controller.Index(12, 47) as ViewResult;
            var viewModel = result.Model as FizzBuzzModel;

            Assert.That(viewModel.First, Is.EqualTo(12));
            Assert.That(viewModel.Last, Is.EqualTo(47));
        }

        [Test]
        public void IndexGetHasEmptyResults()
        {
            var controller = new HomeController();

            var result = controller.Index(12, 42) as ViewResult;
            var viewModel = result.Model as FizzBuzzModel;

            Assert.That(viewModel.Results, Is.Not.Null);
            Assert.That(viewModel.Results.Count, Is.EqualTo(0));
        }


        [Test]
        public void IndexPostReturnsViewWithDefaultPostData()
        {
            var controller = new HomeController();
            var result = controller.Index(new FizzBuzzPostModel()) as ViewResult;

            AssertValidFizzBuzzViewResult(result);
        }

        [Test]
        public void IndexPostReturnsViewWithOneToFifteen()
        {
            var postData = new FizzBuzzPostModel
            {
                First = 1,
                Last = 15
            };
            var controller = new HomeController();

            var result = controller.Index(postData) as ViewResult;

            AssertValidFizzBuzzViewResult(result);
        }

        [Test]
        public void IndexPostEchoesFirstAndLast()
        {
            var postData = new FizzBuzzPostModel
                {
                    First = 1,
                    Last = 15
                };
            var controller = new HomeController();

            var result = controller.Index(postData) as ViewResult;
            var viewModel = result.Model as FizzBuzzModel;

            Assert.That(viewModel.First, Is.EqualTo(1));
            Assert.That(viewModel.Last, Is.EqualTo(15));
        }

        [TestCase(1, "1")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        public void IndexPostReturnsStrings(int index, string expected)
        {
            var postData = new FizzBuzzPostModel
            {
                First = 1,
                Last = 15
            };
            var controller = new HomeController();

            var result = controller.Index(postData) as ViewResult;
            var viewModel = result.Model as FizzBuzzModel;

            Assert.That(viewModel.Results.Count, Is.EqualTo(15));
            Assert.That(viewModel.Results[index - 1], Is.EqualTo(expected));
        }

        private static void AssertValidFizzBuzzViewResult(ViewResult result)
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model, Is.Not.Null);
            Assert.That(result.Model, Is.InstanceOf<FizzBuzzModel>());
        }
    }
}

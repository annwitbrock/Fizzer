using System.Collections.Generic;
using NUnit.Framework;

namespace Fizzle.Tests
{
    [TestFixture]
    public class FizzBuzzerTests
    {
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "Fizz")]
        [TestCase(6, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(10, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(30, "FizzBuzz")]
        [TestCase(0, "")]
        public void ShouldReturnFizzBuzzOrNumber(int i, string expected)
        {
            var fizzBuzzer = new FizzBuzzer();
            Assert.That(fizzBuzzer.Answer(i), Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class FizzBuzzSequenceTests
    {
        [TestCase(1, 1, new string[] {"1"})]
        [TestCase(1, 2, new string[] {"1", "2"})]
        [TestCase(10, 16, new string[] { "Buzz", "11","Fizz", "13", "14", "FizzBuzz", "16"})]
        [TestCase(1, 0, new string[] { })]
        [TestCase(16, 2, new string[] { })]
        [TestCase(0, 0, new string[] { })]
        [TestCase(-1, 0, new string[] { })]
        public void ShouldReturnFizzBuzzSequence(int first, int last, string[] expected)
        {
            var fizzBuzzer = new FizzBuzzer();
            Assert.That(fizzBuzzer.Sequence(first,last).ToArray(), Is.EqualTo(expected));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2;
using System.Dynamic;

namespace Lab02.Tests
{
    [TestClass]
    public class FizzBuzzTests
    {

        [TestMethod]
        public void value_4_equals_4()
        {

            var sut = new FizzBuzz();

            var result = sut.Evaluate(4);

            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public void value_3_equals_Fizz()
        {

            var sut = new FizzBuzz();

            var result = sut.Evaluate(3);

            Assert.AreEqual("Fizz", result);
        }

        [TestMethod]
        public void value_5_equals_Buzz()
        {

            var sut = new FizzBuzz();

            var result = sut.Evaluate(5);

            Assert.AreEqual("Buzz", result);
        }

        [TestMethod]
        public void Multiple_of_15_equals_FizzBuzz()
        {

            var sut = new FizzBuzz();

            var result = sut.Evaluate(30);

            Assert.AreEqual("FizzBuzz", result);
        }

        [TestMethod]
        public void multiple_of_3_equals_Fizz()
        {

            var sut = new FizzBuzz();

            var result = sut.Evaluate(9);

            Assert.AreEqual("Fizz", result);
        }

        [TestMethod]
        public void multiple_of_5_equals_Buzz()
        {

            var sut = new FizzBuzz();

            var result = sut.Evaluate(10);

            Assert.AreEqual("Buzz", result);
        }
    }
}

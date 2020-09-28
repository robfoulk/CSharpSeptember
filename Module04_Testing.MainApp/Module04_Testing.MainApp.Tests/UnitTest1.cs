using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Module04_Testing.MainApp;

namespace Module04_Testing.MainApp.Tests
{
    [TestClass]
    public class QuizQuestionsTests
    {
        [TestMethod]
        public void Incorrect_questions_are_wrong()
        {
            //Arrange
            var qq = new QuizQuestion();
            qq.Question = "What is the boiling point of water (F)?";
            qq.Answer = "212";

            //Act
            qq.Grade("100");
            bool isCorrect = qq.AnsweredCorrectly;


            //Assert
            Assert.IsFalse(isCorrect);

        }

        [TestMethod]
        public void Correct_questions_are_right()
        {
            //Arrange

            var qq = new QuizQuestion();
            qq.Question = "How many licks does it take to get the the center of a tootsie pop";
            qq.Answer = "3";

            //Act
            qq.Grade("3");
            var isCorrect = qq.AnsweredCorrectly;



            //Assert
            Assert.IsTrue(isCorrect);
        }

        [TestMethod]
        public void Questions_may_be_case_insensitive()
        {
            var qq = new QuizQuestion();
            qq.Question = "What do you put on your head?";
            qq.Answer = "Hat";
            qq.CaseInsensitive = true;

            //Act
            qq.Grade("hat");
            var isCorrect = qq.AnsweredCorrectly;

            //Assert
            Assert.IsTrue(isCorrect);

        }

    }
}

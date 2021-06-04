using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectUDT_app;

namespace projektUDT_test
{
    /// <summary>
    /// Summary description for FiguresTest
    /// </summary>
    [TestClass]
    public class FiguresTest
    {
        public FiguresTest()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestKoloType()
        {
            Assert.AreEqual("Kolo", Figury.Shape.Kolo.ToString());
        }

        [TestMethod]
        public void TestPunktType()
        {
            Assert.AreEqual("Punkt", Figury.Shape.Punkt.ToString());
        }

        [TestMethod]
        public void TestProstaType()
        {
            Assert.AreEqual("Prosta", Figury.Shape.Prosta.ToString());
        }

        [TestMethod]
        public void TestKwadratType()
        {
            Assert.AreEqual("Kwadrat", Figury.Shape.Kwadrat.ToString());
        }

        [TestMethod]
        public void TestTrojkatType()
        {
            Assert.AreEqual("Trojkat", Figury.Shape.Trojkat.ToString());
        }

        [TestMethod]
        public void TestProstokatType()
        {
            Assert.AreEqual("Prostokat", Figury.Shape.Prostokat.ToString());
        }

        [TestMethod]
        public void TestRownoleglobokType()
        {
            Assert.AreEqual("Rownoleglobok", Figury.Shape.Rownoleglobok.ToString());
        }

        [TestMethod]
        public void TestTrapezType()
        {
            Assert.AreEqual("Trapez", Figury.Shape.Trapez.ToString());
        }
    }
}

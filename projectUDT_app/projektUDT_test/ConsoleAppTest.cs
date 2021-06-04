using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectUDT_app;

namespace projektUDT_test
{
    /// <summary>
    /// Summary description for ConsoleAppTest
    /// </summary>
    [TestClass]
    public class ConsoleAppTest
    {
        public ConsoleAppTest()
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
        public void TestResolveFigureTypeSuccess()
        {
            Assert.AreEqual("Punkt", Program.ResolveFigureType(1));
        }

        [TestMethod]
        public void TestResolveFigureTypeFailOption()
        {
            try
            {
                Program.ResolveFigureType(0);
            }
            catch (Exception e) {
                Assert.AreEqual("Wybrano niewlasciwa opcje!", e.Message);
            }
            
        }

        [TestMethod]
        public void TestResolveFigureTypeFailType()
        {
            Assert.AreNotEqual("Punkt", Program.ResolveFigureType(3));
        }

        [TestMethod]
        public void TestWhereConditionFail()
        {
            try
            {
                Program.WhereCondition("TestowaFigura", "TEST", "=");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Wprowadzono niepoprawne dane!", e.Message);
            }
        }
    }
}

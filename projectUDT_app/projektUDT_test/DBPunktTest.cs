using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectUDT_app;

namespace projektUDT_test
{
    /// <summary>
    /// Summary description for DBPunktTest
    /// </summary>
    [TestClass]
    public class DBPunktTest
    {
        private DBConnection db;
        public DBPunktTest()
        {
            db = new DBConnection();
            //
            // TODO: Add constructor logic here
            //
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
        public void TestInsertPunktSuccess()
        {
            string query = "INSERT INTO dbo.Punkt VALUES('-1/1');";
            string result="";

            try
            {
                db.InsertQuery(query);
            }
            catch(Exception e) 
            {
                result = e.Message;
            }

            Assert.AreEqual("Pomyslnie wprowadzono nowe dane!", result);
        }

        [TestMethod]
        public void TestInsertPunktFailWrongData()
        {
            string query = "INSERT INTO dbo.Punkt VALUES('-1/x');";
            string result = "";

            try
            {
                db.InsertQuery(query);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            Assert.AreEqual("Niepoprawny typ danych!", result);
        }

        [TestMethod]
        public void TestInsertPunktFailWrongArgumentsNumber()
        {
            string query = "INSERT INTO dbo.Punkt VALUES('-1/1/1');";
            string result = "";

            try
            {
                db.InsertQuery(query);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            Assert.AreEqual("Niepoprawna liczba argumentów! (wymagane 2)", result);
        }

        [TestMethod]
        public void TestSelectPunktLengthCompute()
        {
            string query_insert = "INSERT INTO dbo.Punkt VALUES('-1/1');";
            string query_select = "SELECT Punkt.WyznaczObwod() AS Obwod FROM dbo.Punkt;";
            List<string> result = new List<string>();

            List<string> expected = new List<string>();
            expected.Add("0");
            List<string> attributes = new List<string>();
            attributes.Add("Obwod");

            string delete_query = "DELETE dbo.Punkt";

            try
            {
                db.DeleteQuery(delete_query);
            }
            catch (Exception e)
            {
            }

            try
            {
                db.InsertQuery(query_insert);
            }
            catch (Exception)
            {
            }

            try
            {
                result = db.ExecuteQuery(query_select, attributes);
            }
            catch (Exception)
            {
            }

            Assert.AreEqual(expected[0], result[0]);
        }

        [TestMethod]
        public void TestSelectPunktAreaCompute()
        {
            string query_insert = "INSERT INTO dbo.Punkt VALUES('-1/1');";
            string query_select = "SELECT Punkt.WyznaczPole() AS Pole FROM dbo.Punkt;";
            List<string> result = new List<string>();

            List<string> expected = new List<string>();
            expected.Add("0");
            List<string> attributes = new List<string>();
            attributes.Add("Pole");

            string delete_query = "DELETE dbo.Punkt";

            try
            {
                db.DeleteQuery(delete_query);
            }
            catch (Exception e)
            {
            }

            try
            {
                db.InsertQuery(query_insert);
            }
            catch (Exception)
            {
            }

            try
            {
                result = db.ExecuteQuery(query_select, attributes);
            }
            catch (Exception)
            {
            }

            Assert.AreEqual(expected[0], result[0]);
        }

        [TestMethod]
        public void TestSelectPunktInfo()
        {
            string query_insert = "INSERT INTO dbo.Punkt VALUES('-1/1');";
            string query_select = "SELECT Punkt.ToString() AS Info FROM dbo.Punkt;";
            List<string> result = new List<string>();

            List<string> expected = new List<string>();
            expected.Add("Punkt o wspolrzednych (-1, 1).");
            List<string> attributes = new List<string>();
            attributes.Add("Info");

            string delete_query = "DELETE dbo.Punkt";

            try
            {
                db.DeleteQuery(delete_query);
            }
            catch (Exception e)
            {
            }

            try
            {
                db.InsertQuery(query_insert);
            }
            catch (Exception)
            {
            }

            try
            {
                result = db.ExecuteQuery(query_select, attributes);
            }
            catch (Exception)
            {
            }

            Assert.AreEqual(expected[0], result[0]);
        }

        [TestMethod]
        public void TestDeletePunktSuccess()
        {
            string query = "INSERT INTO dbo.Punkt VALUES('-1/1');";
            string delete_query = "DELETE dbo.Punkt";
            string result = "";

            try
            {
                db.DeleteQuery(delete_query);
            }
            catch (Exception e)
            {
            }

            try
            {
                db.InsertQuery(query);
            }
            catch (Exception e)
            {
            }

            try
            {
                db.DeleteQuery(delete_query);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            Assert.AreEqual("Pomyslne usuniecie liczby rekordow: 1", result);
        }

        [TestMethod]
        public void TestDeletePunktEmpty()
        {
            string delete_query = "DELETE dbo.Punkt";
            string result = "";

            try
            {
                db.DeleteQuery(delete_query);
            }
            catch (Exception e)
            {
            }

            try
            {
                db.DeleteQuery(delete_query);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            Assert.AreEqual("Brak danych do usuniecia!", result);
        }
    }
}

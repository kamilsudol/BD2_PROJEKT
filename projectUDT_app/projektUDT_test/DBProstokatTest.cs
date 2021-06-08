using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectUDT_app;

namespace projektUDT_test
{
    /// <summary>
    /// Summary description for DBProstokatTestcs
    /// </summary>
    [TestClass]
    public class DBProstokatTest
    {
        private DBConnection db;
        public DBProstokatTest()
        {
            db = new DBConnection();
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
        public void TestInsertProstokatSuccess()
        {
            string query = "INSERT INTO dbo.Prostokat VALUES('0/0/0/4/4/4/4/0');";
            string result = "";

            try
            {
                db.InsertQuery(query);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            Assert.AreEqual("Pomyslnie wprowadzono nowe dane!", result);
        }

        [TestMethod]
        public void TestInsertProstokatFailWrongData()
        {
            string query = "INSERT INTO dbo.Prostokat VALUES('0/0/0/4/4/4/4/x');";
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
        public void TestInsertProstokatFailWrongArgumentsNumber()
        {
            string query = "INSERT INTO dbo.Prostokat VALUES('-1/1/1/3');";
            string result = "";

            try
            {
                db.InsertQuery(query);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            Assert.AreEqual("Niepoprawna liczba argumentów! (wymagane 8)", result);
        }

        [TestMethod]
        public void TestInsertProstokatFailValidator()
        {
            string query = "INSERT INTO dbo.Prostokat VALUES('0/0/0/0/0/0/0/0');";
            string result = "";

            try
            {
                db.InsertQuery(query);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            Assert.AreEqual("Nie da sie utworzyc prostokatu z podanych punktow!", result);
        }

        [TestMethod]
        public void TestSelectProstokatLengthCompute()
        {
            string query_insert = "INSERT INTO dbo.Prostokat VALUES('0/0/0/4/4/4/4/0');";
            string query_select = "SELECT Prostokat.WyznaczObwod() AS Obwod FROM dbo.Prostokat;";
            List<string> result = new List<string>();

            List<string> expected = new List<string>();
            expected.Add("16");
            List<string> attributes = new List<string>();
            attributes.Add("Obwod");

            string delete_query = "DELETE dbo.Prostokat";

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
        public void TestSelectProstokatAreaCompute()
        {
            string query_insert = "INSERT INTO dbo.Prostokat VALUES('0/0/0/4/4/4/4/0');";
            string query_select = "SELECT Prostokat.WyznaczPole() AS Pole FROM dbo.Prostokat;";
            List<string> result = new List<string>();

            List<string> expected = new List<string>();
            expected.Add("16");
            List<string> attributes = new List<string>();
            attributes.Add("Pole");

            string delete_query = "DELETE dbo.Prostokat";

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
        public void TestSelectProstokatInfo()
        {
            string query_insert = "INSERT INTO dbo.Prostokat VALUES('0/0/0/4/4/4/4/0');";
            string query_select = "SELECT Prostokat.ToString() AS Info FROM dbo.Prostokat;";
            List<string> result = new List<string>();

            List<string> expected = new List<string>();
            expected.Add("Prostokat o wspolrzednych (0, 0), (0, 4), (4, 4) oraz (4, 0).");
            List<string> attributes = new List<string>();
            attributes.Add("Info");

            string delete_query = "DELETE dbo.Prostokat";

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
        public void TestDeleteProstokatSuccess()
        {
            string query = "INSERT INTO dbo.Prostokat VALUES('0/0/0/4/4/4/4/0');";
            string delete_query = "DELETE dbo.Prostokat";
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
        public void TestDeleteProstokatEmpty()
        {
            string delete_query = "DELETE dbo.Prostokat";
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

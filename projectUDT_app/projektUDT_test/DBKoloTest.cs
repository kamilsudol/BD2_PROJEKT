using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectUDT_app;

namespace projektUDT_test
{
    /// <summary>
    /// Summary description for DBKoloTestcs
    /// </summary>
    [TestClass]
    public class DBKoloTest
    {
        private DBConnection db;
        public DBKoloTest()
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
        public void TestInsertKoloSuccess()
        {
            string query = "INSERT INTO dbo.Kolo VALUES('-1/1/2/2');";
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
        public void TestInsertKoloFailWrongData()
        {
            string query = "INSERT INTO dbo.Kolo VALUES('-1/x/2/2');";
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
        public void TestInsertKoloFailWrongArgumentsNumber()
        {
            string query = "INSERT INTO dbo.Kolo VALUES('-1/1/1');";
            string result = "";

            try
            {
                db.InsertQuery(query);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            Assert.AreEqual("Niepoprawna liczba argumentów! (wymagane 4)", result);
        }

        [TestMethod]
        public void TestInsertKoloFailValidator()
        {
            string query = "INSERT INTO dbo.Kolo VALUES('0/0/0/0');";
            string result = "";

            try
            {
                db.InsertQuery(query);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            Assert.AreEqual("Nie da sie utworzyc kola z podanych punktow!", result);
        }

        [TestMethod]
        public void TestSelectKoloLengthCompute()
        {
            string query_insert = "INSERT INTO dbo.Kolo VALUES('-1/1/2/2');";
            string query_select = "SELECT Kolo.WyznaczObwod() AS Obwod FROM dbo.Kolo;";
            List<string> result = new List<string>();

            List<string> expected = new List<string>();
            expected.Add("19,87");
            List<string> attributes = new List<string>();
            attributes.Add("Obwod");

            string delete_query = "DELETE dbo.Kolo";

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
        public void TestSelectKoloAreaCompute()
        {
            string query_insert = "INSERT INTO dbo.Kolo VALUES('-1/1/2/2');";
            string query_select = "SELECT Kolo.WyznaczPole() AS Pole FROM dbo.Kolo;";
            List<string> result = new List<string>();

            List<string> expected = new List<string>();
            expected.Add("31,42");
            List<string> attributes = new List<string>();
            attributes.Add("Pole");

            string delete_query = "DELETE dbo.Kolo";

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
        public void TestSelectKoloInfo()
        {
            string query_insert = "INSERT INTO dbo.Kolo VALUES('0/0/0/2');";
            string query_select = "SELECT Kolo.ToString() AS Info FROM dbo.Kolo;";
            List<string> result = new List<string>();

            List<string> expected = new List<string>();
            expected.Add("Kolo o promieniu 2 o wspolrzednych srodka (0, 0).");
            List<string> attributes = new List<string>();
            attributes.Add("Info");

            string delete_query = "DELETE dbo.Kolo";

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
        public void TestDeleteKoloSuccess()
        {
            string query = "INSERT INTO dbo.Kolo VALUES('-1/1/2/2');";
            string delete_query = "DELETE dbo.Kolo";
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
        public void TestDeleteKoloEmpty()
        {
            string delete_query = "DELETE dbo.Kolo";
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

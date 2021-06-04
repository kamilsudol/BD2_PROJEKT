using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectUDT_app;

namespace projektUDT_test
{
    /// <summary>
    /// Summary description for DBRownoleglobokTestcs
    /// </summary>
    [TestClass]
    public class DBRownoleglobokTest
    {
        private DBConnection db;
        public DBRownoleglobokTest()
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
        public void TestInsertRownoleglobokSuccess()
        {
            string query = "INSERT INTO dbo.Rownoleglobok VALUES('0/0/0/4/4/4/4/0');";
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
        public void TestInsertRownoleglobokFailWrongData()
        {
            string query = "INSERT INTO dbo.Rownoleglobok VALUES('0/0/0/4/4/4/4/x');";
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
        public void TestInsertRownoleglobokFailWrongArgumentsNumber()
        {
            string query = "INSERT INTO dbo.Rownoleglobok VALUES('-1/1/1/3');";
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
        public void TestInsertRownoleglobokFailValidator()
        {
            string query = "INSERT INTO dbo.Rownoleglobok VALUES('0/0/0/0/0/0/0/0');";
            string result = "";

            try
            {
                db.InsertQuery(query);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            Assert.AreEqual("Nie da sie utworzyc rownolegloboku z podanych punktow!", result);
        }

        [TestMethod]
        public void TestSelectRownoleglobokLengthCompute()
        {
            string query_insert = "INSERT INTO dbo.Rownoleglobok VALUES('0/0/0/4/4/4/4/0');";
            string query_select = "SELECT Rownoleglobok.WyznaczObwod() AS Obwod FROM dbo.Rownoleglobok;";
            List<string> result = new List<string>();

            List<string> expected = new List<string>();
            expected.Add("16");
            List<string> attributes = new List<string>();
            attributes.Add("Obwod");

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
        public void TestSelectRownoleglobokAreaCompute()
        {
            string query_insert = "INSERT INTO dbo.Rownoleglobok VALUES('0/0/0/4/4/4/4/0');";
            string query_select = "SELECT Rownoleglobok.WyznaczPole() AS Pole FROM dbo.Rownoleglobok;";
            List<string> result = new List<string>();

            List<string> expected = new List<string>();
            expected.Add("16");
            List<string> attributes = new List<string>();
            attributes.Add("Pole");

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
        public void TestSelectRownoleglobokInfo()
        {
            string query_insert = "INSERT INTO dbo.Rownoleglobok VALUES('0/0/0/4/4/4/4/0');";
            string query_select = "SELECT Rownoleglobok.ToString() AS Info FROM dbo.Rownoleglobok;";
            List<string> result = new List<string>();

            List<string> expected = new List<string>();
            expected.Add("Rownoleglobok o wspolrzednych (0, 0), (0, 4), (4, 4) oraz (4, 0).");
            List<string> attributes = new List<string>();
            attributes.Add("Info");

            string delete_query = "DELETE dbo.Rownoleglobok";

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
        public void TestDeleteRownoleglobokSuccess()
        {
            string query = "INSERT INTO dbo.Rownoleglobok VALUES('0/0/0/4/4/4/4/0');";
            string delete_query = "DELETE dbo.Rownoleglobok";
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
        public void TestDeleteRownoleglobokEmpty()
        {
            string delete_query = "DELETE dbo.Rownoleglobok";
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

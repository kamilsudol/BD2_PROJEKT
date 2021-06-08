using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projectUDT_app;

namespace projektUDT_test
{
    /// <summary>
    /// Summary description for DBProstaTestcs
    /// </summary>
    [TestClass]
    public class DBProstaTest
    {
        private DBConnection db;
        public DBProstaTest()
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
        public void TestInsertProstaSuccess()
        {
            string query = "INSERT INTO dbo.Prosta VALUES('-1/1/2/2');";
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
        public void TestInsertProstaFailWrongData()
        {
            string query = "INSERT INTO dbo.Prosta VALUES('-1/x/2/2');";
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
        public void TestInsertProstaFailWrongArgumentsNumber()
        {
            string query = "INSERT INTO dbo.Prosta VALUES('-1/1/1');";
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
        public void TestInsertProstaFailValidator()
        {
            string query = "INSERT INTO dbo.Prosta VALUES('0/0/0/0');";
            string result = "";

            try
            {
                db.InsertQuery(query);
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            Assert.AreEqual("Nie da sie utworzyc prostej z podanych punktow!", result);
        }

        [TestMethod]
        public void TestSelectProstaLengthCompute()
        {
            string query_insert = "INSERT INTO dbo.Prosta VALUES('-1/1/2/2');";
            string query_select = "SELECT Prosta.WyznaczObwod() AS Obwod FROM dbo.Prosta;";
            List<string> result = new List<string>();

            List<string> expected = new List<string>();
            expected.Add("0");
            List<string> attributes = new List<string>();
            attributes.Add("Obwod");

            string delete_query = "DELETE dbo.Prosta";

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
        public void TestSelectProstaAreaCompute()
        {
            string query_insert = "INSERT INTO dbo.Prosta VALUES('-1/1/2/2');";
            string query_select = "SELECT Prosta.WyznaczPole() AS Pole FROM dbo.Prosta;";
            List<string> result = new List<string>();

            List<string> expected = new List<string>();
            expected.Add("0");
            List<string> attributes = new List<string>();
            attributes.Add("Pole");

            string delete_query = "DELETE dbo.Prosta";

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
        public void TestSelectProstaInfo()
        {
            string query_insert = "INSERT INTO dbo.Prosta VALUES('0/0/0/2');";
            string query_select = "SELECT Prosta.ToString() AS Info FROM dbo.Prosta;";
            List<string> result = new List<string>();

            List<string> expected = new List<string>();
            expected.Add("Prosta o dlugosci 2 o wspolrzednych (0, 0) oraz (0, 2).");
            List<string> attributes = new List<string>();
            attributes.Add("Info");

            string delete_query = "DELETE dbo.Prosta";
           
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
        public void TestDeleteProstaSuccess()
        {
            string query = "INSERT INTO dbo.Prosta VALUES('-1/1/2/2');";
            string delete_query = "DELETE dbo.Prosta";
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
        public void TestDeleteProstaEmpty()
        {
            string delete_query = "DELETE dbo.Prosta";
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

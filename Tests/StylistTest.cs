using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
    public class StylistTest : IDisposable
    {
        public StylistTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void GetAll_StylistsEmptyAtFirst_true()
        {
            int result = Stylist.GetAll().Count;

            Assert.Equal(0, result);
        }

        [Fact]
        public void Equals_ReturnsTrueForSameName_true()
        {
            //Arrange, Act
            Stylist firstStylist = new Stylist("Betty", "curly", 3);
            Stylist secondStylist = new Stylist("Betty", "curly", 3);

            //Assert
            Assert.Equal(firstStylist, secondStylist);
        }

        [Fact]
        public void GetAllAndSave_ReturnListOfOneStylist_true()
        {
            Stylist firstStylist = new Stylist("Nancy", "updos", 5);
            firstStylist.Save();

            List<Stylist> testStylistList = new List<Stylist> {firstStylist};
            List<Stylist> resultStylistList = Stylist.GetAll();
            Assert.Equal(testStylistList, resultStylistList);
        }

        [Fact]
        public void GetAllAndSave_ReturnListOfMultipleStylists_true()
        {
            Stylist firstStylist = new Stylist("Nancy", "updos", 5);
            Stylist secondStylist = new Stylist("Karina", "men's hair", 6);
            firstStylist.Save();
            secondStylist.Save();

            List<Stylist> testStylistList = new List<Stylist> {firstStylist, secondStylist};
            List<Stylist> resultStylistList = Stylist.GetAll();
            Assert.Equal(testStylistList, resultStylistList);
        }

        [Fact]
        public void GetId_GetsIdForStylist_true()
        {
            //Arrange
            Stylist testStylist = new Stylist("Wanda", "natural hair", 12);
            testStylist.Save();

            //Act
            Stylist savedStylist = Stylist.GetAll()[0];

            int result = savedStylist.GetId();
            int testId = testStylist.GetId();

            //Assert
            Assert.Equal(testId, result);
        }

        [Fact]
        public void Find_FindsStylistInDatabase_true()
        {
            //Arrange
            Stylist testStylist = new Stylist("Aretha" ,"curly", 4);
            testStylist.Save();

            //Act
            Stylist foundStylist = Stylist.Find(testStylist.GetId());

            //Assert
            Assert.Equal(testStylist, foundStylist);
        }

        [Fact]
        public void FindByName_FindsStylistInDatabaseByName_true()
        {
           //Arrange
           Stylist testStylist = new Stylist("Wanda", "natural hair", 12);
           testStylist.Save();

           //Act
           Stylist foundStylist = Stylist.FindByName(testStylist.GetName());

           //Assert
           Assert.Equal(testStylist, foundStylist);
        }


        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
        }
    }
}

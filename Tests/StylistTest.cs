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
        public void GetClients_ReturnListOfClientsForSpecificStylist_true()
        {
            Stylist testStylist = new Stylist("Cath", "short hair", 7);
            testStylist.Save();

            Client firstClient = new Client("fred", testStylist.GetId());
            firstClient.Save();
            Client secondClient = new Client("betty", testStylist.GetId());
            secondClient.Save();


            List<Client> testClientList = new List<Client> {firstClient, secondClient};
            List<Client> resultClientList = testStylist.GetClients();

            Assert.Equal(testClientList, resultClientList);
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

        [Fact]
        public void UpdateProperties_UpdatePropertiesInDatabase_true()
        {
            //Arrange
            string name = "Darlene";
            string specialty = "color";
            int experience = 3;

            Stylist testStylist = new Stylist(name, specialty, experience);
            testStylist.Save();
            string newName = "Darla";
            string newSpecialty = "highlights";
            int newExperience = 4;

            //Act
            testStylist.UpdateProperties(newName, newSpecialty, newExperience);
            Stylist result = Stylist.GetAll()[0];

            //Assert
            Assert.Equal(testStylist, result);
            Assert.Equal(newName, result.GetName());
        }

        [Fact]
        public void DeleteStylist_DeleteStylistInDatabase_true()
        {
            //Arrange
            string name1 = "Mira";
            string specialty1 = "curls";
            int experience1 = 7;
            Stylist testStylist1 = new Stylist(name1, specialty1, experience1);
            testStylist1.Save();

            string name2 = "Macklemore";
            string specialty2 = "flat tops, fades";
            int experience2 = 4;
            Stylist testStylist2 = new Stylist(name2, specialty2, experience2);
            testStylist2.Save();

            //Act
            testStylist1.Delete();
            List<Stylist> resultStylists = Stylist.GetAll();
            List<Stylist> testStylistList = new List<Stylist> {testStylist2};

            //Assert
            Assert.Equal(testStylistList, resultStylists);

        }

        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
        }
    }
}

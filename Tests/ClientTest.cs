using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
    public class ClientTest : IDisposable
    {
        public ClientTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void GetAll_ClientsEmptyAtFirst_true()
        {
            int result = Client.GetAll().Count;

            Assert.Equal(0, result);
        }

        [Fact]
        public void Equals_ReturnsTrueForSameName_true()
        {
            //Arrange, Act
           Client firstClient = new Client("Bob", 1);
           Client secondClient = new Client("Bob", 1);

           //Assert
           Assert.Equal(firstClient, secondClient);
        }

        [Fact]
        public void Save_TestIfClientSaved_true()
        {
            Client testClient = new Client("Bill", 1);
            testClient.Save();

            List<Client> allClientList = new List<Client>{testClient};

            List<Client> result = Client.GetAll();
            List<Client> testList = new List<Client>{testClient};

            Assert.Equal(testList, result);
        }

        [Fact]
        public void GetId_GetsIdForClient_true()
        {
            //Arrange
            Client testClient = new Client("Albert", 2);
            testClient.Save();

            //Act
            Client savedClient = Client.GetAll()[0];

            int result = savedClient.GetId();
            int testId = testClient.GetId();

            //Assert
            Assert.Equal(testId, result);
        }

        [Fact]
        public void GetAll_ReturnListOfAllClients_true()
        {
            Client firstClient = new Client("Bob", 3);
            Client secondClient = new Client("Bill", 1);
            firstClient.Save();
            secondClient.Save();

            List<Client> testClientList = new List<Client> {firstClient, secondClient};
            List<Client> resultClientList = Client.GetAll();
            Assert.Equal(testClientList, resultClientList);
        }

        [Fact]
        public void Find_FindsClientInDatabaseById_true()
        {
            //Arrange
            Client testClient = new Client("Alexandra", 2);
            testClient.Save();

            //Act
            Client foundClient = Client.Find(testClient.GetId());

            //Assert
            Assert.Equal(testClient, foundClient);
        }

        [Fact]
        public void Find_FindsClientInDatabaseByName_true()
        {
           //Arrange
           Client testClient = new Client("Hannah", 21);
           testClient.Save();

           //Act
           Client foundClient = Client.FindByName(testClient.GetName());

           //Assert
           Assert.Equal(testClient, foundClient);
        }

        [Fact]
        public void UpdateName_UpdateNameInDatabase_true()
        {
            //Arrange
            string name = "Darlene";

            Client testClient = new Client(name, 1);
            testClient.Save();
            string newName = "Edna";

            //Act
            testClient.UpdateName(newName);
            Client result = Client.GetAll()[0];

            //Assert
            Assert.Equal(testClient, result);
            Assert.Equal(newName, result.GetName());
        }

        [Fact]
        public void DeleteClient_DeleteClientInDatabase_true()
        {
            //Arrange
            string name1 = "Hannah";
            Client testClient1 = new Client(name1, 1);
            testClient1.Save();

            string name2 = "John";
            Client testClient2 = new Client(name2, 2);
            testClient2.Save();

            //Act
            testClient1.Delete();
            List<Client> resultClients = Client.GetAll();
            List<Client> testClientList = new List<Client> {testClient2};

            //Assert
            Assert.Equal(testClientList, resultClients);

        }


        public void Dispose()
       {
           Client.DeleteAll();
       }
    }
}

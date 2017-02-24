using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
    public class HairSalonTest : IDisposable
    {
        public HairSalonTest()
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




        public void Dispose()
        {
            Stylist.DeleteAll();
            // Client.DeleteAll();
        }
    }
}

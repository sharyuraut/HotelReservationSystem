using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;

namespace HotelReservationSystemTest
{
    [TestClass]
    public class UnitTest1
    {
        HotelOperations hotelSystem = new HotelOperations();

        //UC 1
        [TestMethod]
        public void Given_NameAndRegularRates_Add_Hotel_To_List()
        {
            string hotelName = "HotelB";
            int ratesForRegularCustomer = 200;

            hotelSystem.AddHotel(new Hotel(hotelName, ratesForRegularCustomer));

            Assert.AreEqual(2, hotelSystem.hotelList.Count);
        }
    }
}

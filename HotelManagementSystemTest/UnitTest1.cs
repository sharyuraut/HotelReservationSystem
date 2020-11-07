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

            Assert.AreEqual(1, hotelSystem.hotelList.Count);
        }

        //UC 2.1 - Happy test
        [TestMethod]
        public void Given_ValidDate_Should_Return_CheapestHotel()
        {
            hotelSystem.AddHotel(new Hotel("HotelA", 100));
            hotelSystem.AddHotel(new Hotel("HotelB", 200));
            hotelSystem.AddHotel(new Hotel("HotelC", 300));
            hotelSystem.AddHotel(new Hotel("HotelD", 150));
            hotelSystem.AddHotel(new Hotel("HotelE", 500));
            string[] dates = "01-01-2021 10-01-2021".Split(" ");

            Hotel cheapestHotel = hotelSystem.FindCheapestHotel(dates);

            Assert.AreEqual("HotelA", cheapestHotel.Hotelname);
        }
    }
}

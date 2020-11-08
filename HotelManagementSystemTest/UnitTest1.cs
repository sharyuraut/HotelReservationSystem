using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;

namespace HotelReservationSystemTest
{
    [TestClass]
    public class UnitTest1
    {
        readonly HotelOperations hotelOperations = new HotelOperations();

        //UC 1
        [TestMethod]
        public void Given_NameAndRegularRates_Add_Hotel_To_List()
        {
            string hotelName = "HotelB";
            int ratesForCustomerWeekday = 200;
            int ratesForCustomerWeekend = 600;

            hotelOperations.AddHotel(new Hotel(hotelName, ratesForCustomerWeekday, ratesForCustomerWeekend));

            Assert.AreEqual(1, hotelOperations.hotelList.Count);
        }

        //UC 2.1 - Happy test
        [TestMethod]
        public void Given_ValidDate_Should_Return_CheapestHotel()
        {
            hotelOperations.AddHotel(new Hotel("HotelA", 100, 150));
            hotelOperations.AddHotel(new Hotel("HotelB", 200, 600));
            hotelOperations.AddHotel(new Hotel("HotelC", 300, 1000));
            hotelOperations.AddHotel(new Hotel("HotelD", 150, 180));
            hotelOperations.AddHotel(new Hotel("HotelE", 500, 800));
            string[] dates = "01-01-2021 10-01-2021".Split(" ");

            Hotel cheapestHotel = hotelOperations.FindCheapestHotel(dates);

            Assert.AreEqual("HotelA", cheapestHotel.Hotelname);
        }


        //UC2.2 given invalid date should throw exception
        [TestMethod]
        [DataRow("")]
        [DataRow("01-01-2020-10-01-2020")]
        public void Given_InvalidDates_Should_Return_HotelReservationException(string date)
        {
            hotelOperations.AddHotel(new Hotel("HotelA", 100, 150));
            hotelOperations.AddHotel(new Hotel("HotelB", 200, 600));
            hotelOperations.AddHotel(new Hotel("HotelC", 300, 1000));
            hotelOperations.AddHotel(new Hotel("HotelD", 150, 180));
            hotelOperations.AddHotel(new Hotel("HotelE", 500, 800));
            string[] dates = date.Split(" ");

            var exception = Assert.ThrowsException<HotelReservationExceptions>(() => hotelOperations.FindCheapestHotel(dates));

            Assert.AreEqual(HotelReservationExceptions.ExceptionType.INVALID_DATE_FORMAT, exception.type);
        }


        //UC2.2 given null as date should throw exception
        [TestMethod]
        public void Given_NullDates_Should_Return_HotelReservationException()
        {
            hotelOperations.AddHotel(new Hotel("HotelA", 100, 150));
            hotelOperations.AddHotel(new Hotel("HotelB", 200, 600));
            hotelOperations.AddHotel(new Hotel("HotelC", 300, 1000));
            hotelOperations.AddHotel(new Hotel("HotelD", 150, 180));
            hotelOperations.AddHotel(new Hotel("HotelE", 500, 800));
            string[] dates = null;

            var exception = Assert.ThrowsException<HotelReservationExceptions>(() => hotelOperations.FindCheapestHotel(dates));

            Assert.AreEqual(HotelReservationExceptions.ExceptionType.NULL_DATES, exception.type);
        }
    }
}

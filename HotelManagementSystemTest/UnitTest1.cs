using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;
using System.Collections.Generic;

namespace HotelReservationSystemTest
{
    [TestClass]
    public class UnitTest1
    {
        readonly HotelOperations hotelOperations = new HotelOperations(CustomerType.REGULAR);

        //UC 1
        [TestMethod]
        public void Given_NameAndRegularRates_Add_Hotel_To_List()
        {
            string hotelName = "Bridgewood";
            int ratesForRegularCustomerWeekday = 110;
            int ratesForRegularCustomerWeekend = 90;

            int ratesForRewardCustomerWeekday = 80;
            int ratesForRewardCustomerWeekend = 80;

            int ratings = 5;

            hotelOperations.AddHotel(new Hotel(hotelName, ratesForRegularCustomerWeekday, ratesForRegularCustomerWeekend, ratings, ratesForRewardCustomerWeekday, ratesForRewardCustomerWeekend));

            Assert.AreEqual(1, hotelOperations.hotelList.Count);
        }

        //UC 2.1 - Happy test
        [TestMethod]
        public void Given_ValidDate_Should_Return_CheapestHotel()
        {
            hotelOperations.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelOperations.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelOperations.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));
            string[] dates = "13Nov2020 14Nov2020".Split(" ");    //Friday,Saturday

            Hotel[] cheapestHotel = hotelOperations.FindCheapestHotel(dates).ToArray();

            Assert.AreEqual("Lakewood", cheapestHotel[0].Hotelname);
            Assert.AreEqual(2, cheapestHotel.Length);
        }


        //UC2.2 given invalid date should throw exception
        [TestMethod]
        [DataRow("")]
        [DataRow("01-01-2020-10-01-2020")]
        public void Given_InvalidDates_Should_Return_HotelReservationException(string date)
        {
            hotelOperations.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelOperations.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelOperations.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));
            string[] dates = date.Split(" ");

            var exception = Assert.ThrowsException<HotelReservationExceptions>(() => hotelOperations.FindCheapestHotel(dates));

            Assert.AreEqual(HotelReservationExceptions.ExceptionType.INVALID_DATE_FORMAT, exception.type);
        }


        //UC2.3 given null as date should throw exception
        [TestMethod]
        public void Given_NullDates_Should_Return_HotelReservationException()
        {
            hotelOperations.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelOperations.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelOperations.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));
            string[] dates = null;

            var exception = Assert.ThrowsException<HotelReservationExceptions>(() => hotelOperations.FindCheapestHotel(dates));

            Assert.AreEqual(HotelReservationExceptions.ExceptionType.NULL_DATES, exception.type);
        }

        //UC 4
        [TestMethod]
        [DataRow("11Nov2018 12Nov2018")]
        [DataRow("13Nov2020 11Nov2020")]
        public void Given_InvalidDate_Should_Return_HotelReservationException(string date)
        {
            hotelOperations.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelOperations.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelOperations.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));
            string[] dates = date.Split(" ");

            var exception = Assert.ThrowsException<HotelReservationExceptions>(() => hotelOperations.FindCheapestHotel(dates));

            Assert.AreEqual(HotelReservationExceptions.ExceptionType.INVALID_DATE, exception.type);
        }

        [TestMethod]
        public void Given_ValidDate_Should_Return_CheapestBestRatedHotel()
        {
            hotelOperations.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelOperations.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelOperations.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));
            string[] dates = "13Nov2020,14Nov2020".Split(",");    //Friday,Saturday

            Hotel[] cheapestHotel = hotelOperations.FindCheapestBestRatedHotel(dates).ToArray();

            Assert.AreEqual(1, cheapestHotel.Length);
            Assert.AreEqual("Bridgewood", cheapestHotel[0].Hotelname);
        }

        [TestMethod]
        public void Given_ValidDate_Should_Return_BestRatedHotel()
        {
            hotelOperations.AddHotel(new Hotel("Lakewood", 110, 90, 80, 80, 3));
            hotelOperations.AddHotel(new Hotel("Bridgewood", 150, 50, 110, 150, 4));
            hotelOperations.AddHotel(new Hotel("Ridgewood", 220, 150, 100, 40, 5));
            string[] dates = "13Nov2020 14Nov2020".Split(" ");    //Friday,Saturday

            Hotel[] bestRatedHotel = hotelOperations.FindBestRatedHotel(dates).ToArray();

            Assert.AreEqual(1, bestRatedHotel.Length);
            Assert.AreEqual("Bridgewood", bestRatedHotel[0].Hotelname);
        }
    }
}

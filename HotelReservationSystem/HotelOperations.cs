using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelOperations
    {
        public List<Hotel> hotelList;
        readonly DateValidation dateValidation = new DateValidation();

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelOperations"/> class.
        /// </summary>
        public HotelOperations()
        {
            hotelList = new List<Hotel>();
        }

        /// <summary>
        /// Adds the hotel.
        /// </summary>
        /// <param name="hotel">The hotel.</param>
        public void AddHotel(Hotel hotel)
        {
            hotelList.Add(hotel);
        }

        /// <summary>
        /// Finds the cheapest hotel.
        /// </summary>
        /// <param name="dates">The dates.</param>
        /// <returns></returns>
        public Hotel FindCheapestHotel(string[] dates)
        {
            DateTime[] validatedDates = dateValidation.ValidateDates(dates);
            hotelList.Sort((e1, e2) => e1.ratesForCustomerWeekday.CompareTo(e2.ratesForCustomerWeekday));
            return hotelList.First();
        }
    }
}

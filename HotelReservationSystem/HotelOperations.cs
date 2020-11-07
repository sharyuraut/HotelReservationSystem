using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelOperations
    {
        public List<Hotel> hotelList;

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
    }
}

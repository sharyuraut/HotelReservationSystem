namespace HotelReservationSystem
{
    public class Hotel
    {
        public string Hotelname;
        public int ratesForCustomerWeekday;
        public int ratesForCustomerWeekend;
        public int ratings;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hotel"/> class.
        /// </summary>
        public Hotel()
        {
            Hotelname = "";
            ratesForCustomerWeekday = 0;
            ratesForCustomerWeekend = 0;
            ratings = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hotel"/> class.
        /// </summary>
        /// <param name="Hotelname">The hotelname.</param>
        /// <param name="ratesForCustomerWeekday">The rates for customer weekday.</param>
        /// <param name="ratesForCustomerWeekend">The rates for customer weekend.</param>
        /// <param name="ratings">The ratings.</param>
        public Hotel(string Hotelname, int ratesForCustomerWeekday, int ratesForCustomerWeekend, int ratings)
        {
            this.Hotelname = Hotelname;
            this.ratesForCustomerWeekday = ratesForCustomerWeekday;
            this.ratesForCustomerWeekday = ratesForCustomerWeekend;
            this.ratings = ratings;
        }
    }
}
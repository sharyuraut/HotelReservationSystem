namespace HotelReservationSystem
{
    public class Hotel
    {
        public string Hotelname;
        public int ratesForCustomerWeekday;
        public int ratesForCustomerWeekend;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hotel"/> class.
        /// </summary>
        public Hotel()
        {
            Hotelname = "";
            ratesForCustomerWeekday = 0;
            ratesForCustomerWeekend = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hotel"/> class.
        /// </summary>
        /// <param name="Hotelname">The hotelname.</param>
        /// <param name="ratesForCustomerWeekday">The rates for customer weekday.</param>
        /// <param name="ratesForCustomerWeekend">The rates for customer weekend.</param>
        public Hotel(string Hotelname, int ratesForCustomerWeekday, int ratesForCustomerWeekend)
        {
            this.Hotelname = Hotelname;
            this.ratesForCustomerWeekday = ratesForCustomerWeekday;
            this.ratesForCustomerWeekday = ratesForCustomerWeekend;
        }
    }
}
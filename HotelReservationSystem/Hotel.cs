namespace HotelReservationSystem
{
    public class Hotel
    {
        public string Hotelname;
        public int ratesForCustomer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hotel"/> class.
        /// </summary>
        public Hotel()
        {
            Hotelname = "";
            ratesForCustomer = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hotel"/> class.
        /// </summary>
        /// <param name="Hotelname">The hotelname.</param>
        /// <param name="ratesForRegularCustomer">The rates for regular customer.</param>
        public Hotel(string Hotelname, int ratesForRegularCustomer)
        {
            this.Hotelname = Hotelname;
            this.ratesForCustomer = ratesForRegularCustomer;
        }
    }
}
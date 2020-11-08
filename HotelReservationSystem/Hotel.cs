namespace HotelReservationSystem
{
    public class Hotel
    {
        public string Hotelname;
        public int ratesForRegularCustomerWeekday;
        public int ratesForRegularCustomerWeekend;

        public int ratesForRewardCustomerWeekday;
        public int ratesForRewardCustomerWeekend;

        public int ratings;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hotel"/> class.
        /// </summary>
        public Hotel()
        {
            Hotelname = "";
            ratesForRegularCustomerWeekday = 0;
            ratesForRegularCustomerWeekend = 0;

            ratesForRewardCustomerWeekday = 0;
            ratesForRewardCustomerWeekend = 0;
            ratings = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hotel"/> class.
        /// </summary>
        /// <param name="Hotelname">The hotelname.</param>
        /// <param name="ratesForRegularCustomerWeekday">The rates for customer weekday.</param>
        /// <param name="ratesForRegularCustomerWeekend">The rates for customer weekend.</param>
        /// <param name="ratings">The ratings.</param>
        public Hotel(string Hotelname, int ratesForRegularCustomerWeekday, int ratesForRegularCustomerWeekend, int ratings , int ratesForRewardCustomerWeekday, int ratesForRewardCustomerWeekend)
        {
            this.Hotelname = Hotelname;
            this.ratesForRegularCustomerWeekday = ratesForRegularCustomerWeekday;
            this.ratesForRegularCustomerWeekend = ratesForRegularCustomerWeekend;

            this.ratesForRewardCustomerWeekday = ratesForRewardCustomerWeekday;
            this.ratesForRewardCustomerWeekend = ratesForRewardCustomerWeekend;
            this.ratings = ratings;
        }
    }
}
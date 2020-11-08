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
        int no_of_weekdays = 0;
        int no_of_weekends = 0;

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

        public static void UserInput(HotelOperations hotelOperations)
        {
            try
            {
                Console.WriteLine("Enter dates in dd-mm-yyyy format");
                string[] dates = Console.ReadLine().Split(" ");

                Hotel[] cheapestHotels = hotelOperations.FindCheapestHotel(dates).ToArray();
                Console.WriteLine("Cheapest Hotel :");

                hotelOperations.DisplayHotels(cheapestHotels);
            }
            catch (HotelReservationExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Finds the cheapest hotel.
        /// </summary>
        /// <param name="dates">The dates.</param>
        /// <returns></returns>
        public List<Hotel> FindCheapestHotel(string[] dates)
        {
            int i = 0;
            int rate = 0;
            List<Hotel> cheapestHotels = new List<Hotel>();

            DateTime[] validatedDates = dateValidation.ValidateDates(dates);
            SetWeekendsAndWeekdays(validatedDates);

            foreach (Hotel hotel in hotelList)
            {
                int totalRate = CalculateTotalRate(hotel);
                i++;
                if (i == 1)
                    rate = totalRate;
                if (totalRate == rate)
                    cheapestHotels.Add(hotel);
                if (totalRate < rate)
                {
                    rate = totalRate;
                    cheapestHotels.Clear();
                    cheapestHotels.Add(hotel);
                }
            }
            return cheapestHotels;
        }

        public void SetWeekendsAndWeekdays(DateTime[] dates)
        {
            no_of_weekends = 0; no_of_weekdays = 0;
            foreach (DateTime date in dates)
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    no_of_weekends++;
                else
                    no_of_weekdays++;
            }
        }

        public int CalculateTotalRate(Hotel hotel)
        {
            return (no_of_weekdays * hotel.ratesForCustomerWeekday) + (no_of_weekends * hotel.ratesForCustomerWeekend);
        }

        private void DisplayHotels(Hotel[] hotels)
        {
            for (int i = 1; i <= hotels.Length; i++)
            {
                Console.WriteLine(i + ". " + hotels[i - 1].Hotelname);
            }
            Console.WriteLine("Rate :" + CalculateTotalRate(hotels[0]));
        }
    }
}

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
        public CustomerType ctype;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelOperations"/> class.
        /// </summary>
        public HotelOperations(CustomerType ctype)
        {
            this.ctype = ctype;
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
        /// Users the input.
        /// </summary>
        /// <param name="hotelOperations">The hotel operations.</param>
        public static void UserInput(HotelOperations hotelOperations)
        {
            try
            {
                bool flag = true;

                Console.WriteLine("Enter customer type :1.REGULAR  2.REWARD");
                Console.WriteLine("...................................");

                int customerChoice = Convert.ToInt32(Console.ReadLine());

                if (customerChoice == 1)
                    hotelOperations.ctype = CustomerType.REGULAR;
                else if (customerChoice == 2)
                    hotelOperations.ctype = CustomerType.REWARD;
                else
                    throw new HotelReservationExceptions(HotelReservationExceptions.ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid Customer Type");
                Console.WriteLine("Enter dates in dd-mm-yyyy format");
                string[] dates = Console.ReadLine().Split(" ");

                Console.WriteLine("Choose One:\n 1.Find cheapest hotel\t 2. Find cheapest and best rated hotel \t 3.Best rated hotel");
                while (flag)
                {
                    int choice = Convert.ToInt32( Console.ReadLine());               
                    switch (choice)
                    {
                        case 1:
                            flag = false;
                            Hotel[] cheapestHotels = hotelOperations.FindCheapestHotel(dates).ToArray();
                            Console.WriteLine("Cheapest Hotel :");
                            hotelOperations.DisplayHotels(cheapestHotels);
                            break;

                        case 2:
                            flag = false;
                            Hotel[] cheapestBestRatedHotels = hotelOperations.FindCheapestBestRatedHotel(dates).ToArray();
                            Console.WriteLine("Cheapest And Best Rated Hotel :");
                            hotelOperations.DisplayHotels(cheapestBestRatedHotels);
                            break;

                        case 3:
                            flag = false;
                            Hotel[] bestRatedHotel = hotelOperations.FindBestRatedHotel(dates).ToArray();
                            Console.WriteLine("Best rated hotel is: ");
                            hotelOperations.DisplayHotels(bestRatedHotel);
                            break;

                        default:
                            flag = true;
                            Console.WriteLine("Enter Valid Choice.");
                            break;
                    }
                }
            }
            catch (HotelReservationExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Hotel> FindBestRatedHotel(string[] dates)
        {
            DateTime[] validatedDates = dateValidation.ValidateDates(dates);
            SetWeekendsAndWeekdays(validatedDates);

            hotelList.Sort((e1, e2) => e1.ratings.CompareTo(e2.ratings));
            int highestRating = hotelList.Last().ratings;
            return hotelList.FindAll(e => e.ratings == highestRating);
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

        /// <summary>
        /// Finds the cheapest best rated hotel.
        /// </summary>
        /// <param name="dates">The dates.</param>
        /// <returns></returns>
        public List<Hotel> FindCheapestBestRatedHotel(string[] dates)
        {
            List<Hotel> cheapestHotels = FindCheapestHotel(dates);
            cheapestHotels.Sort((e1, e2) => e1.ratings.CompareTo(e2.ratings));
            int highestRating = cheapestHotels.Last().ratings;
            return cheapestHotels.FindAll(e => e.ratings == highestRating);
        }

        /// <summary>
        /// Sets the weekends and weekdays.
        /// </summary>
        /// <param name="dates">The dates.</param>
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

        /// <summary>
        /// Calculates the total rate.
        /// </summary>
        /// <param name="hotel">The hotel.</param>
        /// <returns></returns>
        public int CalculateTotalRate(Hotel hotel)
        {
            if (ctype == CustomerType.REGULAR)
                return (no_of_weekdays * hotel.ratesForRegularCustomerWeekday) + (no_of_weekends * hotel.ratesForRegularCustomerWeekend);
            else
                return (no_of_weekdays * hotel.ratesForRegularCustomerWeekday) + (no_of_weekends * hotel.ratesForRegularCustomerWeekend);
        }

        /// <summary>
        /// Displays the hotels.
        /// </summary>
        /// <param name="hotels">The hotels.</param>
        private void DisplayHotels(Hotel[] hotels)
        {
            for (int i = 1; i <= hotels.Length; i++)
            {
                Console.WriteLine(hotels[i - 1].Hotelname);
            }
            Console.WriteLine("Rate :" + CalculateTotalRate(hotels[0]));
            Console.WriteLine("Rating: " + hotels[0].ratings);
        }
    }
}

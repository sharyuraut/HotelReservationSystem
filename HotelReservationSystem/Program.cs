using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation Syatem!!");
            
            //Adding Hotels to the list
            HotelOperations hotelSystem = new HotelOperations();
            hotelSystem.AddHotel(new Hotel("HotelA", 100));
            hotelSystem.AddHotel(new Hotel("HotelB", 200));
            hotelSystem.AddHotel(new Hotel("HotelC", 300));
            hotelSystem.AddHotel(new Hotel("HotelD", 150));
            hotelSystem.AddHotel(new Hotel("HotelE", 500));

            Console.WriteLine("------Names of Hotels added------");

            //Finding cheapest hotel
            try
            {
                Console.WriteLine("Enter dates in dd-mm-yyyy format");
                string[] dates = Console.ReadLine().Split(" ");

                Hotel cheapestHotel = hotelSystem.FindCheapestHotel(dates);
                Console.WriteLine("The Cheapest Hotel during the given dates is :");
                Console.WriteLine("Hotel Name: " + cheapestHotel.Hotelname + " ,Charges per day: " +cheapestHotel.ratesForCustomer);
            }
            catch (HotelReservationExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

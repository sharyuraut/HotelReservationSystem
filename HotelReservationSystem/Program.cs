using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation Syatem!!");
            
            //Adding Hotels to the list
            HotelOperations hotelOperations = new HotelOperations();
            hotelOperations.AddHotel(new Hotel("HotelA", 100,150));
            hotelOperations.AddHotel(new Hotel("HotelB", 200,600));
            hotelOperations.AddHotel(new Hotel("HotelC", 300,1000));
            hotelOperations.AddHotel(new Hotel("HotelD", 150,180));
            hotelOperations.AddHotel(new Hotel("HotelE", 500,800));

            Console.WriteLine("------Names of Hotels added------");

            //Finding cheapest hotel
            try
            {
                Console.WriteLine("Enter dates in dd-mm-yyyy format");
                string[] dates = Console.ReadLine().Split(" ");

                Hotel cheapestHotel = hotelOperations.FindCheapestHotel(dates);
                Console.WriteLine("The Cheapest Hotel during the given dates is :");
                Console.WriteLine("Hotel Name: " + cheapestHotel.Hotelname + " ,Charges per day: " +cheapestHotel.ratesForCustomerWeekday);
            }
            catch (HotelReservationExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

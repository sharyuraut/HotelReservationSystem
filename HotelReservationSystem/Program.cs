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
            hotelOperations.AddHotel(new Hotel("Lakewood", 110, 90, 3));
            hotelOperations.AddHotel(new Hotel("Bridgewood", 150, 50, 4));
            hotelOperations.AddHotel(new Hotel("Ridgewood", 220, 150, 5));

            Console.WriteLine("------Names of Hotels added------");

           HotelOperations.UserInput(hotelOperations);
        }
    }
}

using System;
using System.Runtime.Serialization;

namespace HotelReservationSystem
{
    [Serializable]
    internal class HotelReservationExceptions : Exception
    {
        public enum ExceptionType
        {
            INVALID_DATE,
            NULL_DATES,
            INVALID_DATE_FORMAT,
        }
        public ExceptionType type;

        public HotelReservationExceptions(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
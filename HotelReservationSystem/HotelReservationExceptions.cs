using System;
using System.Runtime.Serialization;

namespace HotelReservationSystem
{
    [Serializable]
    public class HotelReservationExceptions : Exception
    {
        /// <summary>
        /// enum for exceptions types
        /// </summary>
        public enum ExceptionType
        {
            INVALID_DATE,
            NULL_DATES,
            INVALID_DATE_FORMAT,
        }
        public ExceptionType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelReservationExceptions"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="message">The message.</param>
        public HotelReservationExceptions(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
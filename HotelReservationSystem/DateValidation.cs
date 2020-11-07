using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    class DateValidation
    {
        public DateTime[] ValidateDates(string[] Dates)
        {
            if (Dates == null)
            {
                throw new HotelReservationExceptions(HotelReservationExceptions.ExceptionType.NULL_DATES, "Dates are null");
            }
            DateTime startDate = ConvertToDate(Dates[0]);
            DateTime endDate = ConvertToDate(Dates[1]);
            if (startDate > endDate || startDate < DateTime.Today)
            {
                throw new HotelReservationExceptions(HotelReservationExceptions.ExceptionType.INVALID_DATE, "Dates are invalid");
            }

            TimeSpan t = endDate.Date - startDate.Date;
            int noOfDays = t.Days + 1;
            DateTime[] datesValidated = new DateTime[noOfDays];

            for (int i = 0; i < noOfDays; i++)
            {
                datesValidated[i] = startDate.AddDays(i);
            }

            return datesValidated;
        }

        public DateTime ConvertToDate(string givenDates)
        {
            try
            {
                DateTime date = DateTime.Parse(givenDates);
                return date;
            }
            catch (FormatException)
            {
                throw new HotelReservationExceptions(HotelReservationExceptions.ExceptionType.INVALID_DATE_FORMAT, "Date Format is Invalid");
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace MyWebAPICore.DataAccess
{
    public interface IAccessMeterReadings
    {
        bool isValidMeterReadingData(int accId,DateTime dVal, string mrVal, out int mrReadingValue);
        IEnumerable<MeterReading> GetMeterReadings();
         void AddMeterReading(MeterReading mrVal);
    }
}
using System;
using System.Globalization;
using System.IO;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using MyWebAPICore.DataAccess;

namespace MyWebAPICore.Service
{
    public class StorageService : IStorageService
    {
        private readonly IAccessMeterReadings _accessMeterReadings;

        public StorageService(IAccessMeterReadings accessMeterReadings)
        {
            _accessMeterReadings = accessMeterReadings;
        }
        public string Upload(IFormFile file)
        { 
            using (Stream stream = file.OpenReadStream())
            using (StreamReader streamReader = new StreamReader(stream))
            {

                using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);
                var meterReadings = csvReader.GetRecords<MeterReadingRecord>();
                
                int successfulReadings=0;
                int unsuccessfulReadings = 0;
                foreach (var mr in meterReadings)
                {  
                    int mrValue = 0;
                    if (_accessMeterReadings.isValidMeterReadingData(mr.AccountId,mr.MeterReadingDateTime,mr.MeterReadValue, out mrValue))
                    {
                        successfulReadings++;
                        var mrData = new MeterReading{
                        AccountId = mr.AccountId,
                        MeterReadingDateTime = mr.MeterReadingDateTime,
                        MeterReadValue = mrValue
                        };
                        _accessMeterReadings.AddMeterReading(mrData);
                    }
                    else    
                        unsuccessfulReadings++;
                }
                return $"successful meter readings {successfulReadings} unsuccessful meter readings {unsuccessfulReadings}";
                
            }
        }
        public record MeterReadingRecord(int AccountId, DateTime MeterReadingDateTime, string MeterReadValue);
    }
}


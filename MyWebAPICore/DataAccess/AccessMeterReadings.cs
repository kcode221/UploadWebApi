using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyWebAPICore.DataAccess;

namespace MyWebAPICore
{
    public class AccessMeterReadings : IAccessMeterReadings
    {   
        private readonly IAccessAccounts _accessAccounts;
        private readonly EnergyDbContext _energyDbContext;

        public AccessMeterReadings(EnergyDbContext energyDbContext, IAccessAccounts accessAccounts)
        {
            _energyDbContext = energyDbContext;
            _accessAccounts = accessAccounts;
        }
        public bool isValidMeterReadingData(int accId,DateTime dVal, string mrVal, out int mrReadingValue)
        {
            int mrValue = 0;
            mrReadingValue = mrValue;
            bool isMeterReadingNumeric = int.TryParse(mrVal, out mrValue);
            if (isMeterReadingNumeric && mrValue >=0)
            {
                mrReadingValue = mrValue;
            //check if meter reading already exists
                
                if (_accessAccounts.GetAccount(accId)== null)
                    return false;

                var mrData = new MeterReading{
                    AccountId = accId,
                    MeterReadingDateTime = dVal,
                    MeterReadValue = mrValue
                };
                if (CountMeterReading(mrData) > 0)
                    return false;

                return true;
            }
            return false;
        }

        public void AddMeterReading(MeterReading mrVal)
        {
                _energyDbContext.MeterReadings.Add(new MeterReading{
                    AccountId = mrVal.AccountId,
                    MeterReadingDateTime = mrVal.MeterReadingDateTime,
                    MeterReadValue = mrVal.MeterReadValue
                });
                _energyDbContext.SaveChanges();
        }
        private int CountMeterReading(MeterReading mrVal)
        {
                return _energyDbContext.MeterReadings
                .Where(mr=>mr.AccountId == mrVal.AccountId
                && mr.MeterReadingDateTime == mrVal.MeterReadingDateTime
                && mr.MeterReadValue == mrVal.MeterReadValue).Count();
        }

        public IEnumerable<MeterReading> GetMeterReadings() => _energyDbContext.MeterReadings.ToArray();

    }
}
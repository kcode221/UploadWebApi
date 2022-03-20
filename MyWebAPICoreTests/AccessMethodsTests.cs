using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyWebAPICore;
using Xunit;
using Newtonsoft.Json;

namespace MyWebAPICoreTests
{
    public class AccessMethodsTests : IClassFixture<DatabaseFixture>
    {
        private AccessAccounts _accessAccounts;

        private AccessMeterReadings _accessMeterReadings;
        public AccessMethodsTests(DatabaseFixture fixture)
        {
            _accessAccounts = new AccessAccounts(fixture.testDb);
            _accessMeterReadings = new AccessMeterReadings(fixture.testDb, new AccessAccounts(fixture.testDb));          
        }

        [Fact]
        public void GetAccountsTest()
        {
                var accounts = _accessAccounts.GetAccounts().ToArray();
                Assert.Equal(3, accounts.Length);
        }

        [Fact]
        public void GetAccountTest()
        {
                
                var account = _accessAccounts.GetAccount(3);
                var account3 = new Account {AccountId = 3, FirstName = "FirstName 3", LastName = "LastName 3"};
                var account1Str = JsonConvert.SerializeObject(account);
                var account2Str = JsonConvert.SerializeObject(account3);               
                Assert.Equal(account1Str,account2Str);
        }

        [Fact]
        public void GetmeterReadingsTest()
        {
                var meterReadings = _accessMeterReadings.GetMeterReadings().ToArray();
                Assert.Equal(3, meterReadings.Length);
        }

        [Fact]
        public void IsMeterReadingDataValidTest()
        {
                var invalidMeterReading = new MeterReading {AccountId = 3, MeterReadingDateTime = DateTime.Now, MeterReadValue = 1001};
                var isValid = _accessMeterReadings.isValidMeterReadingData(invalidMeterReading.AccountId,
                                                    invalidMeterReading.MeterReadingDateTime,
                                                    invalidMeterReading.MeterReadValue.ToString(), out int mrValue);              
                Assert.True(isValid);
        }

        [Fact]
        public void IsMeterReadingDataInValidTest()
        {
                var invalidMeterReading = new MeterReading {AccountId = 8, MeterReadingDateTime = DateTime.Now, MeterReadValue = 1001};
                var isValid = _accessMeterReadings.isValidMeterReadingData(invalidMeterReading.AccountId,
                                                    invalidMeterReading.MeterReadingDateTime,
                                                    invalidMeterReading.MeterReadValue.ToString(), out int mrValue);              
                Assert.False(isValid);
        }
    }
}

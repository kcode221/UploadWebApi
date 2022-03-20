using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyWebAPICore;
using Xunit;

public class DatabaseFixture : IDisposable
{
    public DatabaseFixture()
    {
        var options = new DbContextOptionsBuilder<EnergyDbContext>()
            .UseInMemoryDatabase(databaseName: "EnergyDatabase")
            .Options;

            // Insert seed data into the database using one instance of the context
            testDb = new EnergyDbContext(options);
        // ... initialize data in the test database ...
            testDb.Accounts.Add(new Account {AccountId = 1, FirstName = "FirstName 1", LastName = "LastName 1"});
            testDb.Accounts.Add(new Account {AccountId = 2, FirstName = "FirstName 2", LastName = "LastName 2"});
            testDb.Accounts.Add(new Account {AccountId = 3, FirstName = "FirstName 3", LastName = "LastName 3"});
            
            testDb.MeterReadings.Add(new MeterReading {MeterReadingId = 1, AccountId = 1, MeterReadingDateTime = DateTime.Now, MeterReadValue = 1001});
            testDb.MeterReadings.Add(new MeterReading {MeterReadingId = 2, AccountId = 2, MeterReadingDateTime = DateTime.Now.AddDays(-1), MeterReadValue = 1002});
            testDb.MeterReadings.Add(new MeterReading {MeterReadingId = 3, AccountId = 3, MeterReadingDateTime = DateTime.Now.AddDays(-2), MeterReadValue = 1003});
            
            testDb.SaveChanges();

    }

    public void Dispose()
    {
        // ... clean up test data from the database ...
        testDb.Dispose();
    }

    public EnergyDbContext testDb { get; private set; }
}
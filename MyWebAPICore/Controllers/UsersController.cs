using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyWebAPICore.DataAccess;

namespace MyWebAPICore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController
    {
        private readonly IAccessAccounts _accessAccounts;
        private readonly IAccessMeterReadings _accessMeterReadings;

        public UsersController(IAccessAccounts accessAccounts, IAccessMeterReadings accessMeterReadings)
        {
            _accessAccounts = accessAccounts;
            _accessMeterReadings = accessMeterReadings;

        }

        [HttpGet]
        [Route("meterreadings")]
        public IEnumerable<MeterReading> Get()
        {
            return _accessMeterReadings.GetMeterReadings();
        }

        [HttpGet]
        [Route("accounts")]
        public IEnumerable<Account> GetAccounts()
        {
                return _accessAccounts.GetAccounts().ToArray();
        }

    }
}
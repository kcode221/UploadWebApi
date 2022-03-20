using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebAPICore
{
    public class MeterReading
    {
        [Key]
        public int MeterReadingId{get; set;}
        [Required]
        public int AccountId {get; set;}
        public DateTime MeterReadingDateTime {get; set;}

        [Range(0,int.MaxValue)]
        public int MeterReadValue {get; set;}

    }
}
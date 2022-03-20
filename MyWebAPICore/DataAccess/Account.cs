using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPICore
{
    public class Account
    {
        [Required]
        public int AccountId {get; set;}
        [Required]
        [StringLength(100)]
        public string FirstName{get; set;}

        [StringLength(100)]
        public string LastName{get;set;}

    }
}
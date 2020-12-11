using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace borealisMVC.Models
{
    public class Time
    {
        [Key]
        public int TimeId { get; set; }
        [Required]
        public TimeSpan TimeValue { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public Boolean Approved { get; set; }
    }
}

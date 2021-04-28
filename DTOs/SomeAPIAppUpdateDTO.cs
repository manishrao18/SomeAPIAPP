using System;
using System.ComponentModel.DataAnnotations;

namespace SomeAPIAPP.DTOs
{
    public class SomeAPIAppUpdateDTO
    { 
        //public int ID { get; set; } // auto increment hence not required.
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public bool IsExist {get; set;} // mandatory field hence required.
    }
}
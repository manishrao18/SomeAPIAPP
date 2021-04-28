namespace SomeAPIAPP.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SomeAPIModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]   
        public bool IsExist {get; set;}
    }
}
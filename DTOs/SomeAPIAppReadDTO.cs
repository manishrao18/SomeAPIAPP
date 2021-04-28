namespace SomeAPIAPP.DTOs
{
    using System;

    public class SomeAPIAppReadDTO
    { 
        public int ID { get; set; }
        
        public string Name { get; set; }
        public string Details { get; set; }
        
        public DateTime RegisterDate { get; set; }
       
        //public bool IsExist {get; set;}
    }
}
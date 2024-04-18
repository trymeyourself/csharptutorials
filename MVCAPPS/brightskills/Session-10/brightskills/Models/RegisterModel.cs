using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace brightskills.Models
{
    public class RegisterModel
    {
        
        [Key]
        public int? RegisterID {get; set;} 
        public string? FullName {get; set;} 
        public string? UserName {get; set;} 
        public string? Email {get; set;} 
        public string? ContactNumber {get; set;} 
        public string? Password {get; set;} 
        public string? selected_course {get; set;} 

    }
}
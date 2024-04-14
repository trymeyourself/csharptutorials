using System.ComponentModel.DataAnnotations;

namespace brightskills.Models{

    public class LoginModel{

        [Key]
        public int? loginid {get; set; }
        public string? username{get; set;}
        public string? password {get; set;}
        public string? jobrole {get; set;}
    }
}
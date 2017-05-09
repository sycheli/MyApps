using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAppAPI.Models
{
    public class User
    {
        public User()
        {
        
            this.address = new Address();

        }
        public int ID { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string email { get; set; }

        public string img { get; set; }
        public string cover { get; set; }


        public virtual Address address { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _72HrChallenge.Models
{
    public class User
    {
        [Key, Required]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        [Required]
        public string UserName { get; set; }
        //public virtual List<Posts> {get, set,} = new List<Posts>        
    }
}
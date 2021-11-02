using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _72HrChallenge.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        [Required]
        public string UserName { get; set; }
        [ForeignKey("PostId")]
        public virtual List<Post> Posts { get; set; } = new List<Post>();     
    }
}
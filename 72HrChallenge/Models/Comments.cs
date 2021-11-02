using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _72HrChallenge.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
       
        public Guid PostId { get; set; }

       // public virtual List<Replies> {get, set,} = new List<Replies>
        
    }
}
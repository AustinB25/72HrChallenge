using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _72HrChallenge.Models
{
    public class Replies
    {
        [Key]
        public int ReplyId { get; set; }
        [Required]
        public string Text { get; set; }
        public int UserId { get; set; }
    }
}
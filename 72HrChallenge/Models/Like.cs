﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _72HrChallenge.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
       public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
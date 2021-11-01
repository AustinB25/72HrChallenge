﻿using _72HrChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _72HrChallenge.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserDbContext _context = new UserDbContext();
        public async Task<IHttpActionResult> CreateUser([FromBody] User model)
        {
            if(model == null)
            {
                return BadRequest("Your request body cannot be empty");
            }
            if (ModelState.IsValid)
            {
                _context.Users.Add(model);
                await _context.SaveChangesAsync();
                return Ok("User was created");
            }
            return BadRequest(ModelState);
        }
    }
}

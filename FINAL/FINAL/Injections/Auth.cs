﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using FINAL.Data;
using FINAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.Injections
{
    public interface IAuth
    {
        User User { get; }
    }

    public class Auth : IAuth
    {
        private readonly PropDbContext _context;
        private readonly IHttpContextAccessor _accessor;

        public Auth(PropDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        public User User
        {
            get
            {
                string token = string.Empty;

                bool hasHeader = this._accessor.HttpContext.Request.Cookies.TryGetValue("token", out token);

                if (!hasHeader)
                {
                    return null;
                }

                User LoggedUser = _context.Users.FirstOrDefault(c => c.Token == token);

                //LoggedUser.Resumes = _context.UserResumes.Include("educations").Include("works").FirstOrDefault(r => r.UserId == LoggedUser.UserId);


                if (LoggedUser == null)
                {
                    return null;
                }

                return LoggedUser;
            }
        }

    }
}
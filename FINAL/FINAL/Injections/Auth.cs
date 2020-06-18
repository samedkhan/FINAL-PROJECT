using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using FINAL.Data;
using FINAL.Models;
using FINAL.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL.Injections
{
    public interface IAuth
    {
        User User { get; }

        APuser APuser { get; }
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


                if (LoggedUser == null)
                {
                    return null;
                }

                return LoggedUser;
            }
        }

        public APuser APuser
        {

            get
            {
                string token = string.Empty;

                bool hasHeader = this._accessor.HttpContext.Request.Cookies.TryGetValue("APtoken", out token);

                if (!hasHeader)
                {
                    return null;
                }

                APuser LoggedAPUser = _context.APusers.FirstOrDefault(c => c.Token == token);


                if (LoggedAPUser == null)
                {
                    return null;
                }

                return LoggedAPUser;
            }
        }

    }
}
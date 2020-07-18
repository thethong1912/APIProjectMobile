using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProjectMobile.Models;
using APIProjectMobile.Services;
using APIProjectMobile.ViewModels;

namespace APIProjectMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAccountService _account;

        public LoginController(IAccountService account)
        {
            _account = account;
        }

        // GET: api/Login
        [HttpPost]
        public async Task<ActionResult<LoginVM>> GetUsers(LoginInfoVM loginInfo)
        {
            var info = await _account.CheckLoginSV(loginInfo.AccEmail, loginInfo.AccPassword).FirstOrDefaultAsync();
            if (info == null) return NotFound();
            else return Ok(info);
            //return await _context.Users.ToListAsync();
        }
    }
}

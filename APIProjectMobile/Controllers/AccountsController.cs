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
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    // GET: api/Accounts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActorBasicInfoVM>>> SearchUsers(string accName)
    {
        if (accName == null) return NotFound();
        var list = await _accountService.SearchActorVM(accName).ToListAsync();
        if (list.Count == 0) return NotFound();
        else return Ok(list);
    }

    // GET: api/Accounts
    [HttpGet("List")]
    public async Task<ActionResult<IEnumerable<ActorBasicInfoVM>>> GetUsers()
    {
        var list = await _accountService.GetListActorVM().ToListAsync();
        if (list.Count == 0) return NotFound();
        else return Ok(list);
    }

    //POST: api/Accounts
    [HttpPost]
    public async Task<ActionResult> AddActor(ActorInfoVM actor)
    {
        try
        {
            await _accountService.AddActorSV(actor);
        }
        catch (Exception)
        {
            return BadRequest();
        }
        return NoContent();
    }

    // DELETE: api/Accounts/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        try
        {
            var isDelete = await _accountService.DeleteActorSV(id);
            if (isDelete) return NoContent();
            else return NotFound();
        }
        catch (Exception) { return BadRequest(); }
    }

    // GET: api/Accounts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ActorInfoVM>> GetUser(int id)
    {
        var account = await _accountService.GetActorSV(id).FirstOrDefaultAsync();

        if (account == null)
        {
            return NotFound();
        }

        return Ok(account);
    }

    // PUT: api/Accounts/5
    [HttpPut("{id}")]
    public async Task<ActionResult<int>> PutUser(int id, ActorInfoVM account)
    {
        if (id != account.AccId)
        {
            return BadRequest();
        }

        try
        {
            int idUpdate = await _accountService.UpdateActorSV(id, account);
            if (idUpdate == -1) return NotFound();
            else return Ok(id);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
}

using APIProjectMobile.Models;
using APIProjectMobile.Repository;
using APIProjectMobile.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProjectMobile.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task AddActorSV(ActorInfoVM actor)
        {
            await _repository.AddActor(actor);
        }

        public IQueryable<LoginVM> CheckLoginSV(string accEmail, string password)
        {
            return _repository.CheckLogin(accEmail, password);
        }

        public async Task<bool> DeleteActorSV(int id)
        {
            try
            {
                bool check = await _repository.DeleteActor(id);
                if (check == true) return true;
                else return false;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public IQueryable<ActorInfoVM> GetActorSV(int id)
        {
            return _repository.GetActor(id);
        }

        public IQueryable<ActorBasicInfoVM> GetListActorVM()
        {
            return _repository.GetListActor();
        }

        public IQueryable<ActorBasicInfoVM> SearchActorVM(string accName)
        {
            return _repository.SearchActor(accName.Trim());
        }

        public Task<int> UpdateActorSV(int id, ActorInfoVM actor)
        {
            return _repository.UpdateActor(id, actor);
        }
    }

    public interface IAccountService
    {
        IQueryable<LoginVM> CheckLoginSV(string accEmail, string password);
        IQueryable<ActorBasicInfoVM> GetListActorVM();
        IQueryable<ActorBasicInfoVM> SearchActorVM(string accName);
        Task AddActorSV(ActorInfoVM actor);
        Task<bool> DeleteActorSV(int id);
        IQueryable<ActorInfoVM> GetActorSV(int id);
        Task<int> UpdateActorSV(int id, ActorInfoVM actor);

    }
}

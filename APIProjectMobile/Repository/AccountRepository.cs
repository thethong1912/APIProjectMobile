using APIProjectMobile.Enum;
using APIProjectMobile.Models;
using APIProjectMobile.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProjectMobile.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ProjectMobileContext _context;
        public AccountRepository(ProjectMobileContext context)
        {
            _context = context;
        }

        private bool AccountExists(int id)
        {
            return _context.TblAccount.Any(record => record.AccId == id);
        }

        public IQueryable<LoginVM> CheckLogin(string accountEmail, string password)
        {
            var loginInfo = _context.TblAccount
                                .Where(record => record.AccEmail.Equals(accountEmail) && record.AccPassword.Equals(password) && record.AccIsDelete.Equals(IsDelete.ACTIVE))
                                .Select(record => new LoginVM
                                {
                                    AccId = record.AccId,
                                    AccName = record.AccName,
                                    AccEmail = record.AccEmail,
                                    AccImage = record.AccImage,
                                    AccRole = record.AccRole,
                                });
            return loginInfo;
        }

        public IQueryable<ActorBasicInfoVM> GetListActor()
        {
            var listActor = _context.TblAccount
                                    .Where(record => record.AccRole.Equals(Role.USER) && record.AccIsDelete.Equals(IsDelete.ACTIVE))
                                    .Select(record => new ActorBasicInfoVM
                                    {
                                        AccId = record.AccId,
                                        AccEmail = record.AccEmail,
                                        AccImage = record.AccImage,
                                        AccName = record.AccName,
                                    });
            return listActor;
        }

        public IQueryable<ActorBasicInfoVM> SearchActor(string accountName)
        {
            var listActor = _context.TblAccount
                                    .Where(record => record.AccName.Contains(accountName) && record.AccRole.Equals(Role.USER) && record.AccIsDelete.Equals(IsDelete.ACTIVE))
                                    .Select(record => new ActorBasicInfoVM
                                    {
                                        AccId = record.AccId,
                                        AccEmail = record.AccEmail,
                                        AccImage = record.AccImage,
                                        AccName = record.AccName,
                                    });
            return listActor;
        }

        public async Task AddActor(ActorInfoVM actor)
        {
            TblAccount accountModel = new TblAccount();
            accountModel.AccName = actor.AccName;
            accountModel.AccPassword = actor.AccPassword;
            accountModel.AccImage = actor.AccImage;
            accountModel.AccPhoneNum = actor.AccPhoneNum;
            accountModel.AccEmail = actor.AccEmail;
            accountModel.AccDescription = actor.AccDescription;
            accountModel.AccAdress = actor.AccAdress;
            accountModel.AccRole = Role.USER;
            accountModel.AccStatus = Status.AVAILABLE;
            accountModel.AccIsDelete = IsDelete.ACTIVE;
            accountModel.AccCreateBy = actor.AccCreateBy;
            accountModel.AccUpdateTime = actor.AccUpdateTime;
            accountModel.AccUpdateBy = actor.AccUpdateBy; ;


            _context.TblAccount.Add(accountModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<bool> DeleteActor(int id)
        {
            var actor = await _context.TblAccount.FindAsync(id);
            if (actor == null)
            {
                return false;
            }
            try
            {
                actor.AccIsDelete = IsDelete.ISDELETED;
                _context.Entry(actor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public IQueryable<ActorInfoVM> GetActor(int id)
        {
            var actor = _context.TblAccount
                                    .Where(record => record.AccId == id && record.AccIsDelete == IsDelete.ACTIVE)
                                    .Select(record => new ActorInfoVM
                                    {
                                        AccId = record.AccId,
                                        AccAdress = record.AccAdress,
                                        AccDescription = record.AccDescription,
                                        AccEmail = record.AccEmail,
                                        AccImage = record.AccImage,
                                        AccName = record.AccName,
                                        AccPassword = record.AccPassword,
                                        AccPhoneNum = record.AccPhoneNum,
                                        AccCreateBy = record.AccCreateBy,
                                        AccUpdateBy = record.AccUpdateBy,
                                        AccUpdateTime = record.AccUpdateTime
                                    });
            return actor;
        }


        public async Task<int> UpdateActor(int id, ActorInfoVM actor)
        {
            TblAccount account = await _context.TblAccount.FindAsync(id);
            if (account == null) return -1;
            account.AccName = actor.AccName;
            account.AccPassword = actor.AccPassword;
            account.AccPhoneNum = actor.AccPhoneNum;
            account.AccImage = actor.AccImage;
            account.AccEmail = actor.AccEmail;
            account.AccDescription = actor.AccDescription;
            account.AccAdress = actor.AccAdress;
            account.AccUpdateBy = actor.AccUpdateBy;
            account.AccUpdateTime = actor.AccUpdateTime;

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return account.AccId;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return -1;
                }
                else throw;
            }
        }
    }

    public interface IAccountRepository
    {
        IQueryable<LoginVM> CheckLogin(string accountEmail, string password);
        IQueryable<ActorInfoVM> GetActor(int id);
        IQueryable<ActorBasicInfoVM> GetListActor();
        IQueryable<ActorBasicInfoVM> SearchActor(string accountName);
        Task AddActor(ActorInfoVM actor);
        Task<int> UpdateActor(int id, ActorInfoVM actor);
        Task<bool> DeleteActor(int id);
    }
}


using Microsoft.AspNet.Identity;
using MyBlog.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.Repository
{
    public class MyUserStore : 
        IUserStore<MyUser>, 
        IUserPasswordStore<MyUser>, 
        IUserRoleStore<MyUser>, 
        IUserLockoutStore<MyUser,string>,
        IUserTwoFactorStore<MyUser,string>
    {
        private MyBlogContext db = MyBlogContext.Create();

        #region IUserStore
        public Task CreateAsync(MyUser user)
        {
            db.MyUsers.Add(user);
            return db.SaveChangesAsync();
        }

        public void Dispose(){ }

        public Task<MyUser> FindByIdAsync(string userId)
        {
            return Task.FromResult(db.MyUsers.Find(userId));
        }

        public Task<MyUser> FindByNameAsync(string userName)
        {
            return Task.FromResult(db
                .MyUsers
                .Where(u => u.UserName == userName)
                ?.SingleOrDefault());
        }

        public Task DeleteAsync(MyUser user) => throw new NotImplementedException();
        public Task UpdateAsync(MyUser user)
        {
            db.Entry(db.MyUsers.Find(user.Id)).CurrentValues.SetValues(user);
            return db.SaveChangesAsync();
        }
        #endregion

        #region IUserPasswordStore
        public Task SetPasswordHashAsync(MyUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(MyUser user) => Task.FromResult(user.PasswordHash);

        public Task<bool> HasPasswordAsync(MyUser user) => Task.FromResult(true);
        #endregion

        #region IUserRoleStore
        public Task AddToRoleAsync(MyUser user, string roleName)
        {
            user.Roles.Add(roleName);
            return UpdateAsync(user);
        }

        public Task RemoveFromRoleAsync(MyUser user, string roleName)
        {
            user.Roles.Remove(roleName);
            return UpdateAsync(user);
        }

        public Task<IList<string>> GetRolesAsync(MyUser user)
        {
            return Task.FromResult((IList<string>)user.Roles);
        }

        public Task<bool> IsInRoleAsync(MyUser user, string roleName)
        {
            return Task.FromResult(user.Roles.Contains(roleName));
        }
        #endregion

        #region IUserLockoutStore
        public Task<bool> GetLockoutEnabledAsync(MyUser user)
        => Task.FromResult(false);
        public Task<int> GetAccessFailedCountAsync(MyUser user) 
        => Task.FromResult(0);

        public Task<DateTimeOffset> GetLockoutEndDateAsync(MyUser user) => throw new NotImplementedException();
        public Task SetLockoutEndDateAsync(MyUser user, DateTimeOffset lockoutEnd) => throw new NotImplementedException();
        public Task ResetAccessFailedCountAsync(MyUser user) => throw new NotImplementedException();
        public Task<int> IncrementAccessFailedCountAsync(MyUser user) => throw new NotImplementedException();
        public Task SetLockoutEnabledAsync(MyUser user, bool enabled) =>throw new NotImplementedException();
        #endregion

        #region IUserTwoFactorStore
        public Task SetTwoFactorEnabledAsync(MyUser user, bool enabled)
        => Task.CompletedTask;

        public Task<bool> GetTwoFactorEnabledAsync(MyUser user)
        => Task.FromResult(false);
        #endregion
    }
}

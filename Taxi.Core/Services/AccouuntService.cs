using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Taxi.Core.Generators;
using Taxi.Core.Interfaces;
using Taxi.Core.Securities;
using Taxi.Core.Senders;
using Taxi.Core.ViewModels;
using Taxi.DataAccessLayer.Context;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.Services
{
    public class AccouuntService : IAccounting
    {
        private DatabaseContext _context;

        public AccouuntService(DatabaseContext context)
        {
            _context = context;
        }

        #region Active code
        public async Task<User> ActiveCode(ActiveViewModel viewModel)
        {
            string password = HashEncode.GetHashCode(CodeGenerator.GetActiveCode());

            User user = _context.Users.SingleOrDefault(u=>u.Password == password);

            if (user == null) 
            { 
                user.IsActive = true;
                user.Password = HashEncode.GetHashCode(CodeGenerator.GetActiveCode());
                _context.SaveChanges();       
            }

            return await Task.FromResult(user); 
        }
        #endregion
        public bool CheckMobileNumber(string username)
        {
            return _context.Users.Any( u => u.UserName == username);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public Guid GetRoleByName(string name)
        {
            return _context.Roles.SingleOrDefault(r => r.Name == name).Id;
        }

        public async Task<User> GetUser(string username)
        {
            return await Task.FromResult(_context.Users.SingleOrDefault(u => u.UserName == username));
        }

        public async Task<User> RegisterUser(RegisterViewModel viewModel)
        {
           if (!CheckMobileNumber(viewModel.Username))
            {
                string code = CodeGenerator.GetActiveCode();
                User user = new User()
                {
                    IsActive = false,
                    Id = CodeGenerator.GetId(),
                    Password = HashEncode.GetHashCode(code),
                    RoleId = GetRoleByName("user"),
                    Token = code,
                    UserName = viewModel.Username,
                };
                _context.Users.Add(user);

                UserDetail userDetail = new UserDetail()
                {
                    Id = user.Id,
                    BirthDate = null,
                    Date = DataTimeGenerator.GetShamsiDate(),
                    Time = DataTimeGenerator.GetShamsiTime(),
                    FullName = null,
                };

                _context.UserDetails.Add(userDetail);
                _context.SaveChanges();

                try
                {
                    SmsSender.VeryFySend(user.UserName, "", code);
                }
                catch (Exception)
                {

                    throw;
                }
                return await Task.FromResult(user);


            }
            else
            {
                User user = await GetUser(viewModel.Username);
                string code = CodeGenerator.GetActiveCode();

                UpdatePasswordGuid(user.Id, HashEncode.GetHashCode(code));

                try
                {
                    SmsSender.VeryFySend(user.UserName, "", code);
                }
                catch (Exception)
                {

                    throw;
                }
                return await Task.FromResult(user);
            }
        }

        public void UpdatePasswordGuid(Guid Id, string code)
        {
            User user = _context.Users.Find(Id);

            user.Password = HashEncode.GetHashCode(code);
            _context.SaveChanges();
        }
    }
}

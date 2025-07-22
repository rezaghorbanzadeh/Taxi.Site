using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Taxi.Core.Interfaces;
using Taxi.Core.ViewModels.AdminPanel;
using Taxi.Core.ViewModels.Panel;
using Taxi.DataAccessLayer.Context;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.Services
{
    public class PanelService : IPanel
    {
        private DatabaseContext _context;
        public PanelService(DatabaseContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public string GetRoleName(string username)
        {
            return _context.Users.Include(u=>u.Role).SingleOrDefault(u=>u.UserName == username).Role.Name;
        }

        public async Task<UserDetail> GetUserDetail(string username)
        {
            return await _context.UserDetails.Include(u => u.User).SingleOrDefaultAsync(u => u.User.UserName == username);
        }

        public bool UpdateUserDetailProfile(Guid userId, UserDetailProfileViewModel viewModel)
        {
           UserDetail user = _context.UserDetails.Find(userId);

            if (user != null) { 
                user.FullName = viewModel.FullName;
                user.BirthDate = viewModel.BirthDate;

                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

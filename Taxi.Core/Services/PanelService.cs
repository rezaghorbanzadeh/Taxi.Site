using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Taxi.Core.Generators;
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

        public void AddFactor(Factor factor)
        {
            _context.Factors.Add(factor);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public async Task<Factor> GetFactor(Guid id)
        {
            return await _context.Factors.FindAsync(id);
        }

        public Guid GetFactorById(string orderNumber)
        {
           return _context.Factors.SingleOrDefault(f=>f.OrderNumber == orderNumber).Id;
        }

        public string GetRoleName(string username)
        {
            return _context.Users.Include(u=>u.Role).SingleOrDefault(u=>u.UserName == username).Role.Name;
        }

        public async Task<UserDetail> GetUserDetail(string username)
        {
            return await _context.UserDetails.Include(u => u.User).SingleOrDefaultAsync(u => u.User.UserName == username);
        }

        public bool UpdateFactor(Guid userId,string orderNumber , long Price)
        {
            Factor factor = _context.Factors.SingleOrDefault(f=>f.UserId == userId && f.BankName == null);
            if (factor != null)
            {
                factor.OrderNumber =orderNumber;
                factor.Price = Convert.ToInt32(Price);

                _context.SaveChanges(); 
                return true;
            }
            return false;
        }

        public void UpdatePayment(Guid Id, string date, string time, string desc, string bank, string trace, string refId)
        {
            Factor factor = _context.Factors.Find(Id);
            User user = _context.Users.Find(factor.UserId);
            factor.Date = DataTimeGenerator.GetShamsiDate();
            factor.Time = DataTimeGenerator.GetShamsiTime();
            factor.Desc = desc;
            factor.TraceNumber = trace;
            factor.BankName = bank;
            factor.RefNumber = refId;
            user.Wallet += factor.Price;
            _context.SaveChanges();
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

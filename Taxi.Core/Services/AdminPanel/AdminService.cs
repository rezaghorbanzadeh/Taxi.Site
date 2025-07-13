using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Taxi.Core.Generators;
using Taxi.Core.Interfaces;
using Taxi.Core.Interfaces.Admin;
using Taxi.Core.Securities;
using Taxi.Core.Senders;
using Taxi.Core.ViewModels;
using Taxi.Core.ViewModels.AdminPanel;
using Taxi.DataAccessLayer.Context;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.Services.AdminPanel
{
    public class AdminService : IAdmin
    {
        private DatabaseContext _context;

        public AdminService(DatabaseContext context)
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



        #region Car
        public void AddCar(CarViewModel viewModel)
        {
            Car car = new Car()
            {
                Id = CodeGenerator.GetId(),
                Name = viewModel.Name,
            };
            _context.Add(car);
            _context.SaveChanges();
        }

        public bool DeleteCar(Guid id)
        {
            Car car = _context.Cars.Find(id);

            if (car != null) { 
                _context.Remove(car);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Car> GetCarById(Guid id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<List<Car>> GetCars()
        {
            return await _context.Cars.OrderBy(c=>c.Name).ToListAsync();
        }

        public bool UpdateCar(Guid id, CarViewModel viewModel)
        {
            Car car = _context.Cars.Find(id);
            if (car != null) { 
                car.Name = viewModel.Name;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}

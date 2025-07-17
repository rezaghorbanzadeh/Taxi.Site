using System;
using System.Collections.Generic;
using System.IO;
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

            if (car != null)
            {
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
            return await _context.Cars.OrderBy(c => c.Name).ToListAsync();
        }

        public bool UpdateCar(Guid id, CarViewModel viewModel)
        {
            Car car = _context.Cars.Find(id);
            if (car != null)
            {
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

        #region Car Color
        public async Task<List<CarColor>> GetColor()
        {
            return await _context.CarColors.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<CarColor> GetColorId(Guid id)
        {
            return await _context.CarColors.FindAsync(id);
        }

        public void AddColor(CarColorViewModel viewModel)
        {
            CarColor carColor = new CarColor()
            {
                Id = CodeGenerator.GetId(),
                Name = viewModel.Name,
                Code = viewModel.Code,
            };
            _context.CarColors.Add(carColor);
            _context.SaveChanges();
        }

        public bool UpdateColor(Guid id, CarColorViewModel viewModel)
        {
            CarColor color = _context.CarColors.Find(id);

            if (color != null)
            {
                color.Name = viewModel.Name;
                color.Code = viewModel.Code;

                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteColor(Guid id)
        {
            CarColor car = _context.CarColors.Find(id);


            if (car != null)
            {
                _context.Remove(car);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }


        #endregion

        #region RateType

        public async Task<List<RateType>> GetRateType()
        {
            return await  _context.RateTypes.OrderBy(r => r.Name).ToListAsync();
        }

        public async Task<RateType> GetRateTypeById(Guid id)
        {
            return await _context.RateTypes.FindAsync(id);
        }

        public void AddRateType(RateTypeViewModel viewModel)
        {
            RateType rateType = new RateType()
            {
                Id = CodeGenerator.GetId(),
                Name = viewModel.Name,
                Ok = viewModel.Ok,
                ViewOrder = viewModel.ViewOrder,

            };
            _context.RateTypes.Add(rateType);
            _context.SaveChanges();

        }

        public bool UpdateRateType(Guid id, RateTypeViewModel viewModel)
        {
            RateType rateType = _context.RateTypes.Find(id);
            if (rateType != null) { 
                
                rateType.Name = viewModel.Name;
                rateType.Ok = viewModel.Ok;
                rateType.ViewOrder = viewModel.ViewOrder;
            
                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public bool DeleteRateType(Guid id)
        {
            RateType rateType = _context.RateTypes.Find(id);
            if (rateType != null) { 
                _context.RateTypes.Remove(rateType);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region SiteSetting
        public async Task<Setting> GetSetting()
        {
            return await  _context.Settings.FirstOrDefaultAsync();
        }

        public bool UpdateSiteSetting(SiteSettingViewModel viewModel)
        {
            Setting setting = _context.Settings.FirstOrDefault();

            if (setting != null) { 
               setting.Name = viewModel.Name;
               setting.Tel = viewModel.Tel; 
               setting.Fax = viewModel.Fax;
               setting.Desc = viewModel.Desc;

                _context.SaveChanges();
                return true;
            }
            return false ;
        }

        public bool UpdatePriceSetting(PriceSettingViewModel viewModel)
        {
            Setting setting = _context.Settings.FirstOrDefault();

            if (setting != null)
            {
                setting.IsDistance = viewModel.IsDistance;
                setting.IsWeatherPrice = viewModel.IsWeatherPrice;


                _context.SaveChanges();
                return true;
            }
            return false;
        }
        
        public bool UpdateAboutSetting(AboutSettingViewModel viewModel)
        {
            Setting setting = _context.Settings.FirstOrDefault();

            if (setting != null)
            {
                setting.About = viewModel.About;
      
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateTermSetting(TermSettingViewModel viewModel)
        {
            Setting setting = _context.Settings.FirstOrDefault();

            if (setting != null)
            {
                setting.Terms = viewModel.Terms;

                _context.SaveChanges();
                return true;
            }
            return false;
        }


        #endregion

        #region PriceType
        public async Task<List<PriceType>> GetPriceType()
        {
            return await _context.PriceTypes.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<PriceType> GetPriceTypeById(Guid id)
        {
            return await _context.PriceTypes.FindAsync(id);
        }

        public void AddPriceType(PriceTypeViewModel viewModel)
        {
            PriceType priceType = new PriceType()
            {
                Id = CodeGenerator.GetId(),
                Name = viewModel.Name,
                End = viewModel.End,
                Start = viewModel.Start,
                Price  = viewModel.Price,
            };
            _context.Add(priceType);
            _context.SaveChanges();
        }

        public bool UpdatePriceType(Guid id, PriceTypeViewModel viewModel)
        {
            PriceType priceType = _context.PriceTypes.Find(id);
            if (priceType != null)
            {
                priceType.Name = viewModel.Name;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DeletePriceType(Guid id)
        {
            PriceType priceType = _context.PriceTypes.Find(id);

            if (priceType != null)
            {
                _context.Remove(priceType);
                _context.SaveChanges();
                
            }
        }
        #endregion

        #region MonthType
        public async Task<List<MonthType>> GetMonthType()
        {
            return await _context.MonthTypes.OrderBy(m => m.Name).ToListAsync();
        }

        public async Task<MonthType> GetMonthTypeById(Guid id)
        {
           return await _context.MonthTypes.FindAsync(id);
        }

        public void AddMonthType(MonthTypeViewModel viewModel)
        {
            MonthType monthType = new MonthType()
            {
                Name = viewModel.Name,
                precent = viewModel.precent,
                End =viewModel.End,
                Start = viewModel.Start,

                
            };
            _context.Add(monthType);
            _context.SaveChanges();
        }

        public bool UpdateMonthType(Guid id, MonthTypeViewModel viewModel)
        {
            MonthType monthType = _context.MonthTypes.Find(id);
            if (monthType != null) { 
                monthType.Name = viewModel.Name;
                monthType.Start = viewModel.Start;
                monthType.End = viewModel.End;  
                monthType.precent = viewModel.precent;  
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteMonthType(Guid id)
        {
            MonthType mouthType = _context.MonthTypes.Find(id);

            if (mouthType != null)
            {
                _context.Remove(mouthType);
                _context.SaveChanges();

            }
        }
        #endregion


    }
}

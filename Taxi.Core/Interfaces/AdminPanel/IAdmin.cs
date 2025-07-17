using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Core.ViewModels.AdminPanel;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.Interfaces.Admin
{
    public interface IAdmin
    {
        #region Car
        Task<List<Car>> GetCars();

        Task<Car> GetCarById(Guid id);

        void AddCar(CarViewModel viewModel);
        bool UpdateCar(Guid id,CarViewModel viewModel);

        bool DeleteCar(Guid id);

        #endregion


        #region Car Color
        Task<List<CarColor>> GetColor();

        Task<CarColor> GetColorId(Guid id);

        void AddColor(CarColorViewModel viewModel);
        bool UpdateColor(Guid id,CarColorViewModel viewModel);

        bool DeleteColor(Guid id);

        #endregion
        
        
        #region RateType
        Task<List<RateType>> GetRateType();

        Task<RateType> GetRateTypeById(Guid id);

        void AddRateType(RateTypeViewModel viewModel);
        bool UpdateRateType(Guid id, RateTypeViewModel viewModel);

        bool DeleteRateType(Guid id);

        #endregion

        #region SiteSetting

        Task<Setting> GetSetting();

        bool UpdateSiteSetting(SiteSettingViewModel viewModel);
        bool UpdatePriceSetting(PriceSettingViewModel viewModel); 
        bool UpdateAboutSetting(AboutSettingViewModel viewModel); 
        bool UpdateTermSetting(TermSettingViewModel viewModel);

        #endregion



        #region PriceType

        Task<List<PriceType>> GetPriceType();
        Task<PriceType> GetPriceTypeById(Guid id);
        void AddPriceType(PriceTypeViewModel viewModel);
        bool UpdatePriceType(Guid id, PriceTypeViewModel viewModel);

        void DeletePriceType(Guid id);
        #endregion 
        
        #region MonthType

        Task<List<MonthType>> GetMonthType();
        Task<MonthType> GetMonthTypeById(Guid id);
        void AddMonthType(MonthTypeViewModel viewModel);
        bool UpdateMonthType(Guid id, MonthTypeViewModel viewModel);
        void DeleteMonthType(Guid id);
        #endregion
    }
}

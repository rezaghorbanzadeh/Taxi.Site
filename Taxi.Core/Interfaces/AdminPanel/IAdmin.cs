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

        bool DeletePriceType(Guid id);
        #endregion 
        
        #region MonthType

        Task<List<MonthType>> GetMonthType();
        Task<MonthType> GetMonthTypeById(Guid id);
        void AddMonthType(MonthTypeViewModel viewModel);
        bool UpdateMonthType(Guid id, MonthTypeViewModel viewModel);

        bool DeleteMonthType(Guid id);
        #endregion

        #region Humidity

        Task<List<Humidity>> GetHumidity();
        Task<Humidity> GetHumidityById(Guid id);
        void AddHumidity(MonthTypeViewModel viewModel);
        bool UpdateHumidity(Guid id, MonthTypeViewModel viewModel);

        bool DeleteHumidity(Guid id);
        #endregion

        #region Temperature

        Task<List<Temperature>> GetTemperature();
        Task<Temperature> GetTemperatureById(Guid id);
        void AddTemperature(MonthTypeViewModel viewModel);
        bool UpdateTemperature(Guid id, MonthTypeViewModel viewModel);

        bool DeleteTemperature(Guid id);
        #endregion

        #region Role

        Task<List<Role>> GetRoles();

        Task<Role> GetRoleId(Guid id);

        void AddRole(RoleViewModel viewModel);
        bool UpdateRole(Guid id, RoleViewModel viewModel);

        bool DeleteRole(Guid id);
        #endregion

        #region User

        string GetRoleName(Guid id);
        bool CheckUser(string username);
        void AddUser(UserViewModel viewModel);
        Task<List<User>> GetUsers();
        void DeleteUser(Guid id);
        void AddDriver(Guid id);
        void DeleteDriver(Guid id);
        bool UpdateUser(UserEditViewModel viewModel, Guid id);
        bool CheckUserForUpdate(string username,Guid id);
        Task<User> GetUserById(Guid id);
        Task<UserDetail> GetUserDetail(Guid id);
        Task<Driver> GetDriver(Guid id);

        bool UpdateDriverProp(Guid id,DriverPropViewModel viewModel);
        bool UpdateDriverCertificate(Guid id,DriverImgViewModel viewModel);
        bool UpdateDriverCar(Guid id,DriverCarViewModel viewModel);
        #endregion

        #region Discounts
        Task<List<Discount>> GetDiscounts();

        Task<Discount> GetDiscountById(Guid id);

        void AddDiscount(AdminDiscountsViewModel viewModel);
        bool UpdateDiscount(Guid id, AdminDiscountsViewModel viewModel);

        void DeleteDiscount(Guid id);
        #endregion


        #region Report
        int WeeklyFactor(string date);

        #endregion
    }
}

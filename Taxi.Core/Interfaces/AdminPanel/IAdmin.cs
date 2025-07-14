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
    }
}

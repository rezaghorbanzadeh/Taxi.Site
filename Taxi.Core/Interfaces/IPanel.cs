using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Taxi.Core.ViewModels.Panel;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.Interfaces
{
    public interface IPanel : IDisposable
    {
        Task<UserDetail> GetUserDetail(string username);
        string GetRoleName(string username);
        bool UpdateUserDetailProfile(Guid userId, UserDetailProfileViewModel viewModel);


        #region Payment
        void AddFactor(Factor factor);
        bool UpdateFactor(Guid userId,string orderNumber, long Price);

        Guid GetFactorById(string orderNumber);

        Task<Factor>  GetFactor(Guid id);
        void UpdatePayment(Guid Id, string date , string time , string desc, string bank
            , string trace, string refId );
        #endregion

    }
}

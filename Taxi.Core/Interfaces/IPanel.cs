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
    }
}

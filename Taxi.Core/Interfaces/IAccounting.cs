using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Core.ViewModels;
using Taxi.DataAccessLayer.Entites;

namespace Taxi.Core.Interfaces
{
    public interface IAccounting :IDisposable
    {
        //if mobile exist
        bool CheckMobileNumber(string username);


        Task<User> RegisterUser(RegisterViewModel viewModel);

        Guid GetRoleByName(string name);

        Task<User> GetUser(string username);


        void UpdatePasswordGuid(Guid Id , string code);
    }
}

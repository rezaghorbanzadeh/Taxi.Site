using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Identity.Client;
using Taxi.Core.Interfaces;

namespace Taxi.Core.Securities
{
    public  class RoleAttribute : AuthorizeAttribute, IAuthorizationFilter
    {

        private IAccounting _accounting;
        private string _roleName;

        public RoleAttribute(string roleName)
        {
            _roleName = roleName;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated) 
            {
                string username = context.HttpContext.User.Identity.Name;
                _accounting = (IAccounting) context.HttpContext.RequestServices.GetService(typeof(IAccounting));

                if (!_accounting.ChekUserRole(_roleName,username)) 
                {
                    context.Result = new RedirectResult("/Account/Register");
                }
            }
            else
            {
                context.Result = new RedirectResult("/Account/Register");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Core.Interfaces;

namespace Taxi.Core.Scopes
{
    public class SiteScope
    {
        private IPanel _panel;

        public SiteScope(IPanel panel)
        {
            _panel = panel;
        }

        public string GetUserRole(string username)
        {
            return _panel.GetRoleName(username);
        }

    }
}

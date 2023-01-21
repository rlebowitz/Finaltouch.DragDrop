using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finaltouch.DragDrop.Client.Shared
{
    public partial class TopNavBar : ComponentBase
    {
        private bool collapseNavMenu = true;
        private string? NavBarCssClass => collapseNavMenu ? null : "show";
        private string? NavButtonCssClass => collapseNavMenu ? "collapsed" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }
    }
}

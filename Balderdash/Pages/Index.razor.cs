using Balderdash.Services;
using Balderdash.Models;
using Microsoft.AspNetCore.Components;

namespace Balderdash.Pages
{
    public partial class Index
    {
        [Inject] private INavigationService NavigationService { get; set; } = INavigationService.Null;
        [Inject] private IPlayerService PlayerService { get; set; } = IPlayerService.Null;

        private void Join()
        {
            NavigationService.Joined();
        }
    }
}

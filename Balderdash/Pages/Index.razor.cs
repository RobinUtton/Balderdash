using Balderdash.Data;
using Microsoft.AspNetCore.Components;

namespace Balderdash.Pages
{
    public partial class Index
    {
        [Inject] private INavigationService NavigationService { get; set; } = INavigationService.Null;
        [Inject] private IPlayerService PlayerService { get; set; } = IPlayerService.Null;

        private Player Player { get; set; } = new Player();

        protected override void OnInitialized()
        {
            Player = PlayerService.Player;
        }

        private void Join()
        {
            NavigationService.Joined();
        }
    }
}

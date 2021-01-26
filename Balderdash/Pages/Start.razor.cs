using Balderdash.Data;
using Microsoft.AspNetCore.Components;

namespace Balderdash.Pages
{
    public partial class Start
    {
        [Inject] private INavigationService NavigationService { get; set; } = INavigationService.Null;
        [Inject] private IQuestionService QuestionService { get; set; } = IQuestionService.Null;
        [Inject] private IPlayerService PlayerService { get; set; } = IPlayerService.Null;

        private void PlayAsDasher()
        {
            QuestionService.SetDasher(PlayerService.Player);

            NavigationService.BecameDasher();
        }
    }
}

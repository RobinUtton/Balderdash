using Balderdash.Data;
using Microsoft.AspNetCore.Components;

namespace Balderdash.Pages
{
    public partial class Results
    {
        [Inject] private IQuestionService QuestionService { get; set; } = IQuestionService.Null;
        [Inject] private INavigationService NavigationService { get; set; } = INavigationService.Null;
        [Inject] private IPlayerService PlayerService { get; set; } = IPlayerService.Null;

        private bool HighlightOwnAnswer { get; set; } = false;
        private string HighlightText => HighlightOwnAnswer ? "Disguise" : "Highlight";

        private void ReturnToStart()
        {
            NavigationService.NewRound();
        }

        private void ToggleHighlight()
        {
            HighlightOwnAnswer = !HighlightOwnAnswer;
        }
    }
}

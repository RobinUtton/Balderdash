using Balderdash.Services;
using Microsoft.AspNetCore.Components;

namespace Balderdash.Pages
{
    public partial class Results
    {
        [Inject] private IQuestionService QuestionService { get; set; } = IQuestionService.Null;
        [Inject] private IPlayerService PlayerService { get; set; } = IPlayerService.Null;

        private bool HighlightOwnAnswer { get; set; } = false;
        private string HighlightText => HighlightOwnAnswer ? "Disguise" : "Highlight";

        private void ReturnToStart()
        {
            QuestionService.EndRound();
        }

        private void ToggleHighlight()
        {
            HighlightOwnAnswer = !HighlightOwnAnswer;
        }
    }
}

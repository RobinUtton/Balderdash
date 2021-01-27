using Balderdash.Services;
using Balderdash.Models;
using Microsoft.AspNetCore.Components;

namespace Balderdash.Pages
{
    public partial class Respond
    {
        [Inject] private INavigationService NavigationService { get; set; } = INavigationService.Null;
        [Inject] private IQuestionService QuestionService { get; set; } = IQuestionService.Null;
        [Inject] private IPlayerService PlayerService { get; set; } = IPlayerService.Null;

        private Answer Answer { get; set; } = new Answer();

        private string QuestionText => QuestionService.QuestionText;

        protected override void OnInitialized()
        {
            Answer.Player = PlayerService.Player;
            Answer.IsCorrect = PlayerService.Player == QuestionService.Dasher;
        }

        private void SubmitAnswer()
        {
            Answer.OriginalContent = Answer.Content;

            QuestionService.SubmitAnswer(Answer);

            NavigationService.Answered();
        }
    }
}

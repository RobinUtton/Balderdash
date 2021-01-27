using Balderdash.Services;
using Balderdash.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace Balderdash.Pages
{
    public partial class EditAnswer
    {
        [Inject] private INavigationService NavigationService { get; set; } = INavigationService.Null;
        [Inject] private IQuestionService QuestionService { get; set; } = IQuestionService.Null;

        [Parameter] public string Id { get; set; } = string.Empty;
        private int QuestionId => int.Parse(Id);

        private Answer Answer { get; set; } = new Answer();

        protected override void OnInitialized()
        {
            Answer = QuestionService.Answers.ElementAt(QuestionId);
        }

        private void UpdateAnswer()
        {
            NavigationService.Answered();
        }

        private void RevertAnswer()
        {
            Answer.Content = Answer.OriginalContent;
        }

        private void MarkCorrect()
        {
            QuestionService.RemoveAnswer(Answer);

            NavigationService.Answered();
        }
    }
}

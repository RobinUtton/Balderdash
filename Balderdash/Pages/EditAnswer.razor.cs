using Balderdash.Models;
using Balderdash.Services;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace Balderdash.Pages
{
    public partial class EditAnswer
    {
        [Inject] private INavigationService NavigationService { get; set; } = INavigationService.Null;
        [Inject] private IQuestionService QuestionService { get; set; } = IQuestionService.Null;

        [Parameter] public int Id { get; set; } = 0;

        private Answer Answer { get; set; } = new Answer();

        protected override void OnInitialized()
        {
            Answer = QuestionService.Answers.ElementAt(Id);
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

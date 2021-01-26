using Balderdash.Data;
using Microsoft.AspNetCore.Components;

namespace Balderdash.Pages
{
    public partial class Ask
    {
        [Inject] private INavigationService NavigationService { get; set; } = INavigationService.Null;
        [Inject] private IQuestionService QuestionService { get; set; } = IQuestionService.Null;

        private Question Question { get; set; } = new Question();

        private void SetQuestion()
        {
            QuestionService.SetQuestion(Question);

            NavigationService.Asked();
        }
    }
}

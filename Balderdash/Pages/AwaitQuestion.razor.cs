using Balderdash.Data;
using Microsoft.AspNetCore.Components;

namespace Balderdash.Pages
{
    public partial class AwaitQuestion
    {
        [Inject] private IQuestionService QuestionService { get; set; } = IQuestionService.Null;

        private string Dasher => QuestionService.DasherName;
    }
}

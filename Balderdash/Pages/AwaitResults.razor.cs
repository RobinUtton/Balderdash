using Balderdash.Data;
using Microsoft.AspNetCore.Components;

namespace Balderdash.Pages
{
    public partial class AwaitResults
    {
        [Inject] private IQuestionService QuestionService { get; set; } = IQuestionService.Null;

        private string Dasher => QuestionService.DasherName;
    }
}

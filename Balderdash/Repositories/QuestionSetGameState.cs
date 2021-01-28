using Balderdash.Models;

namespace Balderdash.Repositories
{
    public class QuestionSetGameState : GameStateDecorator
    {
        public override bool IsQuestionSet => true;

        public override Question Question { get; }

        public QuestionSetGameState(Question question, IGameState previousState) : base(previousState)
        {
            Question = question;
        }
    }

}

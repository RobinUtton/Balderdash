using Balderdash.Models;
using System.Collections.Generic;
using System.Linq;

namespace Balderdash.Repositories
{
    public class AnswerSubmittedGameState : GameStateDecorator
    {
        private readonly Answer _answer;

        public override IEnumerable<Answer> Answers => base.Answers.Append(_answer);

        public AnswerSubmittedGameState(Answer answer, IGameState previousState) : base(previousState)
        {
            _answer = answer;
        }
    }

}

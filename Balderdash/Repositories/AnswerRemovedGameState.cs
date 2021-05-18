using Balderdash.Models;
using System.Collections.Generic;
using System.Linq;

namespace Balderdash.Repositories
{
    public class AnswerRemovedGameState : GameStateDecorator
    {
        private readonly Answer _answer;

        public override IEnumerable<Answer> Answers => base.Answers.Where(a => a != _answer);

        public AnswerRemovedGameState(Answer answer, IGameState previousState) : base(previousState)
        {
            _answer = answer;
        }
    }
}

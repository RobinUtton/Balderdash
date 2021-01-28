using Balderdash.Extensions;
using Balderdash.Models;
using System.Collections.Generic;

namespace Balderdash.Repositories
{
    public class AnswersConfirmedGameState : GameStateDecorator
    {
        public override IEnumerable<Answer> Answers { get; }

        public AnswersConfirmedGameState(IGameState previousState) : base(previousState)
        {
            Answers = previousState.Answers.Shuffle();
        }
    }

}

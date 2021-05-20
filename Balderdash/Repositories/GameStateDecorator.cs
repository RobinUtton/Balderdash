using Balderdash.Models;
using System.Collections.Generic;

namespace Balderdash.Repositories
{
    public abstract class GameStateDecorator : IGameState
    {
        private readonly IGameState _previousState;

        public virtual bool IsDasherSet => _previousState.IsDasherSet;
        public virtual bool IsQuestionSet => _previousState.IsQuestionSet;
        public virtual bool IsQuestionComplete => _previousState.IsQuestionComplete;

        public virtual Player? Dasher => _previousState.Dasher;
        public virtual Question? Question => _previousState.Question;
        public virtual IEnumerable<Answer> Answers => _previousState.Answers;

        protected GameStateDecorator(IGameState previousState)
        {
            _previousState = previousState;
        }
    }

}

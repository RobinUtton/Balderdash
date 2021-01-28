using Balderdash.Models;
using System.Collections.Generic;

namespace Balderdash.Repositories
{
    public interface IGameState
    {
        bool IsDasherSet { get; }
        bool IsQuestionSet { get; }
        bool IsQuestionComplete { get; }

        Player? Dasher { get; }
        Question? Question { get; }
        IEnumerable<Answer> Answers { get; }
    }

}

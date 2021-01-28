using Balderdash.Models;
using System.Collections.Generic;
using System.Linq;

namespace Balderdash.Repositories
{
    public class NewRoundGameState : IGameState
    {
        public virtual bool IsDasherSet => false;
        public virtual bool IsQuestionSet => false;
        public virtual bool IsQuestionComplete => false;

        public virtual Player? Dasher => null;
        public virtual Question? Question => null;
        public virtual IEnumerable<Answer> Answers => Enumerable.Empty<Answer>();
    }

}

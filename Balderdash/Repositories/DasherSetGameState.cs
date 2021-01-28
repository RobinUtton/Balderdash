using Balderdash.Models;

namespace Balderdash.Repositories
{
    public class DasherSetGameState : GameStateDecorator
    {
        public override bool IsDasherSet => true;

        public override Player Dasher { get; }

        public DasherSetGameState(Player dasher, IGameState previousState) : base(previousState)
        {
            Dasher = dasher;
        }
    }

}

using System;

namespace Balderdash.Repositories
{
    public class GameIdEventArgs : EventArgs
    {
        public string GameId { get; }

        public GameIdEventArgs(string gameId)
        {
            GameId = gameId;
        }
    }
}
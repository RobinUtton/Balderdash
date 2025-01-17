﻿using Balderdash.Models;

namespace Balderdash.Services
{
    /// <summary>
    /// Represents a service providing access to information about the player in the current session.
    /// </summary>
    public interface IPlayerService
    {
        /// <summary>
        /// Gets or sets the current player.
        /// </summary>
        Player Player { get; set; }

        /// <summary>
        /// Gets or sets the current game id.
        /// </summary>
        string GameId { get; set; }

        /// <summary>
        /// Gets a fallback implementation of the player service interface.
        /// </summary>
        public static IPlayerService Null { get; } = new NullPlayerService();

        private class NullPlayerService : IPlayerService
        {
            public Player Player { get; set; } = new Player();

            public string GameId { get; set; } = string.Empty;
        }
    }
}

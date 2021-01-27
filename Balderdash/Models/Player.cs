using System.ComponentModel.DataAnnotations;

namespace Balderdash.Models
{
    /// <summary>
    /// Represents a player in the game.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The name of the player.
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}

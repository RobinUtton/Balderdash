using Balderdash.Models;

namespace Balderdash.Services
{
    public class PlayerService : IPlayerService
    {
        public Player Player { get; set; } = new Player();
    }
}

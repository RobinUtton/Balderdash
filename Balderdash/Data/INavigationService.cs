namespace Balderdash.Data
{
    /// <summary>
    /// Represents a service managing navigation between the pages of the site.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Performs the required navigation after joining the game.
        /// </summary>
        void Joined();
        /// <summary>
        /// Performs the required navigation after becoming the dasher.
        /// </summary>
        void BecameDasher();
        /// <summary>
        /// Performs the required navigation after asking a question.
        /// </summary>
        void Asked();
        /// <summary>
        /// Performs the required navigation after answering a question.
        /// </summary>
        void Answered();
        /// <summary>
        /// Performs the required navigation for editing an answer with a given ID.
        /// </summary>
        /// <param name="id">The ID of the question to edit.</param>
        void Edit(int id);
        /// <summary>
        /// Performs the required navigation after starting a new round.
        /// </summary>
        void NewRound();

        /// <summary>
        /// Gets a fallback implementation of the navigation service interface.
        /// </summary>
        public static INavigationService Null { get; } = new NullNavigationService();

        private class NullNavigationService : INavigationService
        {
            public void Joined() { }
            public void BecameDasher() { }
            public void Asked() { }
            public void Answered() { }
            public void Edit(int id) { }
            public void NewRound() { }
        }
    }
}

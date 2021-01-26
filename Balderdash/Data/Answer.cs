namespace Balderdash.Data
{
    /// <summary>
    /// Represents a player's answer to a question.
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Gets or sets the text of the answer.
        /// </summary>
        public string Content { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the text of the answer as submitted by the answering player.
        /// </summary>
        public string OriginalContent { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the player who originally submitted the answer.
        /// </summary>
        public Player Player { get; set; } = new Player();
        /// <summary>
        /// Gets or sets a value indicating whether the answer is the correct answer submitted by the dasher.
        /// </summary>
        public bool IsCorrect { get; set; } = false;
    }
}
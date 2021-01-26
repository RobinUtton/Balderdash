using System;
using System.Collections.Generic;
using System.Linq;

namespace Balderdash.Data
{
    /// <summary>
    /// Represents a service describing the state of the round being played.
    /// </summary>
    public interface IQuestionService
    {
        /// <summary>
        /// Gets the player asking the current question.
        /// </summary>
        Player? Dasher { get; }

        /// <summary>
        /// Gets the name of the current dasher.
        /// </summary>
        string DasherName { get; }
        /// <summary>
        /// Getss the text of the current question.
        /// </summary>
        string QuestionText { get; }

        /// <summary>
        /// Gets the answers submitted by players to the current question.
        /// </summary>
        IEnumerable<Answer> Answers { get; }
        /// <summary>
        /// Gets the answers from which the players can choose for the current question after review by the dasher.
        /// </summary>
        IEnumerable<Answer> Options { get; }

        /// <summary>
        /// Gets a value indicating whether the dasher has been chosen for the current question.
        /// </summary>
        bool IsDasherSet { get; }
        /// <summary>
        /// Gets a value indicating whether the text of the question has been set.
        /// </summary>
        bool IsQuestionSet { get; }
        /// <summary>
        /// Gets a value indicating whether the dasher has reviewed the answers.
        /// </summary>
        bool IsQuestionComplete { get; }

        /// <summary>
        /// Nominates a player as the dasher.
        /// </summary>
        /// <param name="player">The player to ask the question.</param>
        void SetDasher(Player player);
        /// <summary>
        /// Submits the question to ask the players.
        /// </summary>
        /// <param name="question">The question being asked.</param>
        void SetQuestion(Question question);
        /// <summary>
        /// Submits a player's answer to the question.
        /// </summary>
        /// <param name="answer">The answer to submit.</param>
        void SubmitAnswer(Answer answer);
        /// <summary>
        /// Removes an answer from the submitted answers, such as when it is close to the correct answer.
        /// </summary>
        /// <param name="answer">The answer to remove.</param>
        void RemoveAnswer(Answer answer);
        /// <summary>
        /// Confirms the submitted answers after review by the dasher.
        /// </summary>
        void CompleteQuestion();

        /// <summary>
        /// Occurs when the dasher has been set.
        /// </summary>
        event Action? DasherSet;
        /// <summary>
        /// Occurs when the question text has been set.
        /// </summary>
        event Action? QuestionSet;
        /// <summary>
        /// Occurs when an answer has been submitted by a player.
        /// </summary>
        event Action? AnswerReceived;
        /// <summary>
        /// Occurs when the dasher has reviewed and accepted the answers.
        /// </summary>
        event Action? QuestionComplete;

        /// <summary>
        /// Gets a fallback implementation of question service interface.
        /// </summary>
        public static IQuestionService Null { get; } = new NullQuestionService();

        private class NullQuestionService : IQuestionService
        {
            public Player? Dasher => null;

            public string DasherName => string.Empty;
            public string QuestionText => string.Empty;
            public string CorrectAnswer => string.Empty;

            public IEnumerable<Answer> Answers => Enumerable.Empty<Answer>();
            public IEnumerable<Answer> Options => Enumerable.Empty<Answer>();

            public bool IsDasherSet => false;
            public bool IsQuestionSet => false;
            public bool IsQuestionComplete => false;

            public void SetDasher(Player player) { DasherSet?.Invoke(); }
            public void SetQuestion(Question question) { QuestionSet?.Invoke(); }
            public void SubmitAnswer(Answer answer) { AnswerReceived?.Invoke(); }
            public void RemoveAnswer(Answer answer) { }
            public void CompleteQuestion() { QuestionComplete?.Invoke(); }

            public event Action? DasherSet;
            public event Action? QuestionSet;
            public event Action? AnswerReceived;
            public event Action? QuestionComplete;
        }
    }
}

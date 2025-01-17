﻿using Balderdash.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Balderdash.Services
{
    /// <summary>
    /// Represents a service describing the state of the round being played.
    /// </summary>
    public interface IQuestionService
    {
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
        /// Determines if the given player is the dasher.
        /// </summary>
        /// <param name="player">The player to check.</param>
        /// <returns>True if the player is the dasher, otherwise false.</returns>
        bool IsPlayerDasher(Player player);

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
        void ConfirmAnswers();
        /// <summary>
        /// Ends the round and prepares to begin the next.
        /// </summary>
        void EndRound();

        /// <summary>
        /// Occurs when the dasher has been set.
        /// </summary>
        event EventHandler? DasherSet;
        /// <summary>
        /// Occurs when the question text has been set.
        /// </summary>
        event EventHandler? QuestionSet;
        /// <summary>
        /// Occurs when an answer has been submitted by a player.
        /// </summary>
        event EventHandler? AnswerReceived;
        /// <summary>
        /// Occurs when the dasher has reviewed and accepted the answers.
        /// </summary>
        event EventHandler? AnswersConfirmed;
        /// <summary>
        /// Occurs when the round has been ended.
        /// </summary>
        event EventHandler? RoundEnded;

        /// <summary>
        /// Gets a fallback implementation of question service interface.
        /// </summary>
        public static IQuestionService Null { get; } = new NullQuestionService();

        private class NullQuestionService : IQuestionService
        {
            public string DasherName => string.Empty;
            public string QuestionText => string.Empty;

            public IEnumerable<Answer> Answers => Enumerable.Empty<Answer>();
            public IEnumerable<Answer> Options => Enumerable.Empty<Answer>();

            public bool IsDasherSet => false;
            public bool IsQuestionSet => false;
            public bool IsQuestionComplete => false;

            public bool IsPlayerDasher(Player player) => false;

            public void SetDasher(Player player) { DasherSet?.Invoke(this, EventArgs.Empty); }
            public void SetQuestion(Question question) { QuestionSet?.Invoke(this, EventArgs.Empty); }
            public void SubmitAnswer(Answer answer) { AnswerReceived?.Invoke(this, EventArgs.Empty); }
            public void RemoveAnswer(Answer answer) { }
            public void ConfirmAnswers() { AnswersConfirmed?.Invoke(this, EventArgs.Empty); }
            public void EndRound() { RoundEnded?.Invoke(this, EventArgs.Empty); }

            public event EventHandler? DasherSet;
            public event EventHandler? QuestionSet;
            public event EventHandler? AnswerReceived;
            public event EventHandler? AnswersConfirmed;
            public event EventHandler? RoundEnded;
        }
    }
}

using Balderdash.Extensions;
using Balderdash.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Balderdash.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly List<Answer> _answers = new List<Answer>();

        private Player? _dasher;
        private Question? _question;

        public IEnumerable<Answer> Answers => _answers;
        public IEnumerable<Answer> Options { get; private set; } = Enumerable.Empty<Answer>();

        public string DasherName => _dasher?.Name ?? "The dasher";
        public string QuestionText => _question?.QuestionText ?? "ERROR: Question not set.";

        public bool IsDasherSet => !(_dasher is null);
        public bool IsQuestionSet => !(_question is null);
        public bool IsQuestionComplete => Options.Any();

        public event EventHandler? DasherSet;
        public event EventHandler? QuestionSet;
        public event EventHandler? AnswerReceived;
        public event EventHandler? AnswersConfirmed;
        public event EventHandler? RoundEnded;

        public bool IsPlayerDasher(Player player) => player == _dasher;

        public void SetDasher(Player player)
        {
            _dasher = player;

            DasherSet?.Invoke(this, EventArgs.Empty);
        }

        public void SetQuestion(Question question)
        {
            _question = question;

            QuestionSet?.Invoke(this, EventArgs.Empty);
        }

        public void SubmitAnswer(Answer answer)
        {
            _answers.Add(answer);

            AnswerReceived?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveAnswer(Answer answer)
        {
            _answers.Remove(answer);
        }

        public void ConfirmAnswers()
        {
            Options = Answers
                .Shuffle()
                .ToList();

            AnswersConfirmed?.Invoke(this, EventArgs.Empty);
        }

        public void EndRound()
        {
            _dasher = null;
            _question = null;
            _answers.Clear();
            Options = Enumerable.Empty<Answer>();

            RoundEnded?.Invoke(this, EventArgs.Empty);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Balderdash.Data
{
    public class QuestionService : IQuestionService
    {
        private readonly List<Answer> _answers = new List<Answer>();

        public Player? Dasher { get; private set; }
        public Question? Question { get; private set; }

        public IEnumerable<Answer> Answers => _answers;
        public IEnumerable<Answer> Options { get; private set; } = Enumerable.Empty<Answer>();

        public string DasherName => Dasher?.Name ?? "The dasher";
        public string QuestionText => Question?.QuestionText ?? "ERROR: Question not set.";

        public bool IsDasherSet => !(Dasher is null);
        public bool IsQuestionSet => !(Question is null);
        public bool IsQuestionComplete => Options.Any();

        public event Action? DasherSet;
        public event Action? QuestionSet;
        public event Action? AnswerReceived;
        public event Action? AnswersConfirmed;
        public event Action? RoundEnded;

        public void SetDasher(Player player)
        {
            Dasher = player;

            DasherSet?.Invoke();
        }

        public void SetQuestion(Question question)
        {
            Question = question;

            QuestionSet?.Invoke();
        }

        public void SubmitAnswer(Answer answer)
        {
            _answers.Add(answer);

            AnswerReceived?.Invoke();
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

            AnswersConfirmed?.Invoke();
        }

        public void EndRound()
        {
            Dasher = null;
            Question = null;
            _answers.Clear();
            Options = Enumerable.Empty<Answer>();

            RoundEnded?.Invoke();
        }
    }
}

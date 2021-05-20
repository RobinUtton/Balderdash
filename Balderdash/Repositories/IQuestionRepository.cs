using Balderdash.Models;
using System;
using System.Collections.Generic;

namespace Balderdash.Repositories
{
    public interface IQuestionRepository
    {
        bool IsDasherSet(string gameId);
        bool IsQuestionSet(string gameId);
        bool IsQuestionComplete(string gameId);

        Player? GetDasher(string gameId);
        Question? GetQuestion(string gameId);
        IEnumerable<Answer> GetAnswers(string gameId);

        void SetDasher(string gameId, Player dasher);
        void SetQuestion(string gameId, Question question);
        void SubmitAnswer(string gameId, Answer answer);
        void RemoveAnswer(string gameId, Answer answer);
        void ConfirmAnswers(string gameId);
        void EndRound(string gameId);

        public event EventHandler<GameIdEventArgs>? DasherSet;
        public event EventHandler<GameIdEventArgs>? QuestionSet;
        public event EventHandler<GameIdEventArgs>? AnswerReceived;
        public event EventHandler<GameIdEventArgs>? AnswersConfirmed;
        public event EventHandler<GameIdEventArgs>? RoundEnded;
    }
}
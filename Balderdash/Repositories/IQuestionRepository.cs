using Balderdash.Models;
using System.Collections.Generic;

namespace Balderdash.Repositories
{
    public interface IQuestionRepository
    {
        bool IsDasherSet(string gameID);
        bool IsQuestionSet(string gameID);
        bool IsQuestionComplete(string gameID);

        Player? GetDasher(string gameID);
        Question? GetQuestion(string gameID);
        IEnumerable<Answer> GetAnswers(string gameID);

        void SetDasher(string gameID, Player dasher);
        void SetQuestion(string gameID, Question question);
        void SubmitAnswer(string gameID, Answer answer);
        void ConfirmAnswers(string gameID);
        void EndRound(string gameID);
    }
}
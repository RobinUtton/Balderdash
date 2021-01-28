using Balderdash.Models;
using System;
using System.Collections.Generic;

namespace Balderdash.Repositories
{
    public class InMemoryQuestionRepository : IQuestionRepository
    {
        private readonly Dictionary<string, IGameState> _gameStates = new Dictionary<string, IGameState>();

        public bool IsDasherSet(string gameID) => GetGameState(gameID).IsDasherSet;
        public bool IsQuestionSet(string gameID) => GetGameState(gameID).IsQuestionSet;
        public bool IsQuestionComplete(string gameID) => GetGameState(gameID).IsQuestionComplete;

        public Player? GetDasher(string gameID) => GetGameState(gameID).Dasher;
        public Question? GetQuestion(string gameID) => GetGameState(gameID).Question;
        public IEnumerable<Answer> GetAnswers(string gameID) => GetGameState(gameID).Answers;

        public void SetDasher(string gameID, Player dasher)
        {
            UpdateGameState(gameID, gs => new DasherSetGameState(dasher, gs));
        }
        public void SetQuestion(string gameID, Question question)
        {
            UpdateGameState(gameID, gs => new QuestionSetGameState(question, gs));
        }
        public void SubmitAnswer(string gameID, Answer answer)
        {
            UpdateGameState(gameID, gs => new AnswerSubmittedGameState(answer, gs));
        }
        public void ConfirmAnswers(string gameID)
        {
            UpdateGameState(gameID, gs => new AnswersConfirmedGameState(gs));
        }
        public void EndRound(string gameID)
        {
            DeleteGameState(gameID);
        }

        private IGameState GetGameState(string gameID) => _gameStates.ContainsKey(gameID) ? _gameStates[gameID] : new NewRoundGameState();
        private void UpdateGameState(string gameID, Func<IGameState, IGameState> change)
        {
            _gameStates[gameID] = change(GetGameState(gameID));
        }
        private void DeleteGameState(string gameID)
        {
            _gameStates.Remove(gameID);
        }
    }
}

using Balderdash.Models;
using System;
using System.Collections.Generic;

namespace Balderdash.Repositories
{
    public class InMemoryQuestionRepository : IQuestionRepository
    {
        private readonly Dictionary<string, IGameState> _gameStates = new Dictionary<string, IGameState>();

        public bool IsDasherSet(string gameId) => GetGameState(gameId).IsDasherSet;
        public bool IsQuestionSet(string gameId) => GetGameState(gameId).IsQuestionSet;
        public bool IsQuestionComplete(string gameId) => GetGameState(gameId).IsQuestionComplete;

        public Player? GetDasher(string gameId) => GetGameState(gameId).Dasher;
        public Question? GetQuestion(string gameId) => GetGameState(gameId).Question;
        public IEnumerable<Answer> GetAnswers(string gameId) => GetGameState(gameId).Answers;

        public void SetDasher(string gameId, Player dasher)
        {
            UpdateGameState(gameId, gs => new DasherSetGameState(dasher, gs));

            DasherSet?.Invoke(this, new GameIdEventArgs(gameId));
        }
        public void SetQuestion(string gameId, Question question)
        {
            UpdateGameState(gameId, gs => new QuestionSetGameState(question, gs));

            QuestionSet?.Invoke(this, new GameIdEventArgs(gameId));
        }
        public void SubmitAnswer(string gameId, Answer answer)
        {
            UpdateGameState(gameId, gs => new AnswerSubmittedGameState(answer, gs));

            AnswerReceived?.Invoke(this, new GameIdEventArgs(gameId));
        }
        public void RemoveAnswer(string gameId, Answer answer)
        {
            UpdateGameState(gameId, gs => new AnswerRemovedGameState(answer, gs));
        }
        public void ConfirmAnswers(string gameId)
        {
            UpdateGameState(gameId, gs => new AnswersConfirmedGameState(gs));

            AnswersConfirmed?.Invoke(this, new GameIdEventArgs(gameId));
        }
        public void EndRound(string gameId)
        {
            DeleteGameState(gameId);

            RoundEnded?.Invoke(this, new GameIdEventArgs(gameId));
        }

        private IGameState GetGameState(string gameId) => _gameStates.ContainsKey(gameId) ? _gameStates[gameId] : new NewRoundGameState();
        private void UpdateGameState(string gameId, Func<IGameState, IGameState> change)
        {
            _gameStates[gameId] = change(GetGameState(gameId));
        }
        private void DeleteGameState(string gameId)
        {
            _gameStates.Remove(gameId);
        }

        public event EventHandler<GameIdEventArgs>? DasherSet;
        public event EventHandler<GameIdEventArgs>? QuestionSet;
        public event EventHandler<GameIdEventArgs>? AnswerReceived;
        public event EventHandler<GameIdEventArgs>? AnswersConfirmed;
        public event EventHandler<GameIdEventArgs>? RoundEnded;
    }
}

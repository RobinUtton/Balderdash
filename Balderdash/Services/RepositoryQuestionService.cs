using Balderdash.Models;
using Balderdash.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Balderdash.Services
{
    public class RepositoryQuestionService : IQuestionService, IDisposable
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IPlayerService _playerService;

        private string GameId => _playerService.GameId;

        public RepositoryQuestionService(IQuestionRepository questionRepository, IPlayerService playerService)
        {
            _questionRepository = questionRepository;
            _playerService = playerService;

            RegisterCallbacks();
        }

        public string DasherName => _questionRepository.GetDasher(GameId)?.Name ?? string.Empty;

        public string QuestionText => _questionRepository.GetQuestion(GameId)?.QuestionText ?? string.Empty;

        public IEnumerable<Answer> Answers => _questionRepository.GetAnswers(GameId) ?? Enumerable.Empty<Answer>();

        public IEnumerable<Answer> Options => _questionRepository.GetAnswers(GameId) ?? Enumerable.Empty<Answer>();

        public bool IsDasherSet => _questionRepository.IsDasherSet(GameId);

        public bool IsQuestionSet => _questionRepository.IsQuestionSet(GameId);

        public bool IsQuestionComplete => _questionRepository.IsQuestionComplete(GameId);

        public event Action? DasherSet;
        public event Action? QuestionSet;
        public event Action? AnswerReceived;
        public event Action? AnswersConfirmed;
        public event Action? RoundEnded;

        public void ConfirmAnswers()
        {
            _questionRepository.ConfirmAnswers(GameId);
        }

        public void EndRound()
        {
            _questionRepository.EndRound(GameId);
        }

        public bool IsPlayerDasher(Player player)
        {
            return _questionRepository.GetDasher(GameId) is Player dasher && dasher == player;
        }

        public void RemoveAnswer(Answer answer)
        {
            _questionRepository.RemoveAnswer(GameId, answer);
        }

        public void SetDasher(Player player)
        {
            _questionRepository.SetDasher(GameId, player);
        }

        public void SetQuestion(Question question)
        {
            _questionRepository.SetQuestion(GameId, question);
        }

        public void SubmitAnswer(Answer answer)
        {
            _questionRepository.SubmitAnswer(GameId, answer);
        }

        private void RegisterCallbacks()
        {
            _questionRepository.DasherSet += OnDasherSet;
            _questionRepository.QuestionSet += OnQuestionSet;
            _questionRepository.AnswerReceived += OnAnswerReceived;
            _questionRepository.AnswersConfirmed += OnAnswersConfirmed;
            _questionRepository.RoundEnded += OnRoundEnded;
        }

        private void UnregisterCallbacks()
        {
            _questionRepository.DasherSet -= OnDasherSet;
            _questionRepository.QuestionSet -= OnQuestionSet;
            _questionRepository.AnswerReceived -= OnAnswerReceived;
            _questionRepository.AnswersConfirmed -= OnAnswersConfirmed;
            _questionRepository.RoundEnded -= OnRoundEnded;
        }

        private void OnDasherSet(string gameId)
        {
            if (gameId == GameId)
                DasherSet?.Invoke();
        }

        private void OnQuestionSet(string gameId)
        {
            if (gameId == GameId)
                QuestionSet?.Invoke();
        }

        private void OnAnswerReceived(string gameId)
        {
            if (gameId == GameId)
                AnswerReceived?.Invoke();
        }

        private void OnAnswersConfirmed(string gameId)
        {
            if (gameId == GameId)
                AnswersConfirmed?.Invoke();
        }

        private void OnRoundEnded(string gameId)
        {
            if (gameId == GameId)
                RoundEnded?.Invoke();
        }

        void IDisposable.Dispose()
        {
            UnregisterCallbacks();
        }
    }
}

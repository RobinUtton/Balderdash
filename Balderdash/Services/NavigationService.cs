using Microsoft.AspNetCore.Components;
using System;

namespace Balderdash.Services
{
    public class NavigationService : INavigationService, IDisposable
    {
        private readonly NavigationManager _navigationManager;
        private readonly IQuestionService _questionService;
        private readonly IPlayerService _playerService;

        public NavigationService(NavigationManager navigationManager, IQuestionService questionService, IPlayerService playerService)
        {
            _navigationManager = navigationManager;
            _questionService = questionService;
            _playerService = playerService;
        }

        public void Joined()
        {
            RegisterCallbacks();

            NewRound();
        }

        public void NewRound()
        {
            if (!_questionService.IsDasherSet)
            {
                NavigateTo("/Start");
            }
            else if (!_questionService.IsQuestionSet)
            {
                NavigateTo("/AwaitQuestion");
            }
            else if (!_questionService.IsQuestionComplete)
            {
                NavigateTo("/Respond");
            }
            else
            {
                NavigateTo("/Results");
            }
        }

        public void BecameDasher()
        {
            NavigateTo("/Ask");
        }

        public void Asked()
        {
            NavigateTo("/Respond");
        }

        public void Answered()
        {
            if (!_questionService.IsQuestionComplete)
            {
                if (_playerService.Player == _questionService.Dasher)
                {
                    NavigateTo("/ReceiveAnswers");
                }
                else
                {
                    NavigateTo("/AwaitResults");
                }
            }
            else
            {
                NavigateTo("/Results");
            }
        }

        public void Edit(int id)
        {
            NavigateTo($"/EditAnswer/{id}");
        }

        /// <summary>
        /// Navigates to a given URI.
        /// </summary>
        /// <param name="uri">The URI of the page to navigate to.</param>
        private void NavigateTo(string uri)
        {
            _navigationManager.NavigateTo(uri);
        }

        /// <summary>
        /// Registers callbacks with the question service events.
        /// </summary>
        private void RegisterCallbacks()
        {
            _questionService.DasherSet += OnDasherSet;
            _questionService.QuestionSet += OnQuestionSet;
            _questionService.AnswersConfirmed += OnQuestionCompleted;
            _questionService.RoundEnded += OnRoundEnded;
        }

        /// <summary>
        /// Unregisters callbacks from the question service events.
        /// </summary>
        private void UnregisterCallbacks()
        {
            _questionService.DasherSet -= OnDasherSet;
            _questionService.QuestionSet -= OnQuestionSet;
            _questionService.AnswersConfirmed -= OnQuestionCompleted;
            _questionService.RoundEnded -= OnRoundEnded;
        }

        private void OnDasherSet()
        {
            NavigateTo("/AwaitQuestion");
        }

        private void OnQuestionSet()
        {
            if (_playerService.Player != _questionService.Dasher)
            {
                NavigateTo("/Respond");
            }
        }

        private void OnQuestionCompleted()
        {
            NavigateTo("/Results");
        }

        private void OnRoundEnded()
        {
            NewRound();
        }

        void IDisposable.Dispose()
        {
            UnregisterCallbacks();
        }
    }
}

﻿using Balderdash.Services;
using Microsoft.AspNetCore.Components;
using System;

namespace Balderdash.Pages
{
    public partial class ReceiveAnswers
    {
        [Inject] IQuestionService QuestionService { get; set; } = IQuestionService.Null;
        [Inject] INavigationService NavigationService { get; set; } = INavigationService.Null;

        protected override void OnInitialized()
        {
            QuestionService.AnswerReceived += AnswerReceived;
        }

        private void AnswerReceived(object? sender, EventArgs e)
        {
            InvokeAsync(StateHasChanged);
        }

        private void Continue()
        {
            QuestionService.ConfirmAnswers();
        }

        private EventCallback Edit(int id)
        {
            NavigationService.Edit(id);

            return EventCallback.Empty;
        }
    }
}

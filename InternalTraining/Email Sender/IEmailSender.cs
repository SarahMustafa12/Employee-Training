﻿namespace InternalTraining.Email_Sender
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

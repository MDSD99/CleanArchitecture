﻿using CleanArchitecture.App.Services;
using System.Net.Mail;
using GenericEmailService;
using System.Net.Mail;

namespace CleanArchitecture.Infrastructure.Services
{
    public sealed class MailService : IMailService
    {
        public async Task SendMailAsync(List<string> emails, string subject, string body, List<Attachment> attachments = null)
        {
            SendEmailModel sendEmailModel = new()
            {
                Body = body,
                Attachments = attachments,
                Emails = emails,
                Email = "",
                Html = true,
                Password = "",
                Port = 587,
                Smtp = "",
                SSL = true,
                Subject = subject,
                //Attachments = attachments
            };

            await EmailService.SendEmailAsync(sendEmailModel);
        }
    }
}


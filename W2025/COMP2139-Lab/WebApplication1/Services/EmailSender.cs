﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace WebApplication1.Services;

public class EmailSender:IEmailSender
{
    private readonly string _sendGridApiKey;

    public EmailSender(IConfiguration configuration)
    {
        _sendGridApiKey = configuration["SendGrid:ApiKey"] ?? throw new ArgumentException("SendGrid key is missing");
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        try
        {
            var client = new SendGridClient(_sendGridApiKey);
            var from = new EmailAddress("pyylppppx382@gmail.com", "PM Tool Default Sender");
            var to = new EmailAddress(email);
            var msg = MailHelper
                .CreateSingleEmail(from, to, subject, "Welcome to PM Tool Inc", message);
            var response = await client.SendEmailAsync(msg);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Body.ReadAsStringAsync();
                Console.WriteLine($"An error occured while sending email: {errorMessage}");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occured while sending email: {e.Message}");
            throw;
        }
    }
}
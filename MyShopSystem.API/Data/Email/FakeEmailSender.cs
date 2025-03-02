using Microsoft.AspNetCore.Identity.UI.Services;

namespace MyShopSystem.API.Data.Email
{
    public class FakeEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine($"Fake Email Send to: {email}, Subject: {subject}");
            return Task.CompletedTask;
        }
    }
}

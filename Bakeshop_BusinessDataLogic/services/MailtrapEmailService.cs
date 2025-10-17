using System;
using System.Threading;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Bakeshop_BusinessLogic.Services
{
    public class MailtrapEmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public MailtrapEmailService(EmailSettings settings)
        {
            _settings = settings;
        }

        public async Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default)
        {
            var mimeMessage = new MimeMessage();

            mimeMessage.From.Add(new MailboxAddress(_settings.FromName, _settings.FromEmail));
            foreach (var to in message.To)
            {
                mimeMessage.To.Add(MailboxAddress.Parse(to));
            }

            mimeMessage.Subject = message.Subject ?? string.Empty;

            var builder = new BodyBuilder
            {
                HtmlBody = message.BodyHtml,
                TextBody = message.BodyText
            };

            mimeMessage.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            try
            {
                await smtp.ConnectAsync(_settings.SmtpHost, _settings.SmtpPort, SecureSocketOptions.StartTls, cancellationToken);
                await smtp.AuthenticateAsync(_settings.SmtpUser, _settings.SmtpPass, cancellationToken);
                await smtp.SendAsync(mimeMessage, cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EmailService] Failed: {ex.Message}");
                throw;
            }
            finally
            {
                await smtp.DisconnectAsync(true, cancellationToken);
            }
        }
    }
}

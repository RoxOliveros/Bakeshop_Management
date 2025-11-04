using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using Microsoft.Extensions.Configuration;

namespace Email
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(string accountName, string accountEmail)
        {
           
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("from: rox", "sbhjsf"));
            message.To.Add(new MailboxAddress(accountName, accountEmail));
            message.Subject = "Welcome to Bakeshop Management System";

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $@"
                <html>
                <body style='font-family:Segoe UI, sans-serif; background-color:#fdf6f0;'>
                    <div style='max-width:600px; margin:40px auto; background:#fff; border-radius:10px; overflow:hidden;'>
                        <div style='background:#f8c291; padding:20px; text-align:center;'>
                            <h1 style='color:#5d4037; margin:0;'>🥐 Welcome to Bakeshop Management!</h1>
                        </div>
                        <div style='padding:30px; color:#333;'>
                            <h2>Hello {accountName}!</h2>
                            <p>We’re thrilled to have you as part of the <strong>Cozy Family</strong>! 🍰</p>
                            <p>Enjoy managing your favorite treats and tracking your orders effortlessly.</p>
                            <a href='#' style='background:#f8c291; color:#5d4037; padding:10px 20px; text-decoration:none; border-radius:5px;'>Explore the Menu</a>
                        </div>
                        <div style='background:#f3e5ab; text-align:center; padding:15px; font-size:13px; color:#5d4037;'>
                            © {DateTime.Now.Year} Cozy Crust. All Rights Reserved.
                        </div>
                    </div>
                </body>
                </html>"
            };

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(
                    _config["EmailSettings:SmtpHost"],
                    int.Parse(_config["EmailSettings:SmtpPort"]),
                    SecureSocketOptions.StartTls
                );

                client.Authenticate(
                    _config["EmailSettings:Username"],
                    _config["EmailSettings:Password"]
                );

                client.Send(message);
                client.Disconnect(true);
            }


        }
    }
}

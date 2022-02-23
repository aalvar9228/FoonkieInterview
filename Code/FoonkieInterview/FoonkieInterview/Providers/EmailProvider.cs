using FoonkieInterview.Common.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FoonkieInterview.Providers
{
    public class EmailProvider : IEmailProvider
    {
        public async Task SendEmail(string subject, string body, List<string> recipients = null)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients ?? new List<string>()
                };
                await Email.ComposeAsync(message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}

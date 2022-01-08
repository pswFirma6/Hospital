﻿using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace HospitalAPI.ImplService
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;

            _emailConfig.From = "HospitalBeyondCare@gmail.com";
            _emailConfig.SmtpServer = "smtp.gmail.com";
            _emailConfig.Port = 465;
            _emailConfig.UserName = "HospitalBeyondCare@gmail.com";
            _emailConfig.Password = "hospital12345";

        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        public async Task SendEmailAsync(Message message)
        {
            var mailMessage = CreateEmailMessage(message);

            await SendAsync(mailMessage);
        }

        public MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder 
            { 
                HtmlBody = "<!DOCTYPE html><title></title><meta content=\"text/html; charset=utf-8\"http-equiv=Content-Type><meta content=\"width=device-width,initial-scale=1\"name=viewport><meta content=\"IE=edge\"http-equiv=X-UA-Compatible><style>@media screen{@font-face{font-family:Lato;font-style:normal;font-weight:400;src:local('Lato Regular'),local('Lato-Regular'),url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format('woff')}@font-face{font-family:Lato;font-style:normal;font-weight:700;src:local('Lato Bold'),local('Lato-Bold'),url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format('woff')}@font-face{font-family:Lato;font-style:italic;font-weight:400;src:local('Lato Italic'),local('Lato-Italic'),url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format('woff')}@font-face{font-family:Lato;font-style:italic;font-weight:700;src:local('Lato Bold Italic'),local('Lato-BoldItalic'),url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format('woff')}}a,body,table,td{-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%}table,td{mso-table-lspace:0;mso-table-rspace:0}img{-ms-interpolation-mode:bicubic}img{border:0;height:auto;line-height:100%;outline:0;text-decoration:none}table{border-collapse:collapse!important}body{height:100%!important;margin:0!important;padding:0!important;width:100%!important}a[x-apple-data-detectors]{color:inherit!important;text-decoration:none!important;font-size:inherit!important;font-family:inherit!important;font-weight:inherit!important;line-height:inherit!important}@media screen and (max-width:600px){h1{font-size:32px!important;line-height:32px!important}}div[style*=\"margin: 16px 0;\"]{margin:0!important}</style><body style=background-color:#f4f4f4;margin:0!important;padding:0!important><div style=display:none;font-size:1px;color:#fefefe;line-height:1px;font-family:Lato,Helvetica,Arial,sans-serif;max-height:0;max-width:0;opacity:0;overflow:hidden>We're thrilled to have you here! Get ready to dive into your new account.</div><table border=0 cellpadding=0 cellspacing=0 width=100%><tr><td align=center bgcolor=#db2b1f><table border=0 cellpadding=0 cellspacing=0 width=100% style=max-width:600px><tr><td align=center style=\"padding:40px 10px 40px 10px\"valign=top></table><tr><td align=center bgcolor=#db2b1f style=\"padding:0 10px 0 10px\"><table border=0 cellpadding=0 cellspacing=0 width=100% style=max-width:600px><tr><td align=center bgcolor=#ffffff style=\"padding:40px 20px 20px 20px;border-radius:4px 4px 0 0;color:#111;font-family:Lato,Helvetica,Arial,sans-serif;font-size:48px;font-weight:400;letter-spacing:4px;line-height:48px\"valign=top><h1 style=font-size:48px;font-weight:400;margin:2>Welcome!</h1><h2 style=font-size:28px;font-weight:10;margin:2>To Hospital Beyond Care</h2><img height=120 src=https://img.icons8.com/clouds/100/000000/handshake.png style=display:block;border:0 width=125></table><tr><td align=center bgcolor=#f4f4f4 style=\"padding:0 10px 0 10px\"><table border=0 cellpadding=0 cellspacing=0 width=100% style=max-width:600px><tr><td align=left bgcolor=#ffffff style=\"padding:20px 30px 40px 30px;color:#666;font-family:Lato,Helvetica,Arial,sans-serif;font-size:18px;font-weight:400;line-height:25px\"><p style=margin:0>We're excited to have you get started with Hospital Beyond Care. First, you need to confirm your account. Just press the button below.<tr><td align=left bgcolor=#ffffff><table border=0 cellpadding=0 cellspacing=0 width=100%><tr><td align=center bgcolor=#ffffff style=\"padding:20px 30px 60px 30px\"><table border=0 cellpadding=0 cellspacing=0><tr><td align=center bgcolor=#db2b1f style=border-radius:3px><a href=\"" + message.Content + "\" style=\"font-size:20px;font-family:Helvetica,Arial,sans-serif;color:#fff;text-decoration:none;color:#fff;text-decoration:none;padding:15px 25px;border-radius:2px;border:1px solid #db2b1f;display:inline-block\"target=_blank>Confirm Account</a></table></table></table></table>", 
            };

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                    client.Send(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}

/*
 * Acknowledgements:
 * https://stackoverflow.com/questions/15796067/sending-email-using-smtp-in-c-sharp 
 */

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace OrbitalDrydock.IO
{
    public class MailUtil
    {
        public static string sendEmail(
            MailAddress from
            , MailAddress to
            , MailAddress cc
            , MailAddress bcc
            , MailAddress replyto
            , string subject
            , string body
            , string host
            , uint port
            , uint timeOut
            , bool useSsl
            , bool isBodyHtml
            , string password)
        {
            return sendEmail(
                getAddress(from)
                , getAddress(to)
                , getAddress(cc)
                , getAddress(bcc)
                , getAddress(replyto)
                , subject
                , body
                , host
                , (int)port
                , (int)timeOut
                , useSsl
                , isBodyHtml
                , password);
        }
        public static string sendEmail(
           string from
           , string to
           , string cc
           , string bcc
           , string replyto
           , string subject
           , string body
           , string host
           , int port
           , int timeOut
           , bool useSsl
           , bool isBodyHtml
           , string password)
        {
            List<string> response = new List<string>();

            if (string.IsNullOrEmpty(from)
            || string.IsNullOrEmpty(to)
            || string.IsNullOrEmpty(host)
            || port < 0
            || timeOut < 0)
            {
                response.Add("Received bad input.");
            }
            else
            {
                SmtpClient smtpClient = new SmtpClient(host, port);
                try
                {
                    MailMessage mailMessage = new MailMessage(from, to, subject, body);

                    if (!string.IsNullOrEmpty(bcc))
                    {
                        mailMessage.Bcc.Add(new MailAddress(bcc));
                    }
                    if (!string.IsNullOrEmpty(cc))
                    {
                        mailMessage.CC.Add(new MailAddress(cc));
                    }
                    if (!string.IsNullOrEmpty(replyto))
                    {
                        mailMessage.ReplyToList.Add(new MailAddress(replyto));
                    }

                    mailMessage.IsBodyHtml = isBodyHtml;
                    mailMessage.Priority = MailPriority.Normal;
                    smtpClient.EnableSsl = useSsl;
                    smtpClient.Timeout = timeOut;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(mailMessage.From.ToString(), password);
                    smtpClient.Send(mailMessage);
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.Message, "exception.Message");
                    response.Add(exception.Message);
                }
                finally
                {
                    smtpClient.Dispose();
                }
            }

            return string.Join(string.Empty, response.ToArray());
        }

        private static string getAddress(MailAddress mailAddress)
        {
            return mailAddress != null ? mailAddress.Address : null;
        }
    }
}

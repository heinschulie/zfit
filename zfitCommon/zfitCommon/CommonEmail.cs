using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;

namespace Zephry
{
    /// <summary>
    /// A static utility class with commonly used Email and Calendar methods
    /// </summary>
    public static class CommonEmail
    {
        #region SendEmailMessage
        /// <summary>
        /// Sends the email message.
        /// </summary>
        /// <param name="aEmailHost">A email host.</param>
        /// <param name="aEmailArgument">A email argument.</param>
        public static void SendEmailMessage(EmailHost aEmailHost, EmailArgument aEmailArgument)
        {
            try
            {
                using (var vMailMessage = GetEmailMessage(aEmailArgument))
                {
                    SendMail(aEmailHost, vMailMessage);
                }
            }
            catch (Exception ex)
            {
                throw new ZpCodedException(SourceAssembly.Common, ex.Message, "SendEmailException", "SendEmailMessage", "Email", ex.InnerException);
            }
        }
        #endregion

        #region GetEmailMessage
        /// <summary>
        /// Returns an Email Message as a standard <see cref="MailMessage"/>.
        /// </summary>
        /// <param name="aEmailArgument">A email argument.</param>
        /// <returns></returns>
        private static MailMessage GetEmailMessage(EmailArgument aEmailArgument)
        {
            var vMailMessage = new MailMessage();

            // Add text and HTML views
            vMailMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(aEmailArgument.Body, new ContentType("text/plain")));
            vMailMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(aEmailArgument.Body, new ContentType("text/html")));
            //  Address the message to not-empty addresses
            vMailMessage.From = new MailAddress(aEmailArgument.Organizer.Address, aEmailArgument.Organizer.DisplayName);
            aEmailArgument.RecipientList.ForEach(vEmailAddress =>
            {
                if (!String.IsNullOrWhiteSpace(vEmailAddress.Address))
                {
                    vMailMessage.To.Add(new MailAddress(vEmailAddress.Address, vEmailAddress.DisplayName));
                }
            });
            vMailMessage.Subject = aEmailArgument.Subject;

            return vMailMessage;
        }
        #endregion

        #region SendMeetingRequest
        /// <summary>
        /// Sends an Email Message as a meeting request.
        /// </summary>
        /// <param name="aEmailHost">A email host.</param>
        /// <param name="aEmailArgument">A email argument.</param>
        public static void SendMeetingRequest(EmailHost aEmailHost, EmailArgument aEmailArgument)
        {
            try
            {
                using (var vMailMessage = GetMeetingRequest(aEmailArgument))
                {
                    SendMail(aEmailHost, vMailMessage);
                }
            }
            catch (Exception ex)
            {
                throw new ZpCodedException(SourceAssembly.Common, ex.Message, "SendEmailException", "SendMeetingRequest", "Email", ex.InnerException);
            }
        }
        #endregion

        #region GetMeetingRequest
        /// <summary>
        /// Returns a Meeting Request as a standard <see cref="MailMessage"/>.
        /// </summary>
        /// <param name="aEmailArgument">A email argument.</param>
        /// <returns></returns>
        private static MailMessage GetMeetingRequest(EmailArgument aEmailArgument)
        {
            var vMailMessage = new MailMessage();

            // Add text and HTML views
            vMailMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(GetMeetingBodyText(aEmailArgument), new ContentType("text/plain")));
            vMailMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(GetMeetingBodyHtml(aEmailArgument), new ContentType("text/html")));
            // Add Calendar View
            var calendarView = AlternateView.CreateAlternateViewFromString(GetMeetingBodyCalendar(aEmailArgument), new ContentType("text/calendar; method=REQUEST; charset=utf-8; name=invite.ics"));
            calendarView.TransferEncoding = TransferEncoding.SevenBit;
            vMailMessage.AlternateViews.Add(calendarView);
            //  Address the message to not-empty addresses
            vMailMessage.From = new MailAddress(aEmailArgument.Organizer.Address, aEmailArgument.Organizer.DisplayName);
            aEmailArgument.RecipientList.ForEach(vEmailAddress => 
            {
                if (!String.IsNullOrWhiteSpace(vEmailAddress.Address))
                {
                    vMailMessage.To.Add(new MailAddress(vEmailAddress.Address, vEmailAddress.DisplayName));
                }
            });
            vMailMessage.Subject = aEmailArgument.Subject;

            return vMailMessage;
        }
        #endregion

        #region GetMeetingBodyText
        /// <summary>
        /// Gets the Text body of a Calendar View message.
        /// </summary>
        /// <param name="aEmailArgument">A email argument.</param>
        /// <returns></returns>
        private static string GetMeetingBodyText(EmailArgument aEmailArgument)
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("Type:Single Meeting");
            vStringBuilder.AppendLine(String.Format("Organizer: {0}", aEmailArgument.Organizer.DisplayName));
            vStringBuilder.AppendLine(String.Format("Start Time:{0}{1}", aEmailArgument.DateStart.ToLongDateString(), aEmailArgument.DateStart.ToLongTimeString()));
            vStringBuilder.AppendLine(String.Format("End Time:{0}{1}", aEmailArgument.DateEnd.ToLongDateString(), aEmailArgument.DateEnd.ToLongTimeString()));
            vStringBuilder.AppendLine(String.Format("Time Zone:{0}", System.TimeZone.CurrentTimeZone.StandardName));
            vStringBuilder.AppendLine(String.Format("Location: {0}", aEmailArgument.Location));
            vStringBuilder.AppendLine("");
            vStringBuilder.AppendLine("*~*~*~*~*~*~*~*~*~*");
            vStringBuilder.AppendLine("");
            vStringBuilder.AppendLine(String.Format("{0}", aEmailArgument.Summary));
            return vStringBuilder.ToString();
        }
        #endregion

        #region GetMeetingBodyHtml
        /// <summary>
        /// Gets the Html body of a Calendar View message.
        /// </summary>
        /// <param name="aEmailArgument">A email argument.</param>
        /// <returns></returns>
        private static string GetMeetingBodyHtml(EmailArgument aEmailArgument)
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine(String.Format("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 3.2//EN\">", String.Empty));
            vStringBuilder.AppendLine(String.Format("<html>", String.Empty));
            vStringBuilder.AppendLine(String.Format("    <head>", String.Empty));
            vStringBuilder.AppendLine(String.Format("        <META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html; charset=utf-8\">", String.Empty));
            vStringBuilder.AppendLine(String.Format("        <META NAME=\"Generator\" CONTENT=\"MS Exchange Server version 6.5.7652.24\">", String.Empty));
            vStringBuilder.AppendLine(String.Format("        <title>{0}</title>", aEmailArgument.Summary));
            vStringBuilder.AppendLine(String.Format("    </head>", String.Empty));
            vStringBuilder.AppendLine(String.Format("    <body>", String.Empty));
            vStringBuilder.AppendLine(String.Format("        <p><font size=2>Type: Meeting<br>", String.Empty));
            vStringBuilder.AppendLine(String.Format("           Organizer: {0}<br>", aEmailArgument.Organizer.DisplayName));
            vStringBuilder.AppendLine(String.Format("           Start Time: {0} {1}<br>", aEmailArgument.DateStart.ToLongDateString(), aEmailArgument.DateStart.ToLongTimeString()));
            vStringBuilder.AppendLine(String.Format("           End Time: {0} {1}<br>", aEmailArgument.DateEnd.ToLongDateString(), aEmailArgument.DateEnd.ToLongTimeString()));
            vStringBuilder.AppendLine(String.Format("           Time Zone:{0}<br>", System.TimeZone.CurrentTimeZone.StandardName));
            vStringBuilder.AppendLine(String.Format("           Location: {0}<br>", aEmailArgument.Location));
            vStringBuilder.AppendLine(String.Format("           <br>", String.Empty));
            vStringBuilder.AppendLine(String.Format("           Additional Notes: {0}<br></font>", aEmailArgument.Summary));
            vStringBuilder.AppendLine(String.Format("        </p>", String.Empty));
            vStringBuilder.AppendLine(String.Format("        ", String.Empty));
            vStringBuilder.AppendLine(String.Format("    </body>", String.Empty));
            vStringBuilder.AppendLine(String.Format("</html>", String.Empty));
            //
            return vStringBuilder.ToString();
        }
        #endregion

        #region GetMeetingBodyCalendar
        /// <summary>
        /// Gets the Calendar body of a Calendar View message.
        /// </summary>
        /// <param name="aEmailArgument">A email argument.</param>
        /// <returns></returns>
        private static string GetMeetingBodyCalendar(EmailArgument aEmailArgument)
        {
            const string calDateFormat = "yyyyMMddTHHmmssZ";
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("BEGIN:VCALENDAR");
            vStringBuilder.AppendLine("METHOD:REQUEST");
            vStringBuilder.AppendLine("PRODID:Microsoft Exchange Server 2007");
            vStringBuilder.AppendLine("VERSION:2.0");
            vStringBuilder.AppendLine("BEGIN:VTIMEZONE");
            vStringBuilder.AppendLine("TZID:South Africa Standard Time");
            vStringBuilder.AppendLine("BEGIN:STANDARD");
            vStringBuilder.AppendLine("DTSTART:16010101T000000");
            vStringBuilder.AppendLine("TZOFFSETFROM:+0200");
            vStringBuilder.AppendLine("TZOFFSETTO:+0200");
            vStringBuilder.AppendLine("END:STANDARD");
            vStringBuilder.AppendLine("BEGIN:DAYLIGHT");
            vStringBuilder.AppendLine("DTSTART:16010101T000000");
            vStringBuilder.AppendLine("TZOFFSETFROM:+0200");
            vStringBuilder.AppendLine("TZOFFSETTO:+0200");
            vStringBuilder.AppendLine("END:DAYLIGHT");
            vStringBuilder.AppendLine("END:VTIMEZONE");
            vStringBuilder.AppendLine("BEGIN:VEVENT");
            vStringBuilder.AppendLine(String.Format("ORGANIZER;CN={0}:MAILTO:{1}", aEmailArgument.Organizer.DisplayName, aEmailArgument.Organizer.Address));
            aEmailArgument.RecipientList.ForEach(vEmailAddress =>  
            {
                vStringBuilder.AppendLine(String.Format("ATTENDEE;ROLE=REQ-PARTICIPANT;PARTSTAT=NEEDS-ACTION;RSVP=TRUE;CN={0}:MAILTO:{1}", vEmailAddress.Address, vEmailAddress.Address));
            });
            vStringBuilder.AppendLine(String.Format("DESCRIPTION;LANGUAGE=en-US:{0}\\n\\n", aEmailArgument.Subject.Replace(",", "\\,")));
            vStringBuilder.AppendLine(String.Format("SUMMARY;LANGUAGE=en-US:{0}", aEmailArgument.Subject));            
            vStringBuilder.AppendLine(String.Format("DTSTART;TZID=South Africa Standard Time:{0}", aEmailArgument.DateStart.ToUniversalTime().ToString(calDateFormat)));
            vStringBuilder.AppendLine(String.Format("DTEND;TZID=South Africa Standard Time:{0}", aEmailArgument.DateEnd.ToUniversalTime().ToString(calDateFormat)));
            vStringBuilder.AppendLine(String.Format("UID:{0}", Guid.NewGuid().ToString("B")));
            vStringBuilder.AppendLine("CLASS:PUBLIC");
            vStringBuilder.AppendLine("PRIORITY:5");
            vStringBuilder.AppendLine(String.Format("DTSTAMP:{0}", DateTime.Now.ToUniversalTime().ToString(calDateFormat)));
            vStringBuilder.AppendLine("TRANSP:OPAQUE");
            vStringBuilder.AppendLine("STATUS:CONFIRMED");
            vStringBuilder.AppendLine("SEQUENCE:0");
            vStringBuilder.AppendLine(String.Format("LOCATION;LANGUAGE=en-US:{0}", aEmailArgument.Location));
            vStringBuilder.AppendLine("X-MICROSOFT-CDO-APPT-SEQUENCE:0");
            vStringBuilder.AppendLine("X-MICROSOFT-CDO-OWNERAPPTID:-1");
            vStringBuilder.AppendLine("X-MICROSOFT-CDO-BUSYSTATUS:TENTATIVE");
            vStringBuilder.AppendLine("X-MICROSOFT-CDO-INTENDEDSTATUS:BUSY");
            vStringBuilder.AppendLine("X-MICROSOFT-CDO-ALLDAYEVENT:FALSE");
            vStringBuilder.AppendLine("X-MICROSOFT-CDO-IMPORTANCE:1");
            vStringBuilder.AppendLine("X-MICROSOFT-CDO-INSTTYPE:0");            
            vStringBuilder.AppendLine("BEGIN:VALARM");
            vStringBuilder.AppendLine("ACTION:DISPLAY");
            vStringBuilder.AppendLine("DESCRIPTION:REMINDER");
            vStringBuilder.AppendLine("TRIGGER;RELATED=START:-PT15M");
            vStringBuilder.AppendLine("END:VALARM");
            vStringBuilder.AppendLine("END:VEVENT");
            vStringBuilder.AppendLine("END:VCALENDAR");
            //
            return vStringBuilder.ToString();
        }
        #endregion

        #region SendMail
        /// <summary>
        /// Sends the mail message via the host.
        /// </summary>
        /// <param name="aEmailHost">A email host.</param>
        /// <param name="aMailMessage">A mail message.</param>
        private static void SendMail(EmailHost aEmailHost, MailMessage aMailMessage)
        {
            using (var smtpClient = new SmtpClient()
            {
                Host = aEmailHost.Name,
                Port = aEmailHost.Port,
                EnableSsl = aEmailHost.EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = aEmailHost.UseDefaultCredentials,
                Credentials = new NetworkCredential(aEmailHost.UserID, aEmailHost.Password)
            })
            {
                smtpClient.Send(aMailMessage);
            }
        }
        #endregion

    }
}

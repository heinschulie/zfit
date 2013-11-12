using System;
using System.Collections.Generic;
using System.Linq;

namespace Zephry
{
    /// <summary>
    /// A list of parameters used in the construction of Email and Calendar Messages
    /// </summary>
    public class EmailArgument
    {
        #region Fields
        DateTime _dateStart;
        DateTime _dateEnd;
        string _subject;
        string _body;
        string _summary;
        string _location;
        private EmailAddress _organizer = new EmailAddress();
        private List<EmailAddress> _recipientList = new List<EmailAddress>();
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the date start.
        /// </summary>
        /// <value>
        /// The date start.
        /// </value>
        public DateTime DateStart
        {
            get { return _dateStart; }
            set { _dateStart = value; }
        }
        /// <summary>
        /// Gets or sets the date end.
        /// </summary>
        /// <value>
        /// The date end.
        /// </value>
        public DateTime DateEnd
        {
            get { return _dateEnd; }
            set { _dateEnd = value; }
        }
        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }    
        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        /// <value>
        /// The summary.
        /// </value>
        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        /// <summary>
        /// Gets or sets the organizer.
        /// </summary>
        /// <value>
        /// The organizer.
        /// </value>
        public EmailAddress Organizer
        {
            get { return _organizer; }
            set { _organizer = value; }
        }
        /// <summary>
        /// Gets or sets the recipients.
        /// </summary>
        /// <value>
        /// The recipients.
        /// </value>
        public List<EmailAddress> RecipientList
        {
            get { return _recipientList; }
            set { _recipientList = value; }
        }
        #endregion
    }
}

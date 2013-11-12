using System;
using System.Collections.Generic;
using System.Linq;

namespace Zephry
{
    #region Action
    /// <summary>
    /// The actions that can be performed on a POCO object, including List and CRUD.
    /// </summary>
    public enum AccessMode
    {
        List,
        Create,
        Read,
        Update,
        Delete
    }
    #endregion

    #region ActiveFilter
    /// <summary>
    ///   Active filter enumeration.
    /// </summary>
    public enum ActiveFilter
    {
        /// <summary>
        ///   Enumeration for <i>Active</i>.
        /// </summary>
        Active,
        /// <summary>
        ///   Enumeration for <i>Inactive</i>.
        /// </summary>
        Inactive,
        /// <summary>
        ///   Enumeration for <i>All</i>.
        /// </summary>
        All
    }
    #endregion

    #region AdminFilter
    /// <summary>
    ///   Admin filter enumeration.
    /// </summary>
    public enum AdminFilter
    {
        /// <summary>
        ///   Enumeration for <i>Administrator</i>.
        /// </summary>
        Admin,
        /// <summary>
        ///   Enumeration for <i>Normal</i> user.
        /// </summary>
        Normal,
        /// <summary>
        ///   Enumeration for <i>All</i>.
        /// </summary>
        All
    }
    #endregion

    #region ChangeAction
    /// <summary>
    ///   Change action enumeration.
    /// </summary>
    public enum ChangeAction
    {
        /// <summary>
        ///   Enumeration for <i>Insert</i>.
        /// </summary>
        Insert,
        /// <summary>
        ///   Enumeration for <i>Update</i>.
        /// </summary>
        Update,
        /// <summary>
        ///   Enumeration for <i>Delete</i>.
        /// </summary>
        Delete,
        /// <summary>
        ///   Enumeration for <i>Browse</i>.
        /// </summary>
        Browse
    }
    #endregion

    #region ConnectionContext
    /// <summary>
    ///   Connection context enumeration.
    /// </summary>
    public enum ConnectionContext 
    {
        Smart, Browse, Integrated 
    }
    #endregion

    #region DateOperator
    /// <summary>
    ///   A list of filter operators that can be applied to a <see cref="DateTime"/> type.
    /// </summary>
    public enum DateOperator
    {
        None, LessThan, LessEqual, GreaterThan, GreaterEqual, Equal, Between
    }
    #endregion

    #region Deviance
    /// <summary>
    /// DevianceCorrection
    /// </summary>
    public enum DevianceCorrection 
    { 
        None, 
        CorrectAmount, 
        CorrectList 
    }
    #endregion

    #region EmailPriority
    /// <summary>
    /// Email Priority
    /// </summary>
    public enum EmailPriority
    {
        Low, Normal, High
    }
    #endregion

    #region ExceptionType
    /// <summary>
    /// The type of an exception that was raised
    /// </summary>
    public enum TransactionResult
    {
        /// <summary>
        /// The transaction completed successfully
        /// </summary>
        OK = 1,
        /// <summary>
        /// The transaction raised a general exception
        /// </summary>
        GeneralException = 2,
        /// <summary>
        /// The transaction raised an access exception
        /// </summary>
        AccessException = 3
    }
    #endregion

    #region FieldType
    /// <summary>
    /// FieldType Enumerator. Describes the DataType of a Custom Field 
    /// </summary>
    public enum FieldType
    {
        /// <summary>
        /// FieldType is lookup
        /// </summary>
        Lookup = 0,
        /// <summary>
        /// FieldType is string
        /// </summary>
        String = 1,
        /// <summary>
        /// FieldType is boolean
        /// </summary>
        Boolean = 2,
        /// <summary>
        /// FieldType is Date
        /// </summary>
        Date = 3,
        /// <summary>
        /// FieldType is integer
        /// </summary>
        Integer = 4,
        /// <summary>
        /// FieldType is integer
        /// </summary>
        Float = 5
    }
    #endregion
    
    #region Gender
    /// <summary>
    /// An enumeration of Gender
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// A Male
        /// </summary>
        Male=1,
        /// <summary>
        /// A Female
        /// </summary>
        Female=2,
        /// <summary>
        /// An indeterminate gender
        /// </summary>
        Indeterminate=3
    }
    #endregion

    #region IDType
    /// <summary>
    /// An enumeration of IDType
    /// </summary>
    public enum IDType
    {
        /// <summary>
        /// A South African ID Number
        /// </summary>
        SAID=1,
        /// <summary>
        /// A South African Passport
        /// </summary>
        SAPassport=2
    }
    #endregion

    #region IntegrationKey
    /// <summary>
    /// An essentially hard-coded list of integrated organizations.
    /// </summary>
    public enum IntegrationKey
    {
        /// <summary>
        /// The Automated Fingerprint Identification Systems of the South African Police Services
        /// </summary>
        ZaAfis=1,
        /// <summary>
        /// The South African Background Screening company Managed Integrity Evaluation (Pty) Limited
        /// </summary>
        ZaMie=2
    }
    #endregion

    #region JobStatus
    /// <summary>
    /// A Status indication whether a person may work, is working or is no longer working.
    /// </summary>
    public enum JobStatus
    {
        Candidate,
        Active,
        Terminated
    }
    #endregion

    #region JobTerm
    /// <summary>
    /// A Status indication the terms of an emplyee's employment
    /// </summary>
    public enum JobTerm
    {
        None,
        Probation,
        Permanent,
        PartTime,
        Seasonal
    }
    #endregion

    #region LikertScale
    /// <summary>
    ///  A Likert scale is a psychometric scale commonly involved in research that employs questionnaires. 
    /// </summary>
    public enum LikertScale
    {
        StronglyDisagree = 1, Disagree = 2, Neutral = 3, Agree = 4, StronglyAgree = 5
    }
    #endregion

    #region ListAction
    /// <summary>
    ///   List action enumeration.
    /// </summary>
    public enum ListAction
    {
        /// <summary>
        /// Inform the list that double-click should invoke an editor.
        /// </summary>
        Change,
        /// <summary>
        /// Inform the list that double-click should return an item.
        /// </summary>
        Select,
        /// <summary>
        /// Inform the list that a drilldown operation is in progress.
        /// </summary>
        Drilldown
    }
    #endregion

    #region ListBehavior
    /// <summary>
    ///   List behavior enumeration used to specify the behavior of a Smart7  list form.
    /// </summary>
    public enum ListBehavior
    {
        /// <summary>
        ///   Normal.
        /// </summary>
        None,
        /// <summary>
        ///   Multiple selection mode.
        /// </summary>
        Checked
    }
    #endregion

    #region MailRecipientContext
    /// <summary>
    ///   MailRecipientContext enumeration is used to determine what type of email copy a recipient will receive.
    /// </summary>
    public enum MailRecipientContext
    {
        /// <summary>
        ///   Main recipient.
        /// </summary>
        To,
        /// <summary>
        ///   Carbon Copy.
        /// </summary>
        CC,
        /// <summary>
        ///   Blind Carbon Copy.
        /// </summary>
        BCC
    }
    #endregion

    #region MonthOfYear
    /// <summary>
    ///   MonthName enumeration.
    /// </summary>
    public enum MonthOfYear
    {
        /// <summary>
        ///   January
        /// </summary>
        January = 1,

        /// <summary>
        ///   February
        /// </summary>
        February = 2,

        /// <summary>
        ///   March
        /// </summary>
        March = 3,

        /// <summary>
        ///   April
        /// </summary>
        April = 4,

        /// <summary>
        ///   May
        /// </summary>
        May = 5,

        /// <summary>
        ///   June
        /// </summary>
        June = 6,

        /// <summary>
        ///   July
        /// </summary>
        July = 7,

        /// <summary>
        ///   August
        /// </summary>
        August = 8,

        /// <summary>
        ///   September
        /// </summary>
        September = 9,

        /// <summary>
        ///   October
        /// </summary>
        October = 10,

        /// <summary>
        ///   November
        /// </summary>
        November = 11,

        /// <summary>
        ///   December
        /// </summary>
        December = 12
    }
    #endregion

    #region ObjectState
    /// <summary>
    ///   An enumeration of values describing the state of an object. Typically used by lists to disable (exclude)
    ///   itemd for selection
    /// </summary>
    public enum ObjectState
    {
        /// <summary>
        /// No published ObjectState
        /// </summary>
        None,
        /// <summary>
        /// Disabled ObjectState
        /// </summary>
        Disabled,
        /// <summary>
        /// Checked ObjectState
        /// </summary>
        Checked
    }
    #endregion

    #region SourceAssembly
    /// <summary>
    ///   The SourceAssembly enumeration is used to specify in which code assembly a <see cref="ZpCodedException "/> originated.
    /// </summary>
    public enum SourceAssembly
    {
        /// <summary>
        ///   Common assembly.
        /// </summary>
        Common,
        /// <summary>
        ///   Classes assembly.
        /// </summary>
        Classes,
        /// <summary>
        ///   Data assembly.
        /// </summary>
        Data,
        /// <summary>
        ///   Business assembly.
        /// </summary>
        Business,
        /// <summary>
        ///   Services assembly.
        /// </summary>
        Services,
        /// <summary>
        ///   Consumers assembly.
        /// </summary>
        Consumers,
        /// <summary>
        ///   Controls assembly.
        /// </summary>
        Controls
    }
    #endregion

    #region TokenSource
    /// <summary>
    ///   Token source enumeration.
    /// </summary>
    public enum TokenSource
    {
        /// <summary>
        ///   Enumeration for <i>File</i>.
        /// </summary>
        File,
        /// <summary>
        ///   Enumeration for <i>Command line</i>.
        /// </summary>
        Commandline,
        /// <summary>
        ///   Enumeration for <i>Passed parameters</i>.
        /// </summary>
        Params
    }
    #endregion
}

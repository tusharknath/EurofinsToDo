#region Using namespaces.
using System;
using System.Net;
using System.Runtime.Serialization;
#endregion

namespace ToDo.WebAPI.Helper.Error
{
    /// <summary>
    /// Api Data Exception
    /// </summary>
    [Serializable]
    [DataContract]
    public class APIDataException : Exception, IAPIExceptions
    {
        #region Public Serializable properties.
        [DataMember]
        public int ErrorCode { get; set; }
        [DataMember]
        public string ErrorDescription { get; set; }
        [DataMember]
        public HttpStatusCode HttpStatus { get; set; }

        string reasonPhrase = "ApiDataException";

        [DataMember]
        public string ReasonPhrase
        {
            get { return this.reasonPhrase; }

            set { this.reasonPhrase = value; }
        }

        #endregion

        #region Public Constructor.
        /// <summary>
        /// Public constructor for Api Data Exception
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="errorDescription"></param>
        /// <param name="httpStatus"></param>
        public APIDataException(int errorCode, string errorDescription, HttpStatusCode httpStatus)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
            HttpStatus = httpStatus;
        }
        #endregion
    }
}
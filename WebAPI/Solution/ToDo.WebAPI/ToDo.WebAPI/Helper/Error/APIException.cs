#region Using namespaces.
using System;
using System.Net;
using System.Runtime.Serialization;
#endregion


namespace ToDo.WebAPI.Helper.Error
{
    /// <summary>
    /// Api Exception
    /// </summary>
    [Serializable]
    [DataContract]
    public class APIException : Exception, IAPIExceptions
    {
        #region Public Serializable properties.
        [DataMember]
        public int ErrorCode { get; set; }
        [DataMember]
        public string ErrorDescription { get; set; }
        [DataMember]
        public HttpStatusCode HttpStatus { get; set; }
        
        string reasonPhrase = "ApiException";

        [DataMember]
        public string ReasonPhrase
        {
            get { return this.reasonPhrase; }

            set { this.reasonPhrase = value; }
        }
        #endregion
    }
}
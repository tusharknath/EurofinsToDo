using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ToDo.WebAPI.Helper.Error
{
    /// <summary>
    /// IApiExceptions Interface
    /// </summary>
    public interface IAPIExceptions
    {
        /// <summary>
        /// ErrorCode
        /// </summary>
        int ErrorCode { get; set; }
        /// <summary>
        /// ErrorDescription
        /// </summary>
        string ErrorDescription { get; set; }
        /// <summary>
        /// HttpStatus
        /// </summary>
        HttpStatusCode HttpStatus { get; set; }
        /// <summary>
        /// ReasonPhrase
        /// </summary>
        string ReasonPhrase { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Tracing;
using ToDo.DomainLayer.Services;
using ToDo.WebAPI.EF.Data.Model;
using ToDo.WebAPI.Helper;
using ToDo.WebAPI.Repository.UnitOfWork;

namespace ToDo.WebAPI.Handler
{
    public class LogRequestAndResponseHandler : DelegatingHandler
    {
        private readonly ILoggerService _LoggerService;
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 
        /// </summary>
        public LogRequestAndResponseHandler()
        {
            IUnitOfWork _UoW = new UnitOfWork();
            ILoggerService loggerServiceParam = new LoggerService(_UoW);
            this._LoggerService = loggerServiceParam;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {

            // log request body
            string requestBody = await request.Content.ReadAsStringAsync();
            Trace.WriteLine(requestBody);
            logger.Info(requestBody);

            var log = new Log
            {
                UserId = 1,
                RequestIpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Helpers.GetIpAddress(),
                RequestUri = request.RequestUri.ToString(),
                RequestMethod = request.Method.Method,
                RequestPostData = Helpers.Encrypt(requestBody),
                RequestTimestamp = DateTime.Now
            };
            // let other handlers process the request
            var result = await base.SendAsync(request, cancellationToken);
            if (result.Content != null)
            {
                // once response body is ready, log it
                var responseBody = await result.Content.ReadAsStringAsync();
                Trace.WriteLine(responseBody);
                logger.Info(responseBody);

                object content;
                string errorMessage = null;
                string messageDetail = null;
                if (result.TryGetContentValue(out content) && !result.IsSuccessStatusCode)
                {
                    HttpError error = content as HttpError;
                    if (error != null)
                    {
                        messageDetail = error.MessageDetail;
                        errorMessage = error.Message;
                        errorMessage = string.Concat(errorMessage, error.ExceptionMessage, error.StackTrace);
                    }
                }
                if (messageDetail != "No route data was found for this request.")
                {
                    log.ResponseStatusCode = Convert.ToInt32(result.StatusCode).ToString();
                    log.ResponseReasonPhrase = result.ReasonPhrase;
                    log.ResponseErrorMessage = errorMessage;
                    log.ResponseTimestamp = DateTime.Now;
                    _LoggerService.Insert(log);
                }
            }
            return result;
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseMessage.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ResponseMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace TCC.Application
{    
    using System.Collections.Generic;
    using System.Net;

    public class ResponseMessage<T> where T : class
    {
        #region Propeties

        public ResponseMessage()
        {
            statusCode = HttpStatusCode.OK;
            LogicalTest = false;
        }

        public int Quantity { get; set; }
        public T Value { get; set; }
        public List<T> ValueList { get; set; }
        public string mensagem { get; set; }
        public DateTime? dataRegistro { get; set; }
        public List<string> errors { get; set; }
        public string Title { get; set; }
        public bool LogicalTest { get; set; }
        public bool UpdateNotifications { get; set; }
        public HttpStatusCode statusCode { get; set; }       

        #endregion

        #region Methods

        public ResponseMessage<T> CreateErrorResponse()
        {
            var response = new ResponseMessage<T>
            {
                LogicalTest = false,
                mensagem = "Ops! Algo de errado aconteceu. Nossa equipe de suporte já foi informada deste erro. Favor tente novamente mais tarde.",
                statusCode = HttpStatusCode.BadRequest
            };

            return response;
        }

        public ResponseMessage<T> CreateInvalidResponse()
        {
            var response = new ResponseMessage<T>
            {
                LogicalTest = false,
                mensagem = "Os dados informados estão Incorretos.",
                statusCode = HttpStatusCode.BadRequest
            };

            return response;
        }

        #endregion
    }
}

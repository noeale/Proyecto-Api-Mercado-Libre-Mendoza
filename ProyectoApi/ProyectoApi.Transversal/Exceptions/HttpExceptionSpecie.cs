using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProyectoApi.Transversal.Logger
{
    public class HttpExceptionSpecie : System.Web.HttpException
    {
  
        public HttpExceptionSpecie(string descrption, int code) : base(code,descrption)
        {

        }
        public List<string> Messages { get; internal set; }
        public HttpStatusCode ErrorCode { get; internal set; }

        public HttpExceptionSpecie() 
        {
            Messages = new List<string>();
        }
        
        public HttpExceptionSpecie(HttpStatusCode errorCode = HttpStatusCode.InternalServerError) :this()
        {
            ErrorCode = errorCode;
        }

        public HttpExceptionSpecie(List<string> messages)
        {
            Messages = messages ?? new List<string>();
        }

        public HttpExceptionSpecie(List<string> messages, HttpStatusCode errorCode = HttpStatusCode.InternalServerError)
        {
            Messages = messages ?? new List<string>();
            ErrorCode = errorCode;
        }

    }
}

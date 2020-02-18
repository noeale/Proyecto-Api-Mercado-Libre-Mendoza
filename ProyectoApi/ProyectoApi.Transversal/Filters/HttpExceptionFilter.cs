using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using ProyectoApi.Transversal.Logger;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;

namespace ProyectoApi.Transversal.Filters
{
    public class HttpExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var error = new HttpExceptionSpecie(
                new List<string> { "Ocurrio un error" },
                HttpStatusCode.InternalServerError);
            context.HttpContext.Response.StatusCode = 500;

            if (context.Exception is System.Web.HttpException)
            {
                var ex = (System.Web.HttpException)context.Exception;

                var t = new HttpExceptionSpecie(ex.StatusDescription, ex.StatusCode);

                context.HttpContext.Response.StatusCode = t.StatusCode;
                context.Result = new JsonResult(new { error = t.StatusDescription });
            }
            else
                context.Result = new JsonResult(new { error = error.Messages });

            base.OnException(context);

        }
    }
}


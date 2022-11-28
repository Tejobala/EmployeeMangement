using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Net.Http;


namespace ClientMangement.ExceptionFilters
{
    //public class CustomExceptionFilters: ExceptionFilterAttribute
    //{
    //    private object Context;

    //    public override void OnException(ExceptionContext context)
    //    {
    //        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
    //        string errorMessage = string.Empty;
    //        var exceptionType = Context.Exception.GetType();
    //        if (exceptionType = typeof(UnauthorizedAccessException))
    //        {
    //            errorMessage = "Unauthorized Access";
    //            statusCode = HttpStatusCode.Unauthorized;   
    //        }
    //       else if (exceptionType = typeof(NullReferenceException))
    //        {
    //            errorMessage = "Data is Not Found";
    //            statusCode = HttpStatusCode.NotFound;
    //        }
    //        else
    //        {
    //            errorMessage = "Contact to Admin";
    //            statusCode = HttpStatusCode.InternalServerError;
    //        }
    //        var response = new HttpResponseMessage(statusCode)
    //        {
    //            Content = new StringContent(errorMessage),
    //          ReasonPhrase="From Exception Fliter"
    //        };
    //        Context = response;
    //        base.OnException((ExceptionContext)Context);
    //    }

    //}
}

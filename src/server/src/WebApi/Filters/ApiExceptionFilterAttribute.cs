using System;
using System.Collections.Generic;
using System.Security.Authentication;
using GitNode.Application.Common.Exceptions;
using GitNode.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

// TODO: error titles
namespace GitNode.WebApi.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilterAttribute()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(DataValidationException), HandleDataValidationException },
                { typeof(AuthenticationException), HandleAuthorizationException },
                { typeof(UnauthorizedAccessException), HandleAuthorizationException },
                { typeof(ExternalApiException), HandleExternalApiException },
                { typeof(InternalServerException), HandleInternalServerException },
                { typeof(UnknownPlatformException), HandleUnknownPlatformException }
            };
        }

        public override void OnException(ExceptionContext context)
        {
            var type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
            base.OnException(context);
        }

        private static void HandleDataValidationException(ExceptionContext context)
        {
            var exception = context.Exception as DataValidationException;

            var details = new ValidationProblemDetails(exception?.Errors)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }

        private static void HandleAuthorizationException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = "An authorization error has occurred.",
                Detail = context.Exception.Message,
                Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1"
            };

            context.Result = new ObjectResult(details) { StatusCode = StatusCodes.Status401Unauthorized };
            context.ExceptionHandled = true;
        }
        
        private static void HandleExternalApiException(ExceptionContext context)
        {
            var exception = context.Exception as ExternalApiException;

            var details = new ProblemDetails
            {
                Status = exception?.Code,
                Title = "An external api error has occurred.",
                Detail = context.Exception.Message
                // TODO: status code details
                //Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3"
            };

            context.Result = new ObjectResult(details) { StatusCode = exception?.Code };
            context.ExceptionHandled = true;
        }

        private static void HandleInternalServerException(ExceptionContext context)
        {
            var exception = context.Exception as InternalServerException;

            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An internal server error has occurred.",
                Detail = exception?.Message,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3"
            };

            context.Result = new ObjectResult(details) { StatusCode = StatusCodes.Status500InternalServerError };
            context.ExceptionHandled = true;
        }

        private static void HandleUnknownPlatformException(ExceptionContext context)
        {
            var exception = context.Exception as UnknownPlatformException;

            var details = new ProblemDetails
            {
                // TODO: error code
                Status = StatusCodes.Status500InternalServerError,
                Title = "An external platform error has occurred.",
                Detail = exception?.Message,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3"
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        private static void HandleInvalidModelStateException(ExceptionContext context)
        {
            var details = new ValidationProblemDetails(context.ModelState)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }

        private static void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

            context.Result = new ObjectResult(details) { StatusCode = StatusCodes.Status500InternalServerError };
            context.ExceptionHandled = true;
        }
    }
}
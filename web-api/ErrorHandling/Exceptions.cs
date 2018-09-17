
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Newtonsoft.Json;
using web_api.Models;

namespace web_api.ErrorHandling
{
    public class LowLevelException: Exception
    {
        public LowLevelException()
        {}

        public LowLevelException(string message) : base(message)
        {}

        public LowLevelException(string message, Exception inner) : base (message, inner)
        {}
    }

    public class LevelActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }

}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Recruitment.API.Utility
{
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var errors = actionContext.ModelState
                    .Where(s => s.Value.Errors.Count > 0)
                    .Select(s => new KeyValuePair<string, string>(s.Key, s.Value.Errors.First().ErrorMessage))
                    .ToArray();
                var errorlist = new List<KeyValuePair<string, string>>();
                foreach (var item in errors)
                {
                    errorlist.Add(new KeyValuePair<string, string>(item.Key.Split('.')[item.Key.Split('.').Length - 1], item.Value));
                }
                actionContext.Result = new ContentResult()
                {
                    Content = JsonConvert.SerializeObject(errorlist),
                    StatusCode = 400
                };
                base.OnActionExecuting(actionContext);
            }
        }
    }
}

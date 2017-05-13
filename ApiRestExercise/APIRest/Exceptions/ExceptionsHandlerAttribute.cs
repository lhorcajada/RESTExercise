using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace APIRest.Exceptions
{
    [ExcludeFromCodeCoverage]

    public class ExceptionsHandlerAttribute : ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            RegisterException(actionExecutedContext);
            base.OnException(actionExecutedContext);

        }
        private void RegisterException(HttpActionExecutedContext actionExecutedContext)
        {
            using (var httpRequestScope = actionExecutedContext.ActionContext.ControllerContext.Configuration.DependencyResolver.BeginScope())
            {
                //Aquí podremos registrar la excepción donde queramos. En base de datos, en un servicio externo,
                //en ficheros texto...
            }
        }


    }
}
using D.O.Net.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace D.O.Net.Extensions
{
    public class StatusResult : ActionResult
    {
        public ActionResult InnerResult { get; private set; }

        public string Message { get; set; }

        public StatusType Type { get; set; }

        public static StatusResult Decorate(ActionResult innerResult, string message, StatusType type)
        {
            return new StatusResult(innerResult, message, type);
        }

        private StatusResult(ActionResult innerResult, string message, StatusType type)
        {
            InnerResult = innerResult;
            Message = message;
            Type = type;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.Controller.TempData["StatusMessage"] = Message;
            context.Controller.TempData["StatusMessageType"] = Type.ToString().ToLower();
            InnerResult.ExecuteResult(context);
        }
    }​
}
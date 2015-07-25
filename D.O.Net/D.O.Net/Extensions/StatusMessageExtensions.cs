using D.O.Net.Enumeradores;
using D.O.Net.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace D.O.Net.Extensions
{
    public static class StatusMessageExtensions
    {
        public static ActionResult WithErrorMessage(this ActionResult innerResult, string message)
        {
            return StatusResult.Decorate(innerResult, message, StatusType.Error);
        }

        public static ActionResult WithSuccessMessage(this ActionResult innerResult, string message)
        {
            return StatusResult.Decorate(innerResult, message, StatusType.Success);
        }

        public static ActionResult WithWarningMessage(this ActionResult innerResult, string message)
        {
            return StatusResult.Decorate(innerResult, message, StatusType.Warning);
        }

        public static ActionResult WithInformationMessage(this ActionResult innerResult, string message)
        {
            return StatusResult.Decorate(innerResult, message, StatusType.Information);
        }
    }
}

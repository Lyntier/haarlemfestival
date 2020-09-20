using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hf.Areas.Admin.Controllers
{
    /// <summary>
    /// Helper controller. When inherited, this makes it so this
    /// controller's subclasses have all their Action-methods
    /// behind authorization, unless otherwise specified.
    /// </summary>
    [Authorize]
    public abstract class AuthorizedController : Controller
    {
    }
}
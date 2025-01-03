﻿namespace ForumAppMVC.Web.Areas.Administration.Controllers
{
    using ForumAppMVC.Common;
    using ForumAppMVC.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}

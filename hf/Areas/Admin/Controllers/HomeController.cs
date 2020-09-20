using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using hf.Models;
using hf.Repository;

namespace hf.Areas.Admin.Controllers
{
    public class HomeController : AuthorizedController
    {

        private LoginRepository loginRepository = new LoginRepository();

        // GET: Admin/
        /// <summary>
        /// In case someone goes to the login screen and is authorized, redirects
        /// them to the control panel directly.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return RedirectToAction("Index", "ControlPanel");
        }

        // GET: Admin/Login
        /// <summary>
        /// Shows the login screen for the administration panel.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Attempts to log in the user with the given username and password in the model.
        /// If no match is found, an error is displayed and the user is asked to give their
        /// login details again.
        /// </summary>
        /// <param name="model">The login details the user has provided.</param>
        /// <returns>A redirect to the control panel on successful authentication. Otherwise,
        /// reloads the page.</returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                Login login = loginRepository.GetLogin(model.Username, model.Password);

                if (login != null)
                {
                    FormsAuthentication.SetAuthCookie(login.Username, false);
                    Session["login"] = login;
                    return RedirectToAction("Index", "ControlPanel");
                }
                else
                {
                    ModelState.AddModelError("login-error", "Could not login. Make sure the specified username and password are correct.");
                }
            }
            return View(model);
        }
        
        /// <summary>
        /// Signs the user out of the application.
        /// </summary>
        /// <returns>The login screen of the control panel.</returns>
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
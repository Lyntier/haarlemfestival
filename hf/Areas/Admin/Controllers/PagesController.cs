using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hf.Models;
using hf.Repository;

namespace hf.Areas.Admin.Controllers
{
    public class PagesController : AuthorizedController
    {
        PageInfoRepository pageInfoRepository = new PageInfoRepository();

        // GET: Admin/PageEdit
        /// <summary>
        /// Shows the fields for editing the details in PageInfo.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(pageInfoRepository.GetAll());
        }

        /// <summary>
        /// Updates the page information for one key.
        /// </summary>
        /// <param name="id">ID to query the pageinfo table on.</param>
        /// <param name="description1">The first description to update.</param>
        /// <param name="description2">The second description to update.</param>
        /// <returns>A reload of the page after sending the changes.</returns>
        [HttpPost]
        public ActionResult SendDescriptionChange(int id, string description1, string description2)
        {
            PageInfo pageInfo = pageInfoRepository.GetById(id);

            pageInfo.Description1 = description1;
            pageInfo.Description2 = description2;

            pageInfoRepository.Update(pageInfo);
            return RedirectToAction("Index");
        }
    }
}
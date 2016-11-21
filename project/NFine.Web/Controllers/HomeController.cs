/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 * Website：http://www.nfine.cn
*********************************************************************************/
using NFine.Application.SystemManage;
using NFine.Code;
using NFine.Domain.Entity.SystemManage;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace NFine.Web.Controllers
{
    [HandlerLogin]
    public class HomeController : Controller
    {
        private TaskApp taskApp = new TaskApp();


        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Default()
        {
            int unDoCount = taskApp.GetCount("0");//未完成数
            int doCount = taskApp.GetCount("1");//已完成数
            ViewBag.UnDoCount = unDoCount;
            ViewBag.DoCount = doCount;

            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
    }
}

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
using System.Linq;
using System.Web.Mvc;

namespace NFine.Web.Areas.SystemManage.Controllers
{
    public class TaskController : ControllerBase
    {
        private TaskApp taskApp = new TaskApp();

        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination page,string status)
        {
            var data = taskApp.GetList(page,status);
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTaskCount(string status)
        {
            var data = taskApp.GetCount(status);
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = taskApp.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(TaskEntity roleEntity, string keyValue)
        {
            taskApp.SubmitForm(roleEntity, keyValue);
            return Success("操作成功。");
        }
        
    }
}

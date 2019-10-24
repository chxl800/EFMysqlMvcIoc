using System.Collections.Generic;
using System.Web.Mvc;
using Model;
using Service;

namespace UI.Controllers
{
    public class UserController : BaseController
    {
        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 查询全部用户
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUsers(User user)
        {
            var data = userService.GetUsers(user);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <returns></returns>
        public ActionResult GetEntity(User user)
        {
            var data = userService.GetEntity(user);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUser(User user)
        {
            var data = userService.AddUser(user);
            return Json(data);
        }
    }
}
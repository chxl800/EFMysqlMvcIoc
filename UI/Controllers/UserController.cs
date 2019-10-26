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
            return Json(data);
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <returns></returns>
        public ActionResult GetEntity(User user)
        {
            var data = userService.GetEntity(user);
            return Json(data);
        }

        /// <summary>
        /// 查询关联表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetListEF()
        {
            var data = userService.GetListEF();
            return Json(data);
        }

        /// <summary>
        /// 查询关联表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetListLinq()
        {
            var data = userService.GetListLinq();
            return Json(data);
        }

        /// <summary>
        /// 查询关联表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetListSQL()
        {
            var data = userService.GetListSQL();
            return Json(data);
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

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateUser(User user)
        {
            string[] propertyNames = { "RealName", "Email" };
            var data = userService.UpdateUser(user, propertyNames);
            return Json(data);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateUserAll(User user)
        {
            var data = userService.UpdateUserAll(user);
            return Json(data);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteUser(User user)
        {
            var data = userService.DeleteUser(user);
            return Json(data);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateUesrSQL()
        {
            var data = userService.UpdateUesrSQL();
            return Json(data);
        }
    }
}
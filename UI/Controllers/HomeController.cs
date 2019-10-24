using System.Collections.Generic;
using System.Web.Mvc;
using Model;
using Service;

namespace UI.Controllers
{
    public class HomeController : BaseController
    {
        private IUserService userService;
        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// 查询全部用户
        /// </summary>
        /// <returns></returns>
        public ActionResult All()
        {
            List<User> users = userService.GetUsers();

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public ActionResult Add(User user)
        {
            return Json(user, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Linq;
using XMLWeb.Common;
using XMLWeb.Models;
using XMLWeb.Repositories;

namespace XMLWeb.Controllers
{
    public class UserController : Controller
    {

        private readonly IUsersRepository _usersRepository = null;
        public UserController(IUsersRepository usersRepository)
        {
            this._usersRepository = usersRepository;
        }

        public ActionResult Index()
        {
            User objUser = new User();
            objUser.UserList = _usersRepository.GetUsers();
            return View(objUser);
        }
        [HttpPost]
        public ActionResult Index(User objUsers)
        {
            if (ModelState.IsValid)
            {
                _usersRepository.SaveUser(objUsers);
            }
            return this.RedirectToAction("Index", "User");
        }

        public ActionResult Delete(int Id)
        {
            _usersRepository.DeleteUser(Id);
            return this.RedirectToAction("Index", "User");
        }

        public ActionResult Add()
        {
            User objUser = new User();
            objUser.UserList = new List<User> { 
                new User()  { 
                    FirstName = string.Empty, 
                    Surname = string.Empty, 
                    CellPhone = string.Empty 
                } 
            };
            return View(objUser.UserList);
        }
        [HttpPost]
        public ActionResult Add(List<User> users)
        {
            if (users != null && users.Count > 0)
            {
                foreach (User user in users)
                {
                    _usersRepository.SaveUser(user);
                }
            }
            return this.RedirectToAction("Index", "User");
        }

        public JsonResult EditUser(int Id)
        {
            User objUser = new User();
            objUser = _usersRepository.GetUser(Id);
            return Json(objUser, JsonRequestBehavior.AllowGet);
        }
    }
}
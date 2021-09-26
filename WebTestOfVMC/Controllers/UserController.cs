using Microsoft.AspNetCore.Mvc;
using RailDBProject.Model;
using Services.Interface;
using System.Collections.Generic;
using System.Linq;
using WebTestOfVMC.Models;
using Common.ListExtentions;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using CommonClasses.PaginationAndSort;
using Microsoft.EntityFrameworkCore;
using FilterSortPagingApp.Models;
using Project.BLL.Services.IServiceIntefaces;

namespace WebTestOfVMC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IOrganisationServices _organisationServices;

        public UserController(IUserServices _userServices, IOrganisationServices _organisationServices)
        {
            this._userServices = _userServices;
            this._organisationServices = _organisationServices;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult GetAll()
        {
            var users = _userServices.GetUsers();

            var model = new List<UserInfo>();

            model = users.Select(u => new UserInfo
            {
                UserId = u.UserId,
                FirstName = u.FirstName,
                LastName = u.LastName,
                SurName = u.SurName,
                Email = u.Email,
                Organisation = u.Organisation,
                UserRole = u.UserRole,
                IsDeleted = u.IsDeleted
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult GetOne(int id)
        {
            var _user = _userServices.GetById(id);

            var model = new UserInfo
            {
                UserId = _user.UserId,
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                SurName = _user.SurName,
                Email = _user.Email,
                Login = _user.Login,
                Password = _user.Password,
                Organisation = _user.Organisation,
                UserRole = _user.UserRole,
                IsDeleted = _user.IsDeleted,
                OrganisationCollection = _userServices.GetOrganisationList(),
                SelectList = _userServices.GetOrganisationList().GetOrganisationSelectList()

            };
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult UpdateUser(UserInfo info)
        {
            var newOrg = _organisationServices.GetById(info.OrganisationId);
            var _user = _userServices.GetById(info.UserId);
            _user.FirstName = info.FirstName;
            _user.LastName = info.LastName;
            _user.SurName = info.SurName;
            _user.Login = info.Login;
            _user.Password = info.Password;
            _user.Organisation = newOrg;
            _user.UserRole = info.UserRole;
            _userServices.UpdateUser(_user);

            return Json(new
            {
                newData = new
                {
                    emailMessage = "Редактирование прошло успешно",
                    url = Url.Action("Index", "User")
                }
            });
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            
            var _user = _userServices.GetById(id);
            _userServices.DeleteUser(_user);

            return Json( new {
                    url = Url.Action("Index", "User"),
                    emailMessage = "Удаление прошло успешно!"
               
            });
        }

        [HttpPost]
        public IActionResult CreateUser(UserInfo info)
        {
            User user = new User
            {
                Email = info.Email,
                FirstName = info.FirstName,
                LastName = info.LastName,
                SurName = info.SurName,
                Login = info.Login,
                OrganisationId = info.OrganisationId,
                IsDeleted = info.IsDeleted,
                Password = info.Password,
                UserRole = info.UserRole
            };

            if (_userServices.CheckByEmail(info.Email) == false)
            {
                _userServices.CreateUser(user);
                return Json(new
                {
                    newData = new
                    {
                        emailMessage = "Регистрация прошла успешно!",
                        url = Url.Action("Login", "Account"),
                        urladmin = Url.Action("Index", "User")
                    }
                });
            }
            else
            {
                return Json(new
                {
                    newData = new
                    {
                        emailMessage = "Пользователь с таким e-mail уже существует!",
                        url = Url.Action("Login", "Account")
                    }
                });
            }
        }

         public async Task<IActionResult> Index(int? company, string name, int page = 1, SortState sortOrder = SortState.FirstNameAsc)
        {
            int pageSize = 10;

            IQueryable<User> users = _userServices.GetQuarable();
           

            if (company != null && company != 0)
            {
                users = users.Where(p => p.OrganisationId == company);
            }
            
            switch (sortOrder)
            {
                case SortState.FirstNameDesc:
                    users = users.OrderByDescending(s => s.FirstName);
                    break;
                case SortState.FirstNameAsc:
                    users = users.OrderBy(s => s.FirstName);
                    break;
                case SortState.LastNameDesc:
                    users = users.OrderByDescending(s => s.LastName);
                    break;
                case SortState.LastNameAsc:
                    users = users.OrderBy(s => s.LastName);
                    break;
                case SortState.OrganisationDesc:
                    users = users.OrderByDescending(s => s.Organisation);
                    break;
                case SortState.OrganisationAsc:
                    users = users.OrderBy(s => s.Organisation);
                    break;
                case SortState.UserRoleDesc:
                    users = users.OrderByDescending(s => s.UserRole);
                    break;
                case SortState.UserRoleAsc:
                    users = users.OrderBy(s => s.UserRole);
                    break;
                case SortState.EmailDesc:
                    users = users.OrderByDescending(s => s.Email);
                    break;
                case SortState.EmailAsc:
                    users = users.OrderBy(s => s.Email);
                    break;
            }

            var count = await users.CountAsync();
            var items = await users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(_userServices.GetOrganisationList(), company, name),
                Users = items
            };
            return View(viewModel);
        }
    }
}

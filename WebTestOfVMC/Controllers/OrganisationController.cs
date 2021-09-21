using Common.ListExtentions;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using System.Collections.Generic;
using System.Linq;
using WebTestOfVMC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebTestOfVMC.Controllers
{
    public class OrganisationController : Controller
    {
        private readonly IOrganisationServices _organisationServices;
        public OrganisationController(IOrganisationServices _organisationServices)
        {
            this._organisationServices = _organisationServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var organisations = _organisationServices.GetOrganisationList();
           
            var model = new List<OrganisationInfo>();

            model = organisations.Select(u => new OrganisationInfo
            {
                OrganisationId = u.OrganisationId,
                OrgName = u.OrgName,
                Children = u.Children,
                Parent = u.Parent,
                Users = u.Users,
                GlobalSections = u.GlobalSections,
                IsDeleted = u.IsDeleted
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult GetOne(int id)
        {
            var organisation = _organisationServices.GetById(id);
            return View(organisation);
        }

        [HttpPost]
        public IActionResult UpdateOrganisation(OrganisationInfo info)
        {
            var _organisation = _organisationServices.GetById(info.OrganisationId);
            _organisation.OrgName = info.OrgName;
            _organisation.Children = info.Children;
            _organisation.Parent = info.Parent;
            _organisation.Users = info.Users;
            _organisation.IsDeleted = info.IsDeleted;

            _organisationServices.UpdateOrganisation(_organisation);

            return RedirectToAction("GetAll", "Organisation");
        }

        [HttpPost]
        public IActionResult DeleteOrganisation(int id)
        {
            var _organisation = _organisationServices.GetById(id);
            _organisationServices.DeleteOrganisation(_organisation);

            return RedirectToAction("GetAll", "Organisation");
        }

        public IActionResult CreateOrganisation(OrganisationInfo info)
        {
            var _childList = new List<Organisation>();

            if (info.SelectedOrganisations != null)
            {
                foreach (var item in info.SelectedOrganisations)
                {
                    _childList.Add(_organisationServices.GetById(item));
                }
            }

            if (info.Parent != null)
            {
                Organisation _organisation = new Organisation()
                {
                    OrgName = info.OrgName,
                    Parent = _organisationServices.GetById(info.Parent.OrganisationId),
                    Children = _childList,
                    GlobalSections = info.GlobalSections,
                    Users = info.Users,
                    IsDeleted = info.IsDeleted
                };

                _organisationServices.CreateOrganisation(_organisation);
            }
            else
            {
                Organisation _organisation = new Organisation()
                {
                    OrgName = info.OrgName,
                    Children = _childList,
                    GlobalSections = info.GlobalSections,
                    Users = info.Users,
                    IsDeleted = info.IsDeleted
                };

                _organisationServices.CreateOrganisation(_organisation);
            }

            return Json(new
            {
                newData = new
                {
                    emailMessage = "Регистрация прошла успешно!",
                    resultInfo = "RedirectTrue",
                    url = Url.Action("Login", "Account")
                }
            });
        }
        public IActionResult CreatePage()
        {
            List<Organisation> orgList = _organisationServices.GetOrganisationList();
            var SelectList = orgList.GetOrganisationSelectList();

            var model = new OrganisationInfo()
            {
                OrganisationCollection = orgList,
                SelectList = SelectList,
                MultiSelectList = new MultiSelectList(orgList, "OrganisationId", "OrgName")
            };

            return PartialView(model);
        }




        //??????????????
        public IActionResult GetNodes()
        {
            var organisations = _organisationServices.GetOrganisationList();

            var model = new List<OrganisationInfo>();

            model = organisations.Select(u => new OrganisationInfo
            {
                OrganisationId = u.OrganisationId,
                OrgName = u.OrgName,
                Children = u.Children,
                Parent = u.Parent,
                Users = u.Users,
                GlobalSections = u.GlobalSections,
                IsDeleted = u.IsDeleted
            }).ToList();
            return View(model);
        }
    }
}



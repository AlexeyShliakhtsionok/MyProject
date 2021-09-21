using Common.ListExtentions;
using Microsoft.AspNetCore.Mvc;
using RailDBProject.Model;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Components
{
    public class UpdateUserViewComponent : ViewComponent
    {
        private readonly IUserServices _userServices;
        public UpdateUserViewComponent(IUserServices _userServices)
        {
            this._userServices = _userServices;
        }
        public IViewComponentResult Invoke(int id)
        {

            var _user = _userServices.GetById(id);
            UserInfo info = new UserInfo();

            info.FirstName = _user.FirstName;
            info.LastName = _user.LastName;
            info.SurName = _user.SurName;
            info.Email = _user.Email;
            info.Login = _user.Login;
            info.Password = _user.Password;
            info.OrganisationCollection = _userServices.GetOrganisationList();
            info.UserId = _user.UserId;
            info.Organisation = _user.Organisation;
            info.SelectList = _userServices.GetOrganisationList().GetOrganisationSelectList();
            info.UserRole = _user.UserRole;

            return View(info);
        }
    }
}

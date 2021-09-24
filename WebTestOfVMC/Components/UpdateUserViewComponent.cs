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

        [HttpGet]
        public IViewComponentResult Invoke(int id)
        {
            UserInfo info = new UserInfo();
            info.UserId = id;
            info.OrganisationCollection = _userServices.GetOrganisationList();
            info.SelectList = _userServices.GetOrganisationList().GetOrganisationSelectList();

            return View(info);
        }
    }
}

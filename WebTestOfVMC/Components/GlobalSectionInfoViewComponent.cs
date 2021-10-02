using Common.ListExtentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.Services.IServiceIntefaces;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Components
{
    public class GlobalSectionInfoViewComponent : ViewComponent
    {
        private readonly IGlobalSectionServices _globalSectionServices;
        private readonly IOrganisationServices _organisationServices;
        public GlobalSectionInfoViewComponent(IGlobalSectionServices _globalSectionServices, IOrganisationServices _organisationServices)
        {
            this._globalSectionServices = _globalSectionServices;
            this._organisationServices = _organisationServices;
        }
        public IViewComponentResult Invoke()
        {

            GlobalSectionInfo _info = new GlobalSectionInfo();
            _info.SelectList = _organisationServices.GetOrganisationList().GetOrganisationSelectList();
            _info.OrganisationCollection = _organisationServices.GetOrganisationList();
            _info.MultiSelectList = new MultiSelectList(_info.OrganisationCollection,
                "OrganisationId", "OrgName");

            return View(_info);
        }
    }
}

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
        public GlobalSectionInfoViewComponent(IGlobalSectionServices _globalSectionServices)
        {
            this._globalSectionServices = _globalSectionServices;
        }
        public IViewComponentResult Invoke()
        {

            GlobalSectionInfo _info = new GlobalSectionInfo();
            _info.SelectList = _globalSectionServices.GetGlobalSectionList().GetGlobalSectionSelectList();
            _info.GlobalSectionCollection = _globalSectionServices.GetGlobalSectionList();
            _info.MultiSelectList = new MultiSelectList(_info.GlobalSectionCollection,
                "GlobalSectId", "GlobalSectionName");

            return View(_info);
        }
    }
}

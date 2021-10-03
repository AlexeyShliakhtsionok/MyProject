using Common.ListExtentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.Services.IServiceIntefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Components
{
    public class LocalSectionInfoViewComponent : ViewComponent
    {
        private readonly IGlobalSectionServices _globalSectionServices;
        private readonly ILocalSectionServices _localSectionServices;
        public LocalSectionInfoViewComponent(IGlobalSectionServices _globalSectionServices, ILocalSectionServices _localSectionService)
        {
            this._globalSectionServices = _globalSectionServices;
            this._localSectionServices = _localSectionService;
        }
        public IViewComponentResult Invoke()
        {

            LocalSectionInfo _info = new LocalSectionInfo();

            _info.SelectList = _globalSectionServices.GetGlobalSectionList().GetGlobalSectionSelectList();
            _info.GlobalSectionCollection = _globalSectionServices.GetGlobalSectionList();
            _info.MultiSelectList = new MultiSelectList(_info.GlobalSectionCollection,
                "GlobalSectId", "GlobalSectionName");

            return View(_info);
        }
    }
}

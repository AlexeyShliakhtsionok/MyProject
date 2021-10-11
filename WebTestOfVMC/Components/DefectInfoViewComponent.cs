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
    public class DefectInfoViewComponent : ViewComponent
    {
        private readonly IGlobalSectionServices _globalSectionServices;
        private readonly ILocalSectionServices _localSectionServices;
        //private readonly IDefectServices _defectServices;
        public DefectInfoViewComponent(IGlobalSectionServices _globalSectionServices, ILocalSectionServices _localSectionServices)
        {
            //this._defectServices = _defectServices;
            this._globalSectionServices = _globalSectionServices;
            this._localSectionServices = _localSectionServices;

        }
        public IViewComponentResult Invoke()
        {
            DefectInfo _info = new DefectInfo();
            //_info.DefectCollection = _defectServices.GetDefectList();
            _info.GlobalSectionCollection = _globalSectionServices.GetGlobalSectionList();
            _info.LocalSectionCollection = _localSectionServices.GetLocalSectionList();
            //_info.DefectSelectList = _defectServices.GetDefectList().GetDefectSelectList();
            _info.GlobalSectionSelectList = _globalSectionServices.GetGlobalSectionList().GetGlobalSectionSelectList();
            _info.LocalSectionSelectList = _localSectionServices.GetLocalSectionList().GetLocalSectionSelectList();
            //_info.DefectMultiSelectList = new MultiSelectList(_info.DefectCollection, "DefectId", "DefectCodeName");
            _info.GlobalSectionMultiSelectList = new MultiSelectList(_info.GlobalSectionCollection,
                "GlobalSectId", "GlobalSectionName");
            _info.LocalSectionMultiSelectList = new MultiSelectList(_info.LocalSectionCollection,
                "LocalSectionId", "LocalSectionName");

            return View(_info);
        }  
    }
}

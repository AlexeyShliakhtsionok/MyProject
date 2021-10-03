using Microsoft.AspNetCore.Mvc;
using Project.BLL.Services.IServiceIntefaces;
using System.Collections.Generic;
using System.Linq;
using WebTestOfVMC.Models;

namespace WebApplication.Controllers
{
    public class DefectController : Controller
    {
        private readonly IDefectServices _defectService;

        public DefectController(IDefectServices _defectService)
        {
            this._defectService = _defectService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var defects = _defectService.GetAll();

            var model = new List<DefectInfo>();

            model = defects.Select(o => new DefectInfo
            {
                DefectCode = o.DefectCode,
                DefectLenght = o.DefectLenght,
                DefectDepth = o.DefectDepth,
                DateOfDetection = o.DateOfDetection,
                Path = o.Path,
                ManufactureYear = o.ManufactureYear,
                DefectId = o.DefectId,
                WaySide = o.WaySide
            }).ToList();

            return View(model);
        }
    }
}

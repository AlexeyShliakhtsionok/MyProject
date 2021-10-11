using CommonClasses.PaginationAndSort.Filters;
using CommonClasses.PaginationAndSort.IndexViewModelClasses;
using CommonClasses.PaginationAndSort.PageViewClass;
using CommonClasses.PaginationAndSort.SortingClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestOfVMC.Models;

namespace WebApplication.Controllers
{
    public class DefectController : Controller
    {
        private readonly IDefectServices _defectService;
        private readonly ILocalSectionServices _localSectionServices;
        private readonly IGlobalSectionServices _globalSectionServices;

        public DefectController(IDefectServices _defectService, ILocalSectionServices _localSectionServices, IGlobalSectionServices _globalSectionServices)
        {
            this._defectService = _defectService;
            this._localSectionServices = _localSectionServices;
            this._globalSectionServices = _globalSectionServices;
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

        public async Task<IActionResult> Index(int? defect, int? glSection, string glName, string name, int page = 1, DefectSortState sortOrder = DefectSortState.DateOfDetectionAsc)
        {
            int pageSize = 10;

            IQueryable<Defect> defects = _defectService.GetQuarable();

            if (defect != null && defect != 0)
            {
                var stringId = defect.ToString();
                var selectedDefect = _defectService.GetById(Convert.ToInt32(stringId));
                string selectedName = selectedDefect.DefectCodeName;
                defects = defects.Where(d => d.DefectCodeName == selectedName);
            }
            if (glSection != null && glSection != 0)
            {
                defects = defects.Where(g => g.LocalSection.GlobalSection.GlobalSectId == glSection);
            }

            switch (sortOrder)
            {
                case DefectSortState.DateOfDetectionDesc:
                    defects = defects.OrderByDescending(s => s.DateOfDetection);
                    break;
                case DefectSortState.DateOfDetectionAsc:
                    defects = defects.OrderBy(s => s.DateOfDetection);
                    break;
                case DefectSortState.DefectCodeDesc:
                    defects = defects.OrderByDescending(s => s.DefectCode);
                    break;
                case DefectSortState.DefectCodeAsc:
                    defects = defects.OrderBy(s => s.DefectCode);
                    break;
                case DefectSortState.DefectDepthDesc:
                    defects = defects.OrderByDescending(s => s.DefectDepth);
                    break;
                case DefectSortState.DefectDepthAsc:
                    defects = defects.OrderBy(s => s.DefectDepth);
                    break;
                case DefectSortState.DefectLenghtDesc:
                    defects = defects.OrderByDescending(s => s.DefectLenght);
                    break;
                case DefectSortState.DefectLenghtAsc:
                    defects = defects.OrderBy(s => s.DefectLenght);
                    break;
                case DefectSortState.KilometerDesc:
                    defects = defects.OrderByDescending(s => s.Kilometer);
                    break;
                case DefectSortState.KilometerAsc:
                    defects = defects.OrderBy(s => s.Kilometer);
                    break;
                case DefectSortState.PktDesc:
                    defects = defects.OrderByDescending(s => s.Pkt);
                    break;
                case DefectSortState.PktAsc:
                    defects = defects.OrderBy(s => s.Pkt);
                    break;
                case DefectSortState.WaySideDesc:
                    defects = defects.OrderByDescending(s => s.WaySide);
                    break;
                case DefectSortState.WaySideAsc:
                    defects = defects.OrderBy(s => s.WaySide);
                    break;
                case DefectSortState.PathDesc:
                    defects = defects.OrderByDescending(s => s.Path);
                    break;
                case DefectSortState.PathAsc:
                    defects = defects.OrderBy(s => s.Path);
                    break;
            }

            var count = await defects.CountAsync();
            var items = await defects.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            DefectIndexViewModel viewModel = new DefectIndexViewModel
            {
                PageView = new PageView(count, page, pageSize),
                DefectSortViewModel = new DefectSortViewModel(sortOrder),
                DefectFilter = new DefectFilter(_defectService.GetDefectList(), defect, name),
                GlobalSectionFilter = new GlobalSectionFilter(_globalSectionServices.GetGlobalSectionList(), glSection, glName),
                Defects = items
            };
            return View(viewModel);
        }
    }
}

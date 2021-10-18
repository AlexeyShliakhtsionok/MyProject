using Common.ListExtentions;
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

namespace WebTestOfVMC.Controllers
{
    public class LocalSectionController : Controller
    {
        private readonly ILocalSectionServices _localSectionServices;
        private readonly IGlobalSectionServices _globalSectionServices;

        public LocalSectionController(ILocalSectionServices _localSectionServices, IGlobalSectionServices _globalSectionServices) {
            this._localSectionServices = _localSectionServices;
            this._globalSectionServices = _globalSectionServices;
        }

        [HttpGet]
        public IActionResult GetOne(int id)
        {
            var _localSection = _localSectionServices.GetById(id);
            var _globalSections = _globalSectionServices.GetGlobalSectionList();

            var model = new LocalSectionInfo
            {
                LocalSectionId = _localSection.LocalSectionId,
                LocalWayNumber = _localSection.LocalWayNumber,
                LocaSectionName = _localSection.LocalSectionName,
                GlobalSection = _localSection.GlobalSection,
                GlobalSectionCollection = _globalSectionServices.GetGlobalSectionList(),
                SelectList = _globalSectionServices.GetGlobalSectionList().GetGlobalSectionSelectList()
            };
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult UpdateLocalSection(LocalSectionInfo info)
        {
            var _localSection = _localSectionServices.GetById(info.LocalSectionId);
            var _globalSection = _globalSectionServices.GetById(info.GlobalSection.GlobalSectId);

            _localSection.LocalSectionName = info.LocaSectionName;
            _localSection.LocalWayNumber = info.LocalWayNumber;
            _localSection.GlobalSection = _globalSection;
            _localSectionServices.UpdateLocalSection(_localSection);
            
            return Json(new
            {
                newData = new
                {
                    emailMessage = "Редактирование прошло успешно",
                    url = Url.Action("Index", "LocalSection")
                }
            });
        }

        [HttpPost]
        public IActionResult DeleteLocalSection(int id)
        {
            var _localSection = _localSectionServices.GetById(id);
            _localSectionServices.DeleteLocalSection(_localSection);
            return Json(new
            {
                emailMessage = "Удаление прошло успешно!",
                url = Url.Action("Index", "LocalSEction")
            });
        }

        public IActionResult CreateLocalSection(LocalSectionInfo info)
        {
            var _globalForLocal = _globalSectionServices.GetById(info.GlobalSection.OrganisationId);
                LocalSection _localSection = new LocalSection()
                {
                    LocalWayNumber = info.LocalWayNumber,
                    LocalSectionName = info.LocaSectionName,
                    GlobalSection = _globalForLocal
                };

                _localSectionServices.CreateLocalSection(_localSection);
          
            return Json(new
            {
                url = Url.Action("Index", "LocalSection"),
                emailMessage = "Добавление прошло успешно!"
            });
        }

        public async Task<IActionResult> Index(int? glSection, string name, int page = 1,
                                         LocalSectionSortState sortOrder = LocalSectionSortState.LocalSectionNameAsc)
        {
            int pageSize = 10;

            IQueryable<LocalSection> localSections = _localSectionServices.GetQuarable();


            if (glSection != null && glSection != 0)
            {
                localSections = localSections.Where(p => p.GlobalSection.GlobalSectId == glSection);
            }

            switch (sortOrder)
            {
                case LocalSectionSortState.LocalSectionNameDesc:
                    localSections = localSections.OrderByDescending(s => s.LocalSectionName);
                    break;
                case LocalSectionSortState.LocalSectionNameAsc:
                    localSections = localSections.OrderBy(s => s.LocalSectionName);
                    break;
            }

            var count = await localSections.CountAsync();
            var items = await localSections.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            LocalSectionIndexViewModel viewModel = new LocalSectionIndexViewModel
            {
                PageView = new PageView(count, page, pageSize),
                LocalSectionSortViewModel = new LocalSectionSortViewModel(sortOrder),
                GlobalSectionFilter = new GlobalSectionFilter(_globalSectionServices.GetGlobalSectionList(), glSection, name),
                LocalSections = items
            };
            return View(viewModel);
        }
    }
}

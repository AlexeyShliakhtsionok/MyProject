using Common.ListExtentions;
using CommonClasses.PaginationAndSort.Filters;
using CommonClasses.PaginationAndSort.IndexViewModelClasses;
using CommonClasses.PaginationAndSort.PageViewClass;
using CommonClasses.PaginationAndSort.SortingClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTestOfVMC.Models;

namespace WebTestOfVMC.Controllers
{
    public class GlobalSectionController : Controller
    {
        private readonly IGlobalSectionServices _globalSectionSetvice;
        private readonly IOrganisationServices _organisationServices;

        public GlobalSectionController(IGlobalSectionServices _globalSectionSetvice, IOrganisationServices _organisationServices)
        {
            this._globalSectionSetvice = _globalSectionSetvice;
            this._organisationServices = _organisationServices;
        }

        public async Task<IActionResult> Index(int? company, string name, int page = 1,
                                         GlobalSectionSortState sortOrder = GlobalSectionSortState.GlobalSectionNameAsc)
        {
            int pageSize = 10;

            IQueryable<GlobalSection> sections = _globalSectionSetvice.GetQuarable();

            if (company != null && company != 0)
            {
                sections = sections.Where(p => p.Organisations.Any(o => o.OrganisationId == company));
            }

            switch (sortOrder)
            {
                case GlobalSectionSortState.GlobalSectionNameDesc:
                    sections = sections.OrderByDescending(s => s.GlobaSectionName);
                    break;
                case GlobalSectionSortState.GlobalSectionNameAsc:
                    sections = sections.OrderBy(s => s.GlobaSectionName);
                    break;
                case GlobalSectionSortState.GlobalWayDesc:
                    sections = sections.OrderByDescending(s => s.GlobalWayNumber);
                    break;
                case GlobalSectionSortState.GlobalWayAsc:
                    sections = sections.OrderBy(s => s.GlobalWayNumber);
                    break;
            }

            var count = await sections.CountAsync();
            var items = await sections.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            GlobalSectionIndexViewModel viewModel = new GlobalSectionIndexViewModel
            {
                PageView = new PageView(count, page, pageSize),
                GlobalSectionSortViewModel = new GlobalSectionSortViewModel(sortOrder),
                OrganisationFilter = new OrganisationFilter(_organisationServices.GetOrganisationList(), company, name),
                GlobalSections = items
            };
            return View(viewModel);
        }

        public IActionResult GetOne(int id)
        {
            var _globalSection = _globalSectionSetvice.GetById(id);
            var _organisations = _organisationServices.GetOrganisationList();
            
            var model = new GlobalSectionInfo
            {
                GlobalSectId = _globalSection.GlobalSectId,
                GlobalWayNumber = _globalSection.GlobalWayNumber,
                GlobaSectionName = _globalSection.GlobaSectionName,
                Organisations = _globalSection.Organisations,
                OrganisationCollection = _organisations,
                SelectList = _organisations.GetOrganisationSelectList(),
                MultiSelectList = new MultiSelectList(_organisations, "OrganisationId", "OrgName")
        };
            return PartialView(model);
        }


        public IActionResult UpdateGlobalSection(GlobalSectionInfo info)
        {
            List<Organisation> _organisations = new List<Organisation>(); // Создаем лист организаций

            foreach (var item in info.SelectedOrganisation) // Наполняем лист организациями, выбранными в DropDownList
            {
                _organisations.Add(_organisationServices.GetById(item));
            }

            var _globalSection = _globalSectionSetvice.GetById(info.GlobalSectId); // Считываем из БД участок, который редактируем

            //if (!_organisations.Equals(_globalSection.Organisations)) // Если Лист выбранных в Dropdown-листе организаций не эквивалентен существующему в БД
            //{
                foreach (var selected in _organisations) // Если организация из выбранных в DropDown отсутствует в списке из БД, то добавляем
                {
                    if (!_globalSection.Organisations.Any(o => o.OrganisationId == selected.OrganisationId))
                    {
                        _globalSection.Organisations.Add(selected);
                    }
                }
                //_globalSectionSetvice.UpdateGlobalSection(_globalSection); 

                /*_globalSection = _globalSectionSetvice.GetById(info.GlobalSectId);*/ // Коллекция могла измениться - считываем участок еще раз
               
                List<int> _orgToRemove = new List<int>(); // Лист для id элементов, требующих удаления

                foreach (var existed in _globalSection.Organisations) // Заполняем _orgToRemove (сразу не удаляю, т.к. форич слетит на следующей после удаления итерации
                {
                    if (!_organisations.Any(o => o.OrganisationId == existed.OrganisationId))
                    {
                        _orgToRemove.Add(existed.OrganisationId);
                    }
                }

                for (int i = 0; _orgToRemove != null && i < _orgToRemove.Count; i++) // Удаляем
                {
                    _globalSection.Organisations.Remove(_organisationServices.GetById(_orgToRemove[i]));
                }
            //}
            _globalSection.GlobaSectionName = info.GlobaSectionName;
            _globalSection.GlobalWayNumber = info.GlobalWayNumber;

            _globalSectionSetvice.UpdateGlobalSection(_globalSection);

            return Json(new
            {
                newData = new
                {
                    emailMessage = "Редактирование прошло успешно",
                    url = Url.Action("Index", "GlobalSection")
                }
            });
        }

        

        [HttpPost]
        public IActionResult DeleteGlobalSection(int id)
        {

            var _globalSection = _globalSectionSetvice.GetById(id);
            _globalSectionSetvice.DeleteGlobalSection(_globalSection);

            return Json(new
            {
                url = Url.Action("Index", "GlobalSection"),
                emailMessage = "Удаление прошло успешно!"

            });
        }

        [HttpPost]
        public IActionResult CreateGlobalSection(GlobalSectionInfo info)
        {
            var _orgList = new List<Organisation>();

            if (info.SelectedOrganisation != null)
            {
                foreach (var item in info.SelectedOrganisation)
                {
                    _orgList.Add(_organisationServices.GetById(item));
                }
            }
            GlobalSection globalSection = new GlobalSection
            {
                GlobalSectId = info.GlobalSectId,
                GlobaSectionName = info.GlobaSectionName,
                GlobalWayNumber = info.GlobalWayNumber,
                Organisations = _orgList
            };
            _globalSectionSetvice.CreateGlobalSection(globalSection);

            return Json(new
            {
                newData = new
                {
                    emailMessage = "Регистрация прошла успешно!",
                    url = Url.Action("Index", "GlobalSection")
                }
            });
        }
    }
}

using CommonClasses.PaginationAndSort.Filters;
using CommonClasses.PaginationAndSort.IndexViewModelClasses;
using CommonClasses.PaginationAndSort.PageViewClass;
using CommonClasses.PaginationAndSort.SortingClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index(int? company, string name, int page = 1, GlobalSectionSortState sortOrder = GlobalSectionSortState.GlobalSectionNameAsc)
        {
            int pageSize = 10;

            IQueryable<GlobalSection> sections = _globalSectionSetvice.GetQuarable();

            if (company != null && company != 0)
            {
                sections = sections.Where(p => p.OrganisationId == company);
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
                GlobalSectionFilter = new GlobalSectionFilter(_globalSectionSetvice.GetGlobalSectionList(), company, name),
                GlobalSections = items
            };
            return View(viewModel);
        }
    }
}

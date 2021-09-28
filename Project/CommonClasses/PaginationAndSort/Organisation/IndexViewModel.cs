using FilterSortPagingApp.Models;
using FilterSortPagingApp.Models.Organisations;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.Organisations
{
    public class IndexViewModel
    {
        public IEnumerable<Organisation> Organisations { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
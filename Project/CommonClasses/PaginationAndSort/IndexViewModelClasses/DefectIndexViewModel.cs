using CommonClasses.PaginationAndSort.Filters;
using CommonClasses.PaginationAndSort.PageViewClass;
using CommonClasses.PaginationAndSort.SortingClasses;
using RailDBProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.IndexViewModelClasses
{
    public class DefectIndexViewModel
    {
        public IEnumerable<Defect> Defects { get; set; }
        public PageView PageView { get; set; }
        public DefectFilter DefectFilter { get; set; }
        public DefectSortViewModel DefectSortViewModel { get; set; }
    }
}

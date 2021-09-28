using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.Organisations
{
    public class SortViewModel
    {
        public SortState OrganisationSort { get; private set; }
        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
            OrganisationSort = sortOrder == SortState.OrganisationAsc ? SortState.OrganisationDesc : SortState.OrganisationAsc;

            Current = sortOrder;
        }
    }
}
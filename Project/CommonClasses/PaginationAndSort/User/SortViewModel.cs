using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.Users
{
     public class SortViewModel
    {
        public SortState FirstNameSort { get; private set; }
        public SortState LastNameSort { get; private set; }
        public SortState MiddleNameSort { get; private set; }
        public SortState OrganisationSort { get; private set; }
        public SortState UserRoleSort { get; private set; }
        public SortState EmailSort { get; private set; }
        public SortState PhoneNumberSort { get; private set; }
        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
            FirstNameSort = sortOrder == SortState.FirstNameAsc ? SortState.FirstNameDesc : SortState.FirstNameAsc;

            LastNameSort = sortOrder == SortState.LastNameAsc ? SortState.LastNameDesc : SortState.LastNameAsc;

            MiddleNameSort = sortOrder == SortState.MiddleNameAsc ? SortState.MiddleNameDesc : SortState.MiddleNameAsc;

            OrganisationSort = sortOrder == SortState.OrganisationAsc ? SortState.OrganisationDesc : SortState.OrganisationAsc;

            UserRoleSort = sortOrder == SortState.UserRoleAsc ? SortState.UserRoleDesc : SortState.UserRoleAsc;

            EmailSort = sortOrder == SortState.EmailAsc ? SortState.EmailDesc : SortState.EmailAsc;

            PhoneNumberSort = sortOrder == SortState.PhoneNumberAsc ? SortState.PhoneNumberDesc : SortState.PhoneNumberAsc;
            
            Current = sortOrder;
            }
        }
    }
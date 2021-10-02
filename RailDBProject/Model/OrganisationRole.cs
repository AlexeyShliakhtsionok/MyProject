using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RailDBProject.Model
{
    public enum OrganisationRole
    {
        [Description("ЦДИ")]
        CDI,
        [Description("УПР")]
        UPR,
        [Description("НОД")]
        NOD,
        [Description("ПЧ")]
        PCH
    }
}

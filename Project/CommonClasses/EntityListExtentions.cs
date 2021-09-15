﻿using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System.Collections.Generic;
using System.Windows.Controls.Primitives;

namespace Common.ListExtentions
{
    public static class EntityListExtentions
    {
        public static SelectList GetOrganisationSelectList(this List<Organisation> list)
        {
            List<SelectListItem> items = new List<SelectListItem>(list.Count);
            foreach (var li in list)
            {
                items.Add(new SelectListItem
                {
                    Text = li.OrgName,
                    Value = li.OrganisationId.ToString()
                });
            }
            items.Add(new SelectListItem("please select", ""));
            foreach (var item in items)
            {
                if (item.Text == "please select")
                {
                    item.Selected = true;
                }
            }
           return new SelectList(items, "Value", "Text");
        }
    }
}

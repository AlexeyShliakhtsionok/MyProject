using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BLL.Services.IServiceIntefaces;
using System.Collections.Generic;
using System.Linq;
using WebTestOfVMC.Models;
using EnumExt;

namespace WebTestOfVMC.Controllers.Operator
{
    public class OperatorController : Controller
    {
        private readonly IOperatorServices _operatorService;

        public OperatorController(IOperatorServices _operatorService)
        {
            this._operatorService = _operatorService;
        }

        [HttpPost]
        public IActionResult UpdateOpp(OperatorInfo info)
        {
            var _operator = _operatorService.GetById(info.OperatorId);
            
            _operator.FirstName = info.FirstName;
            _operator.LastName = info.LastName;
            _operator.MiddleName = info.MiddleName;
            _operator.DismissalDate = info.DismissalDate;
            _operator.Defectoscope.DefectoScopeType = info.Defectoscope.DefectoScopeType;
            _operatorService.Update(_operator);

            //SelectList select = _operator.Defectoscope.DefectoScopeType.GetSelectList();
            

            return Json(new
            {
                isDismiss = _operator.DismissalDate,
                newData = new { success = "Успешно" },
                dismissalTextMessage = new { yes = "Да", no = "Нет" }
            });
            // return Redirect(Url.Action("GetAll", "Operator"));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var operators = _operatorService.GetAllOpp();

            var model = new List<OperatorInfo>();

            model = operators.Select(o => new OperatorInfo
            {
                OperatorId = o.OperatorId,
                FirstName = o.FirstName,
                MiddleName = o.MiddleName,
                LastName = o.LastName,
                Qualification = o.Qualification,
                HireDate = o.HireDate,
                LastQualificationTraning = o.LastQualificationTraning,
                OrganisationId = o.OrganisationId,
                Organisation = o.Organisation,
                Defectoscope = o.Defectoscope,
                DismissalDate = o.DismissalDate
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult GetWideInfo(int id)
        {
            var _operator = _operatorService.GetById(id);

            var model = new OperatorInfo
            {
                OperatorId = _operator.OperatorId,
                FirstName = _operator.FirstName,
                MiddleName = _operator.MiddleName,
                LastName = _operator.LastName,
                Qualification = _operator.Qualification,
                HireDate = _operator.HireDate,
                LastQualificationTraning = _operator.LastQualificationTraning,
                Defectoscope = _operator.Defectoscope,
                DismissalDate = _operator.DismissalDate
            };
            return View(model);
        }
    }
}

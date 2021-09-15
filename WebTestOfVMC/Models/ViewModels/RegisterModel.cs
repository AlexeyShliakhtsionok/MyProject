using Microsoft.AspNetCore.Mvc.Rendering;
using RailDBProject.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebTestOfVMC.ViewModels
{
    public class RegisterModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DataType(DataType.Text)]
        public string SurName { get; set; }

        public UserRole UserRole { get; set; }

        public int OrganisationId { get; set; }
        [Display(Name = "Организация: ")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public virtual Organisation Organisation { get; set; }
        public SelectList SelectList { get; set; }
        public List<Organisation> OrganisationCollection { get; set; }

    }
}

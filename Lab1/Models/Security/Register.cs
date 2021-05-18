using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class Register
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Подтвердите пароль")]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "@mail адресс")]
        public string Email { get; set; }
        [Display(Name = "Польное имя")]
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Родной город")]
        public string Bio { get; set; }

    }
}
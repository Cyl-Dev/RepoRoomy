﻿using Roomy.Utils.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Roomy.Models
{
    public class User : BaseModel
    {
        [Required(ErrorMessage = "Le champ Nom est obligatoire")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "L'adresse mail n'est pas au bon format")]
        [EmailUnique(ErrorMessage = "le mail est déja pris!!!")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        [Major(18, ErrorMessage = "Vous devez être majeur !!!")]
        public DateTime BirthDate { get; set; }


        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
ErrorMessage = "{0} incorrect.")]
        public string Password { get; set; }

        [Display(Name = "Confirmer le mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [NotMapped]
        public string ConfirmedPassword { get; set; }

        [Required(ErrorMessage = "Civilité obligatoire")]
        [Display(Name = "Civilité")]
        public int CivilityID { get; set; }

        [ForeignKey("CivilityID")]
        public Civility Civility { get; set; }
    }
}
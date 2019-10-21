﻿using System;
using System.ComponentModel.DataAnnotations;
using CustomFramework.WebApiUtils.Contracts;
using MySuperStats.Contracts.Attributes;
using MySuperStats.Contracts.Utils;

namespace MySuperStats.Contracts.Requests
{
    public class CreatePlayerRequest
    {
        public int MatchGroupId { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(FieldLengths.USER_FIRSTNAME_MAX, MinimumLength = FieldLengths.USER_FIRSTNAME_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [Display(Name = nameof(FirstName))]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        [StringLength(FieldLengths.USER_LASTNAME_MAX, MinimumLength = FieldLengths.USER_LASTNAME_MIN
        , ErrorMessage = ErrorMessages.StringLength)]
        [Display(Name = nameof(LastName))]
        public string LastName { get; set; }

        [MinBirthDate(ErrorMessage = ErrorMessages.InvalidDateOfBirth)]
        [MaxBirthDate(ErrorMessage = ErrorMessages.InvalidDateOfBirth)]
        [DataType(DataType.Date)]
        [Display(Name = nameof(BirthDate))]
        public DateTime BirthDate { get; set; }
    }
}
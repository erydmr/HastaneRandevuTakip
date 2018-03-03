﻿using HastaneRandevu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HastaneRandevu.Areas.Admin.ViewModels
{

    public class UsersIndex
    {
        public IEnumerable<Yoneticiler> Users { get; set; }
    }

    public class UsersNew
    {
        [Required, MaxLength(128)]
        public string AdSoyad { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Rol { get; set; }

    }

    public class UsersEdit
    {
        [Required, MaxLength(128)]
        public string AdSoyad { get; set; }

        [Required]
        public string Rol { get; set; }

        [Required]
        [MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       
    }

    public class UsersResetPassword
    {
        public string AdSoyad { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
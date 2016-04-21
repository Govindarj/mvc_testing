using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewMVCApp.Models
{
    public class Account
    {
       public Account(String username,String password )
        {
            this.Username = username;
            this.Password = password;
        }
        [Display(Name ="Username")]
        [Required(ErrorMessage = "required")]
        public string Username
        {
            get;
            set;

        }
       
        [Display(Name = "Password")]
        [Required(ErrorMessage = "required")]
        public string Password
        {
            get;
            set;
        }
    }
}
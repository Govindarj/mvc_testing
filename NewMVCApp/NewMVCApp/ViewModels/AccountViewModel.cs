using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace NewMVCApp.ViewModels
{
    public class AccountViewModel
    {
        /*
        [Required]
        public  Account account
        {
            get;
            set;
        }*/
    /*    public AccountViewModel(String username, String password)
        {
            Username = username;
            Password = password;
        }*/
      /*  public AccountViewModel()
        {
            Username = "abc";
            Password = "1234";
        }*/
        [Display(Name = "Username")]
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
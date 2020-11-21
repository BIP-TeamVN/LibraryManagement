//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagement.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public long UserId { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirdth { get; set; }
        public string Ssn { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public bool UserStatus { get; set; }
        public string ImagePath { get; set; }
    
        public virtual Admin Admin { get; set; }
        public virtual Librarian Librarian { get; set; }
        public virtual Member Member { get; set; }
    }
}
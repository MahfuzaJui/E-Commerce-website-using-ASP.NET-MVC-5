//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MidProject.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Buyer
    {
        public int B_Id { get; set; }
        public int U_Id { get; set; }
        public string Address { get; set; }
        public string Phone_Number { get; set; }
    
        public virtual User User { get; set; }
    }
}

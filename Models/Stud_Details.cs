//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stud_curd3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stud_Details
    {
        public int Stud_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Hobbies_Id { get; set; }
        public Nullable<int> Collage_Id { get; set; }
    
        public virtual Collage Collage { get; set; }
    }
}

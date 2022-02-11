using Stud_curd3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stud_curd3.ViewModel
{
    public class StudentViewModel
    {
        public List<Hobby> Hobbies { get; set; }
        public List<Collage> Collages { get; set; }

        [Required]
        public int Stud_Id { get; set; }
        [Required]
        public int Collage_Id { get; set; }

        [Required]
        public string Hobby_Id { get; set; }

        [Range(5,20)]
        public string FirstName { get; set; }

        [Range(5,20)]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        public string CollageName { get; set; }

        [Required]
        public string HobbyName { get; set; }
    }
}
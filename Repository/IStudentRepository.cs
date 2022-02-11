using Stud_curd3.Models;
using Stud_curd3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stud_curd3.Repository
{
     public interface IStudentRepository
    {
        List<StudentViewModel> GetStudentList();
        StudentViewModel Insert(int id = 0);
        HandleException Insert(StudentViewModel studentViewModel);
        StudentViewModel Details(int id);
        
        Stud_Details Delete(int id);
    }
}
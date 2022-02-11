using Stud_curd3.Models;
using Stud_curd3.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Stud_curd3.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private instituteEntities db = new instituteEntities();
        public List<StudentViewModel> GetStudentList()
        {
            List<StudentViewModel> StudentList = new List<StudentViewModel>();
            List<Stud_Details> stud_Details = db.Stud_Details.ToList();
            foreach(var item in stud_Details)
            {
                StudentViewModel svm = new StudentViewModel();
                svm = BindStudentData(item);
                StudentList.Add(svm);
            }
            return StudentList;
        }
        public StudentViewModel Insert(int id = 0)
        {
            var svm = new StudentViewModel();
            if (id > 0)
            {
                Stud_Details stud_Details = db.Stud_Details.Find(id);
                svm = BindStudentData(stud_Details);
            }
            svm.Collages = db.Collages.ToList();
            svm.Hobbies = db.Hobbies.ToList();
            return svm;
        }
        private StudentViewModel BindStudentData(Stud_Details stud_Details)
        {
            StudentViewModel svm = new StudentViewModel();
            svm.Stud_Id = stud_Details.Stud_ID;
            svm.Collage_Id =(int) stud_Details.Collage_Id;
            svm.Hobby_Id = stud_Details.Hobbies_Id;
            svm.FirstName = stud_Details.FirstName;
            svm.LastName = stud_Details.LastName;
            svm.Gender = stud_Details.Gender;
            svm.Address = stud_Details.Address;
            string hobbiesNames = "";
            if (!string.IsNullOrEmpty(stud_Details.Hobbies_Id))
            {
                foreach (int item in stud_Details.Hobbies_Id.Split( ',' ).Select(Int32.Parse).ToList())
                {
                    if (string.IsNullOrEmpty(hobbiesNames))
                    {
                        hobbiesNames = db.Hobbies.Where(x => x.HobbyId == item).FirstOrDefault().Name;
                    }
                    else
                    {
                        hobbiesNames = hobbiesNames + "," + db.Hobbies.Where(x => x.HobbyId == item).FirstOrDefault().Name;
                    }
                }   
            }
            svm.HobbyName = hobbiesNames;
            svm.CollageName = stud_Details.Collage.Name;
            return svm;
        }
        public HandleException Insert(StudentViewModel studentViewModel)
        {
            HandleException handleException = new HandleException();
            try
            {
                if(studentViewModel.Stud_Id > 0)
                {
                    Stud_Details stud_Details = new Stud_Details();
                    stud_Details.Stud_ID = studentViewModel.Stud_Id;
                    stud_Details.Collage_Id = studentViewModel.Collage_Id;
                    stud_Details.Hobbies_Id = studentViewModel.Hobby_Id;
                    stud_Details.FirstName = studentViewModel.FirstName;
                    stud_Details.LastName = studentViewModel.LastName;
                    stud_Details.Gender = studentViewModel.Gender;
                    stud_Details.Address = studentViewModel.Address;
                    db.Entry(stud_Details).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    Stud_Details stud_Details = new Stud_Details();
                    stud_Details.Stud_ID = studentViewModel.Stud_Id;
                    stud_Details.Collage_Id = studentViewModel.Collage_Id;
                    stud_Details.Hobbies_Id = studentViewModel.Hobby_Id;
                    stud_Details.FirstName = studentViewModel.FirstName;
                    stud_Details.LastName = studentViewModel.LastName;
                    stud_Details.Gender = studentViewModel.Gender;
                    stud_Details.Address = studentViewModel.Address;
                    db.Stud_Details.Add(stud_Details);
                    db.SaveChanges();
                }
                handleException.Issuccess = true;
                handleException.Message = "Successful";
            }
            catch(Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return handleException;
        }
        public StudentViewModel Details(int id)
        {
            var svm = new StudentViewModel();
            Stud_Details stud_Details = db.Stud_Details.Find(id);
            svm = BindStudentData(stud_Details);
            return svm;
        }
        public Stud_Details Delete(int id)
        {
            Stud_Details stud_Details = db.Stud_Details.Find(id);
            db.Stud_Details.Remove(stud_Details);
            db.SaveChanges();
            return stud_Details;
        }


    }


}

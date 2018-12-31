using CRUDwithoutScaff.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CRUDwithoutScaff.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(Student model)
        {



            return View();
        }

        public ActionResult SaveRecord(Student model)
        {
            try
            {
                Student_DBEntities db = new Student_DBEntities();
                Student student = new Student();
                student.Name = model.Name;
                student.RollNo = model.RollNo;
                student.Gender = model.Gender;

                db.Students.Add(student);
                db.SaveChanges();

            }
            catch (System.Exception)
            {

                throw;
            }

            return RedirectToAction("DataList");
        }


        public ActionResult Details(int Id)
        {
            using (Student_DBEntities dbModel = new Student_DBEntities())
            {
                return View(dbModel.Students.Where(x => x.id == Id).FirstOrDefault());
            }
        }






        public ActionResult DataList(Student model)
        {

            Student_DBEntities dbModels = new Student_DBEntities();

            return View(dbModels.Students.Take(30).ToList());

            //return View();



        }

        public ActionResult DeleteRecord(int id)
        {
            using (Student_DBEntities dbModels = new Student_DBEntities())
            {
                return View(dbModels.Students.Where(x => x.id == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult DeleteRecord(int id, FormCollection collection)
        {
            try
            {
                using (Student_DBEntities dbModel = new Student_DBEntities())
                {
                    Student student = dbModel.Students.Where(x => x.id == id).FirstOrDefault();
                    dbModel.Students.Remove(student);
                    dbModel.SaveChanges();
                }
                return RedirectToAction("DataList");
            }
            catch
            {
                return View();
            }
        }





        public ActionResult Edit(int id)
        {
            using (Student_DBEntities dbModel = new Student_DBEntities())
            {
                return View(dbModel.Students.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, Student objStudent)
        {
            //try
            //{
            //    using (Student_DBEntities dbModel = new Student_DBEntities())
            //    {
            //        var studentData = Student_DBEntities.Students.Where(x => x.id == id).FirstOrDefault();
            //        if (student != null)
            //        {
            //             name = model.Name;
            //            student roll = model.RollNo;



            //            dbModel.Entry(model).State = EntityState.Modified;
            //            dbModel.SaveChanges();
            //        }
            //    } //Entry provides access   State gets or sets state of the entity


            Student_DBEntities dbModel = new Student_DBEntities();
            var StudentData = dbModel.Students.Where(x => x.id == Id).FirstOrDefault();
            if (StudentData != null)
            {
                StudentData.Name = objStudent.Name;
                StudentData.RollNo = objStudent.RollNo;
                dbModel.Entry(StudentData).State = EntityState.Modified;
                dbModel.SaveChanges();
            }

            return RedirectToAction("DataList");
        }
        //catch (Exception e)
        //{

        //    return View();
        //}


    }



}

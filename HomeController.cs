using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rits.Models;

namespace Rits.Controllers
{
    public class HomeController : Controller
    {
       private SLKDatabaseEntities entity = new SLKDatabaseEntities();

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(detail post)
        {
            if (ModelState.IsValid)
            {
                using (SLKDatabaseEntities db = new SLKDatabaseEntities())
                {
                    db.details.Add(new detail
                    {                       
                        FirstName = post.FirstName,
                        MiddleName = post.MiddleName,
                        LastName = post.LastName,
                        PhoneNumber = post.PhoneNumber,
                        Gender = post.Gender,
                        DateOfBirth = post.DateOfBirth,
                        EmailID = post.EmailID,
                        Address = post.Address,
                        City = post.City,
                        ZipCode = post.ZipCode,
                        State = post.State,
                        Country = post.Country,
                        Department = post.Department,
                        TenthBoard = post.TenthBoard,
                        TenthMarks = post.TenthMarks,
                        TwelfthBoard = post.TwelfthBoard,
                        TwelfthMarks = post.TwelfthMarks,                        
                    });
                    db.SaveChanges();
                }

                ModelState.Clear();

            }
            return View();
        }
        public ActionResult Home()
        {
            detail model = new detail();
            using (SLKDatabaseEntities db = new SLKDatabaseEntities())
            {
                var data = db.details.ToList();

                List<detail> jobpos = new List<detail>();
                foreach (var item in data)
                {
                    detail obj = new detail();
                    obj.UserId = item.UserId;
                    obj.FirstName = item.FirstName;
                    obj.MiddleName = item.MiddleName;
                    obj.LastName = item.LastName;
                    obj.PhoneNumber = item.PhoneNumber;
                    obj.Gender = item.Gender;
                    obj.DateOfBirth = item.DateOfBirth;
                    obj.EmailID = item.EmailID;
                    obj.Address = item.Address;
                    obj.City = item.City;
                    obj.ZipCode = item.ZipCode;
                    obj.State = item.State;
                    obj.Country = item.Country;
                    obj.Department = item.Department;
                    obj.TenthBoard = item.TenthBoard;
                    obj.TenthMarks = item.TenthMarks;
                    obj.TwelfthBoard = item.TwelfthBoard;
                    obj.TwelfthMarks = item.TwelfthMarks;
                    jobpos.Add(obj);                                               
                }
                ViewBag.list = jobpos;
            }
            return View();
        }

        public ActionResult Edit(int UserId)
        {
            detail Post = new detail();
            using (SLKDatabaseEntities db = new SLKDatabaseEntities())
            {
                Post = db.details.Where(r => r.UserId == UserId).FirstOrDefault();              
            }
            return View(Post);
        }

        [HttpPost]
        public ActionResult Edit(detail Post)
        {
            if (ModelState.IsValid)
            {
                using (SLKDatabaseEntities db = new SLKDatabaseEntities())
                {
                    db.Entry(Post).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Home", "Home");
                }
            }

            return View(Post);
        }
        //delete recruiter

        public ActionResult Delete(int UserId)
        {
            detail Post = new detail();
            using (SLKDatabaseEntities db = new SLKDatabaseEntities())
            {
                Post = db.details.Where(r => r.UserId == UserId).FirstOrDefault();           
            }
            return View(Post);
        }
        [HttpPost]
        public ActionResult Delete(detail Post)
        {
            if (ModelState.IsValid)
            {
                using (SLKDatabaseEntities db = new SLKDatabaseEntities())
                {
                    db.Entry(Post).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    return RedirectToAction("Home", "Home");
                }
            }

            return View(Post);

        }

        //public ActionResult Home()
        //{          
        //    return View(entity.details.ToList());
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "UserId")]detail slk)
        {
            try
            {
                entity.details.Add(slk);
                entity.SaveChanges();
                return RedirectToAction("Home");
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult Edit(string EmailID)
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Edit(string EmailID, FormCollection collection)
        //{
        //    try
        //    {

        //        return RedirectToAction("Home");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //public ActionResult Delete(string EmailID)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Delete(string EmailID, FormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction("Home");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}      
    }
} 
  
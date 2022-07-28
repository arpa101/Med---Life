using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Project.Models.Database;
using Project.Models.Entities;


namespace Project.Controllers
{

    public class StoreController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(SystemuserModel user)
        {
            if (ModelState.IsValid)
            {
                var db = new projectEntities3();
                var u = (from e in db.Systemusers where e.U_name.Equals(user.U_name) & e.U_password.Equals(user.U_password) select e).FirstOrDefault();
                if (u != null)
                {
                    Session["Id"] = u.Id;
                    Session["U_name"] = u.U_name;
                    Session["Usertype"] = u.Usertype;
                    Session["U_phone"] = u.U_phone;
                    Session["U_address"] = u.U_address;
                    Session["U_username"] = u.U_username;
                    Session["U_email"] = u.U_email;
                    Session["U_password"] = u.U_password;
                    Session["U_profileimg"] = u.U_profileimg;
                    Session["pharmacyname"] = u.pharmacyname;
                    if (u.Usertype.Equals("Customer"))
                    {
                        //Customer Dashboard
                    }
                    else if (u.Usertype.Equals("Staff"))
                    {
                        //Pharmacy Dashboard
                        return RedirectToAction("Index");
                    }
                }

            }
            return View();
        }


        // GET: Staff
        public ActionResult Index()
        {
           
            bager();
            Bager();
            projectEntities3 db = new projectEntities3();
            var data = db.Ratings.ToList();
            return View(data);


        }
        public ActionResult AddProduct()
        {
            
            projectEntities3 db = new projectEntities3();
            var data = db.Products.ToList();
            return View(data);
        }


        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View(new Product());
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            
            if (ModelState.IsValid)
            {
                //db insertion
                projectEntities3 db = new projectEntities3();
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("AddProduct");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditProduct(int Id)
        {
            projectEntities3 db = new projectEntities3();
            var data1 = (from s in db.Products where s.Id == Id select s).FirstOrDefault();
            return View(data1);
        }
        [HttpPost]
        public ActionResult EditProduct(Product s_Id)
        {
            projectEntities3 db = new projectEntities3();
            var datta2 = (from s in db.Products where s.Id == s_Id.Id select s).FirstOrDefault();
            db.Entry(datta2).CurrentValues.SetValues(s_Id);

            db.SaveChanges();


            return RedirectToAction("AddProduct");
        }
        public ActionResult DeleteProduct(Product p_Id)
        {

            projectEntities3 db = new projectEntities3();
            var data2 = (from s in db.Products where s.Id == p_Id.Id select s).FirstOrDefault();
            db.Products.Remove(data2);
             db.SaveChanges();
            return RedirectToAction("AddProduct");
        }

        public ActionResult Profilee()
        {
            projectEntities3 db = new projectEntities3();
            var username = Session["U_username"].ToString();
            var data = (from u in db.Systemusers where u.U_username == username select u).FirstOrDefault();
            return View(data);

        }
        [HttpGet]
        public ActionResult EditProfile(int Id)
        {
            projectEntities3 db = new projectEntities3();
            var dataa2 = (from s in db.Systemusers where s.Id == Id select s).FirstOrDefault();
            return View(dataa2);
        }
        [HttpPost]

        public ActionResult EditProfile(Systemuser s_Id)
        {
           
                projectEntities3 db = new projectEntities3();
            var data2 = (from s in db.Systemusers where s.Id == s_Id.Id select s).FirstOrDefault();
            db.Entry(data2).CurrentValues.SetValues(s_Id);

            db.SaveChanges();


            return RedirectToAction("Profilee");

        }


        public ActionResult OrderedDetails()
        {
           

            projectEntities3 db = new projectEntities3();
            var orders = db.Orderdetails.ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Orderdetail, OrderDetailsModel>();
                cfg.CreateMap<myorder, myordersModel>();
            }
            );
            var mapper = new Mapper(config);
            var data = mapper.Map<List<OrderDetailsModel>>(orders);



            return View(data);

        }

        public void bager()
        {
            projectEntities3 db = new projectEntities3();
            ViewBag.displayProduct = db.Products.ToList();
            ViewBag.Count = db.Products.Count();
        }
        public void Bager()
        {
            projectEntities3 db = new projectEntities3();
            ViewBag.displayProduct = db.returndetelis.ToList();
            ViewBag.Countt = db.returndetelis.Count();
        }
        public ActionResult Logout()
        {
            @Session.Clear();
            @Session.Abandon();
            return View("Login");
        }





    }
}
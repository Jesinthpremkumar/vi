using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using vi.Models;
using vi.viewModel;
using Microsoft.EntityFrameworkCore.Internal;

namespace vi.Controllers
{
    public class customerController : Controller
    {
        // GET: customer
        CustomerList customerList = new CustomerList();
        private ApplicationDbContext _context;

        public customerController()
        {
            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Route("customers")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("customers/details/{custid}")]
        [Route("customers/details/")]
        public ActionResult Customerdetail(int? custid)
        {

            if (custid == null)
            {
                return RedirectToAction("index");
            }
            if (_context.customer.Max(c => c.id) < custid)
            {
                ViewBag.error = "not found";
                return View();
            }
            var customer = _context.customer.Include(c => c.MembershipType).ToList().Find(c => c.id == custid);

            return View(customer);

        }
        
        public ActionResult New()
        {
            var membershipType = _context.membershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                customer=new customer(),
                MembershipTypes = membershipType,
    
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult save(customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    customer = customer,
                    MembershipTypes = _context.membershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }
            if (customer.id == 0)
            {
                _context.customer.Add(customer);

            }
            else
            {
                var customerInDb = _context.customer.Single(c => c.id == customer.id);
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.isSubscribedToNewsletter = customer.isSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                
                customerInDb.name = customer.name;
            }
            _context.SaveChanges();
            
            return RedirectToAction("index","customer");
        }
        [Route("customers/Edit/{id}")]
        public ActionResult edit(int id)
        {
            var customer = _context.customer.Single(c => c.id == id);
            if (customer==null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                customer = customer,
                MembershipTypes = _context.membershipTypes.ToList()
            };
            
            return View("CustomerForm",viewModel);
        }
    }
}
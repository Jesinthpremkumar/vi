using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Mvc;
using vi.Dtos;
using vi.Models;

namespace vi.Controllers
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<CustomerDto> GetCustomers()
        {
           var cust=  _context.customer
                .Include("MembershipType")
                .ToList()
                .Select(Mapper.Map<customer,CustomerDto>);
            return cust;
        }
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.customer.Single(m => m.id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<customer,CustomerDto>(customer));
        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult AddCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, customer>(customerDto);
            _context.customer.Add(customer);
            _context.SaveChanges();
            customerDto.id = customer.id;
            return Created(new Uri(Request.RequestUri+"/"+customerDto.id),customerDto);
        }
        [System.Web.Http.HttpPut]
        public void UpdateCustomer(int id,CustomerDto customerDto)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpRequestException("bad Request");

            }
            var customerinDb = (customer)_context.customer.SingleOrDefault(m => m.id == id);
            if (customerinDb == null)
            {
                throw new HttpRequestException("Not found");
            }
            Mapper.Map(customerDto, customerinDb);
           
            _context.SaveChanges();
        }
        [System.Web.Http.HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerinDb = (customer)_context.customer.SingleOrDefault(m => m.id == id);
            if (customerinDb == null)
            {
                throw new HttpRequestException("Not found");
            }
            _context.customer.Remove(customerinDb);
            _context.SaveChanges();

        }

    }
}

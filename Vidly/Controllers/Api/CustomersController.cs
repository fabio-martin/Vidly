using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;

using System.Web.Http;
using AutoMapper;
using Vidly.App_Start;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private MyDbContext _context;

        private readonly IMapper mapper;

        public CustomersController()
        {
            _context = new MyDbContext();
            mapper = AutoMapperConfig.Mapper;
        }

        // GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            //return _context.Customers
            //    .Include(c => c.MembershipType)
            //    .ToList()
            //    .Select(mapper.Map<CustomerDto>);      

            var customersInDb = _context.Customers
                .Include(c => c.MembershipType)
                .ToList();

            var customersDto = customersInDb.Select(mapper.Map<CustomerDto>);
            
            return Ok(customersDto);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer =  _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(mapper.Map<CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = mapper.Map<Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            var uri = Request.RequestUri + "/" + customer.Id;

            return Created(uri, customerDto);

        }

        // PUT /api/customers/1 
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            
            mapper.Map(customerDto, customerInDb);
            
            _context.SaveChanges();

        }


        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }

 

}

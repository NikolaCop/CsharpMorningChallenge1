using System;
using System.Collections.Generic;
using CsharpMorningChallenge1.Models;
using CsharpMorningChallenge1.Services;
using Microsoft.AspNetCore.Mvc;

namespace CsharpMorningChallenge1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _service;


        public ProductsController(ProductsService service)
        {
            _service = service;
        }



        [HttpGet] //Get
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{productsId}")] //Get By ID
        public ActionResult<Product> GetById(string productsId)
        {
            try
            {
                return Ok(_service.GetById(productsId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        [HttpPut("{productsId}")] //EDIT
        public ActionResult<Product> editProducts(string productId, Product editProducts)
        {
            try
            {
                editProducts.productId = productId;
                return Ok(_service.Edit(editProducts));

            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        [HttpPost] //Create
        public ActionResult<Product> Create([FromBody] Product newProducts)
        {
            try
            {
                return Ok(_service.Create(newProducts));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")] //Delort
        public ActionResult<string> DeleteProducts(string id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
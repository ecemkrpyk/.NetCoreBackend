using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //attribute deniyor
    public class ProductsController : ControllerBase
    {
        //loosly coupled : gevşek bağlılık
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
           _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //dependency chain
            Thread.Sleep(millisecondsTimeout:1000);
            
            var result = _productService.GetAll();
            //http status code---------
            if (result.Success)
            {
                return Ok(result); //resultı ok ile dönmek var
            }
            return BadRequest(result); //resultı badrequest ile dönmek varmış

        }
        [HttpGet("getbyid")] //karışmaması için isim verdik- alyas verdik
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycategory")] 
        public IActionResult GetAllByCategoryId(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getproductdetails")]
        public IActionResult GetProductDetail(int categoryId)
        {
            var result = _productService.GetProductDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        //ürün ekledik
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}

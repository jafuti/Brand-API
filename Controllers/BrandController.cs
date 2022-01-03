using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WesbServceDemo.Models;

namespace WesbServceDemo.Controllers
{
    public class BrandController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public List<Brand> GetBrands()
        {
            var brands = _context.Brands.ToList();
            return brands;
        }

        public Brand GetBrand(int id)
        {
            var brand = _context.Brands.Where(br => br.Id == id).FirstOrDefault();
            return brand;
        }
        public void Post(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }
        public void Put(Brand brand)
        {
            var exsitingBrand = _context.Brands.Where(br => br.Id == brand.Id).FirstOrDefault();
            exsitingBrand.Name = brand.Name;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
         var brand =_context.Brands.Where(br => br.Id == id).FirstOrDefault();
            _context.Brands.Remove(brand);
            _context.SaveChanges();
        }

    }
}

using EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace EFCodeFirst.ApiControllers
{
    public class BrandsController : ApiController
    {
        //phải có chữ "Get" ở đầu tên hàm thì mới gọi được
        public List<Brand> GetBrands()
        {
            CompanyDBContext db = new CompanyDBContext();
            // lấy tất cả các bản ghi trong bảng Brand
            List<Brand> brands = db.Brands.ToList();
            // trả về danh sách các bản ghi
            return brands;
        }

        public Brand GetBrandByID(long id)
        {
            CompanyDBContext db = new CompanyDBContext();
            // tìm bản ghi có BrandID = id
            Brand brand = db.Brands.Find(id);
            // trả về bản ghi
            return brand;
        }

        //IHttpActionResult là một interface được sử dụng để tạo ra các phản hồi HTTP (HTTP responses)
        public IHttpActionResult PostBrand(Brand brand)
        {
            if (brand == null)
            {
                return BadRequest("Brand is null!");
            }
            CompanyDBContext db = new CompanyDBContext();
            db.Brands.Add(brand);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = brand.BrandID }, brand);
        }

        public IHttpActionResult PutBrand(Brand brand)
        {
            if (brand == null)
            {
                return BadRequest("Brand is null!");
            }
            CompanyDBContext db = new CompanyDBContext();
            // tìm bản ghi có BrandID = id
            Brand brandToUpdate = db.Brands.Find(brand.BrandID);
            if (brandToUpdate == null)
            {
                return NotFound();
            }
            brandToUpdate.BrandName = brand.BrandName;
            db.SaveChanges();
            return Ok(brandToUpdate);
        }

        public IHttpActionResult DeleteBrand(long id)
        {
            CompanyDBContext db = new CompanyDBContext();
            // tìm bản ghi có BrandID = id
            Brand brandToDelete = db.Brands.Find(id);
            if (brandToDelete == null)
            {
                return NotFound();
            }
            db.Brands.Remove(brandToDelete);
            db.SaveChanges();
            return Ok(brandToDelete);
        }

    }
}

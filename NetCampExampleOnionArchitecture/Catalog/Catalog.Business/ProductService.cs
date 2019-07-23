using Catalog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalog.Business
{
    public class ProductService
    {
        public List<Category> GetCategory()
        {
            using (var db = new EFCoreContext())
            {
                return db.Categories.ToList();
            }
        }
        public List<Brand> GetBrand()
        {
            using (var db = new EFCoreContext())
            {
                return db.Brand.ToList();
            }
        }

        public List<Product> GetList()
        {
            using (var db = new EFCoreContext())
            {
                return db.Product.ToList();
            }
        }
        public Product Add(Product model)
        {
            using (var db = new EFCoreContext())
            {
                db.Product.Add(model);
                db.SaveChanges();
                return model;
            }
        }
        public Product Update(Product model)
        {
            using (var db = new EFCoreContext())
            {
                db.Product.Update(model);
                db.SaveChanges();
                return model;
            }
        }
        public bool Delete(int id)
        {
            using (var db = new EFCoreContext())
            {
                var model = db.Product.FirstOrDefault(q => q.Id == id);
                if (model == null)
                {
                    return false;
                }
                db.Product.Remove(model);
                db.SaveChanges();
                return true;
            }
        }
    }
}

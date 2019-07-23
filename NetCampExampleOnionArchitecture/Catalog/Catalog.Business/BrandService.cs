using Catalog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalog.Business
{
   public class BrandService
    {
        public List<Brand> GetList()
        {
            using (var db=new EFCoreContext())
            {
                return db.Brand.ToList();
            }
        }
        public Brand Add(Brand model)
        {
            using (var db = new EFCoreContext())
            {
                db.Brand.Add(model);
                db.SaveChanges();
                return model;
            }
        }
        public Brand Update(Brand model)
        {
            using (var db = new EFCoreContext())
            {
                db.Brand.Update(model);
                db.SaveChanges();
                return model;
            }
        }
        public bool Delete(int id)
        {
            using (var db = new EFCoreContext())
            {
                var model = db.Brand.FirstOrDefault(q => q.Id == id);
                if (model==null)
                {
                    return false;
                }
                db.Brand.Remove(model);
                db.SaveChanges();
                return true;
            }
        }
    }
}

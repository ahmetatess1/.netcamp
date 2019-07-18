using NetCampWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCampWeb.Models.Services
{
    public class OgrenciService
    {
        public OgrenciService()
        {
            if(GlobalData.Ogrenciler==null)
            {
                GlobalData.Ogrenciler = new List<Ogrenci>();
                GlobalData.Ogrenciler.Add(new Ogrenci { Adi = "Admin", Id = 1, KullaniciAdi = "Admin", Parola = "123", Soyadi = "Admin", Yasi = 1 });

            }
        }
        public List<Ogrenci> GetList()
        {
            return GlobalData.Ogrenciler;
        }
        public Ogrenci Get(long id)
        {
            return GlobalData.Ogrenciler.SingleOrDefault(k=>k.Id==id);
        }
        public Ogrenci Insert(Ogrenci model)
        {
            model.Id = DateTime.Now.Ticks;
            GlobalData.Ogrenciler.Add(model);
            return model;
        }
        public Ogrenci Update(Ogrenci model)
        {
            var data = GlobalData.Ogrenciler.Where(k => k.Id == model.Id).SingleOrDefault();
            var index = GlobalData.Ogrenciler.IndexOf(data);
            GlobalData.Ogrenciler[index] = model;
            return model;
        }
        public bool Delete(long id)
        {
            GlobalData.Ogrenciler.Remove(GlobalData.Ogrenciler.Where(k => k.Id == id).SingleOrDefault());
            return true;
        }
    }
}

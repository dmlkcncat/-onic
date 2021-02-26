using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace mobil.Controllers
{
    public class BiletController:ApiController
    {
        mobilprojeEntities _ent = new mobilprojeEntities();

        [HttpGet]

        public void BiletSalonuGetir(int? salonid)
        {
            _ent.bilet.Where(p => p.salonid == salonid).Select(p => new bilettip() {
                salonadi = p.salon.salonadi,
            }).ToList();
        }

        [HttpGet]
        public List<bilettip> BiletFilmiGetir(int? filmid)
        {

            return _ent.film.Where(p => p.filmid == filmid).Select(p => new bilettip() {
                filmadi = p.filmadi,
                yonetmen = p.yonetmen,
                filmid = p.filmid,
                
            }).ToList();
            
        }
        [HttpGet]
        public void BiletKoltukGetir(int koltukid)
        {
            _ent.bilet.Where(p => p.koltukid == koltukid).Select(p => new bilettip()
            {
                koltukno = p.koltuk.koltukno,
            }).ToList();
        }

        [HttpPost]
        public List<bilettip> YeniBiletEkle(bilettip veri)
        {
            try
            {
                bilet b = new bilet();
                b.filmid = veri.filmid;
                b.salonid = veri.salonid;
                b.koltukid = veri.koltukid;
                b.fiyat = veri.fiyat;
                _ent.bilet.Add(b);
                _ent.SaveChanges();
                return BiletFilmiGetir(veri.filmid);
            }
            catch(Exception)
            {
                return null;
            }
          
        }

        [HttpGet]
        public List<bilettip> BiletSil(int biletid)
        {
            try
            {
                int? filmid = _ent.bilet.Find(biletid).filmid;
                _ent.bilet.Remove(_ent.bilet.Find(biletid));
                _ent.SaveChanges();
                return BiletFilmiGetir(filmid);
            }
            catch(Exception)
            {
                return null;
            }
           
        }

    }


    public class bilettip
    {
        public int biletid { get; set; }
        public Nullable<int> filmid { get; set; }
        public string filmadi { get; set; }
        public string yonetmen { get; set; }
        public Nullable<int> salonid { get; set; }
        public string salonadi { get; set; }
        public Nullable<int> koltukid { get; set; }
        public string koltukno { get; set; }

        public string fiyat { get; set; }

    }
}
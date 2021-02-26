using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace mobil.Controllers
{
    public class FilmController:ApiController
    {
        mobilprojeEntities _ent = new mobilprojeEntities();

        [HttpGet]

        public List<filmtip> TumFilmleriGetir()
        {
            return _ent.film.Select(p => new filmtip()
            {
                filmadi = p.filmadi,
                yonetmen = p.yonetmen,
                filmid = p.filmid,
                dakika = p.dakika,
            }).ToList();
        }

        [HttpPost]
        public List<filmtip> YeniFilmEkle(filmtip veri)
        {
            try
            {
                film f = new film();
                f.filmid = veri.filmid;
                f.filmadi = veri.filmadi;
                f.yonetmen = veri.yonetmen;
                f.dakika = veri.dakika;
                _ent.film.Add(f);
                _ent.SaveChanges();
                return TumFilmleriGetir();
            }
            catch (Exception)
            {
                return null;
            }

        }

        [HttpGet]
        public List<filmtip> FilmSil(int filmid)
        {
            try
            {
                //int? filmid = _ent.bilet.Find(biletid).filmid;
                _ent.film.Remove(_ent.film.Find(filmid));
                _ent.SaveChanges();
                return TumFilmleriGetir();
            }
            catch (Exception)
            {
                return null;
            }

        }

    }


    public class filmtip
    {
        public int filmid { get; set; }
        public string filmadi { get; set; }
        public string yonetmen { get; set; }
        public Nullable<int> dakika { get; set; }

    }
}
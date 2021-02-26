using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace mobil.Controllers
{
    public class SalonController:ApiController
    {
        mobilprojeEntities _ent = new mobilprojeEntities();

        [HttpGet]

        public List<salontip> TumSalonlariGetir()
        {
           return _ent.salon.Select(p => new salontip()
            {
                salonadi = p.salonadi,
                koltuksayisi = p.koltuksayisi,
                boskoltuk = p.boskoltuk,
                dolukoltuk = p.dolukoltuk,
                salonid = p.salonid,
            }).ToList();

        }
    }
    public class salontip
    {
        public int salonid { get; set; }
        public string salonadi { get; set; }
        public Nullable<int> koltuksayisi { get; set; }
        public Nullable<int> boskoltuk { get; set; }
        public Nullable<int> dolukoltuk { get; set; }
    }
}
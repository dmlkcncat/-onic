using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace mobil.Controllers
{
    public class KoltukController:ApiController
    {
        mobilprojeEntities _ent = new mobilprojeEntities();

        [HttpGet]

        public List<koltuktip>TumKoltukGetir()
        {
            return _ent.koltuk.Select(p => new koltuktip()
            {
                koltukid = p.koltukid,
                koltukno = p.koltukno,
            }).ToList();
        }
    }
    public class koltuktip
    {
        public int koltukid { get; set; }
        public string koltukno { get; set; }
    }
}
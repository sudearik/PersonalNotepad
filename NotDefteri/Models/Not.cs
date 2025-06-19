using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefteri.Models
{
    public class Not
    {
        public string Baslik { get; set; }
        public string İcerik { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }

        public Not()
        {
            OlusturulmaTarihi = DateTime.Now;
            GuncellenmeTarihi = DateTime.Now;
        }
    }
}

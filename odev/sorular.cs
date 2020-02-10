using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using veritabani;

namespace soru
{
    public class sorular
    {
       public  dbBaglanti db = new dbBaglanti();
        public string soruyuGonder(int sorunumarasi)
        {
           
            string soru = db.soruAl(sorunumarasi);
            return soru;
        }
        public string cevapGonder(string soru)
        {
            dbBaglanti db = new dbBaglanti();
            string cevap = db.cevapAl(soru);
            return cevap;
        }
    }
}

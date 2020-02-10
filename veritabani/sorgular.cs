using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veritabani
{
    public class sorgular
    {
        public string soruAl(int soruno)
        {
            return "SELECT soru FROM soru.sorular where id="+soruno+"";
        }
        public string cevapAl(string soruno)
        {
            return "SELECT cevap FROM soru.sorular where soru = '" + soruno + "'";

        }
    }
}

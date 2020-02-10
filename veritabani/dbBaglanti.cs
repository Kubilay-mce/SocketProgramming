using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veritabani// Veri tabanı bağlantılar genel olarak aşağıdadır (MYSQL KULLANDIK)
{
    public class dbBaglanti
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public string soruAl(int no)
        {
            string soru = null;
            sorgular sorgular = new sorgular();
            con = new MySqlConnection(getBaglanti());
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sorgular.soruAl(no);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                soru = dr["soru"].ToString();
            }
            con.Close();
            return soru;
        }

        public string cevapAl(string soru)
        {
            string cevap = null;
            sorgular sorgular = new sorgular();
            con = new MySqlConnection(getBaglanti());
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sorgular.cevapAl(soru);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cevap = dr["cevap"].ToString();
            }
            con.Close();
            return cevap;
        }
        public string getBaglanti()
        {
            return "Server=127.0.0.1;PORT=3306;Database=soru;Uid=root;Pwd=123456;Pooling=false;";
        }

    }
}


 
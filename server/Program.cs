
using soru;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Sockets;
using System.Threading;
 
namespace Server
{
    public class Program
    {
        static int baglanti = 0, kaybedenlersayisi = 0;
        static List<int> xx = new List<int>();
        static void Main(string[] args)
        {
            Socket socket = null;
            var listener = new TcpListener(5000);
            listener.Start();
            Console.WriteLine("{********************SUNUCU TARAFI***********************}");
            Console.WriteLine("{********************Dunyanin en iyi Yarismesine Hoşgeldiniz.************************}\n");
            yarismacilar(3, socket, listener);// BURADA MAX OLARAK YAPILAN CLIENT BELIRLENIYOR BURADA 2-3 SECTIK BIZ
        }

        static void FunctionContestant(Socket socket,TcpListener listener,List<int>ss)// Burada Server başlatılıyor ve bağlantı olup olmadığı 
        {                                                                                   //kontrol ediliyor bazen port çakışması sonucunda bağlantı hatası aldığımız oldu
            socket = listener.AcceptSocket();
            sorular srlar = new sorular();
            if (!bkontrol(socket.Available))
                Console.WriteLine("Bağlantı Hatası");
            else
            {
                baglanti++;
                Console.WriteLine("{0}-Bağlantı bilgileri:{1}", baglanti, socket.RemoteEndPoint);
                using (NetworkStream network = new NetworkStream(socket))
                {
                    using(StreamReader reader=new StreamReader(network))
                    {
                        using(StreamWriter writer=new StreamWriter(network))
                        {
                            string outStr;
                            while (true)
                            {
                                foreach(int number in ss)
                                {
                                    writer.WriteLine(srlar.soruyuGonder(number));
                                    writer.Flush();
                                    outStr = reader.ReadLine();
                                    Console.WriteLine("{0}-connection answer:{1}", baglanti, outStr);
                                   
                                    if (outStr == srlar.cevapGonder(srlar.soruyuGonder(number)))
                                    {
                                        Console.WriteLine("checking.......");
                                        Thread.Sleep(30000);
                                        Console.WriteLine("connection answer:{ Dogru(TRUE) }");
                                    }
                                    else
                                    {
                                        kaybedenlersayisi++;
                                        Console.WriteLine("{0}-connection answer:Yanlıs", baglanti);
                                        Console.WriteLine("{0}-connection lose.", baglanti);
                                        Console.WriteLine("loser count: {0}", kaybedenlersayisi);
                                        writer.WriteLine("---------Yanlis-------------"); 
                                        writer.Flush();
                                    }
                                
                                }
                               
                            }
                        }
                    }
                }
            }
        }

        static void yarismacilar(int numberOfContestant,Socket socket,TcpListener listener)
        {
            List<int> yy=soruNumaralari();
            for (int k=0; k< numberOfContestant; k++)
            {
                var process = new Thread(delegate () { FunctionContestant(socket, listener,yy); }); process.Start();
            }
        }

        public static bool bkontrol(int active) // bağlantı kontrol ediliyor
        {
            bool bk=false;
            if (active == 0)
                bk = true;
            else
                bk = false;
            return bk;
        }

        public static List<int> soruNumaralari() // soru numaralı ID lerine göre burada alınıyor
        {
           
            int number = 0;
            Random random = new Random();
            for(int i=1; i < 7; i++)
            {
                number = random.Next(1, 7);
                xx.Add(number);
            }
            return xx;
        }

    }
}

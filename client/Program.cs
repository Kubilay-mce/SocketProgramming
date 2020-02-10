
 
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    public class Program
    {
        static int x=0;
        static void Main(string[] args)
        {
           
            TcpClient istemciTcp = new TcpClient("127.0.0.1", 5000);
     
            if (istemciTcp.Connected)
            {
                Console.WriteLine("Dünyanın en iyi bilgiyarışmasına hosgeldiniz");
                Console.WriteLine("********************SORULAR*********************");
                string stringOut = "";
                using (NetworkStream network = istemciTcp.GetStream())
                {
                    using (StreamWriter writer = new StreamWriter(network))
                    {
                        using (StreamReader reader = new StreamReader(network))
                        {
                            while (true)
                            {

                                string messagekont = reader.ReadLine();
                                Console.WriteLine(messagekont);
                                writer.Flush();

                                if (kontrolet(messagekont))//Burada kontrol yapılıyor
                                {
                                    Console.Write("Cevabinizi buraya giriniz:");
                                    stringOut = Console.ReadLine();
                                    writer.WriteLine(stringOut);
                                    writer.Flush();
                                    Console.WriteLine("Kontrol asamasi..............");

                                    Thread.Sleep(5000);
                                    
                                }
                                else
                                {
                                    Console.Write("********************YOU LOSE LOL *************************");
                                    Console.ReadLine();

                                    
                                }
                            }
                        }
                    }
                }
            }
        }

        public static bool kontrolet(string mesaj)
        {
            bool cevapkont = true;
            if (mesaj.IndexOf("Yanlis") == -1)
                cevapkont = true;
            else
                cevapkont = false;
            return cevapkont;
        }
    }
}
